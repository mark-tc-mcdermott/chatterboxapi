using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ChatterboxApi.DAL.Models
{
    public class Chat
    {
        [Key]
        public int ChatId { get; set; }
        public string Name { get; set; }
        public System.DateTime CreationDate { get; set; }
    }
}