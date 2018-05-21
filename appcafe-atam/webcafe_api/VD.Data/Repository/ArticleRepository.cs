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
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(IUnitOfWork UOW) : base(UOW) { }

        public PG<Article> GetQueryPaging(article_sp paging = null, Expression<Func<Article, bool>> where = null)
        {
            IQueryable<Article> query;
            //PHÂN QUYỀN ĐỒ
            query = GetList(where);

            if (paging.catid != -1)
            {
                query = query.Where(w => w.CategoryId == paging.catid);
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
            return (new PGQuery<Article>(query)).GetPG(paging);
        }
    }
}
