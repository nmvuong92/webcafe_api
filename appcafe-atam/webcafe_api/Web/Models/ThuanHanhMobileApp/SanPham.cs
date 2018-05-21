using System.Collections.Generic;
using System.Linq;
using VD.Data.Entity.MF;

namespace Web.Models.ThuanHanhMobileApp
{
    public class SanPham
    {
        public int ID { get; set; }
        public int? ThucDonId { get; set; }
        public string MaSo { get; set; }
        public int Gia { get; set; }
        public string Size { get; set; }
        public string MauSac { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }

        public string MoTa { get; set; }

        public int DanhMucId { get; set; }
        public string TenDanhMuc { get; set; }

        public bool KM { get; set; }
        public bool Hot { get; set; }
        public bool New { get; set; }
        public bool Slide { get; set; }

        public int SoLuongGia { get; set; }

        public List<BangGiaCTJson> BangGiaCT { get; set; }

        public static List<SanPham> map(IEnumerable<ThucDonCT> data)
        {
            List<SanPham> lst = new List<SanPham>();
            foreach (var item in data)
            {
                lst.Add(map(item));
            }
            return lst;
        }
        public static List<SanPham> map2(IEnumerable<ThucDonCT> data,int? thucdonid)
        {
            List<SanPham> lst = new List<SanPham>();
            foreach (var item in data)
            {
                lst.Add(map2(item,item.ThucDonId));
            }
            return lst;
        }
        public static SanPham map2(ThucDonCT item,int? thucdonid)
        {
            return new SanPham()
            {
                ID = item.Id,
                ThucDonId = thucdonid,
                MaSo = item.Product.MaSo,
                HinhAnh = Utils.site + item.Product.ThumbnailImage,
                TenSanPham = item.Product.ProductName,

                MoTa = item.Product.Infomation,

                DanhMucId = item.Product.ProductCatId,
                TenDanhMuc = item.Product.ProductCat.Name,
                Hot = item.Product.Hot,
                New = item.Product.New,

                KM = item.Product.IsGiamGia,
                Gia = item.Product.Price,
                SoLuongGia = item.Product.SoLuongGia,
                BangGiaCT =item.Product.BangGiaCT.Select(s=>new BangGiaCTJson()
                {
                    Id=s.Id,
                    Ten = s.Ten,
                    Price = s.Price
                }).ToList()
            };
        }

        public static SanPham map(ThucDonCT item)
        {
            return new SanPham()
            {
                ID = item.Id,
                ThucDonId = item.Id,
                MaSo = item.Product.MaSo,
                HinhAnh = Utils.site + item.Product.ThumbnailImage,
                TenSanPham = item.Product.ProductName,

                MoTa = item.Product.Infomation,

                DanhMucId = item.Product.ProductCatId,
                TenDanhMuc = item.Product.ProductCat.Name,
                Hot = item.Product.Hot,
                New = item.Product.New,

                KM = item.Product.IsGiamGia,
                Gia = item.Product.Price,
                SoLuongGia = item.Product.SoLuongGia,
                BangGiaCT = item.Product.BangGiaCT.Select(s => new BangGiaCTJson()
                {
                    Id = s.Id,
                    Ten = s.Ten,
                    Price = s.Price
                }).ToList()
            };
        }

        public static SanPham map(Product item,int? thucdonid)
        {
            return new SanPham()
            {
                ID = item.Id,
                ThucDonId = thucdonid,
                MaSo = item.MaSo,
                HinhAnh = Utils.site + item.ThumbnailImage,
                TenSanPham = item.ProductName,

                MoTa = item.Infomation,

                DanhMucId = item.ProductCatId,
                TenDanhMuc = item.ProductCat.Name,
                Hot = item.Hot,
                New = item.New,

                KM = item.IsGiamGia,
                Gia = item.Price,

                SoLuongGia = item.SoLuongGia,
                BangGiaCT = item.BangGiaCT.Select(s => new BangGiaCTJson()
                {
                    Id = s.Id,
                    Ten = s.Ten,
                    Price = s.Price
                }).ToList()
            };
        }

      
    }

    public class BangGiaCTJson
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public int Price { get; set; }
    }
}