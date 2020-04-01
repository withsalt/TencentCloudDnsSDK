using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudDnsSDK.Model.Interface;

namespace TencentCloudDnsSDK.Model.Response
{
    public class RecordModifyResult : IResult
    {
        public RecordModifyResultData Data { get; set; }
    }

    public class RecordModifyResultData
    {
        public RecordModifyResultRecord Record { get; set; }
    }

    public class RecordModifyResultRecord
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
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
