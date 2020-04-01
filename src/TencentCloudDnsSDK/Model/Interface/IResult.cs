using System;
using System.Collections.Generic;
using System.Text;

namespace TencentCloudDnsSDK.Model.Interface
{
    public abstract class IResult
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public string CodeDesc { get; set; }
    }
}
