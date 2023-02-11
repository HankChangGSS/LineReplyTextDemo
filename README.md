# LineReplyTextDemo
快速建立 LineBot - 最基本的回應 Text

## 專案建立步驟

### 建立新專案
```bash
dotnet new webapi -f net6.0 -n LineReplyTextDemo
```

### 刪除內建的 WeatherForecast

### 加入基本的 class
- \Controllers\LineMessagingApiController.cs
- \Dto\LineBotMessageDtos.cs
- \Utility\Utility.cs

### 修改主程式
Program.cs (拿掉 swagger 部份的註解)
```cs
/*
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/
app.UseSwagger();
app.UseSwaggerUI();
```

### 發布專案
```bash
dotnet build
dotnet publish -c Release -o ./bin/Publish
```

### 本機 debug 路徑
https://localhost:7059/swagger/index.html