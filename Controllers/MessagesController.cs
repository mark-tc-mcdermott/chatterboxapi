using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNet.Authorization;
namespace ChatterboxAppApi.Controllers
{
    [Authorize]
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