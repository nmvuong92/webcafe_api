using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using VD.Data.Entity.MF;

namespace Web.ViewModels.MF
{
    public class AboutUsView
    {
        
    }

    public class AboutUsIndexView
    {
        public int? Id { get; set; }
        public Article Chinh { get; set; }
        public IPagedList<Article> LienQuan { get; set; } 
    }
}