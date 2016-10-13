using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatterboxApi.DTO;
using System.Net.Http;
using Microsoft.AspNetCore.Owin;
using ChatterboxApi.DAL.Models;
using ChatterboxApi.DAL;
using System.Net;
using Newtonsoft.Json;

namespace ChatterboxAppApi.Controllers
{
    [Route("users/register")]
    public class RegisterController : Controller
    {
        private ChatterboxRepository cbRep;

        public RegisterController()
        {
             this.cbRep = new ChatterboxRepository(new ChatterboxContext());
        }

        [HttpPost]
        public ActionResult Post([FromBody] RegisterDTO payload)
        {
            if (ModelState.IsValid)
            {
                User user = new User(payload);
                this.cbRep.InsertUser(user);
                
                return Json(new { success=true, data= new UserResponseDTO(user)});
            }
            else
            {   
                 return BadRequest();
            }
        }
    }   
}