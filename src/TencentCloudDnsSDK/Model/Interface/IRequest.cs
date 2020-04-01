using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using TencentCloudDnsSDK.Config;
using TencentCloudDnsSDK.Enum;
using TencentCloudDnsSDK.Utils.Api;
using TencentCloudDnsSDK.Utils.Date;
using TencentCloudDnsSDK.Utils.Http;

namespace TencentCloudDnsSDK.Model.Interface
{
    public abstract class IRequest
    {
        public IRequest()
        {
            this.Nonce = new Random().Next(0, 9999);
            this.Timestamp = TimeUtil.Timestamp();
        }

        private const BindingFlags InstanceBindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        /// <summary>
        /// 是否签名，在发起请求钱先进行签名
        /// </summary>
        internal bool IsSignature { get; private set; } = false;

        /// <summary>
        /// 具体操作的指令接口名称，例如，腾讯云 CVM 用户调用 查询实例列表 接口，则 Action 参数即为 DescribeInstances。
        /// </summary>
        protected string Action { get; set; }

        /// <summary>
        /// 地域参数，用来标识希望操作哪个地域的实例。详细信息可参见 地域和可用区 列表，或使用 查询地域列表 API 接口查看。
        /// </summary>
        //protected string Region { get; set; }

        /// <summary>
        /// 当前 UNIX 时间戳，可记录发起 API 请求的时间。
        /// </summary>
        protected long Timestamp { get; private set; }

        /// <summary>
        /// 用户可自定义随机正整数，与 Timestamp 联合起来， 用于防止重放攻击。
        /// </summary>
        protected int Nonce { get; private set; }

        /// <summary>
        /// 在 云API密钥 上申请的标识身份的 SecretId，一个 SecretId 对应唯一的 SecretKey , 而 SecretKey 会用来生成请求签名 Signature。具体可参考 签名方法 章节。
        /// </summary>
        protected string SecretId { get; private set; } = AppConfig.SecretId;

        /// <summary>
        /// 请求签名，用来验证此次请求的合法性，需要用户根据实际的输入参数计算得出。计算方法可参考 签名方法 章节。
        /// </summary>
        protected string Signature { get; private set; }

        /// <summary>
        /// 签名方式，目前支持 HmacSHA256 和 HmacSHA1。只有指定此参数为 HmacSHA256 时，才使用 HmacSHA256 算法验证签名，其他情况均使用 HmacSHA1 验证签名。详细签名计算方法可参考 签名方法 章节。
        /// </summary>
        protected SignatureType SignatureMethod { get; set; } = SignatureType.HmacSHA1;

        /// <summary>
        /// 临时证书所用的 Token，需要结合临时密钥一起使用。长期密钥不需要 Token。
        /// </summary>
        internal string Token { get; set; }

        #region Internal Method

        internal void SignatureRequest()
        {
            QueryCollection queries = new QueryCollection();

            PropertyInfo[] propertyInfos = this.GetType().GetProperties(InstanceBindFlags);
            if (propertyInfos == null || propertyInfos.Length == 0)
            {
                throw new Exception("Can not get class properties.");
            }
            foreach (var item in propertyInfos)
            {
                string name = item.Name;
                if (name == "IsSignature" || name == "Signature")
                    continue;
                object valueObj = item.GetValue(this, null);
                string value = valueObj?.ToString();
                queries.Add(name, value);
            }
            queries.Sort((x, y) =>
            {
                for (int i = 0; i < (x.Key.Length < y.Key.Length ? x.Key.Length : y.Key.Length); i++)
                {
                    int val = x.Key[i] - y.Key[i];
                    if (val != 0)
                        return val;
                    else
                        continue;
                }
                return 0;
            });

            StringBuilder sb = new StringBuilder();
            sb.Append(AppConfig.DdnsApiRequestMethod);
            sb.Append(AppConfig.DdnsApiRequestUrl.Replace("https://", ""));
            sb.Append("?");
            sb.Append(string.Join("&", queries.Select(t =>
            {
                //不能对中文进行URL Encode
                if (string.Equals(t.Key, "domain", StringComparison.OrdinalIgnoreCase)
                || string.Equals(t.Key, "recordline", StringComparison.OrdinalIgnoreCase)
                || string.Equals(t.Key, "subDomain", StringComparison.OrdinalIgnoreCase))
                {
                    return $"{t.Key}={(t.Value ?? "")}";
                }
                return $"{HttpUtil.UrlEncode(t.Key)}={(t.Value == null ? "" : HttpUtil.UrlEncode(t.Value))}";
            })));

            HMAC mac = null;
            if (SignatureMethod == SignatureType.HmacSHA1)
            {
                mac = new HMACSHA1(Encoding.UTF8.GetBytes(AppConfig.SecretKey));
            }
            else
            {
                mac = new HMACSHA256(Encoding.UTF8.GetBytes(AppConfig.SecretKey));
            }
            byte[] hashBytes = mac.ComputeHash(Encoding.UTF8.GetBytes(sb.ToString()));
            mac.Dispose();
            Signature = HttpUtil.UrlEncode(Convert.ToBase64String(hashBytes));
            IsSignature = true;
        }

        internal string GetPostData()
        {
            if (!IsSignature)
            {
                throw new Exception("获取POST DATA数据前请先进行签名。");
            }
            return GenPostData();
        }

        internal string GetPostDataWithSign()
        {
            SignatureRequest();
            return GenPostData();
        }

        private string GenPostData()
        {
            QueryCollection queries = new QueryCollection();
            PropertyInfo[] propertyInfos = this.GetType().GetProperties(InstanceBindFlags);
            if (propertyInfos == null || propertyInfos.Length == 0)
            {
                throw new Exception("Can not get class properties.");
            }
            foreach (var item in propertyInfos)
            {
                string name = item.Name;
                if (name == "IsSignature")
                {
                    continue;
                }
                object valueObj = item.GetValue(this, null);
                string value = valueObj?.ToString();
                queries.Add(name, value);
            }
            return string.Join("&", queries.Select(t =>
            {
                if (string.Equals(t.Key, "domain", StringComparison.OrdinalIgnoreCase)
                || string.Equals(t.Key, "Signature")
                || string.Equals(t.Key, "recordline", StringComparison.OrdinalIgnoreCase)
                || string.Equals(t.Key, "subDomain", StringComparison.OrdinalIgnoreCase))
                {
                    return $"{t.Key}={(t.Value ?? "")}";
                }
                else
                {
                    return $"{HttpUtil.UrlEncode(t.Key)}={(t.Value == null ? "" : HttpUtil.UrlEncode(t.Value))}";
                }
            }));
        }


        #endregion
    }
}
