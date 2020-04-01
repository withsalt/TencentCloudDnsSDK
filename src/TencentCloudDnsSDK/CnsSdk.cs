using System;
using System.Threading.Tasks;
using TencentCloudDnsSDK.Config;
using TencentCloudDnsSDK.Model.Interface;
using TencentCloudDnsSDK.Model.Request;
using TencentCloudDnsSDK.Model.Response;
using TencentCloudDnsSDK.Utils.Http;
using TencentCloudDnsSDK.Utils.Json;

namespace TencentCloudDnsSDK
{
    public class CnsSdk : ICnsSdk
    {
        public CnsSdk(string secretId, string secretKey)
        {
            if (string.IsNullOrEmpty(secretId) || string.IsNullOrEmpty(secretKey))
            {
                throw new Exception("SecretId or SecretKey can not null.");
            }
            AppConfig.SecretId = secretId;
            AppConfig.SecretKey = secretKey;
        }

        public async Task<DomainCreateResult> DomainCreate(DomainCreateRequestParam param)
        {
            try
            {
                DomainCreateResult result = await HttpRequest<DomainCreateResult>(param);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Tencent cloud ddns request error. {ex.Message}");
            }
        }

        public async Task<DomainDeleteResult> DomainDelete(DomainDeleteRequestParam param)
        {
            try
            {
                DomainDeleteResult result = await HttpRequest<DomainDeleteResult>(param);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Tencent cloud ddns request error. {ex.Message}");
            }
        }

        public async Task<DomainListResult> DomainList(DomainListRequestParam param)
        {
            try
            {
                DomainListResult result = await HttpRequest<DomainListResult>(param);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Tencent cloud ddns request error. {ex.Message}");
            }
        }

        public async Task<RecordCreateResult> RecordCreate(RecordCreateRequestParam param)
        {
            if (string.IsNullOrEmpty(param.domain))
            {
                throw new Exception("Domain can not null.");
            }
            if (string.IsNullOrEmpty(param.subDomain))
            {
                throw new Exception("subDomain can not null. you can use @ for main record.");
            }
            if (string.IsNullOrEmpty(param.value))
            {
                throw new Exception("Record value can not null.");
            }
            try
            {
                RecordCreateResult result = await HttpRequest<RecordCreateResult>(param);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Tencent cloud ddns request error. {ex.Message}");
            }
        }

        public async Task<RecordDeleteResult> RecordDelete(RecordDeleteRequestParam param)
        {
            if (string.IsNullOrEmpty(param.domain))
            {
                throw new Exception("Domain can not null.");
            }
            if (param.recordId <= 0)
            {
                throw new Exception("recordId can not null. you can use @ for main record.");
            }
            try
            {
                RecordDeleteResult result = await HttpRequest<RecordDeleteResult>(param);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Tencent cloud ddns request error. {ex.Message}");
            }
        }

        public async Task<RecordListResult> RecordList(RecordListRequestParam param)
        {
            if (string.IsNullOrEmpty(param.domain))
            {
                throw new Exception("Domain can not null.");
            }
            try
            {
                RecordListResult result = await HttpRequest<RecordListResult>(param);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Tencent cloud ddns request error. {ex.Message}");
            }
        }

        public async Task<RecordModifyResult> RecordModify(RecordModifyRequestParam param)
        {
            if (string.IsNullOrEmpty(param.domain))
            {
                throw new Exception("Domain can not null.");
            }
            if (string.IsNullOrEmpty(param.subDomain))
            {
                throw new Exception("subDomain can not null. you can use @ for main record.");
            }
            if (string.IsNullOrEmpty(param.value))
            {
                throw new Exception("Record value can not null.");
            }
            try
            {
                RecordModifyResult result = await HttpRequest<RecordModifyResult>(param);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Tencent cloud ddns request error. {ex.Message}");
            }
        }

        public async Task<RecordStatusResult> RecordStatus(RecordStatusRequestParam param)
        {
            if (string.IsNullOrEmpty(param.domain))
            {
                throw new Exception("Domain can not null.");
            }
            if (param.recordId <= 0)
            {
                throw new Exception("recordId can not null. you can use @ for main record.");
            }
            try
            {
                RecordStatusResult result = await HttpRequest<RecordStatusResult>(param);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Tencent cloud ddns request error. {ex.Message}");
            }
        }

        public async Task<SetDomainStatusResult> SetDomainStatus(SetDomainStatusRequestParam param)
        {
            try
            {
                SetDomainStatusResult result = await HttpRequest<SetDomainStatusResult>(param);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Tencent cloud ddns request error. {ex.Message}");
            }
        }

        #region Private
        private async Task<T> HttpRequest<T>(IRequest param) where T : IResult
        {
            HttpResult httpResult = await new HttpUtil().Request(new HttpItem()
            {
                URL = AppConfig.DdnsApiRequestUrl,
                Method = AppConfig.DdnsApiRequestMethod,
                PostDataType = PostDataType.String,
                Postdata = param.GetPostDataWithSign(),
                Accept = "application/json",
                ContentType = "application/x-www-form-urlencoded;charset=utf-8"
            });

            if (httpResult != null && !string.IsNullOrEmpty(httpResult.Html))
            {
                if (httpResult.Html.Contains("\"data\":[]"))
                {
                    httpResult.Html = httpResult.Html.Replace("\"data\":[]", "\"data\":{}");
                }
                T result = JsonHelper.DeserializeJsonToObject<T>(httpResult.Html);
                return result;
            }
            else
            {
                throw new Exception("Http request result is null.");
            }
        }
        #endregion
    }
}
