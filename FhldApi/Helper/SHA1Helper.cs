using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FhldApi.Helper
{
    public class SHA1Helper
    {
        #region HMACSHA1加密  将二进制数据直接转为字符串返回
        /// <summary>
        /// HMACSHA1加密
        /// </summary>
        /// <param name="text">要加密的原串</param>
        ///<param name="key">私钥</param>
        /// <returns></returns>
        public static string HMACSHA1String(string text, string key)
        {
            //HMACSHA1加密
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = System.Text.Encoding.UTF8.GetBytes(key);

            byte[] dataBuffer = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);

            var enText = new StringBuilder();
            foreach (byte iByte in hashBytes)
            {
                enText.AppendFormat("{0:x2}", iByte);
            }
            return enText.ToString();

        }
        #endregion

        #region HMACSHA1加密  对二进制数据转Base64后再返回
        /// <summary>
        /// HMACSHA1加密
        /// </summary>
        /// <param name="text">要加密的原串</param>
        ///<param name="key">私钥</param>
        /// <returns></returns>
        public static string HMACSHA1Base64String(string text, string key)
        {
            //HMACSHA1加密
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = System.Text.Encoding.UTF8.GetBytes(key);

            byte[] dataBuffer = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);

            return Convert.ToBase64String(hashBytes);

        }
        #endregion
    }
}
