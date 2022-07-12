using KinoIS.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinoIs.Repository.Interface
{
    public interface TicketInOrderRepository
    {
        TicketInOrder Insert(TicketInOrder ticketInOrder);
    }
}
