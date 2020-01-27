using MyRental.Core.Contract;
using MyRental.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyRental.WebUI.Controllers
{
    public class ActivitiesManagerController : Controller
    {
        // GET: ActivitiesManager
        // GET: RoomManagement
        IRepository<Activities> context;

        public ActivitiesManagerController(IRepository<Activities> activityContext)
        {
            context = activityContext;
        }
        public ActionResult Index()
        {
            List<Activities> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            Activities activity = new Activities();
            return View(activity);
        }
        [HttpPost]
        public ActionResult Create(Activities activity, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    activity.Image = activity.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//RoomImages//") + activity.Image);
                }
                context.Insert(activity);
                context.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return View(activity);
            }
        }
        public ActionResult Edit(string Id)
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
        [HttpPost]
        public ActionResult Edit(Activities activity, string Id, HttpPostedFileBase file)
        {
            Activities activityToEdit = context.Find(Id);
            if (activityToEdit != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(activity);
                }
                else
                {
                    if (file != null)
                    {
                        activity.Image = activity.Id + Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath("//Content//RoomImages//") + activity.Image);
                    }
                    activityToEdit.Name = activity.Name;
                    activityToEdit.Description = activity.Description;
                    
                    context.Commit();

                    return RedirectToAction("Index");
                }
            }
            else
            {
                return HttpNotFound();
            }

        }
        public ActionResult Delete(string Id)
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
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Activities activity = context.Find(Id);
            if (activity != null)
            {
                context.Delete(Id);
                context.Commit();

                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}