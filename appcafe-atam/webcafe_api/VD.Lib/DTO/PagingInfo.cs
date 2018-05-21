using System;

namespace VD.Lib.DTO
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerpage { get; set; }
        public int CurentPage { get; set; }

        public int TotalsPage
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerpage); }
        }
    }
}