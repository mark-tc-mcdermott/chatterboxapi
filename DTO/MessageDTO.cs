using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Linq;
using ChatterboxApi.DAL.Models;
using ChatterboxApi.DAL;
using ChatterboxApi.DTO;



namespace ChatterboxApi.DTO
{
    public class MessageDTO 
    {
        public MessageDTO(): base() {}
        public MessageDTO(Message msg)
        {
            this.id= msg.MessageId;
            this.user_id= msg.fromUserId;
            this.chat_id= msg.ChatId;
            this.message= msg.MessageContent;
            this.created= msg.CreationDate;
            this.user= buildUserMessageDTO(msg.fromUserId);
        }

        public int id { get; set; }
         public int user_id { get; set; }
         public int chat_id { get; set; }
         public string message {get; set;}
        public System.DateTime created {get; set;}
        public UserMessageDTO user { get; set;}
        public  UserMessageDTO buildUserMessageDTO(int user_id)
        {
            using (var db = new ChatterboxContext())
            {
                User user = new ChatterboxRepository(db).FindUser(user_id);
                return new UserMessageDTO(user);
            }
        }
    }

    public class UserMessageDTO 
    {
        public UserMessageDTO(User user)
        {
            this.id = user.UserId;
            this.name = user.Name;
        }
        public int id {get;set;}
        public string name {get;set;}
    }
}