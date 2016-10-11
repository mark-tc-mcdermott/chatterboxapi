using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatterboxApi.DTO;
using System.Net.Http;

namespace ChatterboxAppApi.Controllers
{
    [Route("users/login")]
    public class LoginController : Controller
    {
        [HttpPost]
        public ActionResult Post([FromBody] LoginDTO payload)
        {
          if (ModelState.IsValid)
          {
              return Ok();
          }
          else
          {
              return  BadRequest();
          }
        }
    }
}