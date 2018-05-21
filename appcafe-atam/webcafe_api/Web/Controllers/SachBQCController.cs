using System.Collections.Generic;
using System.Web.Mvc;
using VD.Data;
using Web.ViewModels.BQC;

namespace Web.Controllers
{
    public class SachBQCController : BaseController
    {
        // GET: SachBQC
        public ActionResult Index()
        {

            List<SachBQCModel> books = SachBQCModel.layds();


            return View(books);
        }

        public ActionResult Read(int id)
        {
            var model=SachBQCModel.LayById(id);
       
            if (model == null)
            {
                return HttpNotFound("404");
            }

            //VỊP
            var au = MySsAuthUsers.GetAuth();
            if (au != null && au.IsVip1==false)
            {
                model.PDF = model.Lite;
            }
            return View(model);
        }
    }
}