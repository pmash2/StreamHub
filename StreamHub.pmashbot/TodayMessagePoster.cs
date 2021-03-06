﻿using Newtonsoft.Json;
using StreamHub.Core;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StreamHub.pmashbot
{
    public static class TodayMessagePoster
    {
        public static async Task PostMessage(string endpoint, string msg)
        {
            var postMsg = new PostTodayMsg()
            {
                Message = msg
            };

            var json = JsonConvert.SerializeObject(postMsg);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            try
            {
                await client.PostAsync(endpoint + MagicStrings.TodayHub, data);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error posting message: {ex.Message}");
            }
        }
    }
    public class PostTodayMsg
    {
        public string Message { get; set; }
    }
}
