using System;
using System.Text;
namespace VD.Lib
{
    public static class myStringExts
    {
        //cắt chuỗi đến nếu dài vượt quá maxlength
        public static string Truncate(this string value, int maxLength, string dot="...")
        {
            if (string.IsNullOrEmpty(value))
                return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + dot;
        }
        public static string TruncateAndSTripHtml(this string value, int maxLength, string dot = "...")
        {
            if (string.IsNullOrEmpty(value))
                return value;
            value = value.StripHTML();
            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + dot;
        }
        //truncate none ...
        public static string TruncateNone(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
         public static string HienThiTien(object number)
        {
            return String.Format("{0:#,###}", number);
        }
        public static string HienThiThoiGianBinhLuan(DateTime thoigianbinhluan)
        {
            string tgian = "";
            TimeSpan hieuthoigian = DateTime.Now - thoigianbinhluan;

            if (hieuthoigian.Days < 7)
            {
                if (hieuthoigian.Hours > 0)
                {
                    tgian += hieuthoigian.Hours + " giờ, ";
                }

                if (hieuthoigian.Minutes > 0)
                {
                    tgian += hieuthoigian.Minutes + "phút";
                }
               
            }
            else
            {
                tgian += hieuthoigian.Days/7+"tuần";
            }
            return tgian;
        }
        public static string SEO_URL(string chuoi)
        {
            return RemoveSign4VietnameseString(chuoi).Replace(' ', '-');
        }

         private static readonly string[] VietnameseSigns = new string[]
         {

            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"

        };

        public static string RemoveSign4VietnameseString(string str)
        {

            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

            }

            return str.ToLower();

        }
       
        public static string URLFriendly(this string title)
        {
            try
            {
                title = RemoveSign4VietnameseString(title);
                if (title == null) return "";

                const int maxlen = 80;
                int len = title.Length;
                bool prevdash = false;
                var sb = new StringBuilder(len);
                char c;

                for (int i = 0; i < len; i++)
                {
                    c = title[i];
                    if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                    {
                        sb.Append(c);
                        prevdash = false;
                    }
                    else if (c >= 'A' && c <= 'Z')
                    {
                        // tricky way to convert to lowercase
                        sb.Append((char) (c | 32));
                        prevdash = false;
                    }
                    else if (c == ' ' || c == ',' || c == '.' || c == '/' ||
                             c == '\\' || c == '-' || c == '_' || c == '=')
                    {
                        if (!prevdash && sb.Length > 0)
                        {
                            sb.Append('-');
                            prevdash = true;
                        }
                    }
                    else if ((int) c >= 128)
                    {
                        int prevlen = sb.Length;
                        sb.Append(RemapInternationalCharToAscii(c));
                        if (prevlen != sb.Length) prevdash = false;
                    }
                    if (i == maxlen) break;
                }

                if (prevdash)
                    return sb.ToString().Substring(0, sb.Length - 1);
                else
                    return sb.ToString();
            }
            catch (Exception ex)
            {
                return "topic";
            }
        }
        public static string RemapInternationalCharToAscii(char c)
        {
            string s = c.ToString().ToLowerInvariant();
            if ("àåáâäãåą".Contains(s))
            {
                return "a";
            }
            else if ("èéêëę".Contains(s))
            {
                return "e";
            }
            else if ("ìíîïı".Contains(s))
            {
                return "i";
            }
            else if ("òóôõöøőð".Contains(s))
            {
                return "o";
            }
            else if ("ùúûüŭů".Contains(s))
            {
                return "u";
            }
            else if ("çćčĉ".Contains(s))
            {
                return "c";
            }
            else if ("żźž".Contains(s))
            {
                return "z";
            }
            else if ("śşšŝ".Contains(s))
            {
                return "s";
            }
            else if ("ñń".Contains(s))
            {
                return "n";
            }
            else if ("ýÿ".Contains(s))
            {
                return "y";
            }
            else if ("ğĝ".Contains(s))
            {
                return "g";
            }
            else if (c == 'ř')
            {
                return "r";
            }
            else if (c == 'ł')
            {
                return "l";
            }
            else if (c == 'đ')
            {
                return "d";
            }
            else if (c == 'ß')
            {
                return "ss";
            }
            else if (c == 'Þ')
            {
                return "th";
            }
            else if (c == 'ĥ')
            {
                return "h";
            }
            else if (c == 'ĵ')
            {
                return "j";
            }
            else
            {
                return "";
            }
        }
        //link nếu tồn tại
        public static string MakeLinkIfExists(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "javascript:void(0);";
            }
           return value;
        }

        public static string PrintAndNone(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "-";
            }
           return value;
        }

    }
}
