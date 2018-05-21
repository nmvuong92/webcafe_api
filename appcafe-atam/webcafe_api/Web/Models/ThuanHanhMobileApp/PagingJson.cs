using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ThuanHanhMobileApp
{
    public class PagingJson
    {
        public int TotalRecords { get; set; }
        public int RecordsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int PageNext
        {
            get { return this.CurrentPage + 1; }
        }
        public int TotalPages
        {
            get { return (this.TotalRecords + this.RecordsPerPage - 1) / this.RecordsPerPage; }
        }
    }
}