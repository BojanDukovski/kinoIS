using KinoIS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinoIS.Service.Interface
{
    public interface TicketInOrderService
    {
        public List<Ticket> ticketsInOrder(Guid orderId);
    }
}
