using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTickets.Web.Models
{
    public class TripViewModel
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public TimeSpan Depature { get; set; }
        public TimeSpan Arrival { get; set; }
        public DateTime Date { get; set; }
        public bool HasTickets { get; set; }
    }
}
