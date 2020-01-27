using MyRental.Core.Contract;
using MyRental.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyRental.WebUI.Controllers
{
    public class RoomTypeManagerController : Controller
    {
        // GET: RoomTypeManager
        IRepository<RoomType> context;

        public RoomTypeManagerController(IRepository<RoomType> context)
        {
            this.context = context;
        }
        public ActionResult Index()
        {
            List<RoomType> roomTypes = context.Collection().ToList();
            return View(roomTypes);
        }
        public ActionResult Create()
        {
            RoomType roomType = new RoomType();
            return View(roomType);
        }
        [HttpPost]
        public ActionResult Create(RoomType roomType)
        {
            
            if (roomType != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(roomType);
                }
                else
                {
                    context.Insert(roomType);
                    context.Commit();

                    return RedirectToAction("Index");
                }
                }
            else
            {
                return HttpNotFound();
            }

        }
        public ActionResult Edit(string id)
        {
            RoomType type = context.Find(id);
            if (type != null)
            {
                return View(type);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult Edit(RoomType roomType, string id)
        {
            RoomType typeToEdit = context.Find(id);
            if (roomType != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(roomType);
                }
                else
                {
                    typeToEdit.Type = roomType.Type;
                    context.Commit();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return HttpNotFound();
            }

        }
        public ActionResult Delete(string id)
        {
            RoomType type = context.Find(id);
            if (type != null)
                return View(type);
            else
                return HttpNotFound();
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            RoomType typeToDelete = context.Find(id);
            if (typeToDelete != null)
            {
                context.Delete(id);
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