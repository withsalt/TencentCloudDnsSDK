using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudDnsSDK.Config;
using TencentCloudDnsSDK.Model.Interface;

namespace TencentCloudDnsSDK.Model.Request
{
    public class DomainCreateRequestParam : IRequest
    {
        public DomainCreateRequestParam()
        {
            Action = "DomainCreate";
        }
        public string domain { get; set; }

        public int projectId { get; set; }
    }
}
