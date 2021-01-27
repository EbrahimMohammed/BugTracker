using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using BugTracker.Core.Domain;
using BugTracker.Dtos;
using BugTracker.Models;
using BugTracker.Persistance;
using Microsoft.AspNet.Identity;
using File = BugTracker.Core.Domain.File;

namespace BugTracker.Controllers.Api
{

    [System.Web.Http.Authorize]
    public class TicketsController : BaseApiController
    {


        [System.Web.Http.Route("api/Tickets/GetProjectTickets")]
        public IHttpActionResult GetProjectTickets(int id)
        {

            var ticketDto = Context.Tickets
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.TicketType)
                .Where(t => t.ProjectId == id)
                .ToList()
                .Select(Mapper.Map<Ticket, TicketDto>);

           return Ok(ticketDto);

        }


        [System.Web.Http.Route("api/tickets/GetTicketFiles")]
        public IHttpActionResult GetTicketFiles(int id)
        {

            var ticket = Context.Tickets.Include(t=> t.Files).Single(t => t.Id == id);

            var files = ticket.Files;

            var filesDto = files.Select(Mapper.Map<File, FileDto>);

            return Ok(filesDto);

        }




        [System.Web.Http.Route("api/tickets/GetMyTickets")]
        public IHttpActionResult GetMyTickets()
        {
            List<Ticket> tickets;

            var user = Context.Users.Single(u => u.Id == CurrentUserId);



            if (User.IsInRole(Roles.CanManageUsers))
            {
                tickets = Context.Tickets.ToList();
            }
            else
            {
                //Explicitly load User project and the related tickets ( Msdn way )
                Context.Entry(user).Collection(u => u.Projects).Query()
                    .Include(p => p.Users) 
                    .Include(p => p.Tickets)
                    .Load();

                tickets = user
                     .Projects
                     .SelectMany(p => p.Tickets)
                     .ToList();

            }


            Context.Priorities.Load();
            Context.TicketTypes.Load();
            Context.TicketStatuses.Load();


            var ticketsDto = tickets.Select(Mapper.Map<Ticket, TicketDto>);

            return Ok(ticketsDto);

        }


    }
}
