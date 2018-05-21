
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Omu.ValueInjecter;
using VD.Data.Entity;
using VD.Data.IRepository;
using VD.Data.Paging;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;
using Web.Security;
using System.Linq;
using VD.Lib.DTO;
using VD.Data;
using System;
using VD.Data.Base;

namespace Web.Areas.Admin.Controllers
{
    [myAuth(Roles = "1")]
    public class ConfigController : BaseController
    {
        private IUserRepository _userServ;
        private IConfigRepository _confServ;
        private vuong_cms_context _db = new vuong_cms_context();
        public ConfigController(IUserRepository _userServ, IConfigRepository _confServ)
        {
            this._userServ = _userServ;
            this._confServ = _confServ;
        }
        public ActionResult Index()
        {
            Conf viewmodel = new Conf();
            return View(viewmodel);
        }
        [HttpPost]
        public PartialViewResult ajax_paging(Conf_filter paging)
        {
            return PartialView(_confServ.GetQueryPaging(paging));
        }

        public ActionResult Edit(int id)
        {
            var en = _confServ.GetEntry(id);
            var model = new ConfigOneCRUDView();
            model.Content = en.Content;
            model.Description = en.Description;
            model.IsHtmlEditor = en.IsHtmlEditor;
            model.IsImg = en.IsImg;
            model.Id = en.Id;
            model.Key = en.Key;
            return PartialView(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(ConfigOneCRUDView data)
        {
            rs r;
            
                try
                {
                    var model = _confServ.GetEntry(data.Id);
                    model.Content = data.Content;
                    _confServ.Save();
                    CacheServ.ClearAll();
                    r = rs.T("Okay!");
                }
                catch (Exception ex)
                {
                    r = rs.F(ex.Message);
                }
           
            return Json(r, JsonRequestBehavior.DenyGet);
        }
    }
}
