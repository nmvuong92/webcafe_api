
namespace VD.Data.Temp
{
    public class CookieRememberMeVM
    {
        public string CookieKey { get; set; }
        public string CookieValue { get; set; }
        public int UserId { get; set; }
        public bool IsRememberMe { get; set; }
        public bool isCus{get;set;}

    }
    public class CookieRememberMeCandidateVM
    {
        public string CookieKey { get; set; }
        public string CookieValue { get; set; }
        public int CandidateId { get; set; }
        public bool IsRememberMe { get; set; }
    }
    public class CookieRememberMeEmployeeVM
    {
        public string CookieKey { get; set; }
        public string CookieValue { get; set; }
        public int EmployeeId { get; set; }
        public bool IsRememberMe { get; set; }
    }
}
