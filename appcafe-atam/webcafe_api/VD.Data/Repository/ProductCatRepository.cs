using System;
using System.Linq;
using System.Linq.Expressions;
using VD.Data.Base;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Paging;
using VD.Lib.DTO;

namespace VD.Data.Repository
{
    public class ProductCatRepository : RepositoryBase<ProductCat>, IProductCatRepository
    {
        public ProductCatRepository(IUnitOfWork uOW) : base(uOW)
        {
        }

        public PG<ProductCat> GetQueryPaging(smartpaging paging = null, Expression<Func<ProductCat, bool>> @where = null)
        {
            IQueryable<ProductCat> query;
            //PHÂN QUYỀN ĐỒ
            query = GetList(where);
            if (paging.quanid != -1)
            {
                query = query.Where(w => w.QuanId == paging.quanid);
            }

            //SORTING
            query = query.OrderByField(paging.tentruongsort, paging.giatrisort == "asc");
            //FILTERING
            if (paging.bolocs != null)
            {
                foreach (var loc in paging.bolocs)
                {
                    //if (loc.tentruongloc.Equals("Username"))
                    //{
                    //    boloc loc1 = loc;
                    //    // query = query.Where(q => q.Username.Contains(loc1.giatriloc));
                    //}
                }
            }
            return (new PGQuery<ProductCat>(query)).GetPG(paging);
        }
    }
}
