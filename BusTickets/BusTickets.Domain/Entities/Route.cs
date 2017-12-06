using System;
using System.Collections.Generic;
using System.Text;

namespace BusTickets.Domain.Entities
{
    public class Route : IEntity
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
