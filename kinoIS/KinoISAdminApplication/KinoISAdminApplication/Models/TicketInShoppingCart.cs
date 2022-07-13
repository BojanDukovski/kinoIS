using System;

namespace KinoISAdminApplication.Models
{
    public class TicketInShoppingCart
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public Ticket CurrentTicket { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart UserCart { get; set; }
    }
}
