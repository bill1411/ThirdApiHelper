using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPSApi.Models
{
    public class VehicleInfoResponse
    {
        /// <summary>
        /// 本次查询返回的数据总数
        /// </summary>
        public int total { get; set; }
        public List<VehicleInfo> data;

    }

    public class VehicleInfo
    {
        /// <summary>
        /// 设备SIM卡号
        /// </summary>
        public string SIM { get; set; }
        /// <summary>
        /// 设备ID号
        /// </summary>
        public string SIM2 { get; set; }
        /// <summary>
        /// 车辆编号
        /// </summary>
        public string ObjectCode { get; set; }
        /// <summary>
        /// 车辆牌号
        /// </summary>
        public string VehicleNum { get; set; }
        /// <summary>
        /// GPS时间
        /// </summary>
        public string GPSTime { get; set; }
        /// <summary>
        /// 接收时间
        /// </summary>
        public string RcvTime { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string Lon { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string Lat { get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        public string Speed { get; set; }
        /// <summary>
        /// 方向
        /// </summary>
        public string Direct { get; set; }
        /// <summary>
        /// 里程
        /// </summary>
        public string Mileage { get; set; }
        /// <summary>
        /// 车辆状态
        /// </summary>
        public string StatusDes { get; set; }
        /// <summary>
        /// 油量(当前油箱剩余)
        /// </summary>
        public string OilNum { get; set; }
        /// <summary>
        /// 在线状态 0=离线 1=在线
        /// </summary>
        public string IsOnline { get; set; }
        /// <summary>
        /// 报警状态	0=正常 1=报警
        /// </summary>
        public string IsAlarm { get; set; }
        /// <summary>
        /// Acc开关状态 0=熄火	1=启动
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 正反装状态 0=正传 1=反转 2=停转
        /// </summary>
        public string IsReversal { get; set; }

    }
}
