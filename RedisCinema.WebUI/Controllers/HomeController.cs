using RedisCinema.Data;
using RedisCinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisCinema.WebUI.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            RedisCacheManager manager = new RedisCacheManager();
            var desks = manager.Get<List<Desks>>("desks");

            ViewBag.desks = desks;
            return View();
        }

        public ActionResult getDesks()
        {
            RedisCacheManager manager = new RedisCacheManager();
            var desks = manager.Get<List<Desks>>("desks");
            ViewBag.desks = desks;

            return View(ViewBag.desks);
        }




        public ActionResult DataControl()
        {

            RedisCacheManager manager = new RedisCacheManager();
            var desks = manager.Get<List<Desks>>("desks");
            if (manager.dataVarMiKontrol())
            {
                manager.setFalseDataVarMi();
                ViewBag.desks = desks;
                return PartialView("_SeatPartial");
                // return JavaScript("alertjs();");
            }
            return JavaScript("alertjs2();");
        }
        public JsonResult DataControl1()
        {

            RedisCacheManager manager = new RedisCacheManager();
            var desks = manager.Get<List<Desks>>("desks");
            var seats = manager.Get<List<Seat>>("seat");

            foreach (var deskItem in desks)
            {
                foreach (var seatItem in seats)
                {
                    if (deskItem.Id == seatItem.DeskId)
                    {
                        deskItem.isChecked = true;
                    }
                }
            }
            return Json(desks, JsonRequestBehavior.AllowGet);

        }
        public JsonResult DataControl2()
        {

            RedisCacheManager manager = new RedisCacheManager();

            if (manager.dataVarMiKontrol())
            {

                var desks = manager.Get<List<Desks>>("desks");
                var seats = manager.Get<List<Seat>>("seat");
                manager.setFalseDataVarMi();
                ViewBag.desks = desks;

                foreach (var catItem in desks)
                {
                    foreach (var seatItem in seats)
                    {
                        if (catItem.Id == seatItem.DeskId)
                        {
                            catItem.isChecked = true;
                        }
                    }
                }
                return Json(desks, JsonRequestBehavior.AllowGet);
            }
            return Json("", JsonRequestBehavior.AllowGet);

            
        }

    }
}