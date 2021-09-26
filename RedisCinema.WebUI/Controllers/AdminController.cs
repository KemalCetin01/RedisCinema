using RedisCinema.Data;
using RedisCinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedisCinema.WebUI.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            RedisCacheManager manager = new RedisCacheManager();
            var desks = manager.Get<List<Desks>>("desks");
            ViewBag.desks = desks;
            return View();
        }


        [HttpPost]
        public ActionResult AddDesk(Desks model)
        {
            if (ModelState.IsValid)
            {
                RedisCacheManager manager = new RedisCacheManager();
                manager.Set("desks", model, 10);
            }
            return RedirectToAction("Index");
        }

        public ActionResult checkSeatId(Seat model)
        {
            if (ModelState.IsValid)
            {
                RedisCacheManager manager = new RedisCacheManager();
                model.CheckSeat = true;
                manager.Set("seat", model, 10);
                var seats = manager.Get<List<Seat>>("seat");

            }
            return RedirectToAction("Index");
        }


    }
}