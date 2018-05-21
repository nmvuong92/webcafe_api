using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using VD.Data.Entity.MF;
using VD.Data.Migrations;

namespace Web.ViewModels.MF
{
    public class ChiTietSanPhamView
    {
        public int Id { get; set; }
        public Product SanPham { get; set; }
        public List<ProductCat> DanhMucLienQuan { get; set; } 
        public List<Product> SanPhamLienQuan { get; set; } 
    }

    public class ProductIndexByCatView
    {
        public ProductCat ProductCat { get; set; }
        public List<ProductCat> ProductCatRelated { get; set; }
        public IPagedList<Product> Products { get; set; } 
    }

    public class AjaxPartialProductByCatView
    {
        public ProductCat ProductCat { get; set; }
        public List<ProductCat> ProductCatRelated { get; set; }
        public List<Product> Product8 { get; set; }
    }
}