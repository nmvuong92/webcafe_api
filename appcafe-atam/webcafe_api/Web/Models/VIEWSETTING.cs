using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VD.Data;
using VD.Data.Entity;
using VD.Data.Temp;

namespace Web.Models
{
    public class VIEWSETTING
    {
        public Setting __setting { get; set; }
        public SysConfigVM __config { get; set; }
   
        public loginVM __login { get; set; }
       
    }
}