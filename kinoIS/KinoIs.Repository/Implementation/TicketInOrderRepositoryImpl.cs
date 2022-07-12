using KinoIs.Repository.Interface;
using KinoIS.Domain.Relations;
using KinoIS.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinoIs.Repository.Implementation
{
    public class TicketInOrderRepositoryImpl : TicketInOrderRepository
    {
        private readonly ApplicationDbContext context;
        public TicketInOrderRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context; 
        }
        public TicketInOrder Insert(TicketInOrder ticketInOrder)
        {
            this.context.TicketInOrders.Add(ticketInOrder);
            return ticketInOrder;
        }
    }
}
