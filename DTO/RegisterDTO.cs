using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Linq;


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
        public int id { get; set;}

        public string email {get;set;}
        public string name {get;set;}

        public string token { get; set; }

        public void setToken()
        {
            byte[] toBytes = System.Text.Encoding.ASCII.GetBytes(JsonConvert.SerializeObject( new { user_id=this.id, user_email=this.email}));
            string s = Convert.ToBase64String(toBytes); // Standard base64 encoder
        
            s = s.Split('=')[0]; // Remove any trailing '='s
            s = s.Replace('+', '-'); // 62nd char of encoding
            s = s.Replace('/', '_'); // 63rd char of encoding
            this.token = s;
        }
    }
}