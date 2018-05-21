using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VD.Data.Base;
using VD.Data.Entity.MF;
using VD.Data.Paging;
using VD.Lib.DTO;

namespace VD.Data.IRepository
{
    public interface IProductCatRepository : IRepository<ProductCat>
    {
        PG<ProductCat> GetQueryPaging(smartpaging paging = null, Expression<Func<ProductCat, bool>> where = null);
    }
}
