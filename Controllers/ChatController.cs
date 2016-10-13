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
    [Route("chats")]
    public class ChatController : Controller
    {
        private ChatterboxRepository cbRep;

        public ChatController()
        {
             this.cbRep = new ChatterboxRepository(new ChatterboxContext());
        }
        [HttpGet]
        public ActionResult Get([FromQuery] QueryDTO query)
        {

            string authorization = Request.Headers["Authorization"];
            
            User userObject = AuthProvider.validateToken(authorization);
            if (userObject != null)
            {
                List<Chat> listOChats =  this.cbRep.FindChatsByName(query.q);
                List<ChatDTO> dtoList = new List<ChatDTO>();
                foreach (Chat chat_ref in listOChats)
                {
                    var last_message = this.cbRep.FindLastChatMessage(chat_ref.ChatId);

                    MessageDTO message_dto = null;
                    if (last_message != null)
                    {
                        message_dto = new MessageDTO(last_message);
                    }
                    dtoList.Add(new ChatDTO(chat_ref, message_dto));
                }
                
                return Json(new { success=true, data= dtoList});
            } 
            else
            {
                return BadRequest();
            }
            
        }
        
        [HttpPost]
        public ActionResult Post([FromBody] JObject name)
        {   
            User userObject = AuthProvider.validateToken(Request.Headers["Authorization"]);
            if (userObject != null)
            {
                Chat chat_ref = new Chat()
                {
                    Name = name.Value<string>("name"),
                    UserId = userObject.UserId,
                    CreationDate = System.DateTime.Now
                };

                this.cbRep.InsertChat(chat_ref);
 
                return Json(new { success=true, data= new ChatDTO(chat_ref, null)});
            } 
            else
            {
                return BadRequest();
            }
        }
    }
}

