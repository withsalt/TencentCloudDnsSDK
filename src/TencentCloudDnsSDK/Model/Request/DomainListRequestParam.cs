using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudDnsSDK.Model.Interface;

namespace TencentCloudDnsSDK.Model.Request
{
    public class DomainListRequestParam : IRequest
    {
        public DomainListRequestParam()
        {
            Action = "DomainList";
        }

        public int offset { get; set; } = 0;

        private int _length = 20;
        public int length
        {
            get
            {
                return _length;
            }
            set
            {
                if(value < 1 || value > 100)
                {
                    throw new Exception("DomainDelete un support page count. not less than 1 and not more than 100.");
                }
                _length = value;
            }
        }

        public string keyword { get; set; }

        public int qProjectId { get; set; } = 0;
    }
}
