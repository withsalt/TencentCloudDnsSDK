using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudDnsSDK.Enum;
using TencentCloudDnsSDK.Model.Interface;

namespace TencentCloudDnsSDK.Model.Request
{
    public class RecordModifyRequestParam : IRequest
    {
        public RecordModifyRequestParam()
        {
            Action = "RecordModify";
        }

        public string domain { get; set; }

        public long recordId { get; set; }

        public string subDomain { get; set; }

        public RecordType recordType { get; set; } = RecordType.A;

        public string recordLine { get; set; } = "默认";

        public string value { get; set; }

        public int ttl { get; set; } = 600;

        public int mx { get; set; } = 0;
    }
}
