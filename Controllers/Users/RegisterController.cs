using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatterboxApi.DTO;
using System.Net.Http;

namespace ChatterboxAppApi.Controllers
{
    [Route("users/register")]
    public class RegisterController : Controller
    {
        [HttpPost]
        public ActionResult Post([FromBody] RegisterDTO payload)
        {
            if (ModelState.IsValid)
            {
                 return Ok();
            }
            else
            {   
                 return BadRequest();
            }
        }
    }
}