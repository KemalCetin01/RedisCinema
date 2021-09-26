using RedisCinema.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedisCinema.Model;
using System.Web.UI;

namespace RedisCinema.Web.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            RedisCacheManager manager = new RedisCacheManager();
            var categories = manager.Get<List<Categories>>("categories");
            ViewBag.Categories = categories;
            return View();
        }


        [HttpPost]
        public ActionResult AddCategory(Categories model)
        {
            if (ModelState.IsValid)
            {
                RedisCacheManager manager = new RedisCacheManager();
                manager.Set("categories", model, 10);
            }
            return RedirectToAction("Index");
        }

        public ActionResult checkSeatId(Seat model)
        {
            if (ModelState.IsValid)
            {
                RedisCacheManager manager = new RedisCacheManager();
               // model.CategoryId = 1; // model.CategoryId;
                model.CheckSeat = true;
               // model.Id = 1;
                manager.Set("seat", model, 10);
                var seats = manager.Get<List<Seat>>("seat");

            }
            return RedirectToAction("Index");
        }

        //public ActionResult KisiListele()
        //{

        //    RedisCacheManager manager = new RedisCacheManager();
        //    var categories = manager.Get<List<Categories>>("categories");

        //    return JavaScript("addCategoryClick");
        //    //return PartialView("Partial/CategoryPartial", categories);
        //}
    }
}