using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudDnsSDK.Model.Interface;

namespace TencentCloudDnsSDK.Model.Request
{
    public class RecordDeleteRequestParam: IRequest
    {
        public RecordDeleteRequestParam()
        {
            Action = "RecordDelete";
        }

        public string domain { get; set; }

        public long recordId { get; set; }
    }
}
