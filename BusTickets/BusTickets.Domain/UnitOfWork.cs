using BusTickets.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using BusTickets.Domain.Entities;
using BusTickets.Domain.Context;

namespace BusTickets.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly AppDbContext _context;
        private Repository<User> _userRepository;
        private Repository<Ticket> _ticketRepository;
        private Repository<SaledTickets> _saledTicketsRepository;
        private Repository<Route> _routeRepository;
        private Repository<Trip> _tripRepository;
        #endregion

        #region Constructor

        public UnitOfWork(AppDbContext context) => _context = context;

        #endregion

        #region implementation

        public Repository<User> UserRepository => _userRepository ?? (_userRepository = new Repository<User>(_context));

        public Repository<Ticket> TicketRepository => _ticketRepository ?? (_ticketRepository = new Repository<Ticket>(_context));

        public Repository<SaledTickets> SaledTicketRepository => _saledTicketsRepository ?? (_saledTicketsRepository = new Repository<SaledTickets>(_context));

        public Repository<Route> RouteRepository => _routeRepository ?? (_routeRepository = new Repository<Route>(_context));

        public Repository<Trip> TripRepository => _tripRepository ?? (_tripRepository = new Repository<Trip>(_context));

        #endregion

    }
}
