using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugTracker.Models;
using BugTracker.Persistance;
using System.Data.Entity;
using System.IO;
using System.Web.Http;
using BugTracker.Core.Domain;
using BugTracker.Enums;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using File = BugTracker.Core.Domain.File;

namespace BugTracker.Controllers
{
    public class TicketController : Controller
    {
        private ApplicationDbContext _context;
        private string _uploadFolder;
        private static UserStore<IdentityUser> _userStore;
        private static UserManager<IdentityUser> _userManager;
        private static RoleStore<IdentityRole> _roleStore;
        private static RoleManager<IdentityRole> _roleManager;




        public TicketController()
        {
            _context = new ApplicationDbContext();
            _uploadFolder = ConfigurationManager.AppSettings["UploadFolder"];
            _userStore = new UserStore<IdentityUser>();
            _userManager = new UserManager<IdentityUser>(_userStore);
            _roleStore = new RoleStore<IdentityRole>();
            _roleManager = new RoleManager<IdentityRole>(_roleStore);
        }


        public ActionResult Index()
        {

          

            return View();
        }



        public ActionResult Create(int id)
        {
            var ticket = new Ticket
            {
                ProjectId = id

            };

            var model = new CreateTicketViewModel
            {
                Ticket   = ticket,

                ProjectUsers = _context
                    .Projects
                    .Include(p => p.Developers)
                    .Single(p => p.Id == id)
                    .Developers,

                Priorities = _context.Priorities.ToList(),

                TicketTypes = _context.TicketTypes.ToList()


            };
           



            return View(model);
        }


        [System.Web.Mvc.HttpPost]
        public ActionResult Create(CreateTicketViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["swal"] = "Something went wrong" + "| |" + "error";
                return View(model);
            }

            try
            {


                var ticket = model.Ticket;


                if (ticket.AssignedDeveloperId.IsNullOrWhiteSpace())
                {
                    ticket.StatusId = (int) Status.Pending;
                }
                else
                {
                    ticket.StatusId = (int) Status.Assigned;
                }


                _context.Tickets.Add(ticket);

                _context.SaveChanges();
                TempData["swal"] = "Ticket created successfully" + "| |" + "success";


                return RedirectToAction("Details", "Project", new {id = model.Ticket.ProjectId});
            }
            catch 
            {
                TempData["swal"] = "Something went wrong" + "| |" + "error";

                return RedirectToAction("Create","Ticket", model.Ticket.ProjectId);

            }

        }

        public ActionResult Details(int id)
        {
            var role = _userManager.GetRoles(User.Identity.GetUserId()).FirstOrDefault();

            var model = PopulateUpdateTicketViewModel(id , role);


            if (role == Roles.CanManageProjects)
                return View("DetailsManagerView", model);
            
            if (role == Roles.CanManageUsers)
                return View("DetailsAdminView", model);



            return View("DetailsUserView", model);



        }


     



        public UpdateTicketViewModel PopulateUpdateTicketViewModel(int ticketId, string role)
        {

            var model = new UpdateTicketViewModel();

            if (role != null)
            {
                switch (role)
                {
                    case Roles.CanManageUsers:
                        model = PopulateModelForAdmin(ticketId);
                        break;

                    case Roles.CanManageProjects:
                        model = PopulateModelForProjectManager(ticketId);
                        break;

                    case Roles.CanChangeFixedStated:
                        model = PopulateModelForUsers(ticketId);
                        break; 
                    
                    case Roles.CanChangeTestedState:
                        model = PopulateModelForUsers(ticketId);
                        break;
                }

            }
            return model;
        }

        public UpdateTicketViewModel PopulateModelForAdmin(int ticketId)
        {
            var ticket = _context
                .Tickets
                .Include(t => t.AssignedDeveloper)
                .Include(t => t.TicketType)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Single(t => t.Id == ticketId);

            var model = new UpdateTicketViewModel()
            {
                Ticket = ticket,

                FileModel = new FileModel { TicketId = ticket.Id }
            };

            return model;

        }

        public UpdateTicketViewModel PopulateModelForProjectManager(int ticketId)
        {
            var ticket = _context
                .Tickets
                .Single(t => t.Id == ticketId);

            var model = new UpdateTicketViewModel()
            {
                Ticket = ticket,

                ProjectUsers = _context
                    .Projects
                    .Include(p => p.Developers)
                    .Single(p => p.Id == ticket.ProjectId)
                    .Developers
                    .ToList(),

                Priorities = _context.Priorities.ToList(),

                TicketTypes = _context.TicketTypes.ToList(),

                TicketStatus = _context.TicketStatuses.ToList(),

                FileModel = new FileModel { TicketId = ticket.Id }

            };

            return model;

        }

        public UpdateTicketViewModel PopulateModelForUsers(int ticketId)
        {

            var ticket = _context.Tickets
                .Include(t => t.AssignedDeveloper)
                .Include(t => t.TicketType)
                .Include(t => t.Priority)
                .Single(t => t.Id == ticketId);

            var model = new UpdateTicketViewModel()
            {
                Ticket = ticket,

                FileModel = new FileModel { TicketId = ticket.Id }
            };

            if (User.IsInRole(Roles.CanChangeFixedStated))
            {

                model.TicketStatus = _context.TicketStatuses
                    .Where(ts => ts.Name == StatusName.Fixed | ts.Name == StatusName.Assigned | ts.Name == StatusName.InProgress)
                    .ToList();
            }
            else if (User.IsInRole(Roles.CanChangeTestedState))
            {
                model.TicketStatus = _context.TicketStatuses
                    .Where(ts => ts.Name == StatusName.Fixed | ts.Name == StatusName.Tested)
                    .ToList();
            }

            return model;

        }



        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Authorize(Roles = Roles.CanManageUsers)]
        public ActionResult Update(UpdateTicketViewModel model)
        {

            if (!ModelState.IsValid)
            {
                TempData["swal"] = "Something went wrong" + "| |" + "error";
                return RedirectToAction("Details", model);
            }

            try
            {

                var ticket = _context
                    .Tickets
                    .Single(t => t.Id == model.Ticket.Id);


                    ticket.Title = model.Ticket.Title;
                    ticket.Description = model.Ticket.Description;
                    ticket.AssignedDeveloperId = model.Ticket.AssignedDeveloperId;
                    ticket.PriorityId = model.Ticket.PriorityId;
                    ticket.DueDate = model.Ticket.DueDate;
                    ticket.TicketTypeId = model.Ticket.TicketTypeId;
                    ticket.StatusId = model.Ticket.StatusId;

                    


                _context.SaveChanges();

                TempData["swal"] = "Ticket Updated successfully" + "| |" + "success";


                return RedirectToAction("Details", "Project", new { id = model.Ticket.ProjectId });
            }
            catch
            {
                TempData["swal"] = "Something went wrong" + "| |" + "error";

                return RedirectToAction("Details","Ticket", new {id = model.Ticket.Id});
                
            }


        }


        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Authorize(Roles =  Roles.CanChangeFixedStated + "," + Roles.CanChangeTestedState)]
        public ActionResult UpdateStatus(UpdateTicketViewModel model)
        {

            if (!ModelState.IsValid)
            {
                TempData["swal"] = "Something went wrong" + "| |" + "error";
                return RedirectToAction("Details", model);
            }

            try
            {
                var ticket = _context
                    .Tickets
                    .Single(t => t.Id == model.Ticket.Id);

                ticket.StatusId = model.Ticket.StatusId;

                _context.SaveChanges();

                TempData["swal"] = "Ticket Updated successfully" + "| |" + "success";


                return RedirectToAction("Details", "Project", new { id = model.Ticket.ProjectId });
            }
            catch
            {
                TempData["swal"] = "Something went wrong" + "| |" + "error";

                return RedirectToAction("Details", "Ticket", new { id = model.Ticket.Id });

            }


        }




        [System.Web.Mvc.HttpPost]
        public ActionResult FileUpload(FileModel model)
        {

            var supportedTypes = new[] { ".pdf", ".png",".jpg",".pdf",".txt" };

            if (model.TicketId == 0 || model.FileUpload == null || model.Description == null)
            {
                TempData["swal"] = "Something went wrong" + "| |" + "error";
                return RedirectToAction("Details", new { id = model.TicketId });
            }

            try
            {

                var fileName = Path.GetFileNameWithoutExtension(model.FileUpload.FileName);

                var fileExtension = Path.GetExtension(model.FileUpload.FileName);

                if (!supportedTypes.Contains(fileExtension))
                {
                    TempData["swal"] = "Something went wrong" + "| |" + "error";
                    return RedirectToAction("Details", new {id = model.TicketId});
                }


                fileName = DateTime.Now.ToString("yyMMddhhmmss") + "-" + fileName.Trim() + fileExtension;


                var path = Path.Combine(Server.MapPath(_uploadFolder), fileName);

                model.FileUpload.SaveAs(path);


                var file = new File
                {
                    Name = fileName,

                    FilePath = path,

                    Description = model.Description,

                    TicketId = model.TicketId
                };




                _context.Files.Add(file);

                _context.SaveChanges();


                TempData["swal"] = "File uploaded successfully" + "| |" + "success";

                return RedirectToAction("Details","Ticket", new {  id = model.TicketId });

            }
            catch(Exception e)
            {
                TempData["swal"] = "Something went wrong" + "| |" + "error";
                return RedirectToAction("Details","Ticket", new { id = model.TicketId });
            }

        }



        public FileResult DownloadFile(int id)
        {

            var file = _context.Files.Single(f => f.Id == id);

            var fileVirtualPath = Path.Combine(Server.MapPath(_uploadFolder), file.Name);

            return File(fileVirtualPath, "application/force-download", Path.GetFileName(fileVirtualPath));


        }


        protected override void Dispose(bool disposing)
        {

            _context.Dispose();

            base.Dispose(disposing);
        }


    }
}