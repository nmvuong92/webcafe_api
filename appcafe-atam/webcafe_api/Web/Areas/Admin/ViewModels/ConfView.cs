using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VD.Data.Entity;


namespace Web.Areas.Admin.ViewModels
{
    public class ConfView
    {
      
            public Conf conf { get; set; }
            public bool cbDoiMatKhauEmail { get; set; }
            public string matkhauemailmoi { get; set; }
            public string matkhauemailcu3kt { get; set; }
        
    }

    public class CRUDConf
    {
        public int Id { get; set; }
        [Required]
        public string Key { get; set; }
        public string Content { get; set; }

        public int LangId { get; set; }
        public Lang LangEntity { get; set; }
    }
}