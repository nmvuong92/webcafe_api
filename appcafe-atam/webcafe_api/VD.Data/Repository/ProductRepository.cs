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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IUnitOfWork UOW) : base(UOW) { }

        public PG<Product> GetQueryPaging(smartpaging paging = null, Expression<Func<Product, bool>> where = null)
        {
            IQueryable<Product> query;
            //PHÂN QUYỀN ĐỒ
            query = GetList(where);
            if (paging.quanid != -1)
            {
                query = query.Where(w => w.ProductCat.QuanId == paging.quanid);
            }
            if (paging.catid != -1)
            {
                query = query.Where(w => w.ProductCatId== paging.catid);
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
            return (new PGQuery<Product>(query)).GetPG(paging);
        }
    }
}
