using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NovelAIClient.Models;

namespace NovelAIClient
{
    public class EasyNaifuClient : AbstractNaifuClient
    {
        /// <summary>
        /// 实例化一个简单的Naifu客户端对象
        /// Naifu默认地址为：http://127.0.0.1:6969/
        /// </summary>
        /// <param name="host">服务地址</param>
        public EasyNaifuClient(string host = "http://127.0.0.1:6969/") : base(host)
        {
        }

        /// <summary>
        /// 使用网站上原始参数进行请求
        /// 默认添加 masterpiece 和 best quality 标签
        /// </summary>
        /// <param name="prompt">标签</param>
        /// <param name="width">图片宽</param>
        /// <param name="height">图片高</param>
        /// <returns></returns>
        public Task<byte[]> PostAsync(IEnumerable<string> prompt, int width = 512, int height = 768)
        {
            Random rdm = new Random(Guid.NewGuid().GetHashCode());
            GenerationRequest data = new GenerationRequest
            {
                prompt = $"masterpiece, best quality, {string.Join(", ", prompt)}",
                width = width,
                height = height,
                scale = 12,
                sampler = Sampling.k_euler_ancestral,
                steps = 28,
                seed = rdm.Next(0, int.MaxValue),
                n_samples = 1,
                uc = "lowres, bad anatomy, bad hands, text, error, missing fingers, extra digit, fewer digits, cropped, worst quality, low quality, normal quality, jpeg artifacts, signature, watermark, username, blurry"
            };
            return PostAsync(data);
        }
    }
}
