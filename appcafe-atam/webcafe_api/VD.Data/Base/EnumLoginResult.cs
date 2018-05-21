

namespace VD.Data.Base
{
    public enum EnumLoginResult
    {
        Isvalid,
        Locked,
        Success
    }

    public class ApiLoginResult
    {
        public EnumLoginResult LoginResult { get; set; }
        public int UserId { get; set; }
        public int UserType { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
    }
}
