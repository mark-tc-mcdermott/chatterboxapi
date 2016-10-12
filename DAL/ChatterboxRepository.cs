using Chatterbox.DAL;
using ChatterboxApi.DAL.Models;
using System;
using System.Linq;

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
            return cbContext.Users.FirstOrDefault( r => r.Email == userEmail );
        }

        public bool PasswordMatches(string userEmail, string password)
        {
            return this.GetUserByEmail(userEmail).Password == password;
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