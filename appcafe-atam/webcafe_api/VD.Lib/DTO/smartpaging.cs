
using System;

namespace VD.Lib.DTO
{
    public class smartpaging
    {
        public int tranghientai { get; set; }
        public int tongdongmottrang { get; set; }
        //sort
        public string tentruongsort { get; set; }
        public string giatrisort { get; set; }
        public bool? xuatexcel { get; set; }
        public boloc[] bolocs { get; set; }
        public string[] fnjs { get; set; }
        public string url { get; set; } //static

        public int quanid { get; set; }
        public int catid { get; set; }
        //
        public int numSkip
        {
            get { return (this.tranghientai - 1) * this.tongdongmottrang; }
        }
    }

    public class boloc
    {
        public string tentruongloc { get; set; }
        public string giatriloc { get; set; }
    }

    public class article_sp : smartpaging
    {
        public int catid { get; set; }

    }
    public class product_sp : smartpaging
    {
        public int catid { get; set; }
        public int catid2 { get; set; }

    }
    public class donhang_sp : smartpaging
    {
        public int ban { get; set; }
        public int quanid { get; set; }
        public int trangthaigiaohangid { get; set; }
        public int trangthaithanhtoanid { get; set; }
        public DateTime tu { get; set; }
        public DateTime den { get; set; }
        public bool loctg { get; set; }
    }
}
