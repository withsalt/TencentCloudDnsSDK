using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudDnsSDK.Model.Interface;

namespace TencentCloudDnsSDK.Model.Response
{
    public class RecordCreateResult : IResult
    {
        public RecordCreateResultData Data { get; set; }
    }

    public class RecordCreateResultData
    {
        /// <summary>
        /// 
        /// </summary>
        public RecordCreateResultRecord Record { get; set; }
    }

    public class RecordCreateResultRecord
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Weight { get; set; }
    }
}
