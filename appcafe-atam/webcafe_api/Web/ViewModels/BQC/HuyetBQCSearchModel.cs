using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ViewModels.BQC
{
    public class HuyetBQCSearchModel
    {
        public int huyet { get; set; }
        public bool grid { get; set; }
        public string loai { get; set; }

        public string mota { get; set; }
        public int somat { get; set; }
    }
}