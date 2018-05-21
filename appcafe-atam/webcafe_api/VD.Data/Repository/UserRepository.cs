using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.Paging;

using VD.Data.Temp;
using VD.Lib;
using VD.Lib.DTO;
using VD.Lib.Encode;

using VD.Data.IRepository;
namespace VD.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public UserRepository(IUnitOfWork uOW)
            : base(uOW)
        {

        }


        public SimpleAES aes = new SimpleAES();


        public void SSLogin(loginVM user)
        {
            mySessions.Set(SysConsts.SS_login_user, user);
        }

        public rs Login(string username, string password, bool isrememberme,bool api=false)
        {
            rs r;
            string _pass = aes.EncryptToString(password);
            User logrs = base.GetList(u => u.Username == username && u.Password == _pass).FirstOrDefault();
            if (logrs != null)
            {

                if (logrs.UserStatusId != 1) //chwa active
                {
                    r = rs.F("Tài khoản này chưa hoạt động! " + logrs.UserStatus.Name);
                }
                else
                {
                    var logvm = new loginVM(logrs);
                    //set session
                    if (!api)
                    {
                        SSLogin(logvm);
                    }
                    //lưu đăng nhập
                    r = rs.T("Đăng nhập thành công, đang chuyển hướng!",logvm);
                }
            }
            else
            {
                r = rs.F("Tài khoản mật khẩu không chính xác");
            }
            return r;
        }




        public rs ChangePassword(int id, string oldPassword, string newPassword)
        {
            rs r;
            var en = GetEntry(id);
            if (en != null)
            {
                if (aes.EncryptToString(oldPassword) != en.Password)
                {
                    r = rs.F("Mật khẩu cũ không chính xác!");
                }
                else
                {
                    en.Password = aes.EncryptToString(newPassword);
                    _dbContext.SaveChanges();
                    r = rs.T("Okay!");
                }
            }
            else
            {
                r = rs.F("Không tìm thấy tài khoản này!");
            }
            return r;
        }

        public PG<User> GetQueryPaging(User_filter paging = null, Expression<Func<VD.Data.Entity.User, bool>> where = null)
        {
            IQueryable<User> query;
            //PHÂN QUYỀN ĐỒ
            query = GetList(where);
            if (paging.roleid != null && paging.roleid != -1)
            {
                query = query.Where(w => w.RoleId == paging.roleid);
            }
         

            //SORTING
            query = query.OrderByField(paging.tentruongsort, paging.giatrisort == "asc");

            //FILTERING
            if (paging.bolocs != null)
            {
                foreach (var loc in paging.bolocs)
                {
                    if (loc.tentruongloc.Equals("full_text_search"))
                    {
                        boloc loc1 = loc;
                        query = query.FullTextSearch(loc1.giatriloc, true);
                    }
                    else
                    {
                        if (loc.tentruongloc.Equals("Username"))
                        {
                            boloc loc1 = loc;
                            query = query.Where(q => q.Username.Contains(loc1.giatriloc));
                        }

                    }
                }
            }
            return (new PGQuery<User>(query)).GetPG(paging);
        }


        public void SSLogOut()
        {
            mySessions.Clear(SysConsts.SS_login_user);
            myCookies.Clear("auth");
        }
        public bool SSisLogin()
        {
            return mySessions.Get(SysConsts.SS_login_user) != null;
        }
        public loginVM SSgetUserLoged()
        {
            if (SSisLogin())
            {
                return (loginVM)mySessions.Get(SysConsts.SS_login_user);
            }
            return null;
        }


        public void RefreshLogin()
        {
            var ss = MySsAuthUsers.GetAuth();
            if (ss != null)
            {
                var log = base.FirstOrDefault(f => f.Id == ss.ID);
                var newss = new loginVM(log);
                MySsAuthUsers.setLogin(newss);
            }
        }
    }
}
