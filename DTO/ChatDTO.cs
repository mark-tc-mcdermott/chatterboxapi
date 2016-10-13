using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Linq;
using ChatterboxApi.DTO;
using ChatterboxApi.DAL;
using ChatterboxApi.DAL.Models;


namespace ChatterboxApi.DTO
{
    public class QueryDTO
    {
        public string q {get;set;}
        public int page {get;set;}
        public int limit {get;set;}
    }
    public class ChatDTO 
    {
        public ChatDTO() : base() {}
        public ChatDTO(Chat chat_ref, MessageDTO message)
        {
            this.id = chat_ref.ChatId;
            this.user_id = chat_ref.UserId;
            this.name= chat_ref.Name;
            this.created = chat_ref.CreationDate;
            this.user = new UserMessageDTO(new ChatterboxRepository(new ChatterboxContext()).FindUser(chat_ref.UserId));
            this.last_message = message;
        }
        public int id { get; set; }
         public int user_id { get; set; }
         public string name {get; set;}
        public System.DateTime created {get; set;}
        public UserMessageDTO user {get;set;}
        public MessageDTO last_message {get;set;}
    }
}