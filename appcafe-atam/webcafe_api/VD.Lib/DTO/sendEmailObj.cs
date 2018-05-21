using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VD.Lib.Encode;

namespace VD.Lib.DTO
{

    public class sendMailObj
    {
        public string emailNhan { get; set; }
        public string tieude { get; set; }
        public string noidung { get; set; }

        public string emailGui { get; set; }
        public string passEmailGui { get; set; }
        public sendMailObj()
        {
            
        }
        /// <summary>
        /// đối tượng gửi email được giải mã mật khẩu
        /// </summary>
        /// <param name="_emailnhan">email nhận</param>
        /// <param name="_tieude">tiêu đề</param>
        /// <param name="_noidung">Nội dung</param>
        /// <param name="_emailgui">Email gửi</param>
        /// <param name="_passemailgui">Mật khẩu email gửi (dạng đã mã hóa -> cần giải mã)</param>
        /// <param name="lstReplace">Danh sách replace tiêu đề, nội dung nếu có</param>
        public sendMailObj(string _emailnhan, string _tieude, string _noidung, string _emailgui, string _passemailgui, Dictionary<string, string> lstReplace)
        {
            SimpleAES aes = new SimpleAES();
            this.noidung = _noidung;
            this.tieude = _tieude;
            //rep
            if (lstReplace != null && lstReplace.Any())
            {
                foreach (var rep in lstReplace)
                {
                    this.tieude = this.tieude.Replace("{"+rep.Key+"}", rep.Value);
                    this.noidung = this.noidung.Replace("{" + rep.Key + "}", rep.Value);
                }
            }

            this.emailNhan = _emailnhan;
            this.emailGui = _emailgui;
            this.passEmailGui = aes.DecryptString(_passemailgui);
        }
        public static string ReplaceContent(string value, Dictionary<string, string> lstReplace)
        {
            //rep
            if (lstReplace != null && lstReplace.Any())
            {
                foreach (var rep in lstReplace)
                {
                    value = value.Replace("{" + rep.Key + "}", rep.Value);

                }
            }
            return value;
        }
    }

    public class ReplaceKeyContentEmailDto
    {   
        public string key { get; set; }
        public string replaceValue { get; set; }

       
      
    }
 
   



}
