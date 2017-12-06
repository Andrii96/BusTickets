using BusTickets.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusTickets.Domain.Context
{
    public class AppDbContext:IdentityDbContext<User>
    {
        #region Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        #endregion

        #region Properties

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<SaledTickets> SaledTickets { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Trip> Trips { get; set; }

        #endregion
    }
}
