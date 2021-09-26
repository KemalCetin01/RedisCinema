using RedisCinema.Data;
using RedisCinema.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RedisCinema.Web.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            RedisCacheManager manager = new RedisCacheManager();
            var categories = manager.Get<List<Categories>>("categories");
      
            ViewBag.Categories = categories;
            return View();
        }

        public ActionResult getCategories()
        {
            RedisCacheManager manager = new RedisCacheManager();
            var categories = manager.Get<List<Categories>>("categories");
            ViewBag.Categories = categories;

            return View(ViewBag.Categories);
        }


        //public ActionResult Category(int id)
        //{
        //    RedisCacheManager manager = new RedisCacheManager();
        //    var products = manager.Get<List<Products>>(id.ToString());
        //    return View(products);
        //}

        public ActionResult DataControl()
        {

            RedisCacheManager manager = new RedisCacheManager();
            var categories = manager.Get<List<Categories>>("categories");
            if (manager.dataVarMiKontrol())
            {
                manager.setFalseDataVarMi();
                ViewBag.Categories = categories;
                return PartialView("CategoryPartial");
               // return JavaScript("alertjs();");
            }
            return JavaScript("alertjs2();");
            //return PartialView("Partial/CategoryPartial", categories);
        }
        public JsonResult DataControl1()
        {

            RedisCacheManager manager = new RedisCacheManager();
            var categories = manager.Get<List<Categories>>("categories");
            var seats = manager.Get<List<Seat>>("seat");

            foreach (var catItem in categories)
                {
                    foreach (var seatItem in seats)
                    {
                        if (catItem.Id==seatItem.CategoryId)
                        {
                            catItem.isChecked = true;
                        }
                    }
                }
            return Json(categories, JsonRequestBehavior.AllowGet);

            //return PartialView("Partial/CategoryPartial", categories);
        }
        public JsonResult DataControl2()
        {

            RedisCacheManager manager = new RedisCacheManager();

            if (manager.dataVarMiKontrol())
            {

                var categories = manager.Get<List<Categories>>("categories");
                var seats = manager.Get<List<Seat>>("seat");
                manager.setFalseDataVarMi();
                ViewBag.Categories = categories;

                foreach (var catItem in categories)
                {
                    foreach (var seatItem in seats)
                    {
                        if (catItem.Id == seatItem.CategoryId)
                        {
                            catItem.isChecked = true;
                        }
                    }
                }
                return Json(categories,JsonRequestBehavior.AllowGet);
                // return JavaScript("alertjs();");
            }
            return Json("", JsonRequestBehavior.AllowGet);

            //return PartialView("Partial/CategoryPartial", categories);
        }
        //public ActionResult KisiListele()
        //{

        //    RedisCacheManager manager = new RedisCacheManager();
        //    var categories = manager.Get<List<Categories>>("categories");

        //    return JavaScript("addCategoryClick2();");
        //    //return PartialView("Partial/CategoryPartial", categories);
        //}   
        //public ActionResult KisiListele2()
        //{

        //    RedisCacheManager manager = new RedisCacheManager();
        //    var categories = manager.Get<List<Categories>>("categories");

        //    return JavaScript("alertjs();");
        //    //return PartialView("Partial/CategoryPartial", categories);
        //}

    }
}