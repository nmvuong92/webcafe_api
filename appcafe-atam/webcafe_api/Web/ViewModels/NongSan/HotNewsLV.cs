using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VD.Data.Entity.nongsan;
using PagedList;
using System.Web.Mvc;
namespace Web.ViewModels.NongSan
{
    public class HotNewsLV
    {
        public string searchk { get; set; }
        public int cat { get; set; }
        public int sort { get;set; }
        public HotNewsCat HotNewsCat { get; set; }
        public IPagedList<HotNews> pList { get; set; }
        public IEnumerable<SelectListItem> ddlSort { get;set; }
        public IQueryable<HotNewsCat> pHotNewsCats { get; set; }
    }
    public class HotNewsDetailLV
    {
        public HotNews HotNews { get; set; }
        public IQueryable<HotNews> pOrthers { get; set; }
        public IQueryable<HotNewsCat> pHotNewsCats { get; set; }
    }
}