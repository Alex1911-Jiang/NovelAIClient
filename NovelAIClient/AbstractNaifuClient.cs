using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NovelAIClient.Models;

namespace NovelAIClient
{
    public abstract class AbstractNaifuClient : BaseClient
    {
        public AbstractNaifuClient(string host) : base(host)
        {
        }

        /// <summary>
        /// 使用完整自定义参数进行请求
        /// </summary>
        /// <param name="data">请求参数实体</param>
        /// <returns></returns>
        public async Task<byte[]> PostAsync(GenerationRequest data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            string json = JsonConvert.SerializeObject(data);
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_host}generate-stream");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient() { Timeout = Timeout.InfiniteTimeSpan })
            {
                var response = await client.SendAsync(request);
                var str = await response.Content.ReadAsStringAsync();
                str = str.Substring(str.IndexOf("data:") + "data:".Length);
                return Convert.FromBase64String(str);
            }
        }
    }
}
