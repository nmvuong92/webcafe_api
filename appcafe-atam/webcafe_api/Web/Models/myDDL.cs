using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;



namespace Web.Models
{
    public  class myDDL
    {

        public static IEnumerable<SelectListItem> ddlMM
        {
            get
            {
                return Enumerable.Range(1, 12).Select(s => new SelectListItem()
                {
                    Text = s.ToString(),
                    Value = s.ToString()
                });
            }
        }
        public static IEnumerable<SelectListItem> ddlDD
        {
            get
            {
                return Enumerable.Range(1, 31).Select(s => new SelectListItem()
                {
                    Text = s.ToString(),
                    Value = s.ToString()
                });
            }
        }
        public static IEnumerable<SelectListItem> ddlYYY
        {
            get
            {
               
                return Enumerable.Range(DateTime.Now.Year-100,85).Reverse().Select(s => new SelectListItem()
                {
                    Text = s.ToString(),
                    Value = s.ToString()
                });
            }
        }
        public static IEnumerable<SelectListItem> ddlYYYFuture
        {
            get
            {

                return Enumerable.Range(DateTime.Now.Year-5, 1+10).Reverse().Select(s => new SelectListItem()
                {
                    Text = s.ToString(),
                    Value = s.ToString()
                });
            }
        }
    }
}