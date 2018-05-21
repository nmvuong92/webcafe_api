using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using VD.Data.Entity.MF;

namespace Web.ViewModels.MF
{
    public class TinTucView
    {
        public IPagedList<Article> List { get; set; }
        public List<Article> XemNhieu { get; set; } 
    }

    public class TinTucChiTietView
    {
        public Article BaiViet { get; set; }
        
        public List<Article> LienQuan { get; set; } 
    }
}