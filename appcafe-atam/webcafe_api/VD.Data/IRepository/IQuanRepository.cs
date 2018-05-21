using System;
using System.Linq.Expressions;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.Paging;
using VD.Lib.DTO;

namespace VD.Data.IRepository
{
    public interface IQuanRepository : IRepository<Quan>
    {
        PG<Quan> GetQueryPaging(smartpaging paging = null, Expression<Func<Quan, bool>> where = null);
    }
}
