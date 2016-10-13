using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Linq;
using ChatterboxApi.DAL.Models;


namespace ChatterboxApi.DTO
{
    public class RegisterDTO 
    {
        [Required]
        public string name { get; set; }
        [DataType(DataType.Password)]
        public string confirm { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }

    public class UserResponseDTO
    {
        public UserResponseDTO() : base() {}
        public UserResponseDTO(User user_ref)
        {
            this.id = user_ref.UserId;
            this.email= user_ref.Email;
            this.name= user_ref.Name;
            this.token = setToken(user_ref.UserId,user_ref.Email);
        }
        public int id { get; set;}

        public string email {get;set;}
        public string name {get;set;}

        public string token { get; set; }

        public string setToken(int id, string email)
        {
            byte[] toBytes = System.Text.Encoding.ASCII.GetBytes(JsonConvert.SerializeObject( new { user_id=id, user_email=email}));
            string s = Convert.ToBase64String(toBytes); 
        
            s = s.Split('=')[0]; 
            s = s.Replace('+', '-'); 
            s = s.Replace('/', '_'); 
            return s;
        }
    }
}