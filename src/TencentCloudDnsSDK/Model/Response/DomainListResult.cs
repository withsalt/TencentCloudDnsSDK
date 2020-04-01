using System;
using System.Collections.Generic;
using System.Text;
using TencentCloudDnsSDK.Model.Interface;

namespace TencentCloudDnsSDK.Model.Response
{
    public class DomainListResult : IResult
    {
        public DomainListResultData Data { get; set; }
    }

    public class DomainListResultData
    {
        /// <summary>
        /// 
        /// </summary>
        public DomainListResultDataInfo Info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DomainListResultDomainsItem> Domains { get; set; }
    }

    public class DomainListResultDataInfo
    {
        public int domain_total { get; set; }
    }

    public class DomainListResultDomainsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string group_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string searchengine_push { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string is_mark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ttl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string cname_speedup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string created_on { get; set; }

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
        public string punycode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ext_status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string src_flag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string grade { get; set; }

        /// <summary>
        /// 新免费套餐
        /// </summary>
        public string grade_title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string is_vip { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string owner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string records { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int min_ttl { get; set; }
    }
}
