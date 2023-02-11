using Microsoft.AspNetCore.Mvc;
using LineBotMessage.Dtos;

namespace LineBot
{
    [Route("api/linebot")]
    [ApiController]
    public class LineMessagingApiController : ControllerBase
    {
        // 宣告變數
        private readonly string channelAccessToken = "Xxx/KcME+ShNgZwUepxJz3i2V04SGi9NpRp5uIRVB1eQiyY9X+qPxj+DeJkROQM3B63LfUBtOUXxK3t/Z/bUuTyqxfMh5KE69zahm0B2oj6GdyYuqYUYjmxnJRFlmoDq8sDR5kWWzEbRICBvmDte/wdB09x89/1O/w1cDnyilFU=";
        [HttpPost]
        public async Task<IActionResult> Post(WebhookRequestBodyDto body)
        {
            Utility.ReplyMessageAsync(body.Events[0].ReplyToken, body.Events[0].Message.Text + " Demo OK", channelAccessToken);
            return Ok(body);
        }
    }
}
