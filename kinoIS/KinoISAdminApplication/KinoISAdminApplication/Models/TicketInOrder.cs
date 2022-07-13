using System;

namespace KinoISAdminApplication.Models
{
    public class TicketInOrder
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid ProductId { get; set; }
        public Ticket Ticket { get; set; }
        public int Quantity { get; set; }
    }
}