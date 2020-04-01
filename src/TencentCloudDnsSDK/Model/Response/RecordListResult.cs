using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudDnsSDK.Model.Interface;

namespace TencentCloudDnsSDK.Model.Response
{
    public class RecordListResult : IResult
    {
        public RecordListResultData Data { get; set; }
    }

    public class RecordListResultData
    {
        /// <summary>
        /// 
        /// </summary>
        public RecordListResultDomain Domain { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RecordListResultInfo Info { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<RecordListResultRecordItem> Records { get; set; }
    }

    public class RecordListResultRecordItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ttl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int enabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updated_on { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int q_project_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 默认
        /// </summary>
        public string line { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string line_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hold { get; set; }
    }

    public class RecordListResultInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string sub_domains { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string record_total { get; set; }
    }

    public class RecordListResultDomain
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string punycode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string grade { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ext_status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ttl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int min_ttl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> dnspod_ns { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int q_project_id { get; set; }
    }
}
