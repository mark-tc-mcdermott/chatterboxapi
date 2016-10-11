using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatterboxApi.DAL.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string name { get; set; }

        [Required]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }


        public System.DateTime CreationDate { get; set;}
    }
}