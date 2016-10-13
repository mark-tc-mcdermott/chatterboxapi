using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 


namespace ChatterboxApi.DAL.Models
{
    public class Chat
    {
        [Key]  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChatId { get; set; }
        public string Name { get; set; }
        public int UserId {get; set;}
        public System.DateTime CreationDate { get; set; }
    }
}