using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PYS.Application.Security
{
    public static class PYSSecurity
    {
        public static string StrToMd5(string Metin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] array = Encoding.UTF8.GetBytes(Metin);
            array = md5.ComputeHash(array);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in array)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        public static string Encrypt(string clearText, string encryptionKey)
        {            
            return clearText;
        }

        public static string Decrypt(string cipherText, string encryptionKey)
        {           
            return cipherText;
        }
      
    }
}
