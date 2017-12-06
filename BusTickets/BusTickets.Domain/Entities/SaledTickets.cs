using System;
using System.Collections.Generic;
using System.Text;

namespace BusTickets.Domain.Entities
{
    public class SaledTickets
    {
        public Guid Id { get; set; }
        public Guid TicketId { get; set; }
        public string UserId { get; set; }
        public DateTime SaledDate { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual User User { get; set; }
    }
}
