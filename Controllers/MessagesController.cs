using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ChatterboxAppApi.Controllers
{
    [Route("chats")]
    public class MessagesController : Controller
    {
        [HttpGet("{id}/messages")]
        public void Get()
        {
        }
        
        [HttpPost("{id}/messages")]
        public void Post()
        {

        }
    }
}