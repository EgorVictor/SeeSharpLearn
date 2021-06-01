#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new();

        static async Task Main(string[] args)
        {
            var resRepositories = await ProcessRepositories();
            if (resRepositories != null)
                foreach (var rep in resRepositories)
                {
                    Console.WriteLine(rep.Name);
                    Console.WriteLine(rep.LastPush);
                }
        }

        //为所有请求设置 HTTP 标头：
        //Accept接受 JSON 响应的标头
        //一个User-Agent标题。这些头由 GitHub 服务器代码检查，并且是从 GitHub 检索信息所必需的。
        //调用HttpClient.GetStringAsync(String) 以发出 Web 请求并检索响应。此方法启动发出 Web 请求的任务。当请求返回时，任务读取响应流并从流中提取内容。响应的正文作为String返回，在任务完成时可用。
        //等待响应字符串的任务并将响应打印到控制台
        static async Task<List<Repository>?> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            //var msg= await client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
            //Console.WriteLine(msg);
            //var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(msg);


            var streamTask = await client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            return await JsonSerializer.DeserializeAsync<List<Repository>>(streamTask);
        }
    }
}
