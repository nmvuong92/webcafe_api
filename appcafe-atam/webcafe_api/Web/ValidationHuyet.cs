using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using VD.Lib.DTO;
using Web.ViewModels.Form;

namespace Web
{
    public class ValidationHuyet
    {
        public rs totalValidationHuyet(String testStr)
        {
            rs rs = rs.T("Ok");
            if (!isValidHuyet(testStr))
            {

                rs = rs.F("Huyệt chứa những ký tự không hợp lệ");
            }
            if (!isValidHuyet2(testStr))
            {

                rs = rs.F("Số lượng huyệt 3-50");
            }
            if (!isValidHuyet3(testStr))
            {

                rs = rs.F("Huyệt không đúng");
            }

            return isValidDSHuyet(testStr); //validation su hop le
        }

        public rs isValidDSHuyet(string dshuyet)
        {
            List<string> huyet_split = dshuyet.Split(',').ToList();
            string _msg = "Huyệt không tồn tại: ";
            int DemHuyetLoi = 0;
            foreach (var huyet in huyet_split)
            {
                ValidationHuyet __val = new ValidationHuyet();
                var lay_ten = __val.fnLayTenAnhPTCT(huyet);
                string search = System.Web.HttpContext.Current.Server.MapPath("~/Content/bqc/" + lay_ten + ".png");
                
                if (!System.IO.File.Exists(search))
                {
                    _msg += huyet;
                    DemHuyetLoi++;
                }

            }
            rs r;
            if (DemHuyetLoi != 0)
            {
                r = rs.F(_msg);
            }
            else
            {
                r = rs.T("Ok");
            }
            return r;
        }
        //validation
        public Boolean isValidHuyet(String testStr)
        {
            Regex rgx = new Regex("[0-9,_+-]+");
            return rgx.IsMatch(testStr);
        }
        public Boolean isValidHuyet2(String testStr)
        {
            int dem = testStr.Split(',').Length;
            return dem > 0 && dem <= 50;
        }
        public Boolean isValidHuyet3(String testStr)
        {
            String[] splithuyet = testStr.Split(',');
            bool rs = true;
            //chỉ 1 _,-,+ trong mỗi huyệt
            foreach (var mang in splithuyet)
            {

                int dem_gach = 0, dem_cong = 0, dem_tru = 0;
                foreach (char i in mang)
                {
                    if (i == '_')
                    {
                        dem_gach += 1;
                    }
                    else if (i == '+')
                    {
                        dem_cong += 1;
                    }
                    else if (i == '-')
                    {
                        dem_tru += 1;
                    }
                }
                if (dem_gach > 1 || dem_tru > 1 || dem_cong > 1)
                {
                    rs = false;
                }
                else if (dem_cong == 1 && dem_tru == 1)
                {
                    rs = false;
                }
                else
                { //kiểm tra xem có tồn tại số huyệt trong mỗi phần tử ko
                    string new_num = mang.Replace("_", "");

                    new_num = new_num.Replace("+", "");

                    new_num = new_num.Replace("-", "");
                    if (new_num.Length == 0)
                    {
                        rs = false;
                    }
                }
            }
            return rs;
        }

        public string fnLayTenAnhPTCT(string huyetSo)
        {
            string num = huyetSo.Trim();
            string rsStr = "myphacdo_";
            string hauto = "";
            //có gạch chân hiển thị
            if (huyetSo.Contains("_"))
            {
                rsStr = "_myphacdo_";
                num = huyetSo.Replace("_", "");
            }
            //kiem tra dau am
            if (huyetSo.Contains("-"))
            {
                //ĐỔI LẠI DO SAI BAN ĐÂU
                hauto = "cong";
            }
            else if (huyetSo.Contains("+"))
            {
                //ĐỔI LẠI DO SAI BAN ĐÂU
                hauto = "tru0";
            }
            else
            {
                hauto = "";
            }
            //remove;z
            num = huyetSo.Replace("_", "");
            num = num.Replace("-", "");
            num = num.Replace("+", "");
            return rsStr + "" + num + "" + hauto;
        }
    }
}