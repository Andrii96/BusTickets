using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BusTickets.Domain.Abstract;
using BusTickets.Web.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BusTickets.Web.Controllers
{
    
    public class TicketsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Tickets(Guid? id)
        {
            ViewBag.TripId = id;
            var tickets = _unitOfWork.TicketRepository.GetWithInclude(t => t.TripId == id, r => r.Include(s => s.Trip).
                                                                                                 ThenInclude(s => s.Route).
                                                                                                 Include(s => s.SaledTicket));
            List<TicketViewModel> mappedTickets = new List<TicketViewModel>();
            foreach (var ticket in tickets)
            {
                mappedTickets.Add(new TicketViewModel
                {
                    Id = ticket.Id,
                    From = ticket.Trip.Route.From,
                    To = ticket.Trip.Route.To,
                    Price = ticket.Price,
                    SitNumber = ticket.SitNumber,
                    IsTicketSaled = ticket.SaledTicket != null
                });
            };
            return View(mappedTickets);
        }

        public IActionResult SaleSelectedTicket(Guid ticketId,Guid tripId)
        {
            _unitOfWork.SaledTicketRepository.Create(new Domain.Entities.SaledTickets
            {
                SaledDate = DateTime.Now,
                UserId = this.HttpContext.User.FindFirstValue("sub"),
                TicketId = ticketId
            });
            return RedirectToAction("Tickets", new { id = tripId });
        }
    }
}