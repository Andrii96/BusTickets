using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusTickets.Domain.Context;
using BusTickets.Domain.Entities;
using BusTickets.Domain.Abstract;
using BusTickets.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace BusTickets.Web.Controllers
{
    public class RoutesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoutesController(IUnitOfWork unitOfWork)
        {
           
                _unitOfWork = unitOfWork;
            
           
        }

       
        // GET: Routes
        public IActionResult Route()
        {
            return View(_unitOfWork.RouteRepository.Get());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Route route)
        {
            _unitOfWork.RouteRepository.Create(route);
            return RedirectToAction("Route");
        }

        public IActionResult Delete(Guid id)
        {
            var route = _unitOfWork.RouteRepository.FindById(id);
            if (route != null)
            {
                _unitOfWork.RouteRepository.Delete(route);
            }
            return RedirectToAction("Route");
        }

        
    }
}
