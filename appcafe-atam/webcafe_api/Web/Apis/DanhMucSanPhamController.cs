using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using VD.Data;
using VD.Data.Entity.MF;
using VD.Data.IRepository;
using Web.Models.ThuanHanhMobileApp;

namespace Web.Apis
{
    public class DanhMucSanPhamController : ApiController
    {
        
        private IProductCatRepository productCatRepo;
        vuong_cms_context __db = new vuong_cms_context();
        public DanhMucSanPhamController( IProductCatRepository _productCatRepo)
        {
            this.productCatRepo = _productCatRepo;
        }
        [HttpGet]
        [AcceptVerbs("OPTIONS")]
        public IEnumerable<DanhMucSanPham> layds(int quanid, int page = 1, int pageSize = 1000)
        {
            int __v = Utils.GetRandomNumber(1, 1000);
            var td= __db.ProductCat.Where(w => w.QuanId == quanid).ToList().Select(s => new DanhMucSanPham()
            {
                ID = s.Id,
                TenDanhMuc = s.Name,
                HinhAnh = Utils.site + s.ImageThumbnail + "?v=" + __v
            }).ToList();
            foreach (var thucdonitem in td)
            {
                //initial
                var paging = new ListPagingJson<SanPham>();
                paging.Paging.RecordsPerPage = pageSize;
                paging.Paging.CurrentPage = page;
                IQueryable<Product> query = __db.Product;

                DanhMucSanPham thucdonitem1 = thucdonitem;
                query = query.Where(w => w.ProductCatId == thucdonitem1.ID);

                //calculator

                paging.Paging.TotalRecords = query.Count();
                query = query.OrderByDescending(o => o.Id).Skip((page - 1) * pageSize).Take(pageSize);
                paging.List = query.AsQueryable().Select(item => new SanPham()
                {
                    ID = item.Id,
                    ThucDonId = item.Id,
                    MaSo = item.MaSo,
                    HinhAnh = Utils.site + item.ThumbnailImage + "?v=" + __v,
                    TenSanPham = item.ProductName,
                    MoTa = item.Infomation,
                    DanhMucId = item.ProductCatId,
                    TenDanhMuc = item.ProductCat.Name,
                    Hot = item.Hot,
                    New = item.New,
                    KM = item.IsGiamGia,
                    Gia = item.Price,
                    SoLuongGia = item.SoLuongGia,
                    BangGiaCT = item.BangGiaCT.Select(s=>new BangGiaCTJson()
                    {
                        Id = s.Id,
                        Ten = s.Ten,
                        Price = s.Price,
                    }).ToList(),
                }).ToList();
                thucdonitem.DSSP = paging;
            }
            return td;
        }
        
    }
}
