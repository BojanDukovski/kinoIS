using KinoIs.Repository.Interface;
using KinoIS.Domain.Relations;
using KinoIS.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KinoIs.Repository.Implementation
{
    public class TicketInShoppingCartRepositoryImpl : TicketInShoppingCartRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<TicketInShoppingCart> entities;
        public TicketInShoppingCartRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<TicketInShoppingCart>();
        }

        public List<TicketInShoppingCart> findAll()
        {
            return this.context.ticketInShoppingCarts.ToList();
        }

        public List<TicketInShoppingCart> findAllByShoppingCartId(Guid id)
        {
            return this.context.ticketInShoppingCarts.Where(x => x.ShoppingCartId.Equals(id)).ToList();
        }
    }
}
