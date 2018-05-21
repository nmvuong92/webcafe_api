
using VD.Data.Temp;
using VD.Lib;
using VD.Lib.DTO;

namespace VD.Data
{
    public class MySsAuthUsers
    {
        public static loginVM GetAuth()
        {
            var log = mySessions.Get(SysConsts.SS_login_user);
            if (log != null)
            {
                return (loginVM) log;
            }
            return null;
        }
        public static bool IsAuth()
        {
            return mySessions.Get(SysConsts.SS_login_user) != null;
        }

        public static void setLogin(loginVM model)
        {
            mySessions.Set(SysConsts.SS_login_user,model);
        }
        public static void logOut()
        {
            mySessions.Clear(SysConsts.SS_login_user);
        }
    }
   
}
