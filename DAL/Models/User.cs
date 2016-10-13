using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using ChatterboxApi.DTO;

namespace ChatterboxApi.DAL.Models
{
    public class User
    {
        public User() : base() {}
        public User(RegisterDTO payload)
        {
            this.Name = payload.name;
            this.Email = payload.email;
            this.Password = payload.password;
            this.CreationDate = System.DateTime.Now;
        }
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public System.DateTime CreationDate { get; set;}
    }
}