using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VD.Data.Entity.MF;

namespace Web.ViewModels.MF
{
    public class CatalogView
    {
        public Catalog main { get; set; }
        public List<Catalog> List { get; set; } 
    }
}