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
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("获取数据错误：" + response.msg);
                Console.ReadKey();
            }
        }
    }
}
