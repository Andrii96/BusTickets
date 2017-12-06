using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTickets.Web.Models
{
    public class TicketViewModel
    {
        public Guid Id { get; set; }
        public int SitNumber { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Price { get; set; }
        public bool IsTicketSaled { get; set; }
    }
}
