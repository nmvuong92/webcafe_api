using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VD.Data.Base;
using VD.Data.Entity.Logging;
using VD.Data.IRepository.Logging;

namespace VD.Data.Repository.Logging
{
    public class LogExceptionRepository : RepositoryBase<LogException>, ILogExceptionRepository
    {
        public LogExceptionRepository(IUnitOfWork uOW) : base(uOW) { }
    }
}
