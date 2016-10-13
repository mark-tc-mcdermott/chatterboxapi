using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatterboxApi.DAL;
using ChatterboxApi.DAL.Models;
using ChatterboxApi.DTO;
using ChatterboxAPI.Provider;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace ChatterboxAppApi.Controllers
{
    [Route("users")]
    public class UsersController : Controller
    {
        private ChatterboxRepository cbRep;

        public UsersController()
        {
             this.cbRep = new ChatterboxRepository(new ChatterboxContext());
        }

        [HttpGet("me")]
        public ActionResult Get()
        {            
            User userObject = AuthProvider.validateToken(Request.Headers["Authorization"]);
            if (userObject != null)
            { 
                return Json(new { success=true, data= new UserResponseDTO(userObject)});
            } 
            else
            {
                return BadRequest();
            }
        }
        
        [HttpPut("me")]
        public ActionResult Put([FromBody]JObject value)
        {
            
            User userObject =  AuthProvider.validateToken(Request.Headers["Authorization"]);
            if (userObject != null)
            {
                if (value.Value<string>("name") != null)
                {
                    userObject.Name = value.Value<string>("name");
                }
                if (value.Value<string>("password") != null && value.Value<string>("password") == value.Value<string>("password") )
                {
                    userObject.Password = value.Value<string>("password");
                }
                else if(value.Value<string>("password") != null)
                {
                    return BadRequest();
                }
                if (value.Value<string>("email") != null) {
                    userObject.Email = value.Value<string>("email");
                }
                this.cbRep.UpdateUser(userObject);
                
                return Json(new { success=true, data=new UserResponseDTO(userObject)});
            } 
            else
            {
                return BadRequest();
            }

        }
    }
}