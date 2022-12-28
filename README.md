# NovelAIClient

## 这是一个帮助.Net用户调用**私服**NovelAI的库，支持WebUI和Naifu前端

先决条件：您需要有一个可用的**私服**NovelAI实例（WebUI或Naifu前端至少一个能打开，并能成功在浏览器生成图片）

### 如何使用
#### 对于初版WebUI
```C#
            int fn_index = 13;
            WebUIClient webUIClient = new WebUIClient(fn_index, "http://127.0.0.1:7860/");  //WebUI服务地址
            byte[]? imageBytes = await webUIClient.PostAsync("生成提示词");  //还有含屏蔽词和图片尺寸以及所有参数实体的重载
            if (imageBytes is not null)
                Image bmp = new Bitmap(new MemoryStream(imageBytes));
```

#### 对于后续任意魔改版WebUI
```C#
            int fn_index = 104;
            CustomWebUIClient webUIClient = new CustomWebUIClient(fn_index, "http://127.0.0.1:7860/");  //WebUI服务地址
            byte[]? imageBytes = await webUIClient.PostAsync("自定义参数字符串","生成提示词","屏蔽词");
            if (imageBytes is not null)
                Image bmp = new Bitmap(new MemoryStream(imageBytes));
```

#### 对于Naifu
```C#
            NaifuClient naifuClient = new NaifuClient("http://127.0.0.1:6969/", true);  //Naifu服务地址和是否填充Naifu网页默认参数
            byte[]? imageBytes = await naifuClient.PostAsync("生成提示词");  //还有含屏蔽词和图片尺寸以及所有参数实体的重载
            if (imageBytes is not null)
                Image bmp = Image.FromStream(new MemoryStream(imageBytes));
```

#### 关于 WebUI 的 fn_index 和自定义参数获取办法
打开浏览器开发者工具并发起一个请求，随后在（Edge:网络-负载）/（Chrome:网络-请求）中复制
![fn_indexAndData](https://user-images.githubusercontent.com/50268952/209811793-778448f5-9cef-4f47-ac0c-ce57161080de.jpg)


### 如何安装
使用[NuGet包](https://www.nuget.org/packages/NovelAIClient/)安装
```powershell
  Install-Package NovelAIClient
```

暂时只有接入了根据关键词生成图片的API，如果有其他人用这个的话会考虑加上接入以图片生成图片和根据图片反推标签的API
