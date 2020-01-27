using MyRental.Core.Model;
using MyRental.Core.ViewModel;
using MyRental.Core.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MyRental.WebUI.Controllers
{
    public class RoomManagementController : Controller
    {
        // GET: RoomManagement
        IRepository<Room> context;
        IRepository<RoomType> typeContext;

        public RoomManagementController(IRepository<Room> roomContext, IRepository<RoomType> roomTypeContext)
        {
            context = roomContext;
            typeContext = roomTypeContext;
        }
        public ActionResult Index()
        {
            List<Room> rooms = context.Collection().ToList();
            return View(rooms);
        }
        public ActionResult Create()
        {
            RoomTypesViewModel viewModel = new RoomTypesViewModel();
            viewModel.Room = new Room();
            viewModel.typeList = typeContext.Collection();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Room room, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    room.Image = room.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//RoomImages//") + room.Image);
                }
                context.Insert(room);
                context.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return View(room);
            }
        }
        public ActionResult Edit(string Id)
        {
            Room room = context.Find(Id);
            if (room != null)
            {
                RoomTypesViewModel viewModel = new RoomTypesViewModel();
                viewModel.Room = new Room();
                viewModel.typeList = typeContext.Collection();
                return View(viewModel);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult Edit(Room room, string Id, HttpPostedFileBase file)
        {
            Room roomToEdit = context.Find(Id);
            if (roomToEdit != null)
            {
                if (!ModelState.IsValid)
                {
                    return View(room);
                }
                else {
                if (file != null)
                {
                    roomToEdit.Image = room.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//RoomImages//") + room.Image);
                }
                roomToEdit.Name = room.Name;
                roomToEdit.Type = room.Type;
                roomToEdit.Price = room.Price;
                roomToEdit.Description = room.Description;
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
            Room room = context.Find(Id);
            if (room != null)
            {
                return View(room);
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
            Room room = context.Find(Id);
            if (room != null)
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