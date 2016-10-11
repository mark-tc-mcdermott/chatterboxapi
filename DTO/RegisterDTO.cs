using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
}