using FhldApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Common;

namespace FhldApi.Helper
{
    public class fhldHelper
    {
        //定义基础调用地址
        private const string BaseApi = "http://oapi.fhldtech.com/person-risk/v1/comprehensive-assessment";
        private const string accessId = "";
        private const string accessSecret = "";

        private const string responseContent = "{\"code\":200,\"msg\":\"请求成功\",\"time\":\"2020-11-17 15:22:23\",\"seq\":\"123456789\",\"body\":{\"id\":\"F00042019101415393855171107061817394\",\"time\":1571040619417,\"result\":\"E\",\"suggestion\":\"拒绝\",\"content\":{\"person\":{\"detections\":[{\"name\":\"身份实名风险检测\",\"description\":\"根据被查询人的姓名、身份证数据，基于公安系统进行实名验证\",\"conclusion\":\"通过\",\"analysis\":\"验证通过\",\"details\":[]},{\"name\":\"司法风险名单检测\",\"description\":\"根据被查询人的身份信息，在司法体系中检测是否存在被曝光、失信行为、 被执行以及相关的法院判决和诉讼等 \",\"conclusion\":\"中风险\",\"analysis\":\"检测出存在有高度疑似司法案件风险\",\"details\":[{\"name\":\"被执行情况\",\"header\":[\"案号\",\"法院\",\"立案时间\",\"更新时间\",\"执行状态\",\"案由\",\"执行标的\"]}]}],\"phone\":{\"detections\":[{\"name\":\"手机实名风险检测\",\"description\":\"根据被查询人的姓名、身份证和手机数据，基于运营商进行实名验证\",\"conclusion\":\"通过\",\"analysis\":\"验证通过\",\"details\":[]},{\"name\":\"银行多头借款申请风险检测\",\"description\":\"根据被查询人的相关信息，分析其在银行机构场景下，多头借款申请数据中的潜在风险情况 \",\"conclusion\":\"中风险\",\"analysis\":\"检测到有银行机构场景下借款申请风险\",\"details\":[{\"name\":\"银行机构借款申请次数统计数据\",\"header\":[\"机构类型\",\"近 7 天\",\"近 15 天\",\"近 1 个月\",\"近 3 个月\",\"近 6 个月\",\"近 12 个月\"],\"values\":[[\"传统银行\",\"0\",\"0\",\"0\",\"1\",\"2\",\"2\"],[\"网络银行\",\"0\",\"0\",\"0\",\"0\",\"3\",\"3\"]]},{\"name\":\"银行机构借款申请平台数统计数据\",\"header\":[\"机构类型\",\"近 7 天\",\"近 15 天\",\"近 1 个月\",\"近 3 个月\",\"近 6 个月\",\"近 12 个月\"],\"values\":[[\"传统银行\",\"0\",\"0\",\"0\",\"1\",\"1\",\"1\"],[\"网络银行\",\"0\",\"0\",\"0\",\"0\",\"2\",\"2\"]]}]}],\"info\":{\"phoneNumber\":\"XXXXXXXXXXX\",\"isp\":\"中国移动\",\"description\":\"江苏移动数据卡\",\"province\":\"江苏\",\"city\":\"苏州\",\"status\":\"在网\",\"time\":\"6-12 个月\"}}}}}}";
        public static string GetInfo(string name,string phone,string idNumber)
        {
            ApiInfoRequest request = new ApiInfoRequest();
            request.idNumber = idNumber;
            request.name = name;
            request.phoneNumber = phone;
            //序列化后的body
            string body = JsonConvert.SerializeObject(request);
            //得到的签名密文
            string signature = SHA1Helper.HMACSHA1Base64String(body, accessSecret);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("x-fhld-access-key-id", accessId);
            headers.Add("x-fhld-signature", signature);

            return responseContent;   //HttpHelper.HttpPost(BaseApi, body, null, headers);
        }


    }
}
