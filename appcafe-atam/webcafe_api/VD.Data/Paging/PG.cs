using System.Collections.Generic;
using System.Linq;
using System.Text;
using VD.Data.Base;
using VD.Data.Entity;
using VD.Lib;
using VD.Lib.DTO;

namespace VD.Data.Paging
{
    public class PG<T>
    {
        public int tongdong { get; set; } //get
        public int tranghientai { get; set; } //get
        public int dong1trang { get; set; }//get
        public string[] fnjs { get; set; }//get

        public decimal TongTien { get; set; }

        public string thongtinphantrang { get; set; }
        public IEnumerable<T> L { get; set; }

        public PG(int _tongdong, int _tranghientai, int _dong1trang, string[] _fnjs)
           
        {
            this.tongdong = _tongdong;
            this.tranghientai = _tranghientai;
            this.dong1trang = _dong1trang;
            this.fnjs = _fnjs;
            this.thongtinphantrang = LayThongTinPhanTrang();
        }        
        /// <summary>
        /// html paging
        /// </summary>
        /// <returns></returns>
        public string LayThongTinPhanTrang()
        {
            StringBuilder _html = new StringBuilder("");
            if (dong1trang != -1)
            {
                int tong_trang = (tongdong + dong1trang - 1) / dong1trang;
                int trang_bd = 0, trang_kt = tong_trang;

                //chỉ hiển thị nút bấm 10 trang hợp lý 5-6-7-8-9-[10]-11-12-13-14-15
                //nếu tổng số trang >10 (lớn)
                if (tong_trang > 10)
                {
                    //hiển thị trang bắt đầu và kết thúc cách trang hiện tại 5 trang, -> tổng cộng 10 trang show ra
                    //hiển thị trang chọn bắt đầu
                    trang_bd = tranghientai - 5;
                    //hiển thị trang chọn kết thhúc
                    trang_kt = tranghientai + 5;
                    if (trang_bd < 0)
                    {
                        trang_bd = 0;
                        trang_kt = trang_bd + 10;
                    }
                    if (trang_kt > tong_trang)
                    {
                        trang_kt = tong_trang;
                        trang_bd = tong_trang - 10;
                    }
                }

                //thêm phần footer phân trang ở dưới lưới dữ liệu
                _html.Append("<div class='fl fl_pg pagination'>");
                if (tongdong > dong1trang)
                {
                    //nếu trang hiện tại mà từ trang 2 trờ đi thì hiện ra nút << (back lại 1 trang)
                    if (tranghientai > 1)
                    {

                        _html.Append("<li><a data-pg=1 href='javascript:void(0);'> First </a></li>");
                        _html.Append("<li><a data-pg=" + (tranghientai - 1) + " href='javascript:void(0);'> << </a></li>");

                    }

                    //duyệt từ trang bắt đầu tới trang kết thúc xuất ra các nút bấm phân trang
                    for (int i = trang_bd; i < trang_kt; i++)
                    {
                        //đây là trang hiện tại, mang class current
                        if ((i + 1) == tranghientai)
                        {

                            _html.Append("<li  class='active'><a href='javascript:void(0);'>[" + (i + 1) + "]</a></li>");
                        }
                        else //đây không phải trang hiện tại
                        {

                            _html.Append("<li><a data-pg=" + (i + 1) + " href='javascript:void(0);'> " + (i + 1) + " </a></li>");
                        }
                    }
                    if (tranghientai != tong_trang)
                    {

                        _html.Append("<li><a data-pg=" + (tranghientai + 1) + " href='javascript:void(0);'> >> </a></li>");
                        _html.Append("<li><a data-pg=" + tong_trang + " href='javascript:void(0);'> End (" + tong_trang + ") </a></li>");
                    }
                }
                _html.Append("</div>");

                //thống kê tổng dòng
                _html.Append("<div class='fr'>Total " + tongdong + "</span> rows  (page " + tranghientai + "/" +
                             tong_trang + ")</div>");
            }
            else
            {
              
                _html.Append("<div class='fr'>Total " + tongdong + "</span> rows</div>");
              
            }
            string opt_pt = "";
            foreach (var i in myAppSetings.row_per_page)
            {
                if (i == this.dong1trang)
                {
                    opt_pt += "<option value=" + i + " selected='selected'>" + i + "</option>";
                }
                else
                {
                    opt_pt += "<option value=" + i + ">" + i + "</option>";
                }
            }
            _html.Append("<div class='fr'><select class='ddlrpp'>" + opt_pt + "</select></div>");
            return _html.ToString();
        }
    }

    public class PGQuery<T> where T : new()
    {
        public IQueryable<T> values;

        public PGQuery(IQueryable<T> _v)
        {
            this.values = _v;
        }  
    }

    public static class PGetx
    {
        public static PG<T> GetPG<T>(this PGQuery<T> query, smartpaging paging)
            where T : new()
        {
            PG<T> vmpg = null;
            //TOTAL RECORDS
            int tongdong = query.values.Count();
            //PAGING INFORMATION
            if (paging.tongdongmottrang != -1)
            {
                query.values = query.values.Skip(paging.numSkip).Take(paging.tongdongmottrang);
            }

            vmpg = new PG<T>(tongdong, paging.tranghientai, paging.tongdongmottrang, paging.fnjs);
            vmpg.L = query.values.ToList();
            return vmpg;
        }
    }
}
