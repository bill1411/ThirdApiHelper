using iGPSApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Common;

namespace iGPSApi.Helper
{
    public  class iGPSHelper
    {
        //定义基础调用地址
        private const string BaseApi = "http://api.juruiyun.com/";
        //获取token接口名
        private const string GetTokenApi = "api/user/GetLoginToken";
        //根据登录凭证和车牌列表获取车辆当前状态信息
        private const string GetCurrentVehicleInfoApi = "api/vehicle/GetCurrentVehicleInfo";
        //根据登录凭证和设备ID列表获取车辆当前状态信息
        private const string GetCurrentVehicleInfoByDeviceIDsApi = "api/vehicle/GetCurrentVehicleInfoByDeviceIDs";


        //定义测试数据
        private const string tokenString = "{\"Code\": 200,\"Data\": \"E03ABA0AE0758AFCAA311540510FB800\",\"ErrMsg\": null}";
        private const string vehicleInfoString = "{\"Code\": 200,\"Data\": {\"total\": 1,\"data\": [{\"SIM\": \"1064755708\",\"SIM2\": \"8029999\",\"ObjectCode\": \"1808090123\",\"VehicleNum\": \"8020\",\"GPSTime\": \"2018-09-27 13:53:15\",\"RcvTime\": \"2018-09-27 13:53:16\",\"Lon\": 113.940838,\"Lat\": 22.562788,\"Speed\": 0.0,\"Direct\": 189,\"Mileage\": \"13.7\",\"StatusDes\": \"启动怠速[8分14秒],回传[14秒],GSM网络强27,卫星弱0,通讯受干扰报警,主电压12.1V,LBS\",\"OilNum\": \"0.0\",\"IsOnline\": 0,\"IsAlarm\": 0,\"Status\": 0,\"IsReversal\": 0}]},\"ErrMsg\": null}";


        #region 获取token值
        /// <summary>
        /// 获取token值  最长有效期180天
        /// </summary>
        /// <param name="LoginName">用户名</param>
        /// <param name="PassWord">密 码</param>
        /// <returns></returns>
        public static string GetToken(string LoginName, string PassWord)
        {
            string url = BaseApi + GetTokenApi;

            GetTokenRequest request = new GetTokenRequest();
            request.LoginName = LoginName;
            request.PassWord = PassWord;
            
            //序列化要请求的参数
            string poststr = JsonConvert.SerializeObject(request);
            
            //发请求，获取数据
            return HttpHelper.HttpPost(url,poststr);
        }
        #endregion

        #region 根据登录凭证和车牌列表获取车辆当前状态信息
        /// <summary>
        /// 根据登录凭证和车牌列表获取车辆当前状态信息
        /// </summary>
        /// <param name="VehiclePlates">车牌号集合,多个数据用逗号隔开，为空时返回所有车辆信息</param>
        public static string GetCurrentVehicleInfo(List<string> VehiclePlates,string token)
        {
            string url = BaseApi + GetCurrentVehicleInfoApi;
            //加入token参数
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Authorization", "Bearer " + token);

            Dictionary<string, string> pstr = new Dictionary<string, string>();
            pstr.Add("VehiclePlates", VehiclePlates[0].ToString());
            string poststr =  JsonConvert.SerializeObject(pstr);

            return HttpHelper.HttpPost(url, poststr,null,dict);
        }
        #endregion

        #region 根据登录凭证和车牌列表获取车辆当前状态信息
        /// <summary>
        /// 根据登录凭证和车牌列表获取车辆当前状态信息
        /// </summary>
        /// <param name="DeviceIDs">设备ID集合，多个数据用逗号隔开，为空时返回所有车辆信息</param>
        public static string GetCurrentVehicleInfoByDeviceIDs(List<string> DeviceIDs, string token)
        {
            string url = BaseApi + GetCurrentVehicleInfoByDeviceIDsApi;
            
            //加入token参数
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Authorization", "Bearer " + token);

            Dictionary<string, string> pstr = new Dictionary<string, string>();
            pstr.Add("DeviceIDs", DeviceIDs[0].ToString());
            string poststr = JsonConvert.SerializeObject(pstr);

            return HttpHelper.HttpPost(url, poststr,null,dict);
        }
        #endregion


    }
}
