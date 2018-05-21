using System.Web.Mvc;
using Web.Security;

namespace Web.Controllers
{
 
    public class ThongTinController : BaseController
    {
        // GET: ThongTin
        public ActionResult Index()
        {
            return View();
        }
    }
}