using System;
using System.Linq.Expressions;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.Paging;
using VD.Lib.DTO;

namespace VD.Data.IRepository
{
    public interface IBanRepository : IRepository<Ban>
    {
        PG<Ban> GetQueryPaging(smartpaging paging = null, Expression<Func<Ban, bool>> where = null);
    }
}
