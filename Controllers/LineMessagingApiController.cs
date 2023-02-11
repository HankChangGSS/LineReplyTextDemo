using Microsoft.AspNetCore.Mvc;
using LineBotMessage.Dtos;
using Microsoft.Extensions.Configuration;

namespace LineBot
{
    [Route("api/linebot")]
    [ApiController]
    public class LineMessagingApiController : ControllerBase
    {        
        [HttpPost]
        public async Task<IActionResult> Post(WebhookRequestBodyDto body)
        {
            if (body.Events.Count == 0) return Ok();    //try to pass Webhook URL Verify

            IConfiguration configuration = Utility.GetConfig();
            var channelAccessToken = configuration["LineMessagingApi:CommonSetting:ChannelAccessToken"];
            Utility.ReplyMessageAsync(body.Events[0].ReplyToken, body.Events[0].Message.Text + " Demo OK", channelAccessToken);
            return Ok(body);
        }
    }
}
