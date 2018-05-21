using System.Web.Mvc;
using VD.Data;
using VD.Data.Entity;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
     
    public class aWebPartsController :BaseController
    {
        vuong_cms_context __db = new vuong_cms_context();
        public PartialViewResult Head()
        {
            return PartialView();
        }
        public PartialViewResult Header()
        {
            return PartialView();
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }
        public PartialViewResult LeftNav()
        {
            var __auth = MySsAuthUsers.GetAuth();
            User _user = __db.Users.Find(__auth.ID);


            return PartialView(_user);
        }
    }
}