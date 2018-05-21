using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VD.Data.Entity;

namespace Web.Areas.Admin.ViewModels
{
    public class ConfigCRUDView : LangInput
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public bool IsMulLang { get; set; }
        public bool IsHtmlEditor { get; set; }
        public List<ConfigCRUDViewTrans> Trans { get; set; }
    }
    public class ConfigOneCRUDView : LangInput
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public bool IsMulLang { get; set; }
        public bool IsHtmlEditor { get; set; }
        public bool IsImg { get; set; }
        [Required]
        public string Content { get; set; }
    }
    public class ConfigCRUDViewTrans
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public int LangId { get; set; }
        public Lang LangEntity { get; set; }
    }
}