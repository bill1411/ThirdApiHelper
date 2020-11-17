using iGPSApi.Helper;
using iGPSApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPSApi
{
    /*
     * 
     * 服务商网站：http://www.juruiyun.com  
     * 
     * Api接口功能：汽车GPS设备定位
     * 
     * 接口文档信息：版本信息没有注明
     * 
    */
    class Program
    {
        static void Main(string[] args)
        {
            GetToken("111","222");

            //List<string> list = new List<string>();
            //list.Add("A96538");
            //GetVehicleInfo(list, "222");

            //List<string> list = new List<string>();
            //list.Add("96538");
            //GetVehicleInfoByDeviceIDs(list, "222");
        }

        #region  获取token
        private static void GetToken(string loginname,string password)
        {
            
            //获取token值
            string result = iGPSHelper.GetToken(loginname, password);
            //反序列化为对象
            ApiResponse response = JsonConvert.DeserializeObject<ApiResponse>(result);
            if (response.Code == 200)
            {
                Console.WriteLine("获取到的token是：" + response.Data);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("错误：" + response.ErrMsg);
                Console.ReadKey();
            }
            
        }
        #endregion

        #region  根据车牌，获取车辆信息
        /// <summary>
        /// 根据车牌，获取车辆信息
        /// </summary>
        /// <param name="car_licence">要查询的车牌集合，为空 查询所有车辆状态</param>
        /// <param name="token">访问凭证</param>
        private static void GetVehicleInfo(List<string> car_licence,string token)
        {

            //获取token值
            string result = iGPSHelper.GetCurrentVehicleInfo(car_licence,token);
            //反序列化为对象
            ApiResponse response = JsonConvert.DeserializeObject<ApiResponse>(result);
            if (response.Code == 200)
            {
                try
                {
                    VehicleInfoResponse res = JsonConvert.DeserializeObject<VehicleInfoResponse>(response.Data.ToString());
                    Console.WriteLine("获取到的车辆信息是：" + res.data[0].StatusDes);
                    Console.ReadKey();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("error：" + ex.Message);
                }
                
            }
            else
            {
                Console.WriteLine("错误：" + response.ErrMsg);
                Console.ReadKey();
            }

        }
        #endregion

        #region 根据车辆ID，获取车辆信息
        /// <summary>
        /// 根据车辆ID，获取车辆信息
        /// </summary>
        /// <param name="car_ids">车辆IDs集合</param>
        /// <param name="token">凭证</param>
        private static void GetVehicleInfoByDeviceIDs(List<string> car_ids, string token)
        {

            //获取token值
            string result = iGPSHelper.GetCurrentVehicleInfoByDeviceIDs(car_ids, token);
            //反序列化为对象
            ApiResponse response = JsonConvert.DeserializeObject<ApiResponse>(result);
            if (response.Code == 200)
            {
                try
                {
                    VehicleInfoResponse res = JsonConvert.DeserializeObject<VehicleInfoResponse>(response.Data.ToString());
                    Console.WriteLine("获取到的车辆信息是：" + res.data[0].StatusDes);
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error：" + ex.Message);
                }

            }
            else
            {
                Console.WriteLine("错误：" + response.ErrMsg);
                Console.ReadKey();
            }

        }
        #endregion
    }
}
