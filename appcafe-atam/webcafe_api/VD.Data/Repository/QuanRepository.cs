using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Paging;
using VD.Lib.DTO;
using VD.Lib.Encode;

namespace VD.Data.Repository
{
    public class QuanRepository : RepositoryBase<Quan>, IQuanRepository
    {
        public QuanRepository(IUnitOfWork UOW) : base(UOW) { }

        public PG<Quan> GetQueryPaging(smartpaging paging = null, Expression<Func<Quan, bool>> where = null)
        {
            IQueryable<Quan> query;
            //PHÂN QUYỀN ĐỒ
            query = GetList(where);

         
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
            return (new PGQuery<Quan>(query)).GetPG(paging);
        }
    }
}
