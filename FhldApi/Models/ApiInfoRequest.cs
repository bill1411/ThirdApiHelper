using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FhldApi.Models
{
    public class ApiInfoRequest
    {
        /// <summary>
        /// 被查询人姓名  必须字段
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 被查询人身份证号码  必须字段
        /// </summary>
        public string idNumber { get; set; }
        /// <summary>
        /// 被查询人手机号码  必须字段
        /// </summary>
        public string phoneNumber { get; set; }
        /// <summary>
        /// 被查询人授权文件 Base64 字符串    非必须字段
        /// </summary>
        public string authorizationStr { get; set; }

    }
}
