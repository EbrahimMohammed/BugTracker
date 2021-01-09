using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using BugTracker.Core.Domain;
using BugTracker.Dtos;

using BugTracker.Persistance;

namespace BugTracker.Controllers.Api
{
    public class TicketsController : ApiController
    {
        private ApplicationDbContext _context;

        public TicketsController()
        {
            _context = new ApplicationDbContext();
            
        }

        [System.Web.Http.Route("api/Tickets/GetProjectTickets")]
        public IHttpActionResult GetProjectTickets(int id)
        {

            var ticketDto = _context.Tickets
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.TicketType)
                .Where(t => t.ProjectId == id)
                .ToList()
                .Select(Mapper.Map<Ticket, TicketDto>);

           return Ok(ticketDto);

        }



        
    }
}
