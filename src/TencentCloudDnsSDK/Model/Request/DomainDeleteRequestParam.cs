using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudDnsSDK.Model.Interface;

namespace TencentCloudDnsSDK.Model.Request
{
    public class DomainDeleteRequestParam : IRequest
    {
        public DomainDeleteRequestParam()
        {
            Action = "DomainDelete";
        }
        public string domain { get; set; }
    }
}
