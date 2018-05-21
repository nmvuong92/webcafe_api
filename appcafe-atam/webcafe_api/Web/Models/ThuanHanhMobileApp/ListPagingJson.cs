using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ThuanHanhMobileApp
{
    public class ListPagingJson<T>
    {
        public ListPagingJson()
        {
            this.Paging = new PagingJson();
            this.Number1 = 0;
            this.Number2 = 0;
        }
        public PagingJson Paging { get; set; }
        public IEnumerable<T> List { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
    }
}