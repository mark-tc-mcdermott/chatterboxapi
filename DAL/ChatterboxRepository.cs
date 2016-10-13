using ChatterboxApi.DAL;
using ChatterboxApi.DAL.Models;
using System;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace ChatterboxApi.DAL
{
    public class ChatterboxRepository :  IDisposable
    {
        private ChatterboxContext cbContext;

        public ChatterboxRepository(ChatterboxContext context)
        {
            this.cbContext = context;
        }

        public User GetUserByEmail(string userEmail)
        {
            return this.cbContext.Users.FirstOrDefault( r => r.Email == userEmail );
        }

        public bool PasswordMatches(string userEmail, string password)
        {
            return this.GetUserByEmail(userEmail).Password == password;
        }
        public void UpdateUser(User userObject)
        {
            this.cbContext.Entry(userObject).State = EntityState.Modified;
            this.cbContext.SaveChanges();
        }

        public User FindUser(int id)
        {
            return this.cbContext.Users.FirstOrDefault( r => r.UserId == id );
        }
        public List<Chat> FindChatsByName(string name)
        {
            return this.cbContext.Chats.Where(p => p.Name.Contains(name)).ToList();
        }

        public List<Message> FindAllMessagesInChat(int chatnumber)
        {
            return this.cbContext.Messages.Where(p => p.ChatId == chatnumber).ToList();
        }

        public void InsertChat(Chat items)
        {
            this.cbContext.Chats.Add(items);
            this.cbContext.SaveChanges();
        }
        public void InsertUser(User items)
        {
            this.cbContext.Users.Add(items);
            this.cbContext.SaveChanges();
        }
        public void InsertMessage(Message items)
        {
            this.cbContext.Messages.Add(items);
            this.cbContext.SaveChanges();
        }

        public Message FindLastChatMessage(int chatnumber)
        {
            return this.cbContext.Messages.Where(p => p.ChatId ==  chatnumber).OrderByDescending(p => p.CreationDate).FirstOrDefault();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    cbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}