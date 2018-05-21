using System.Linq.Expressions;
using VD.Data.Paging;
using VD.Data.Temp;

namespace VD.Services.UserServc
{
    public interface IUserService
    {
        VD.Data.Entity.User Login(string username, string password, bool isrememberme);
        void SetUserRememberMeDatabase(int userid, string cookie_key, string cookie_value);
        void ClearUserRememberMe(int userid);
        //
        void UpdateProfileUser(EditUserVM vm);

        //
        userPG GetQueryPaging(user_smartpaging paging = null, Expression<System.Func<VD.Data.Entity.User, bool>> where = null);

        void SSLogin(loginVM user);
        CookieRememberMeVM setCookieRememberMe(int userid);
        CookieRememberMeVM GetCookieRememberMe();
        void SSLogOut();
        bool SSisLogin();
        loginVM SSgetUserLoged();
    }
}
