using KinoIs.Repository.Interface;
using KinoIS.Domain.Models;
using KinoIS.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KinoIs.Repository.Implementation
{
    public class KinoUserRepositoryImpl : KinoUserRepository
        
    {
        private readonly ApplicationDbContext context;
        public KinoUserRepositoryImpl (ApplicationDbContext context)
        {
            this.context = context;
        }

        public KinoUser findById(string id)
        {
            return this.context.users.Where(x => x.Id == id).FirstOrDefault();
        }

        public KinoUser Update(KinoUser user)
        {
            this.context.users.Update(user);
            this.context.SaveChanges();
            return user;
        }
        public KinoUser findByEmail(string email)
        {
            return this.context.users.Where(x => x.Email.Equals(email)).FirstOrDefault();
        }

        public void Save(KinoUser user)
        {
            this.context.users.Add(user);
            this.context.SaveChanges();
        }
    }
}
