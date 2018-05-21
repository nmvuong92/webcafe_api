using System.Collections.Generic;
using VD.Data.Entity.MF;
using Web.Areas.Admin.ViewModels.MF;

namespace Web.Models.ThuanHanhMobileApp
{
    public class DanhMucSanPham
    {
        public int ID { get; set; }

        public string TenDanhMuc { get; set; }
        public string HinhAnh { get; set; }
        public ListPagingJson<SanPham> DSSP { get; set; }

        //method
        public static List<DanhMucSanPham> getSeed()
        {
            int id = 0;

            List<DanhMucSanPham> lst = new List<DanhMucSanPham>
            {
                new DanhMucSanPham()
                {
                    ID = ++id,
                    TenDanhMuc = "Kiếng dán",
                    HinhAnh = Utils.url_images_danhmucsanpham + "/kieng-dan.jpg",
                },
                new DanhMucSanPham()
                {
                    ID = ++id,
                    TenDanhMuc = "Kiếng xe",
                    HinhAnh = Utils.url_images_danhmucsanpham + "/kieng-xe.jpg",
                },
                new DanhMucSanPham()
                {
                    ID = ++id,
                    TenDanhMuc = "Gù tay lái",
                    HinhAnh = Utils.url_images_danhmucsanpham + "/gu-tay-lai.jpg",
                },
            };
            return lst;
        }
        public static List<DanhMucSanPham> map(IEnumerable<ProductCat> data)
        {
            List<DanhMucSanPham> lst = new List<DanhMucSanPham>();
            foreach (var item in data)
            {
                lst.Add(new DanhMucSanPham()
                {
                    HinhAnh = Utils.site + item.ImageThumbnail,
                    TenDanhMuc = item.Name,
                    ID = item.Id,
                });
            }
            return lst;
        }

        public static DanhMucSanPham map(ProductCat item)
        {
            return new DanhMucSanPham()
            {
                HinhAnh = Utils.site + item.ImageThumbnail,
                TenDanhMuc = item.Name,
                ID = item.Id,
            };
        }
    }
}