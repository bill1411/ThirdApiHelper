using FhldApi.Helper;
using FhldApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FhldApi
{
    /*
    * 
    * 服务商：杭州符号律动
    * 
    * Api接口功能：提供个人征信数据查询
    * 
    * 接口文档信息：个人综合风险评估  （F0004）  V1
    * 
   */
    class Program
    {
        static void Main(string[] args)
        {

            string result = fhldHelper.GetInfo("11","22", "33");
            //反序列化为对象
            ApiInfoResonse response = JsonConvert.DeserializeObject<ApiInfoResonse>(result);
            if (response.code == 200)
            {
                Console.WriteLine("获取到的数据是：" + response.body.result + " " + response.body.suggestion);
                string content = FilterBigDataJson(response.body);

                Console.WriteLine("复杂的详细信息结果集：" + content);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("获取数据错误：" + response.msg);
                Console.ReadKey();
            }
        }

        #region  过滤不需要的信息
        private static string FilterBigDataJson(Body jsonBody)
        {
            Body body = new Body();
            Content content = new Content();

            body.id = jsonBody.id;
            body.result = jsonBody.result;
            body.suggestion = jsonBody.suggestion;
            body.time = jsonBody.time;

            Person person = new Person();
            person.info = jsonBody.content.person.info;
            person.detections = GetDetections(jsonBody.content.person.detections);
            content.person = person;

            Phone phone = new Phone();
            phone.info = jsonBody.content.phone.info;
            phone.detections = GetDetections(jsonBody.content.phone.detections);
            content.phone = phone;

            body.content = content;

            return JsonConvert.SerializeObject(body);
        }
        #endregion

        #region  根据条件过滤Detections集合
        private static List<Detections> GetDetections(List<Detections> info)
        {
            List<Detections> listDetection = new List<Detections>();
            if (info.Count > 0)
            {
                foreach (var item in info)
                {
                    if (!item.conclusion.Contains("通过") && !item.conclusion.Contains("无风险"))
                    {
                        listDetection.Add(item);
                    }
                }
            }
            return listDetection;
        }
        #endregion
    }
}
