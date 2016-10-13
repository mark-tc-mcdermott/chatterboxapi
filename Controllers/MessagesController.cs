using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatterboxApi.DAL;
using ChatterboxApi.DAL.Models;
using ChatterboxApi.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ChatterboxAPI.Provider;

namespace ChatterboxAppApi.Controllers
{
    [Route("chats")]
    public class MessagesController : Controller
    {
        private ChatterboxRepository cbRep;

        public MessagesController()
        {
             this.cbRep = new ChatterboxRepository(new ChatterboxContext());
        }
        [HttpGet("{chatIdToFind}/messages")]
        public ActionResult Get(int chatIdToFind, [FromQuery] QueryDTO query )
        {   
            User userObject = AuthProvider.validateToken(Request.Headers["Authorization"]);
            if (userObject != null)
            {
                List<Message> listOMessages = this.cbRep.FindAllMessagesInChat(chatIdToFind);
                List<MessageDTO> listODTO = new List<MessageDTO>();
                foreach (Message msg in listOMessages)
                {
                    listODTO.Add(new MessageDTO(msg));
                }
                return Json(new { success=true, data= listODTO});
            } 
            else
            {
                return BadRequest();
            }
        }
        
        [HttpPost("{chat_id}/messages")]
        public ActionResult Post( int chat_id, [FromBody] JObject message)
        {
            User userObject = AuthProvider.validateToken(Request.Headers["Authorization"]);
            if (userObject != null)
            {
                Message message_ref = new Message()
                {
                    fromUserId = userObject.UserId, 
                    ChatId =  chat_id,
                    MessageContent = message.Value<string>("message"),
                    CreationDate = System.DateTime.Now
                };
                this.cbRep.InsertMessage(message_ref);

                var message_dto = new MessageDTO(message_ref);
                
                return Json(new { success=true, data= message_dto});
            } 
            else
            {
                return BadRequest();
            }
        }
    }
}