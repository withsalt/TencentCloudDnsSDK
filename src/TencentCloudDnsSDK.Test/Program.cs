using System;
using System.Threading.Tasks;
using TencentCloudDnsSDK.Model.Request;
using TencentCloudDnsSDK.Model.Response;

namespace TencentCloudDnsSDK.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ICnsSdk ddns = new CnsSdk("你的SecretId", "你的SecretKey");
            //域名添加测试
            //DomainCreateRequestParam domainCreateRequestParam = new DomainCreateRequestParam()
            //{
            //    domain = "你的域名.net"
            //};
            //DomainCreateResult result = await ddns.DomainCreate(domainCreateRequestParam);
            //if (result.Code != "0")
            //{
            //    Console.WriteLine($"请求失败，错误代码：{result.Code}，错误描述：{result.Message}");
            //}
            //else
            //{
            //    Console.WriteLine($"请求成功。添加解析的域名：{result.Data.Domain.Domain}");
            //}

            //设置域名解析状态
            //SetDomainStatusResult result = await ddns.SetDomainStatus(new SetDomainStatusRequestParam()
            //{
            //    domain = "你的域名.net",
            //    status = "disable"
            //});
            //if (result.Code != "0")
            //{
            //    Console.WriteLine($"请求失败，错误代码：{result.Code}，错误描述：{result.Message}");
            //}
            //else
            //{
            //    Console.WriteLine($"请求成功。");
            //}

            //删除解析
            //DomainDeleteResult result = await ddns.DomainDelete(new DomainDeleteRequestParam()
            //{
            //    domain = "你的域名.net",
            //});
            //if (result.Code != "0")
            //{
            //    Console.WriteLine($"请求失败，错误代码：{result.Code}，错误描述：{result.Message}");
            //}
            //else
            //{
            //    Console.WriteLine($"请求成功。");
            //}

            //全部域名列表
            //DomainListResult result = await ddns.DomainList(new DomainListRequestParam());
            //if (result.Code != "0")
            //{
            //    Console.WriteLine($"请求失败，错误代码：{result.Code}，错误描述：{result.Message}");
            //}
            //else
            //{
            //    Console.WriteLine($"请求成功。当前共有{result.Data.Info.domain_total}条记录。");
            //}

            //创建解析记录
            //RecordCreateResult result = await ddns.RecordCreate(new RecordCreateRequestParam()
            //{
            //    domain = "你的域名.net",
            //    subDomain = "1112",
            //    recordType = Enum.RecordType.A,
            //    value = "1.0.0.0"
            //});
            //if (result.Code != "0")
            //{
            //    Console.WriteLine($"请求失败，错误代码：{result.Code}，错误描述：{result.Message}");
            //}
            //else
            //{
            //    Console.WriteLine($"请求成功。记录名称：{result.Data.Record.Name}。");
            //}


            //解析记录状态修改
            //565216111
            //RecordStatusResult result = await ddns.RecordStatus(new RecordStatusRequestParam()
            //{
            //    domain = "你的域名.net",
            //    recordId = 565216111,
            //    status = "disable"
            //});
            //if (result.Code != "0")
            //{
            //    Console.WriteLine($"请求失败，错误代码：{result.Code}，错误描述：{result.Message}");
            //}
            //else
            //{
            //    Console.WriteLine($"请求成功。状态：{result.CodeDesc}。");
            //}


            //解析记录删除
            //565216111
            //RecordDeleteResult result = await ddns.RecordDelete(new RecordDeleteRequestParam()
            //{
            //    domain = "你的域名.net",
            //    recordId = 565216111
            //});
            //if (result.Code != "0")
            //{
            //    Console.WriteLine($"请求失败，错误代码：{result.Code}，错误描述：{result.Message}");
            //}
            //else
            //{
            //    Console.WriteLine($"请求成功，该记录已经删除。");
            //}

            //解析记录修改
            //565241026
            //RecordModifyResult result = await ddns.RecordModify(new RecordModifyRequestParam()
            //{
            //    domain = "你的域名.net",
            //    recordId = 565824016,
            //    subDomain = "66677",
            //    recordType = Enum.RecordType.CNAME,
            //    value = "cname.dnspod.com"
            //});
            //if (result.Code != "0")
            //{
            //    Console.WriteLine($"请求失败，错误代码：{result.Code}，错误描述：{result.Message}");
            //}
            //else
            //{
            //    Console.WriteLine($"请求成功，已修改。");
            //}

            //获取域名解析记录列表
            RecordListResult resultList = await ddns.RecordList(new RecordListRequestParam()
            {
                domain = "你的域名.net",
            });
            if (resultList.Code != "0")
            {
                Console.WriteLine($"请求失败，错误代码：{resultList.Code}，错误描述：{resultList.Message}");
            }
            else
            {
                Console.WriteLine($"请求成功。记录条数：{resultList.Data.Info.record_total}。");
                foreach (var itrm in resultList.Data.Records)
                {
                    Console.WriteLine($"记录ID：{itrm.id}\t记录类型：{itrm.type}\t记录域名：{itrm.name}.{resultList.Data.Domain.name}");
                }
            }

            Console.ReadKey(false);
        }
    }
}
