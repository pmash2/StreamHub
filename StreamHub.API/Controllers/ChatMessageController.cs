using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamHub.API.Hubs;
using StreamHub.Core.Models;
using StreamHub.Core;

namespace StreamHub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatMessageController : ControllerBase
    {
        private readonly ILogger<ChatMessageController> _logger;

        public ChatMessageController(ILogger<ChatMessageController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async void SaveMessage([FromBody] ChatMessage msg)
        {
            var builder = new HubConnectionBuilder();
            Uri site = new Uri(MagicStrings.HubEndpointUrl + MagicStrings.MessageHub);
            var conn = builder.WithUrl(site).Build();
            await conn.StartAsync();
            await conn.SendAsync("SendMessage", msg.User, msg.Message);
            await conn.StopAsync();
        }
    }
}
