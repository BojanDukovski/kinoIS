using KinoIs.Repository.Interface;
using KinoIS.Domain.Models;
using KinoIS.Repository;
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
            Guid guidId = Guid.Parse(id);
            return this.context.users.Where(x => x.Id.Equals(guidId)).FirstOrDefault(); 
        }
    }
}
