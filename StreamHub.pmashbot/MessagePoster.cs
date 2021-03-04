using Newtonsoft.Json;
using StreamHub.Core;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Models;

namespace StreamHub.pmashbot
{
    public class MessagePoster
    {
        public static async Task PostMessage(string endpoint, ChatMessage msg)
        {
            var postMsg = new PostMsg()
            {
                User = msg.DisplayName,
                Message = msg.Message
            };

            var json = JsonConvert.SerializeObject(postMsg);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            try
            {
                await client.PostAsync(endpoint + MagicStrings.MessageHub, data);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error posting message: {ex.Message}");
            }
        }
    }
    public class PostMsg
    {
        public string User { get; set; }
        public string Message { get; set; }
    }
}
