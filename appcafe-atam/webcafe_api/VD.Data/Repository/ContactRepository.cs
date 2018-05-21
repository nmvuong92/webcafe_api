using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Paging;
using VD.Lib.DTO;
using VD.Lib.Encode;

namespace VD.Data.Repository
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(IUnitOfWork UOW) : base(UOW) { }

        public PG<Contact> GetQueryPaging(Contact_filter paging = null, Expression<Func<Contact, bool>> where = null)
        {
            IQueryable<Contact> query;
            //PHÂN QUYỀN ĐỒ
            query = GetList(where);
            if (paging.contactstatusid != -1)
            {
                query = query.Where(w => w.ContactStatusId == paging.contactstatusid);
            }
           
            //SORTING
            query = query.OrderByField(paging.tentruongsort, paging.giatrisort == "asc");
            //FILTERING
            if (paging.bolocs != null)
            {
                foreach (var loc in paging.bolocs)
                {
                    if (loc.tentruongloc.Equals("Username"))
                    {
                        boloc loc1 = loc;
                        // query = query.Where(q => q.Username.Contains(loc1.giatriloc));
                    }
                }
            }
            return (new PGQuery<Contact>(query)).GetPG(paging);
        }

        public rs SendEmail(sendMailObj obj, bool is_robot = false,bool is_send_to_adm = false)
        {
            rs rss;
            try
            {


                vuong_cms_context __db = new vuong_cms_context();
                var confemail = __db.Settings.Find(1);

                SmtpClient client = new SmtpClient();
                client.Port = confemail.smpt_port;//587;
                client.Host = confemail.smpt_host;//"mail.worldofpledges.com";

                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = confemail.smpt_enable_ssl;
                client.UseDefaultCredentials = confemail.smpt_use_default_credentials;
                string _email_robot = "";
                if (is_robot)
                {
                    SimpleAES _aes = new SimpleAES();
                    var _conf = __db.Confs.Find(1);
                    _email_robot = confemail.sys_email_robot; ;
                    string _pw = _aes.DecryptString(confemail.sys_email_robot_pw);
                    client.Credentials = new System.Net.NetworkCredential(_email_robot, _pw);
                }
                else
                {
                    client.Credentials = new System.Net.NetworkCredential(obj.emailGui, obj.passEmailGui);
                }


                MailMessage message = new MailMessage();
                message.From = new MailAddress(is_robot ? _email_robot : obj.emailGui);//"support@worldofpledges.com"
                message.Subject = obj.tieude;
                message.Body = obj.noidung;
                if (is_send_to_adm)
                {
                    message.To.Add(confemail.sys_email);//system
                }
                else
                {
                    message.To.Add(obj.emailNhan); //""Email nhận
                }
              
                message.IsBodyHtml = true;
                client.Send(message);
                rss = rs.T("Gửi mail thành công");
            }
            catch (Exception ex)
            {
                rss = rs.F("Lỗi: " + ex.Message);
            }
            return rss;
        }
    }
}
