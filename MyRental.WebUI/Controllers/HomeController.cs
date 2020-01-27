using MyRental.Core.Contract;
using MyRental.Core.Model;
using MyRental.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyRental.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Room> context;
        IRepository<RoomType> typeContext;

        public HomeController(IRepository<Room> roomContext, IRepository<RoomType> roomTypeContext)
        {
            context = roomContext;
            typeContext = roomTypeContext;
        }
        public ActionResult Index(string Type=null)
        {
            List<Room> rooms = context.Collection().ToList();
            List<RoomType> types = typeContext.Collection().ToList();
            if (Type == null)
            {
                rooms = context.Collection().ToList();
            }
            else
            {
                rooms = context.Collection().Where(p => p.Type == Type).ToList();
            }
            RoomListViewModel model = new RoomListViewModel();
            model.Room = rooms;
            model.TypeList = types;
            return View(model);
        }

        public ActionResult Details(string Id)
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}