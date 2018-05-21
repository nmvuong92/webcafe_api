using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using VD.Data;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using VD.Data.Temp;
using VD.Lib.DTO;
using Web.Models.ThuanHanhMobileApp;
using Web.Models.ThuanHanhMobileApp.VM;
using Web.Security;

namespace Web.Apis
{
    public class SanPhamController : ApiController
    {
        private IProductRepository productRepo;
     
        vuong_cms_context __db = new vuong_cms_context();
        private IUserRepository _userServ;

        public SanPhamController(IProductRepository _productRepo
            , IUserRepository _userServ)
        {
            this.productRepo = _productRepo;
            this._userServ = _userServ;
        }
        [HttpGet]
        [AcceptVerbs("OPTIONS")]
        // [myAuthApi]
        //iddm: thực đơn id
        public ListPagingJson<SanPham> layds(string search = "", int iddm = -1, int page = 1, int pageSize = 1000)
        {
            //initial
            var paging = new ListPagingJson<SanPham>();
            paging.Paging.RecordsPerPage = pageSize;
            paging.Paging.CurrentPage = page;


            IQueryable<ThucDonCT> query = __db.ThucDonCT;
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(w => w.Product.ProductName.Contains(search)|| w.Product.MaSo.Contains(search));
            }
            if (iddm != -1)
            {
                query = query.Where(w => w.ThucDonId == iddm);
            }
           

            //calculator`1
            paging.Paging.TotalRecords = query.Count();
            query = query.OrderByDescending(o => o.Id).Skip((page-1) * pageSize).Take(pageSize);
            paging.List = query.Select(item => new SanPham()
            {
                ID = item.Product.Id,
                ThucDonId = item.Id,
                MaSo = item.Product.MaSo,
                HinhAnh = Utils.site + item.Product.ThumbnailImage + "?v=2",
                TenSanPham = item.Product.ProductName,

                MoTa = item.Product.Infomation,

                DanhMucId = item.Product.ProductCatId,
                TenDanhMuc = item.Product.ProductCat.Name,
                Hot = item.Product.Hot,
                New = item.Product.New,

                KM = item.Product.IsGiamGia,
                Gia = item.Product.Price,

                SoLuongGia = item.Product.SoLuongGia,
                BangGiaCT = item.Product.BangGiaCT.Select(s=>new BangGiaCTJson()
                {
                    Id = s.Id,
                    Ten=s.Ten,
                    Price = s.Price
                }).ToList(),
            });

            return paging;
        }

        [HttpGet]
        [AcceptVerbs("OPTIONS")]
        public SanPham laysp(int id, string search = "")
        {
            ThucDonCT find = __db.ThucDonCT.Find(id);
            return SanPham.map(find);
        }
    }
}
