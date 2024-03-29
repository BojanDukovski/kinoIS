﻿using System;
using System.Collections.Generic;

namespace KinoISAdminApplication.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Movie { get; set; }
        public int Quantity { get; set; }
        public string Genre { get; set; }
        public DateTime date { get; set; }
        public int Price { get; set; }
        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
    }
}