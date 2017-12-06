using System;
using System.Collections.Generic;
using System.Text;

namespace BusTickets.Domain.Entities
{
    public class Ticket : IEntity
    {
        public Guid Id { get; set; }
        public Guid TripId { get; set; }
        public int SitNumber { get; set; }
        public double Price { get; set; }

        public virtual Trip Trip { get; set; }
        public virtual SaledTickets SaledTicket {get;set;}
    }
}
