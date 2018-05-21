using System.Web.Mvc;

namespace Web.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Index()
        {
            return RedirectToAction("Index", "ThongTin");
        }
    }
}