using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public static class StatusEtxCaptionModel
    {
        public static string StatusCommon(this int value)
        {
            string rs = "";
            switch (value)
            {
                case 1:
                    rs = "Đã kích hoạt";
                    break;
                case 0:
                    rs = "Vô hiệu hóa";
                    break;
              
                default:
                    rs = "Không xác định";
                    break;
            }
            return rs;
        }
      
    }
}