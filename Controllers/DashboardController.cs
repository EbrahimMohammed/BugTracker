using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using BugTracker.Core;
using BugTracker.Models;
using BugTracker.Persistance;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BugTracker.Controllers
{

    [Authorize(Roles = Roles.CanManageUsers)]
    public class DashboardController : Controller
    {

        private readonly ApplicationDbContext _context;

     


        public DashboardController()
        {
            _context = new ApplicationDbContext();

        }



        public ActionResult Index()
        {
            var totalProjects = _context.Projects.Count();

            var totalUsers = _context.Users.Count();

            var activeTickets = _context.Tickets
                .Include(t => t.Status)
                .Count(t => t.Status.Name != StatusName.Closed && t.Status.Name != StatusName.Pending);

            var closedTickets = _context.Tickets
                .Include(t => t.Status)
                .Count(t => t.Status.Name == StatusName.Closed);

            var model = new DashboardViewModel
            {
                ActiveTickets = activeTickets,

                ClosedTickets = closedTickets,

                TotalProjects = totalProjects,

                TotalUsers = totalUsers,

                TicketByTypeModel =PopulateTicketByTypeModel(),
                
                TicketByPriorityModel = PopulateGetTicketPriorityModel(),

                TicketByStatusModel = PopulateTicketByStatusModel(),

                UserRolesModel = PopulateUsersRolesModel()

            };


        return View(model);

        }





        public TicketByTypeModel PopulateTicketByTypeModel()
        {
            var ticketWithTypeIncluded = _context.Tickets.Include(t => t.TicketType);


            var bugsTickets = ticketWithTypeIncluded
                .Count(t => t.TicketType.Type == TicketTypes.Bugs);

            var changeRequestTickets = ticketWithTypeIncluded
                .Count(t => t.TicketType.Type == TicketTypes.ChangeRequest);

            var newFunctionalityTickets = ticketWithTypeIncluded
                .Count(t => t.TicketType.Type == TicketTypes.NewFunctionality);


            return  new TicketByTypeModel
            {
                Bugs = bugsTickets,
                ChangeRequests = changeRequestTickets,
                NewFunctionalities = newFunctionalityTickets
            };


        }


        public TicketByStatusModel PopulateTicketByStatusModel()
        {
            var ticketWithStatusIncluded = _context.Tickets.Include(t => t.Status);

            var pendingTickets = ticketWithStatusIncluded
                .Count(t => t.Status.Name != StatusName.Pending);

            var assignedTickets = ticketWithStatusIncluded
                .Count(t => t.Status.Name != StatusName.Assigned);

            var fixedTickets = ticketWithStatusIncluded
                .Count(t => t.Status.Name != StatusName.Fixed);

            var testedTickets = ticketWithStatusIncluded
                .Count(t => t.Status.Name != StatusName.Tested);

            var closedTickets = ticketWithStatusIncluded
                .Count(t => t.Status.Name == StatusName.Closed);

            return new TicketByStatusModel
            {
                Pending = pendingTickets,

                Assigned = assignedTickets,

                Fixed = fixedTickets,

                Tested = testedTickets,

                Closed = closedTickets


            };


        }

        public TicketByPriorityModel PopulateGetTicketPriorityModel()
        {
            var ticketWithPriorityIncluded = _context.Tickets.Include(t => t.Priority);

            var highPriorityTickets = ticketWithPriorityIncluded
                .Count(t => t.Priority.Name == Priorities.High);

            var mediumPriorityTickets =
                ticketWithPriorityIncluded.Count(t => t.Priority.Name == Priorities.Medium);


            var lowPriorityTickets =
                ticketWithPriorityIncluded.Count(t => t.Priority.Name == Priorities.Low);


            return new TicketByPriorityModel
            {

                High = highPriorityTickets,

                Medium = mediumPriorityTickets,

                Low = lowPriorityTickets

            };

        }


        public UserRolesModel PopulateUsersRolesModel()
        {

            return new UserRolesModel
            {
                AdminsCount = GetUsersInRoleCount(Roles.CanManageUsers),

                ProjectManagers = GetUsersInRoleCount(Roles.CanManageProjects),


                DevelopersCount = GetUsersInRoleCount(Roles.CanChangeFixedStated),


                TestersCount =  GetUsersInRoleCount(Roles.CanChangeTestedState)

        };

        }


        public int GetUsersInRoleCount(string roleName)
        {

            var count = 0;

            if (roleName != null)
            {
                var roles = _context.Roles.Where(r => r.Name == roleName);

                if (roles.Any())
                {
                    var roleId = roles.First().Id;
                    count = (from user in _context.Users
                        where user.Roles.Any(r => r.RoleId == roleId)
                        select user).Count();
                }
            }
            return count;
        }


    }
}


