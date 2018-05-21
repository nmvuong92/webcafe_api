using System.Linq.Expressions;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.Paging;
using VD.Data.Temp;
using VD.Lib.DTO;

namespace VD.Data.IRepository
{
    public interface IUserRepository:IRepository<User>
    {
        rs Login(string username, string password, bool isrememberme, bool api = false);
  
        rs ChangePassword(int id, string oldPassword, string newPassword);
        PG<User> GetQueryPaging(User_filter paging = null, Expression<System.Func<User, bool>> where = null);

        void SSLogin(loginVM user);
        void RefreshLogin();
        void SSLogOut();
        bool SSisLogin();
        loginVM SSgetUserLoged();
    }
}
