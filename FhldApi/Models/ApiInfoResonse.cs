using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FhldApi.Models
{
    public class ApiInfoResonse
    {
        /// <summary>
        /// 响应code  200成功
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 响应描述
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 接口响应时间 YYYY-MM-DD
        /// </summary>
        public string time { get; set; }
        /// <summary>
        /// 业务流水号 
        /// </summary>
        public string seq { get; set; }
        /// <summary>
        /// 响应主体
        /// </summary>
        public Body body { get; set; }
    }

    public class Body
    {
        /// <summary>
        /// 报告编号，唯一标识一份报告
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 报告生成时间，当前时间距离格林威治时间 1970 年 1 月 1 号 0 时 0 分0 秒的毫秒数
        /// </summary>
        public long time { get; set; }
        /// <summary>
        /// 报告结论，含义如下所示：
        /// A：属于无风险区域    B：属于风险较低区域
        /// C：属于风险可控区域  D：属于风险危害区域   E：属于风险高危区域
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// 报告建议，包括：通过、人工、拒绝
        /// </summary>
        public string suggestion { get; set; }
        /// <summary>
        /// 报告内容，由身份（person）风险检测和手机（phone）风险检测两部分组成，每一部分检测都包含了基本信息（info）和相关具体检测的列表（detections）
        /// </summary>
        public Content content { get; set; }
    }


    public class Content
    {
        public Person person;
        public Phone phone;
    }

    public class Person
    {
        public List<Detections> detections { get; set; }
        public PersonInfo info { get; set; }
    }

    public class Phone
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Detections> detections { get; set; }
        public PhoneInfo info;
    }

    #region 个人信息类
    public class PersonInfo
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string idNumber { get; set; }
        /// <summary>
        /// 性别 男  女
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 所属省份
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 所属城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 出生日期，用“YYYY-MM-DD”的格式表示
        /// </summary>
        public string brithdate { get; set; }

    }
    #endregion

    #region 手机信息类
    public class PhoneInfo
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string phoneNumber { get; set; }
        /// <summary>
        /// 运行商
        /// </summary>
        public string isp { get; set; }
        /// <summary>
        /// 卡描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 所属省份
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 所属城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 在网状态
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 在网时长
        /// </summary>
        public string time { get; set; }

    }
    #endregion

    #region 风险监测
    public class Detections
    {
        /// <summary>
        /// 检测名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 检测描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 检测结论，包括：通过、不通过、高风险、中风险、低风险、无法验证
        /// </summary>
        public string conclusion { get; set; }
        /// <summary>
        /// 结论分析
        /// </summary>
        public string analysis { get; set; }
        /// <summary>
        /// 检测详情
        /// </summary>
        public List<Detail> details;
    }
    #endregion

    #region 检测详情
    public class Detail
    {
        /// <summary>
        /// 检测详情名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 检测详情表头
        /// </summary>
        public List<string> header { get; set; }
        /// <summary>
        /// 检测详情表值列表
        /// </summary>
        public List<List<string>> values { get; set; }
    }
    #endregion

}
