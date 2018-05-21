using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using VD.Data.Entity.BQC;

namespace Web.ViewModels.BQC
{
    public class PDCTview
    {
        public string Q { get; set; }
        //list
        public IPagedList<PhacDoCuaToi> pList { get; set; }
    }
}