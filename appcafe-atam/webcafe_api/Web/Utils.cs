using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.UI.WebControls;
using VD.Data;
using VD.Data.IRepository;
using VD.Data.Temp;
using VD.Lib;
using VD.Lib.DTO;
using Web.JWT;

namespace Web
{
    public class Utils
    {
        public static string site = myUrl.BaseUrl2();
        public static string api = site + "/api";
        public static string url_images_danhmucsanpham = site + "/Images/DanhMucSanPham";
        public static string url_images_sanpham = site + "/Images/SanPham";

        private static Random random = new Random();
        public static string RandomString(int length = 5)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string getGoogleQRImageLink(int w, int h, string json)
        {
            return "http://chart.apis.google.com/chart?cht=qr&chs=" + w + "x" + h + "&chl=" + json;
        }
        public static int RandomGia()
        {
            List<int> demo = new List<int> { 100000, 200000, 300000, 400000, 500000, 150000, 50000, 15000, 20000, 65000 };
            return demo.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }
        public static int getRandomIntArray(List<int> arr)
        {
            return arr.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }
        /// <summary>
        /// /contents/images/sample/tenanh{1-10}.png
        /// </summary>
        /// <param name="_link">/contents/images/sample/tenanh</param>
        /// <param name="_from">1</param>
        /// <param name="_to">10</param>
        /// <param name="_extention">.png/.jppg</param>
        /// <returns></returns>
        public static string RandomAnhSample(string _link,int _from, int _to,string _extention)
        {
            List<string> demo = new List<string>();
            for (var i = _from; i <= _to; i++)
            {
                demo.Add(_link + i + _extention);
            }
            return demo.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }
        //Function to get random number
        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        public class VAuth
        {
            public static rs Check(HttpRequestMessage Request)
            {
                var headers = Request.Headers;
                if (headers.Contains("jwt"))
                {
                    string token = headers.GetValues("jwt").First();
                    rs rsdecode = EncodeDecodeJWT.Decode(token);
                    if (rsdecode.r && rsdecode.v != null)
                    {
                        return rs.T("Đã đăng nhập", token);
                    }
                    return rs.F("Vui lòng đăng nhập #1");
                }
                else
                {
                    return rs.F("Vui lòng đăng nhập #2");
                }
            }
        }
    }
}