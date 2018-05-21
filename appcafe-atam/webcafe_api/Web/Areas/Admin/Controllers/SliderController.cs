using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using VD.Data.Entity;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Repository;
using VD.Lib;
using VD.Lib.DTO;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
       [myAuth(Roles = "1")]
    public class SliderController : BaseController
    {
        public ISliderRepository _sliderRepo;

        public SliderController(ISliderRepository _sliderRepo)
        {
            this._sliderRepo = _sliderRepo;
        }
        public ActionResult Index(int page=1)
        {
            SliderView model = new SliderView();
            model.Rows = _sliderRepo.GetList(orderBy: i => i.OrderByDescending(o => o.Order)).ToPagedList(page, myAppSetings.admin_pg_size);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SliderCrud model = new SliderCrud();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(SliderCrud model)
        {
            rs r;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelMapped = AutoMapper.Mapper.Map<SliderCrud, Slider>(model);
                    _sliderRepo.Insert(modelMapped);
                    _sliderRepo.Save();
                    r = rs.T("Success!");
                }
                catch (Exception ex)
                {
                    r = rs.F(ex.Message);
                }
                TempData["message"] = r.m;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _sliderRepo.GetEntry(id);
            var modelMapped = AutoMapper.Mapper.Map<Slider, SliderCrud>(model);
            return View(modelMapped);
        }

        [HttpPost]
        public ActionResult Edit(SliderCrud model)
        {
            rs r;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelMapped = AutoMapper.Mapper.Map<SliderCrud, Slider>(model);
                    _sliderRepo.Update(modelMapped);
                    _sliderRepo.Save();
                    r = rs.T("Success!");
                }
                catch (Exception ex)
                {
                    r = rs.F(ex.Message);
                }
                TempData["message"] = r.m;
                return RedirectToAction("Index");
            }
            return View(model);
        }
        // GET: Admin/TVAnh/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            rs r;
            try
            {
                _sliderRepo.Delete(id);
                _sliderRepo.Save();
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