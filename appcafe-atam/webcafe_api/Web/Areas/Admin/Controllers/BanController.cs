using System;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using VD.Data;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Paging;
using VD.Lib.DTO;
using Web.Areas.Admin.ViewModels.MF;
using Web.Controllers;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
    [myAuth(Roles = "1,2")]
    public class BanController : BaseController
    {
        private IBanRepository _BanServ;
        vuong_cms_context __db = new vuong_cms_context();
        private IImgTmpRepository _imgTmpServ;
        public BanController(
            IBanRepository _BanServ, IImgTmpRepository _imgTmpServ)
        {
            this._BanServ = _BanServ;
            this._imgTmpServ = _imgTmpServ;

        }

        public ActionResult Index()
        {

            Ban vm = new Ban();
            return View(vm);
        }

        public ActionResult Print()
        {
            var __auth = MySsAuthUsers.GetAuth();
            var model = __db.Ban.Where(w => w.Quan.UserId == __auth.ID);
            return View(model);
        }

        [HttpPost]
        public PartialViewResult ajax_paging(smartpaging paging)
        {
            var __auth = MySsAuthUsers.GetAuth();
            PG<Ban> vmpg;
            vmpg = _BanServ.GetQueryPaging(paging,w=>w.Quan.UserId==__auth.OwnerId);
            return PartialView(vmpg);
        }


        // GET: Admin/Bans/Create
        public ActionResult Create(int catid=-1)
        {
            var __auth = MySsAuthUsers.GetAuth();
            BanCRUD vm = new BanCRUD();
            vm.ddlQuan = __db.Quan.Where(w => w.UserId == __auth.ID).ToList().Select(s => new SelectListItem()
            {
                Text = s.TenQuan,
                Value = s.Id.ToString(),
            });
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public JsonResult Create(BanCRUD model)
        {
            rs r;
            try
            {
                Ban entity = new Ban();
                entity.MaBan = model.MaBan;
                entity.TenBan = model.TenBan;
                entity.QuanId = model.QuanId;
                __db.Ban.Add(entity);
                __db.SaveChanges();
                r = rs.T("Okay");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        // GET: Admin/Bans/Edit/5
        public ActionResult Edit(int id)
        {
            var __auth = MySsAuthUsers.GetAuth();
            Ban entity = _BanServ.GetEntry(id);

            BanCRUD vm = new BanCRUD();
            vm.Id = entity.Id;
            vm.MaBan = entity.MaBan;
            vm.TenBan = entity.TenBan;
            vm.QuanId = entity.QuanId;
            vm.ddlQuan = __db.Quan.Where(w => w.UserId == __auth.ID).ToList().Select(s => new SelectListItem()
            {
                Text = s.TenQuan,
                Value = s.Id.ToString(),
            });
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       

        public JsonResult Edit(BanCRUD model)
        {
            rs r;
            using (var trans = new TransactionScope())
            {
                try
                {
                   
                    var entity = _BanServ.SingleOrDefault(s => s.Id == model.Id);

                    entity.MaBan = model.MaBan;
                    entity.TenBan = model.TenBan;
                    entity.QuanId = model.QuanId;
                    _BanServ.Save();
                    trans.Complete();
                    r = rs.T("Okay");
                }
                catch (Exception ex)
                {
                    r = rs.F("Lỗi: " + ex.Message);
                }
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            rs r;
            try
            {
                Ban Ban = _BanServ.GetEntry(id);

                _BanServ.Delete(Ban);
                _BanServ.Save();

                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);

            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
        
        [HttpPost]
        public JsonResult xoachon(int[] arr)
        {
            rs r;
            if (arr.Length == 0)
            {
                r = rs.F("Không có mục nào chọn");
            }
            else
            {
                using (var trans = new TransactionScope())
                {
                    try
                    {
                        foreach (int idmess in arr)
                        {
                            __db.Database.ExecuteSqlCommand("DELETE FROM Bans WHERE Id=" + idmess);
                        }
                        r = rs.T("OK");
                        trans.Complete();
                    }
                    catch (Exception ex)
                    {
                        r = rs.F(ex.Message);
                    }
                }

            }

            return Json(r, JsonRequestBehavior.DenyGet);
        }


        #region IMAGES

        #endregion
    }
}
