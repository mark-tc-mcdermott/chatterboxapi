using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 


namespace ChatterboxApi.DAL.Models
{
    public class Message
    {
        [Key]  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        public int  fromUserId { get; set; }
        public int  ChatId { get; set; }
        public string MessageContent { get; set; }
        public System.DateTime CreationDate { get; set; }
    }
}