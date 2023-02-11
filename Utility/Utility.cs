using System.Net;
using System.Text;

public class Utility
{
    public static IConfiguration GetConfig()
    {
        return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
    }
    public static async Task<string> ReplyMessageAsync(string ReplyToken, string Message, string ChannelAccessToken)
    {
        HttpClient client;
        string text = "\r\n{{\r\n    'replyToken':'{0}',\r\n    'messages':[\r\n        {{\r\n            'type':'text',\r\n            'text':'{1}'\r\n        }}\r\n    ]\r\n}}";

        try
        {
            Message = Message.Replace("\n", "\\n");
            Message = Message.Replace("\r", "\\r");
            Message = Message.Replace("\"", "'");
            if (string.IsNullOrEmpty(Message))
            {
                throw new Exception("要傳送的訊息不得為空白!");
            }

            text = text.Replace("'", "\"");
            var json = string.Format(text, ReplyToken, Message);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + ChannelAccessToken);

                var response = await client.PostAsync("https://api.line.me/v2/bot/message/reply", data);

                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }
        catch (WebException ex)
        {
            using StreamReader streamReader = new StreamReader(ex.Response!.GetResponseStream());
            string text2 = streamReader.ReadToEnd();
            throw new Exception("ReplyMessage API ERROR: " + text2, ex);
        }
    }
}