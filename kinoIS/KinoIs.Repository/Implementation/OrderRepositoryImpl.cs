using KinoIs.Repository.Interface;
using KinoIS.Domain.Models;
using KinoIS.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KinoIs.Repository.Implementation
{
    public class OrderRepositoryImpl : OrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> getAllOrders()
        {
            return entities
                .Include(z => z.User)
                .Include(z => z.TicketInOrders)
                .Include("TicketInOrders.Ticket")
                .ToListAsync().Result;
        }

        public Order getOrderDetails(Guid id)
        {
            return entities
               .Include(z => z.User)
               .Include(z => z.TicketInOrders)
               .Include("TicketInOrders.Ticket")
               .SingleOrDefaultAsync(z => z.Id == id).Result;
        }

        public Order Insert(Order order)
        {
            this.context.orders.Add(order);
            this.context.SaveChanges();
            return order;
        }
    }
}
