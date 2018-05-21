using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using VD.Lib.Encode;

namespace VD.Lib
{
    /*
     using 
     *  static void Main(string[] args)
        {
            Console.WriteLine("Please enter a password to use:");
            string password = Console.ReadLine();
            Console.WriteLine("Please enter a string to encrypt:");
            string plaintext = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Your encrypted string is:");
            string encryptedstring = StringCipher.Encrypt(plaintext, password);
            Console.WriteLine(encryptedstring);
            Console.WriteLine("");

            Console.WriteLine("Your decrypted string is:");
            string decryptedstring = StringCipher.Decrypt(encryptedstring, password);
            Console.WriteLine(decryptedstring);
            Console.WriteLine("");

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
     */
    
    public static class myEncryptDecrypt
    {
       
        
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        private const int Keysize = 256;
        public const string passPhrase = "vd_key";
        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText)
        {
            SimpleAES aes = new SimpleAES();
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return aes.EncryptToString(Convert.ToBase64String(cipherTextBytes));
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            SimpleAES aes = new SimpleAES();
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return aes.DecryptString(Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount));
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }

        public static string PackID(long value)
        {
            ulong a = (ulong)value; // make shift easy
            List<byte> bytes = new List<byte>(8);
            while (a != 0)
            {
                bytes.Add((byte)a);
                a >>= 8;
            }
            bytes.Reverse();
            var chunk = bytes.ToArray();
            return Convert.ToBase64String(chunk);
        }
        public static long UnpackID(string value)
        {
            var chunk = Convert.FromBase64String(value);
            ulong a = 0;
            for (int i = 0; i < chunk.Length; i++)
            {
                a <<= 8;
                a |= chunk[i];
            }
            return (long)a;
        }
    }
}
