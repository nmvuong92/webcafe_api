using System;
using System.Linq.Expressions;
using VD.Data.IRepository;
using VD.Data.Paging;
using VD.Data.Temp;
using VD.Services.User;

namespace VD.Services.UserServc
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repo;
        //private readonly UnitOfWork _uOW;
        public UserService(IUserRepository _repo)
        {
            this._repo = _repo;
        }
        public void SSLogin(loginVM user)
        {
            _repo.SSLogin(user);
        }
        public CookieRememberMeVM setCookieRememberMe(int userid)
        {
            return _repo.setCookieRememberMe(userid);
        }
        public VD.Data.Entity.User Login(string username, string password, bool isrememberme)
        {
            return _repo.Login(username, password, isrememberme);
        }

        //
        public void SetUserRememberMeDatabase(int userid, string cookie_key, string cookie_value)
        {
            _repo.SetUserRememberMeDatabase(userid, cookie_key, cookie_value);
        }

        public void ClearUserRememberMe(int userid)
        {
            _repo.ClearUserRememberMe(userid);
        }

        public void UpdateProfileUser(EditUserVM vm)
        {
            _repo.UpdateProfileUser(vm);
        }
        //
        public userPG GetQueryPaging(user_smartpaging paging = null, Expression<Func<VD.Data.Entity.User, bool>> where = null)
        {
            return _repo.GetQueryPaging(paging, where);
        }

        //quy trình nghiêm ngặt kiểm tra xem remember me có đúng ko
        public CookieRememberMeVM GetCookieRememberMe()
        {
            return _repo.GetCookieRememberMe();
        }
        public void SSLogOut()
        {
            _repo.SSLogOut();
        }

        public bool SSisLogin()
        {
            return _repo.SSisLogin();
        }

        public loginVM SSgetUserLoged()
        {
            return _repo.SSgetUserLoged();
        }
    }
}
