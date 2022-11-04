using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NovelAIClient.Models;

namespace NovelAIClient
{
    public class NaifuClient : AbstractNaifuClient
    {
        /// <summary>
        /// 实例化一个Naifu客户端对象
        /// Naifu默认地址为：http://127.0.0.1:6969/
        /// </summary>
        /// <param name="host">服务地址</param>
        public NaifuClient(string host = "http://127.0.0.1:6969/") : base(host)
        {
        }

        /// <summary>
        /// 最简单的方式请求地址并返回图片字节数组，图片尺寸恒定为512*512，不会添加默认标签
        /// </summary>
        /// <param name="prompt">标签</param>
        /// <returns></returns>
        public Task<byte[]> PostAsync(params string[] prompt)
        {
            return PostAsync(prompt, null);
        }

        /// <summary>
        /// 比较简单的方式请求地址并返回图片字节数组，不会添加默认标签
        /// </summary>
        /// <param name="prompt">标签</param>
        /// <param name="uc">屏蔽标签</param>
        /// <param name="width">图片宽</param>
        /// <param name="height">图片高</param>
        /// <param name="seed">种子，null为自动生成</param>
        /// <returns></returns>
        public Task<byte[]> PostAsync(IEnumerable<string> prompt, IEnumerable<string>? uc = null, int width = 512, int height = 512, int? seed = null)
        {
            if (seed == null)
            {
                Random rdm = new Random(Guid.NewGuid().GetHashCode());
                seed = rdm.Next(0, int.MaxValue);
            }
            string struc = "";
            if (uc != null)
                struc = string.Join(", ", uc);
            GenerationRequest data = new GenerationRequest
            {
                prompt = $"{string.Join(", ", prompt)}",
                width = width,
                height = height,
                seed = seed,
                uc = struc
            };
            return PostAsync(data);
        }
    }
}
