using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugTracker.Core;
using BugTracker.Persistance;

namespace BugTracker.Controllers
{
    public class DashboardController : Controller
    {

        private readonly ApplicationDbContext _context;

   


        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }



        public ActionResult Index()
        {

            return View();
        }


        [Authorize]
        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult RangeSlider()
        {
            return View();
        }

        public ActionResult SessionTimeout()
        {
            return View();
        }
    }
}