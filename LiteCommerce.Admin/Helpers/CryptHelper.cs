using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace LiteCommerce.Admin
{
    /// <summary>
    /// 
    /// </summary>
    public static class CryptHelper
    {
        public static string Md5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            Byte[] originalBytes = encoder.GetBytes(text);
            Byte[] encodeBytes = md5.ComputeHash(originalBytes);
            text = BitConverter.ToString(encodeBytes).Replace("-", "");
            var result = text.ToLower();
            return result;
        }
    }
}