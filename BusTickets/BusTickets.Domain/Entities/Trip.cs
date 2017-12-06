using System;
using System.Collections.Generic;
using System.Text;

namespace BusTickets.Domain.Entities
{
    public class Trip : IEntity
    {
        public Guid Id { get; set; }
        public Guid RouteId { get; set; }
        public TimeSpan Depature { get; set; }
        public TimeSpan Arrival { get; set; }
        public DateTime Date { get; set; }

        public virtual Route Route { get; set; }
    }
}
