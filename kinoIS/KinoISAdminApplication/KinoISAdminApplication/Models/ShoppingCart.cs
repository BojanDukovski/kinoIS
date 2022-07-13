using System;
using System.Collections.Generic;

namespace KinoISAdminApplication.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public string OwnerId { get; set; }
        public double TotalPrice { get; set; }
        public virtual KinoUser Owner { get; set; }
        public ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
    }
}
