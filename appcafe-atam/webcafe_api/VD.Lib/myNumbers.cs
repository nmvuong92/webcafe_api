using System;
using System.Collections.Generic;
using System.Globalization;
using VD.Lib.Encode;
using VD.Libs;

namespace VD.Lib
{
    public class myNumbers
    {
        public static Random _srnd = new Random();
        public static int getIntByDefault(object obj,int defaultWrong=-1)
        {
            if (obj == null)
            {
                return defaultWrong;
            }
            int a;
            
            if (int.TryParse(obj.ToString(), out a))
            {
                return a;
            }
            return defaultWrong;

        }

        private static readonly Random getrandom = new Random();

        public static int GetRandomNumberFromTo(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
        public static bool GetRandomBoolean()
        {
            return GetRandomNumberFromTo(1, 1000) % 2 == 0;
        }
        public static int LaySoNgauNhienTuDen(int tu, int den)
        {
            return _srnd.Next(tu, den);
        }

        public static string LayNgauNhien(int tu, int den, int padleft = -1)
        {
            Random rnd = new Random();
            if (padleft == -1)
            {
                return rnd.Next(tu, den).ToString();
            }
            return rnd.Next(tu, den).ToString().PadLeft(padleft, '0');
        }

        public static string RandomeResetPasswordCode(int iduser)
        {
            SimpleAES aes = new SimpleAES();
            //userid(int)_randome split '_'
            return aes.EncryptToString(iduser.ToString()) + "_" + LayMaNgauNhien10ChuSo() + NgauNhienSHA256() + NgauNhienSHA256(10);
        }

        public static string RanDomeResetPasswordGet10CodeLast(string str)
        {
            return str.Substring(str.Length - 10);
        }
        public static string LayMaNgauNhien10ChuSo()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 999999999).ToString().PadLeft(10, '0');
        }

        public static string NgauNhienSHA256()
        {
            Random rnd = new Random();
            return myStringHashExtMethods.GetSHA256HashData(rnd.Next(1, 999999999).ToString());
        }
        public static string NgauNhienSHA256(int num)
        {
            Random rnd = new Random();
            return myStringExts.TruncateNone(myStringHashExtMethods.GetSHA256HashData(rnd.Next(1, 999999999).ToString()), num);
        }

        /// <summary>
        /// chuyển đổi 1 chuỗi số sang dạng số nguyên thủy của nó decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ParseDecimalCulture(string value)
        {
            if (value == "")
            {
                return 0;
            }
            return decimal.Parse(value, new CultureInfo("vi-VN"));
            //return decimal.Parse(value, CultureInfo.InvariantCulture);
        }
        public static decimal ParseDecimalVN(string value)
        {
            return decimal.Parse(value, new CultureInfo("vi-VN"));
            //return decimal.Parse(value, CultureInfo.InvariantCulture);
        }
        // 

        /// <summary>
        /// chuyển đổi 1 chuỗi số sang dạng số nguyên thủy của nó decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ParseDoubleCulture(string value)
        {
            return double.Parse(value, CultureInfo.InvariantCulture);
        }

        private static readonly Random _rng = new Random();
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string RandomString(int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }

        public static string RandomStringNotDup(int size, List<string> arr)
        {
            var s = RandomString(size);
            while (arr.Contains(s))
            {
                s=RandomString(size);
            }
            return s; //mã hóa
        }


        public static int RandomIndexArrNotArr2(List<int> arr, List<int> arr2)
        {
            int randomNumber = _rng.Next(0, arr.Count);
            while (arr2.Contains(arr[randomNumber]))
            {
                randomNumber = _rng.Next(0, arr.Count);
            }
            return arr[randomNumber];
        }
    }
}