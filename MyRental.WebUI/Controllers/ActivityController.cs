using MyRental.Core.Contract;
using MyRental.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyRental.WebUI.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        IRepository<Activities> context;

        public ActivityController(IRepository<Activities> context)
        {
            this.context = context;
          
        }
        public ActionResult Index()
        {
            List<Activities> activities = context.Collection().ToList();
            return View(activities);
        }

        public ActionResult Details(string Id)
        {
            Activities activity = context.Find(Id);
            if (activity != null)
            {
                return View(activity);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}