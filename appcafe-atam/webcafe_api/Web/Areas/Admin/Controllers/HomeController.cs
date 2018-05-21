
using System.Linq;
using System.Web.Mvc;
using VD.Data;
using VD.Data.IRepository;
using Web.Controllers;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
    [myAuth]
    public class HomeController : BaseController
    {
        private IUserRepository _userServ;
        private ICounterRepository _counterRepo;
      
        private vuong_cms_context __db = new vuong_cms_context();

        public HomeController(IUserRepository userServ, ICounterRepository _counterRepo)
        {
            this._userServ = userServ;
            this._counterRepo = _counterRepo;
        }
       
        // GET: Admin/Home
        public ActionResult Index()
        {
         
            return View();
           
        }
        [HttpGet]
        public PartialViewResult ThongKeLuongTruyCap()
        {
            var viewmodel = _counterRepo.GetCounter();
            return PartialView(viewmodel);
        }
        [HttpGet]
        public PartialViewResult BoDem()
        {

            var __auth = MySsAuthUsers.GetAuth();
            int donhang = __db.DonHangs.Count(w => w.BaseUserId == __auth.OwnerId);
            int sanpham = __db.Product.Count(w => w.ProductCat.Quan.UserId == __auth.OwnerId);
            int tintuc = __db.Article.Count();
            int inbox = __db.Contact.Count();
            return PartialView(new BoDem()
            {
                donhang = donhang,
                sanpham = sanpham,
                tintuc = tintuc,
                inbox = inbox
            });
        }

    }

    public class BoDem
    {
        public int donhang{ get; set; }
        public int sanpham { get; set; }
        public int tintuc { get; set; }
        public int inbox { get; set; }
    }
}