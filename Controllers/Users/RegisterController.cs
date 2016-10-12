using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatterboxApi.DTO;
using System.Net.Http;
using Microsoft.AspNetCore.Owin;
using ChatterboxApi.DAL.Models;
using Chatterbox.DAL;
using System.Net;
using Newtonsoft.Json;

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
                var user = new User()
                {
                    Name = payload.name,
                    Email = payload.email,
                    Password = payload.password,
                    CreationDate = System.DateTime.Now
                };
                using (var db = new ChatterboxContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                var registerdto = new UserResponseDTO()
                {
                    id = user.UserId,
                    email= user.Email,
                    name= user.Name
                };
                registerdto.setToken();
                
                return Json(new { success=true, data= registerdto});
            }
            else
            {   
                 return BadRequest();
            }
        }
    }   
}