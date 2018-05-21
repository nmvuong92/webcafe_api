using System;
using Omu.ValueInjecter;
using System.Linq;
using System.Web.Mvc;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Paging;
using VD.Lib.DTO;
using Web.Controllers;
using Web.Security;
using Web.Areas.Admin.ViewModels;
using VD.Data;


namespace Web.Areas.Admin.Controllers
{
    [myAuth(Roles = "1")]
    public class ContactController : BaseController
    {
        private IRoleRepository _roleServ;
        private IPermissionRepository _permisionServ;

        private IContactRepository _contactRepo;
        private vuong_cms_context __db = new vuong_cms_context();
        public ContactController(
            IRoleRepository _roleServ,
            IPermissionRepository _quyenServ,
            IContactRepository _contactRepo)
        {
            this._roleServ = _roleServ;
            this._permisionServ = _quyenServ;
            this._contactRepo = _contactRepo;

        }

        

        public ActionResult Index()
        {
            ViewBag.lstRole = _roleServ.GetList().ToList();
            Contact vm = new Contact();

            ViewBag.ddlContactStatus = __db.ContactStatus.Select(s => new SelectListItem
            { 
                Text=s.Name,
                Value = s.Id.ToString(),
            });
        
            return View(vm);
        }

        public PartialViewResult View(int id)
        {
            var entity = __db.Contact.Find(id);
            ViewBag.Title = entity.HoTen + " > " + entity.Email;
            entity.ContactStatusId = 2;
            __db.SaveChanges();
            return PartialView(entity);
        }
        public PartialViewResult Edit(int id)
        {
            var entity = __db.Contact.Find(id);
            ContactCRUD viewmodel = new ContactCRUD();
           
            viewmodel.ddlContactStatus = __db.ContactStatus.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString(),
            });
            ViewBag.Title = entity.HoTen + " > " + entity.Email;
            viewmodel.InjectFrom(entity);
            return PartialView(viewmodel);
        }
        [HttpPost]
        public JsonResult Edit(ContactCRUD viewmodel)
        {
            rs r;
           
                try
                {
                    var entity = __db.Contact.Find(viewmodel.Id);
                    entity.GhiChu = viewmodel.GhiChu;
                    entity.ModifiedDate = DateTime.Now;
                    entity.ContactStatusId = viewmodel.ContactStatusId;
                    __db.SaveChanges();
                    //

                    r = rs.T("Okay!");
                }
                catch(Exception ex)
                {
                    r = rs.F(ex.Message);
                }
         
            return Json(r,JsonRequestBehavior.DenyGet);

        }

        [HttpPost]
        public PartialViewResult ajax_paging(Contact_filter paging)
        {
            PG<Contact> vmpg;
            vmpg = _contactRepo.GetQueryPaging(paging);
            return PartialView(vmpg);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            rs r;
            try
            {
                Contact Contact = _contactRepo.GetEntry(id);
                _contactRepo.Delete(Contact);
                _contactRepo.Save();
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);

            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

    }
}
