using System;
using System.Text;
using System.Web.Mvc;
using VD.Lib.DTO;

namespace Web.Helpers
{
    public static class PagingHelpers
    {

        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
       
                 //đây là phương thức gen ra html phân trang ở footer
    
            StringBuilder _html = new StringBuilder("");
                int tong_trang = pagingInfo.TotalsPage;
                int trang_bd = 0, trang_kt = tong_trang;
                int TongDong = pagingInfo.TotalItems;
                int TrangHienTai = pagingInfo.CurentPage;
                int Dong1Trang = pagingInfo.ItemsPerpage;

            //chỉ hiển thị nút bấm 10 trang hợp lý 5-6-7-8-9-[10]-11-12-13-14-15
            //nếu tổng số trang >10 (lớn)
            if (tong_trang > 10)
            {
                //hiển thị trang bắt đầu và kết thúc cách trang hiện tại 5 trang, -> tổng cộng 10 trang show ra
                //hiển thị trang chọn bắt đầu
                trang_bd = TrangHienTai - 5;
                //hiển thị trang chọn kết thhúc
                trang_kt = TrangHienTai + 5;
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
            }//thêm phần footer phân trang ở dưới lưới dữ liệu
          
            if (TongDong > Dong1Trang)
            {
                //nếu trang hiện tại mà từ trang 2 trờ đi thì hiện ra nút << (back lại 1 trang)
                if (TrangHienTai > 1)
                {
                    _html.Append("<a href='" + pageUrl(1) + "' class='page-numbers'> Đầu </a>");
                    _html.Append("<a href='" + pageUrl(TrangHienTai - 1) + "' class='page-numbers'> << </a>");
                }

                //duyệt từ trang bắt đầu tới trang kết thúc xuất ra các nút bấm phân trang
                for (int i = trang_bd; i < trang_kt; i++)
                {
                    //đây là trang hiện tại, mang class current
                    if ((i + 1) == TrangHienTai)
                    {
                        _html.Append("<a href='" + pageUrl(i+1) + "' class='page-numbers current'>[" + (i + 1) + "]</a>");
                    }
                    else //đây không phải trang hiện tại
                    {
                        _html.Append("<a href='" + pageUrl(i+1) + "' class='page-numbers'> " + (i + 1) + " </a>");
                    }
                }
                if (TrangHienTai != tong_trang)
                {
                    _html.Append("<a href='" + pageUrl(TrangHienTai + 1) + "' class='page-numbers'> >> </a>");
                    _html.Append("<a href='" + pageUrl(tong_trang) + "' class='page-numbers'> Cuối (" + tong_trang + ") </a>");
                }
            }
          
            
            return MvcHtmlString.Create(_html.ToString());
        }
    }
}