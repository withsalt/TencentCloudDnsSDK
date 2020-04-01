using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudDnsSDK.Model.Interface;

namespace TencentCloudDnsSDK.Model.Request
{
    public class RecordListRequestParam : IRequest
    {
        public RecordListRequestParam()
        {
            Action = "RecordList";
        }

        public string domain { get; set; }

        public int offset { get; set; }

        private int _length = 20;
        public int length
        {
            get
            {
                return _length;
            }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new Exception("record list unsupport page count. not less than 1 and not more than 100.");
                }
                _length = value;
            }
        }

        public string subDomain { get; set; }

        public string recordType { get; set; }

        public int qProjectId { get; set; }

    }
}
