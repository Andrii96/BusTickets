using BusTickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusTickets.Domain.Abstract
{
    public interface IUnitOfWork
    {
        Repository<User> UserRepository { get; }
        Repository<Ticket> TicketRepository { get; }
        Repository<SaledTickets> SaledTicketRepository { get; }
        Repository<Route> RouteRepository { get; }
        Repository<Trip> TripRepository { get; }
    }
}
