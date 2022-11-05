using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NovelAIClient.Models;

namespace NovelAIClient
{
    /// <summary>
    /// WebUI客户端
    /// </summary>
    public class WebUIClient : BaseClient
    {
        /// <summary>
        /// 实例化一个WebUI客户端对象
        /// WebUI默认地址为：http://127.0.0.1:7860/
        /// </summary>
        /// <param name="host">服务地址</param>
        public WebUIClient(string host = "http://127.0.0.1:7860/") : base(host)
        {
        }

        /// <summary>
        /// 最简单的方式请求地址并返回图片字节数组，图片尺寸恒定为512*512
        /// </summary>
        /// <param name="prompt">生成提示词(标签)，多个提示词以英文逗号分隔</param>
        /// <returns></returns>
        public Task<byte[]?> PostAsync(string prompt)
        {
            if (prompt == null)
                throw new ArgumentNullException(nameof(prompt));
            return PostAsync(prompt.Replace("，", ",").Split(','));
        }

        /// <summary>
        /// 最简单的方式请求地址并返回图片字节数组，图片尺寸恒定为512*512
        /// </summary>
        /// <param name="prompt">生成提示词(标签)</param>
        /// <returns>图片字节</returns>
        public Task<byte[]?> PostAsync(params string[] prompt)
        {
            if (prompt == null)
                throw new ArgumentNullException(nameof(prompt));
            WebUIRequestModel webuiModel = new WebUIRequestModel();
            webuiModel.Prompt = string.Join(',', prompt);
            return PostAsync(webuiModel);
        }

        /// <summary>
        /// 比较简单的方式请求地址并返回图片字节数组
        /// </summary>
        /// <param name="prompt">生成提示词(标签)，多个提示词以英文逗号分隔</param>
        /// <param name="negativePrompt">屏蔽词(标签)，多个屏蔽词以英文逗号分隔</param>
        /// <param name="width">图片宽</param>
        /// <param name="height">图片高</param>
        /// <returns></returns>
        public Task<byte[]?> PostAsync(string prompt, string? negativePrompt = null, int width = 512, int height = -1)
        {
            if (prompt == null)
                throw new ArgumentNullException(nameof(prompt));
            string[] arrPrompt = prompt.Replace("，", ",").Split(',');
            string[]? arrNegativePrompt = null;
            if (negativePrompt != null)
                arrNegativePrompt = negativePrompt.Replace("，", ",").Split(',');
            return PostAsync(arrPrompt, arrNegativePrompt, width, height);
        }

        /// <summary>
        /// 比较简单的方式请求地址并返回图片字节数组
        /// </summary>
        /// <param name="prompt">生成提示词(标签)</param>
        /// <param name="negativePrompt">屏蔽词(标签)</param>
        /// <param name="width">图片宽</param>
        /// <param name="height">图片高</param>
        /// <returns>图片字节</returns>
        public Task<byte[]?> PostAsync(IEnumerable<string> prompt, IEnumerable<string>? negativePrompt = null, int width = 512, int height = 512)
        {
            if (prompt == null)
                throw new ArgumentNullException(nameof(prompt));
            WebUIRequestModel webuiModel = new WebUIRequestModel();
            webuiModel.Prompt = string.Join(',', prompt);
            if (negativePrompt != null)
                webuiModel.NegativePrompt = string.Join(',', negativePrompt);
            webuiModel.Width = width;
            webuiModel.Height = height;
            return PostAsync(webuiModel);
        }

        /// <summary>
        /// 使用完整自定义参数请求地址并返回图片字节数组
        /// </summary>
        /// <param name="model">请求参数实体</param>
        /// <returns>图片字节</returns>
        public Task<byte[]?> PostAsync(WebUIRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            input input = new input(model.ToArray());
            return PostAsync(input);
        }

        private async Task<byte[]?> PostAsync(input input)
{
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            string json = JsonConvert.SerializeObject(input);
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{_host}api/predict"))
            {
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient() { Timeout = Timeout.InfiniteTimeSpan })
                {
                    var response = await client.SendAsync(request);
                    string result = await response.Content.ReadAsStringAsync();
                    JToken? jToken = JsonConvert.DeserializeObject<JToken>(result);
                    if (jToken != null)
                    {
                        bool isFile = Convert.ToBoolean(jToken["data"]![0]![0]!["is_file"]);
                        if (isFile)
                        {
                            string fileName = jToken["data"]![0]![0]!["name"]!.ToString();
                            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                            {
                                byte[] imageBytes = new byte[fs.Length];
                                await fs.ReadAsync(imageBytes, 0, imageBytes.Length);
                                return imageBytes;
                            }
                        }
                        else  //不知道怎么让它返回非文件, 猜测是base64, 没测试过
                        {
                            return Convert.FromBase64String(jToken["data"]![0]![0]!["data"]!.ToString());
                        }
                    }
                    return null;
                }
            }
        }

        private class input
        {
            public int fn_index { get; } = 13;
            public ArrayList data { get; set; }

            public input(ArrayList data)
            {
                if (data == null)
                    throw new ArgumentNullException(nameof(data));
                this.data = data;
            }
        }
    }
}