using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VD.Data.Base;
using VD.Data.Entity.Logging;
using VD.Data.IRepository.Logging;

namespace VD.Data.Repository.Logging
{
    public class LogRepository : RepositoryBase<Log>, ILogRepository
    {
        public LogRepository(IUnitOfWork uOW) : base(uOW) { }



        public void Insert(Exception ex)
        {
            vuong_cms_context db = new vuong_cms_context();
            LogException logEx = new LogException();
            logEx.ExceptionMsg = ex.Message;
            logEx.ExceptionType = ex.GetType().Name.ToString();
            logEx.ExceptionURL = HttpContext.Current.Request.Url.ToString();
            logEx.ExceptionSource = ex.StackTrace.ToString();
            logEx.Logdate = DateTime.Now;

            Log log = new Log();
            log.LogException = logEx;
            log.LogTypeId = 3;
            log.Message = ex.Message;
            Insert(log);
            Save();
        }
    }
}
