# TencentCloudDnsSDK
腾讯云DNS SDK，基于.net standard2.1，目前已实现腾讯云DNS解析全部API。

### How to use
1. 安装NuGet包：`TencentCloudDnsSDK`

2. 编写代码
```csharp
static async Task Main(string[] args)
{
    ICnsSdk ddns = new CnsSdk("你的SecretId", "你的SecretKey");
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
```
