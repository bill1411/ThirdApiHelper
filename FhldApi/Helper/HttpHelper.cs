using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace WebAPI.Common
{
    public class HttpHelper
    {

        /// <summary>  
        /// Get同步请求  
        /// </summary>  
        /// <param name="url">Url地址</param>  
        /// <param name="encode">编码(默认UTF8)</param>  
        /// <returns></returns>  
        public static string HttpGet(string url, Encoding encode = null)
        {
            string result;

            try
            {
                var webClient = new WebClient { Encoding = Encoding.UTF8 };

                if (encode != null)
                    webClient.Encoding = encode;

                result = webClient.DownloadString(url);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        /// <summary>  
        /// Get异步请求  
        /// </summary>  
        /// <param name="url">Url地址</param>  
        /// <param name="callBackDownStringCompleted">回调事件</param>  
        /// <param name="encode">编码(默认UTF8)</param>  
        public static void HttpGetAsync(string url,
            DownloadStringCompletedEventHandler callBackDownStringCompleted = null, Encoding encode = null)
        {
            var webClient = new WebClient { Encoding = Encoding.UTF8 };

            if (encode != null)
                webClient.Encoding = encode;

            if (callBackDownStringCompleted != null)
                webClient.DownloadStringCompleted += callBackDownStringCompleted;

            webClient.DownloadStringAsync(new Uri(url));
        }

        /// <summary>  
        ///  Post同步请求  
        /// </summary>  
        /// <param name="url">Url地址</param>  
        /// <param name="postStr">请求Url数据</param>  
        /// <param name="encode">编码(默认UTF8)</param>  
        /// <returns></returns>  
        public static string HttpPost(string url, string postStr = "", Encoding encode = null, Dictionary<string, string> heards = null)
        {
            string result;

            try
            {
                var webClient = new WebClient { Encoding = Encoding.UTF8 };

                if (encode != null)
                    webClient.Encoding = encode;

                var sendData = Encoding.GetEncoding("UTF-8").GetBytes(postStr);

                webClient.Headers.Add("Content-Type", "application/json");
                webClient.Headers.Add("ContentLength", sendData.Length.ToString(CultureInfo.InvariantCulture));
                if (heards != null)
                {
                    foreach (var item in heards)
                    {
                        webClient.Headers.Add(item.Key, item.Value);

                    }
                }

                var readData = webClient.UploadData(url, "POST", sendData);

                result = Encoding.GetEncoding("UTF-8").GetString(readData);

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        /// <summary>  
        /// Post异步请求  
        /// </summary>  
        /// <param name="url">Url地址</param>  
        /// <param name="postStr">请求Url数据</param>  
        /// <param name="callBackUploadDataCompleted">回调事件</param>  
        /// <param name="encode"></param>  
        public static void HttpPostAsync(string url, string postStr = "",
            UploadDataCompletedEventHandler callBackUploadDataCompleted = null, Encoding encode = null, Dictionary<string, string> heards = null)
        {
            var webClient = new WebClient { Encoding = Encoding.UTF8 };

            if (encode != null)
                webClient.Encoding = encode;

            var sendData = Encoding.GetEncoding("UTF-8").GetBytes(postStr);

            webClient.Headers.Add("Content-Type", "application/json");
            webClient.Headers.Add("ContentLength", sendData.Length.ToString(CultureInfo.InvariantCulture));

            if (heards != null)
            {
                foreach (var item in heards)
                {
                    webClient.Headers.Add(item.Key, item.Value);

                }
            }

            if (callBackUploadDataCompleted != null)
                webClient.UploadDataCompleted += callBackUploadDataCompleted;

            webClient.UploadDataAsync(new Uri(url), "POST", sendData);
        }

        // 从一个对象信息生成Json串
        public static string ObjectToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            byte[] dataBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(dataBytes, 0, (int)stream.Length);
            return Encoding.UTF8.GetString(dataBytes);
        }

        // 从一个Json串生成对象信息
        public static object JsonToObject(string jsonString, object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            return serializer.ReadObject(mStream);
        }
    }
}