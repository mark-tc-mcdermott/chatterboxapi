using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ChatterboxApi.DAL.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public virtual User toUserId { get; set; }
        public virtual User fromUserId { get; set; }
        public virtual Chat chatId { get; set; }
        public string messageContent { get; set; }
        public System.DateTime CreationDate { get; set; }
    }
}