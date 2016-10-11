using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ChatterboxAppApi.Controllers
{
    [Route("users")]
    public class UsersController : Controller
    {
        [HttpGet("me")]
        public void Get()
        {

        }
        
        [HttpPut("me")]
        public void Put(int id, [FromBody]string value)
        {

        }
    }
}