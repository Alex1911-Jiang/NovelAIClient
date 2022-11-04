# NovelAIClient

## 这是一个帮助.Net用户调用**私服**NovelAI的库，支持WebUI和Naifu前端

### 如何使用
#### 对于WebUI
```C#
            WebUIClient webUIClient = new WebUIClient("http://127.0.0.1:7860/");  //服务地址和端口
            byte[]? imageBytes = await webUIClient.PostAsync("Tags");  //关键词标签，多个关键词用逗号分隔，还有屏蔽词和图片尺寸的重载
            Bitmap bmp = new Bitmap(new MemoryStream(imageBytes));
```

#### 对于Naifu
```C#
            NaifuClient naifuClient = new NaifuClient("http://127.0.0.1:6969/");
            byte[] imageBytes = await naifuClient.PostAsync("Tags");  //关键词标签，多个关键词用逗号分隔，还有屏蔽词、图片尺寸和种子的重载
            Image bmp = Image.FromStream(new MemoryStream(imageBytes));
```

特别的，Naifu还存在一个简易客户端，除关键词外会使用网站上的默认参数进行生成，只要填入关键词就能生成不错的效果
```C#
            EasyNaifuClient easyNaifuClient = new EasyNaifuClient("http://127.0.0.1:6969/");
            byte[] imageBytes = await easyNaifuClient.PostAsync("Tags");  //关键词标签，多个关键词用逗号分隔
            Image bmp = Image.FromStream(new MemoryStream(imageBytes));
```


###如何安装
使用[NuGet包](https://www.nuget.org/packages/NovelAIClient/)安装
```powershell
  Install-Package NovelAIClient
```
