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
using BugTracker.Core.Domain;
using BugTracker.Enums;
using Microsoft.Ajax.Utilities;
using File = BugTracker.Core.Domain.File;

namespace BugTracker.Controllers
{
    public class TicketController : Controller
    {
        private ApplicationDbContext _context;
        private string _uploadFolder;



        public TicketController()
        {
            _context = new ApplicationDbContext();
            _uploadFolder = ConfigurationManager.AppSettings["UploadFolder"];
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


        [HttpPost]
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

            var ticket = _context
                .Tickets
                .Single(t => t.Id == id);

           


            var model = new UpdateTicketViewModel()
            {
                Ticket = ticket,

                ProjectUsers = _context
                    .Projects
                    .Include(p => p.Developers)
                    .Single(p => p.Id == ticket.ProjectId)
                    .Developers
                    .ToList() ,

                Priorities = _context.Priorities.ToList(),

                TicketTypes = _context.TicketTypes.ToList(),

                TicketStatus = _context.TicketStatuses.ToList(),

                FileModel = new FileModel
                {
                    TicketId = ticket.Id
                } 


            };




            return View(model);


        }





        [HttpPost]
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

 


        [HttpPost]
        public ActionResult FileUpload(FileModel model)
        {

            var supportedTypes = new[] { ".pdf", ".png",".jpg" };

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
            catch
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