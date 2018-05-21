using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using Omu.ValueInjecter.Utils;
using VD.Data;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Paging;
using VD.Lib.DTO;
using VD.Lib.Encode;
using Web.Areas.Admin.ViewModels.MF;
using Web.Controllers;
using Web.Security;

namespace Web.Areas.Admin.Controllers
{
   [myAuth(Roles = "1,2")]
    public class ProductController : BaseController
    {
        private IProductRepository _ProductServ;
        vuong_cms_context __db = new vuong_cms_context();
        private IImgTmpRepository _imgTmpServ;
        public ProductController(
            IProductRepository _ProductServ, IImgTmpRepository _imgTmpServ)
        {
            this._ProductServ = _ProductServ;
            this._imgTmpServ = _imgTmpServ;
        }

        public ActionResult Index()
        {

            Product vm = new Product();
            return View(vm);
        }

        [HttpPost]
        public PartialViewResult ajax_paging(smartpaging paging)
        {
            var __auth = MySsAuthUsers.GetAuth();
            PG<Product> vmpg;
            vmpg = _ProductServ.GetQueryPaging(paging, w => w.ProductCat.Quan.UserId == __auth.OwnerId);
            return PartialView(vmpg);
        }


        // GET: Admin/Products/Create
        public ActionResult Create(int catid,int quanid)
        {
            ProductCRUD vm = new ProductCRUD();
            vm.ProductCatId = catid;
            vm.ProductCat=__db.ProductCat.Find(catid);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public JsonResult Create(ProductCRUD model)
        {
            rs r;
            try
            {

                Product entity = new Product();
                entity.ProductName = model.ProductName;
     
                entity.Price = model.Price;
                entity.Infomation = model.Infomation;
                entity.ProductCatId = model.ProductCatId;
                // entity.ProductCatId2 = model.ProductCatId2 == -1 ? null : model.ProductCatId2;

            
                entity.IsGiamGia = model.IsGiamGia;
                entity.Hot = model.Hot;
                entity.New = model.New;
                if (string.IsNullOrWhiteSpace(model.ThumbnailImage))
                {
                    entity.ThumbnailImage = "/Content/images/sample/product.png";
                }
                else
                {
                    entity.ThumbnailImage = model.ThumbnailImage;
                }


                List<BangGiaCT> gias = new List<BangGiaCT>();
                foreach (var item in model.BangGiaCT)
                {
                    if (item.Price.HasValue && item.Price > 0)
                    {
                        gias.Add(new BangGiaCT()
                        {
                            Ten = item.Ten,
                            Price = item.Price??0,
                        });
                    }
                }
                if (gias.Any())
                {
                    entity.BangGiaCT = gias;
                }
                entity.SoLuongGia = gias.Count;
                __db.Product.Add(entity);
                __db.SaveChanges();
                r = rs.T("Okay");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);
            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int id)
        {
            Product entity = _ProductServ.GetEntry(id);

            ProductCRUD vm = new ProductCRUD();
            vm.Id = entity.Id;
            vm.ProductName = entity.ProductName;
           
            vm.Price = entity.Price;
            vm.Infomation = entity.Infomation;
            vm.ProductCatId = entity.ProductCatId;
            //vm.ProductCatId2 = entity.ProductCatId2 == -1 ? null : entity.ProductCatId2;

            vm.IsGiamGia = entity.IsGiamGia;

            vm.Hot = entity.Hot;
            vm.New = entity.New;
            if (string.IsNullOrWhiteSpace(entity.ThumbnailImage))
            {
                vm.ThumbnailImage = "/Content/images/sample/product.png";
            }
            else
            {
                vm.ThumbnailImage = entity.ThumbnailImage;
            }
           
            vm.BangGiaCT = new List<BangGiaCTCRUD>();
            var BangGiaCT_entity = entity.BangGiaCT.ToList();
            vm.SoLuongEdit = BangGiaCT_entity.Count;
            for (var i = 0; i < 10; i++)
            {
                if (i+1 <= BangGiaCT_entity.Count)
                {
                    vm.BangGiaCT.Add(new BangGiaCTCRUD()
                    {
                        Id = BangGiaCT_entity[i].Id,
                        Ten = BangGiaCT_entity[i].Ten,
                        Price = BangGiaCT_entity[i].Price
                    });
                }
                else
                {
                    vm.BangGiaCT.Add(new BangGiaCTCRUD()
                    {
                        Id = -1,
                        Ten = "",
                        Price = null
                    });
                }
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        public JsonResult Edit(ProductCRUD model)
        {
            rs r;
            using (var trans = new TransactionScope())
            {
                try
                {
                    List<BangGiaCT> gias = new List<BangGiaCT>();
                    foreach (var item in model.BangGiaCT)
                    {
                        if (item.Price.HasValue && item.Price > 0)
                        {
                            gias.Add(new BangGiaCT(){
                                ProductId = model.Id,
                                Ten = item.Ten,
                                Price = item.Price ?? 0,
                            });
                        }
                    }


                    var entity = __db.Product.Find(model.Id);
                    entity.ProductCatId = model.ProductCatId;
                    //entity.ProductCatId2 = model.ProductCatId2 == -1 ? null : model.ProductCatId2;
                    entity.ProductName = model.ProductName;
                    entity.Price = model.Price;
                    if(string.IsNullOrWhiteSpace(model.ThumbnailImage))
                    {
                        entity.ThumbnailImage = "/Content/images/sample/product.png";
                    }
                    else
                    {
                        entity.ThumbnailImage = model.ThumbnailImage;
                    }

                    entity.Infomation = model.Infomation;
                    entity.IsGiamGia = model.IsGiamGia;
                    entity.Hot = model.Hot;
                    entity.New = model.New;
                    entity.SoLuongGia = gias.Count;
                    __db.SaveChanges();

                    var remove_child = entity.BangGiaCT;
                    __db.BangGiaCT.RemoveRange(remove_child.ToList());
                    __db.SaveChanges();

                    __db.BangGiaCT.AddRange(gias);
                    __db.SaveChanges();
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
                Product Product = _ProductServ.GetEntry(id);

                _ProductServ.Delete(Product);
                _ProductServ.Save();

                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);

            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult SetBanChayProduct(int id)
        {
            rs r;
            try
            {

                Product search = _ProductServ.GetEntry(id);
                //search.IsBanChay = !search.IsBanChay;
                _ProductServ.Save();
                r = rs.T("Ok");
            }
            catch (Exception ex)
            {
                r = rs.F("Lỗi: " + ex.Message);

            }
            return Json(r, JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public ActionResult SetMainProduct(int id, string type)
        {
            rs r;
            try
            {

                Product search = _ProductServ.GetEntry(id);
                if (type == "hot")
                {
                    search.Hot = !search.Hot;
                }
                if (type == "new")
                {
                    search.New = !search.New;
                }
                if (type == "giam_gia")
                {
                    search.IsGiamGia = !search.IsGiamGia;
                }

                _ProductServ.Save();
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
                            __db.Database.ExecuteSqlCommand("DELETE FROM Products WHERE Id=" + idmess);
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
