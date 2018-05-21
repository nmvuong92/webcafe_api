using System;
using System.Net.NetworkInformation;

namespace VD.Lib
{
    public static class myStringNumber
    {
        public static int GetIntegerDotDot(this string value)
        {

            string get = value.Replace(".", string.Empty);
            if (string.IsNullOrWhiteSpace(get))
            {
                return 0;
            }

            int ignoreMe;
            if (int.TryParse(get, out ignoreMe))
            {
                return ignoreMe;
            }

            return 0;




        }
        public static string ToMoneyStr(this decimal value)
        {
            return ((double)value).ToString("N0") + " ₫";
            /*
            if ((int)(((decimal)value % 1) * 100) > 0)
            {
                return value.ToString("N2");
            }
            else
            {
                return value.ToString("N0");
            }*/

        }
        public static string ToMoneyStrHD(this decimal value)
        {
            return ((double)value).ToString("N0");
            /*
            if ((int)(((decimal)value % 1) * 100) > 0)
            {
                return value.ToString("N2");
            }
            else
            {
                return value.ToString("N0");
            }*/

        }
        public static string ToMoneyStrRound(this decimal value)
        {
            return ((double)value).ToString("N0") + " ₫";
            /*if ((int)(((decimal)value % 1) * 100) > 0)
            {
                return value.ToString("N1");
            }
            else
            {
                return value.ToString("N0");
            }*/

        }
        public static string ToMoneyStr(this decimal? value)
        {

            if (value == null || value.Value==0)
            {
                return "-Liên hệ-";
            }
            return ((double)value).ToString("N0") + " ₫";
            /*
            if ((int)(((decimal)value % 1) * 100) > 0)
            {
                return value.Value.ToString("N2")+" ₫";
            }
            else
            {
                return value.Value.ToString("N0") + " ₫";
            }*/

        }

        public static string ToMoneyStr(this int value)
        {
            return ((int)value).ToString("N0") + " ₫";

        }
        public static string ToMoneyStr(this int? value)
        {

            if (value == null)
            {
                return "-";
            }
            return ((int)value.Value).ToString("n0") + " ₫";


        }
        #region Đọc tiền thành chữ
        public static String DocTien(this decimal total)
        {
            try
            {
                string rs = "";
                total = Math.Round(total, 0);
                string[] ch = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
                string[] rch = { "lẻ", "mốt", "", "", "", "lăm" };
                string[] u = { "", "mươi", "trăm", "ngàn", "", "", "triệu", "", "", "tỷ", "", "", "ngàn", "", "", "triệu" };
                string nstr = total.ToString();

                int[] n = new int[nstr.Length];
                int len = n.Length;
                for (int i = 0; i < len; i++)
                {
                    n[len - 1 - i] = Convert.ToInt32(nstr.Substring(i, 1));
                }

                for (int i = len - 1; i >= 0; i--)
                {
                    if (i % 3 == 2)// số 0 ở hàng trăm
                    {
                        if (n[i] == 0 && n[i - 1] == 0 && n[i - 2] == 0) continue;//nếu cả 3 số là 0 thì bỏ qua không đọc
                    }
                    else if (i % 3 == 1) // số ở hàng chục
                    {
                        if (n[i] == 0)
                        {
                            if (n[i - 1] == 0) { continue; }// nếu hàng chục và hàng đơn vị đều là 0 thì bỏ qua.
                            else
                            {
                                rs += " " + rch[n[i]]; continue;// hàng chục là 0 thì bỏ qua, đọc số hàng đơn vị
                            }
                        }
                        if (n[i] == 1)//nếu số hàng chục là 1 thì đọc là mười
                        {
                            rs += " mười"; continue;
                        }
                    }
                    else if (i != len - 1)// số ở hàng đơn vị (không phải là số đầu tiên)
                    {
                        if (n[i] == 0)// số hàng đơn vị là 0 thì chỉ đọc đơn vị
                        {
                            if (i + 2 <= len - 1 && n[i + 2] == 0 && n[i + 1] == 0) continue;
                            rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                            continue;
                        }
                        if (n[i] == 1)// nếu là 1 thì tùy vào số hàng chục mà đọc: 0,1: một / còn lại: mốt
                        {
                            rs += " " + ((n[i + 1] == 1 || n[i + 1] == 0) ? ch[n[i]] : rch[n[i]]);
                            rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                            continue;
                        }
                        if (n[i] == 5) // cách đọc số 5
                        {
                            if (n[i + 1] != 0) //nếu số hàng chục khác 0 thì đọc số 5 là lăm
                            {
                                rs += " " + rch[n[i]];// đọc số 
                                rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
                                continue;
                            }
                        }
                    }

                    rs += (rs == "" ? " " : ", ") + ch[n[i]];// đọc số
                    rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
                }
                if (rs[rs.Length - 1] != ' ')
                    rs += " đồng";
                else
                    rs += "đồng";

                if (rs.Length > 2)
                {
                    string rs1 = rs.Substring(0, 2);
                    rs1 = rs1.ToUpper();
                    rs = rs.Substring(2);
                    rs = rs1 + rs;
                }
                return rs.Trim().Replace("lẻ,", "lẻ").Replace("mươi,", "mươi").Replace("trăm,", "trăm").Replace("mười,", "mười");
            }
            catch
            {
                return "";
            }

        }
        #endregion

    }


}
