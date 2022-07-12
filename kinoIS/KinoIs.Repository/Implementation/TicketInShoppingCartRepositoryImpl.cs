﻿using KinoIs.Repository.Interface;
using KinoIS.Domain.Models;
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

        public TicketInShoppingCart add(Guid shoppingCartId, Guid ticketId)
        {
            TicketInShoppingCart ticketInShoppingCart = new TicketInShoppingCart(shoppingCartId, ticketId);
            context.ticketInShoppingCarts.Add(ticketInShoppingCart);
            context.SaveChanges();
            return ticketInShoppingCart;
        }

        public List<TicketInShoppingCart> findAll()
        {
            return this.context.ticketInShoppingCarts.ToList();
        }

        public List<TicketInShoppingCart> findAllByShoppingCartId(Guid id)
        {
            return this.context.ticketInShoppingCarts.Where(x => x.ShoppingCartId.Equals(id)).ToList();
        }

        public List<Ticket> findAllTicketsByShoppingCartId(Guid id)
        {
            //{409c758c-3c5f-4047-20ae-08da63649e9b}
            //409c758c-3c5f-4047-20ae-08da63649e9b
            List<TicketInShoppingCart> ticketInShoppingCarts = context.ticketInShoppingCarts.Where(x => x.ShoppingCartId.Equals(id)).ToList();
            List<Ticket> tickets = new List<Ticket>();
            foreach (var item in ticketInShoppingCarts)
            {
                Ticket t = this.context.tickets.Where(x => x.Id == item.TicketId).FirstOrDefault();
                tickets.Add(t);
            }
            return tickets;
        }
    }
}
