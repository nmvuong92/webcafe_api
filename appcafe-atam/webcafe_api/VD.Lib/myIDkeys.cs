using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VD.Lib
{

    public  class myIDkeys
    {
    
        public const string salt = "vd_key_salt";
        public static string EncryptQueryString(string inputText, string key)
        {
            byte[] plainText = Encoding.UTF8.GetBytes(inputText);

            using (RijndaelManaged rijndaelCipher = new RijndaelManaged())
            {
                PasswordDeriveBytes secretKey = new PasswordDeriveBytes(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(salt));
                using (ICryptoTransform encryptor = rijndaelCipher.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(plainText, 0, plainText.Length);
                            cryptoStream.FlushFinalBlock();
                            string base64 = Convert.ToBase64String(memoryStream.ToArray());

                            // Generate a string that won't get screwed up when passed as a query string.
                            string urlEncoded = HttpUtility.UrlEncode(base64);
                            return urlEncoded;
                        }
                    }
                }
            }
        }

        public static string DecryptQueryString(string inputText, string key)
        {
            byte[] encryptedData = Convert.FromBase64String(inputText);
            PasswordDeriveBytes secretKey = new PasswordDeriveBytes(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(salt));

            using (RijndaelManaged rijndaelCipher = new RijndaelManaged())
            {
                using (ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
                {
                    using (MemoryStream memoryStream = new MemoryStream(encryptedData))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] plainText = new byte[encryptedData.Length];
                            cryptoStream.Read(plainText, 0, plainText.Length);
                            string utf8 = Encoding.UTF8.GetString(plainText);
                            return utf8;
                        }
                    }
                }
            }
        }
    }
}
