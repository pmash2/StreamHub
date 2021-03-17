using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamHub.API.Controllers
{
    public class ChatMessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
