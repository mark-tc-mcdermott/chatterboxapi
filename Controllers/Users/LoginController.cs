using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatterboxApi.DTO;
using ChatterboxApi.DAL.Models;
using ChatterboxApi.DAL;
using System.Net.Http;

namespace ChatterboxAppApi.Controllers
{
    [Route("users/login")]
    public class LoginController : Controller
    {
        private ChatterboxRepository cbRep;

        public LoginController()
        {
            this.cbRep = new ChatterboxRepository(new ChatterboxContext());
        }

        [HttpPost]
        public ActionResult Post([FromBody] LoginDTO payload)
        {
            if (ModelState.IsValid && this.cbRep.PasswordMatches(payload.email, payload.password) )
            {  
                User user = this.cbRep.GetUserByEmail(payload.email);
                
                return Json(new { success=true, data= new UserResponseDTO(user)});
            }
            else
            {
                return  BadRequest();
            }
        }
    }
}