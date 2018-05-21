using System;
using System.Collections.Generic;
using System.Linq;

namespace VD.Lib
{
    public class myBase64EncodeDecode
    {
        private static readonly HashSet<char> _base64Characters = new HashSet<char>() { 
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 
            'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 
            'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 
            'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/', 
            '='
        };
        public static string EncodeBase64(string input)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input));
        }

        public static string DecodeBase64(string input)
        {
            if (IsBase64String(input))
            {
                return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(input));
            }
            else
            {
                return input;
            }
          
        }
        public static bool IsBase64String(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            else if (value.Any(c => !_base64Characters.Contains(c)))
            {
                return false;
            }

            try
            {
                Convert.FromBase64String(value);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
