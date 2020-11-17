using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPSApi.Models
{
    public class ApiResponse
    {
        /// <summary>
        /// 返回值
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string ErrMsg { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public dynamic Data { get; set; }
    }
}
