using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudDnsSDK.Model.Interface;

namespace TencentCloudDnsSDK.Model.Request
{
    public class RecordStatusRequestParam: IRequest
    {
        public RecordStatusRequestParam()
        {
            Action = "RecordStatus";
        }

        public string domain { get; set; }

        public long recordId { get; set; }

        private string _status = "enable";
        public string status
        {
            get
            {
                return _status;
            }
            set
            {
                if (value != "enable" && value != "disable")
                {
                    throw new Exception("SetDomainStatus value only support enable or disable");
                }
                else
                {
                    _status = value;
                }
            }
        }
    }
}
