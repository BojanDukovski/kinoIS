using System;
using System.Collections.Generic;

namespace KinoISAdminApplication.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public KinoUser User { get; set; }

        public ICollection<TicketInOrder> TicketInOrders { get; set; }
    }
}
