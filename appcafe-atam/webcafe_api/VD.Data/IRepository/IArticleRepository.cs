using System;
using System.Linq;
using System.Linq.Expressions;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.Paging;
using VD.Lib.DTO;

namespace VD.Data.IRepository
{
    public interface IArticleRepository : IRepository<Article>
    {
        PG<Article> GetQueryPaging(article_sp paging = null, Expression<Func<Article, bool>> where = null);
    }
}
