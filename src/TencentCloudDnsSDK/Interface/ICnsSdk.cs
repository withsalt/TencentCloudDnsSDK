using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TencentCloudDnsSDK.Model.Interface;
using TencentCloudDnsSDK.Model.Request;
using TencentCloudDnsSDK.Model.Response;

namespace TencentCloudDnsSDK
{
    public interface ICnsSdk
    {
        #region 域名相关接口

        Task<DomainCreateResult> DomainCreate(DomainCreateRequestParam param);

        Task<SetDomainStatusResult> SetDomainStatus(SetDomainStatusRequestParam param);

        Task<DomainListResult> DomainList(DomainListRequestParam param);

        Task<DomainDeleteResult> DomainDelete(DomainDeleteRequestParam param);

        #endregion

        #region 解析记录相关接口
        Task<RecordCreateResult> RecordCreate(RecordCreateRequestParam param);

        Task<RecordStatusResult> RecordStatus(RecordStatusRequestParam param);

        Task<RecordModifyResult> RecordModify(RecordModifyRequestParam param);

        Task<RecordListResult> RecordList(RecordListRequestParam param);

        Task<RecordDeleteResult> RecordDelete(RecordDeleteRequestParam param);
        #endregion


    }
}
