using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChatterboxAppApi.Controllers
{
    [Route("chat")]
    public class ChatController : Controller
    {
        [HttpGet]
        public void Get()
        {
        }
        
        [HttpPost]
        public void Post()
        {

        }
    }
}

