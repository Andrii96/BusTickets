using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusTickets.Domain.Abstract;
using BusTickets.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusTickets.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace BusTickets.Web.Controllers
{
    public class TripsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TripsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Trips(Guid? routeId)
        {
            List<TripViewModel> trips = new List<TripViewModel>();
            var list = _unitOfWork.TripRepository.GetWithInclude(t => t.RouteId == routeId, r => r.Include(s => s.Route));
            foreach (var trip in list)
            {
                trips.Add(new TripViewModel
                {
                    Id = trip.Id,
                    Depature = trip.Depature,
                    Arrival = trip.Arrival,
                    From = trip.Route.From,
                    To = trip.Route.To,
                    Date = trip.Date,
                    HasTickets = _unitOfWork.TicketRepository.Get(t => t.TripId == trip.Id).Any()
                });
            }

            return View(trips);
        }

        public IActionResult Create()
        {
            var routes = _unitOfWork.RouteRepository.Get();
            List<RouteViewModel> mappedRoutes = new List<RouteViewModel>();
            foreach (var route in routes)
            {
                mappedRoutes.Add(new RouteViewModel
                {
                    Id = route.Id,
                    Name = route.From + " - " + route.To
                });
            }
            ViewBag.Routes = new SelectList(mappedRoutes, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Trip trip)
        {
            _unitOfWork.TripRepository.Create(trip);
            return RedirectToAction("Route","Routes");
        }
    }
}