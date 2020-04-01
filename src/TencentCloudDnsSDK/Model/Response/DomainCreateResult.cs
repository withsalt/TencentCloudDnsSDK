using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudDnsSDK.Model.Interface;

namespace TencentCloudDnsSDK.Model.Response
{
    public class DomainCreateResult : IResult
    {
        public DomainCreateResultData Data { get; set; }
    }

    public class DomainCreateResultData
    {
        public DomainCreateResultDataDomain Domain { get; set; }
    }

    public class DomainCreateResultDataDomain
    {
        public string Id { get; set; }

        public string Punycode { get; set; }

        public string Domain { get; set; }
    }
}
