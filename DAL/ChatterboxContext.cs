using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

using ChatterboxApi.DAL.Models;

namespace ChatterboxApi.DAL
{
    public class ChatterboxContext : DbContext 
    { 
        public DbSet<Chat> Chats  { get; set; } 
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Filename=chatterbox.db");
        }
    
    }
}