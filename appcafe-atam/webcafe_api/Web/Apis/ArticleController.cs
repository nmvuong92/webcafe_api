using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VD.Data;
using Web.Models.ThuanHanhMobileApp.VM;

namespace Web.Apis
{
    public class ArticleController : ApiController
    {
        [HttpGet]
        [AcceptVerbs("OPTIONS")]

        public IEnumerable<ArticleVM> layds()
        {
            vuong_cms_context __db = new vuong_cms_context();
            var data = __db.Article.Where(w=>w.CategoryId==1||w.CategoryId==3).OrderByDescending(o => o.Id);
            return ArticleVM.map(data);
        }
        [HttpGet]
        [AcceptVerbs("OPTIONS")]
        public ArticleVM get_by_id(int id)
        {
            vuong_cms_context __db = new vuong_cms_context();
            var data = __db.Article.FirstOrDefault(f => f.Id == id);
            return ArticleVM.map(data);
        }
    }
}
