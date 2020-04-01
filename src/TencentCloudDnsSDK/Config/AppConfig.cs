using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudDnsSDK.Model.Interface;
using TencentCloudDnsSDK.Utils.Http;

namespace TencentCloudDnsSDK.Config
{
    public class AppConfig
    {
        public static string SecretId { get; set; }

        public static string SecretKey { get; set; }

        public static string DdnsApiRequestUrl { get; set; } = "https://cns.api.qcloud.com/v2/index.php";

        public static Method DdnsApiRequestMethod { get; private set; } = Method.POST;

    }
}
