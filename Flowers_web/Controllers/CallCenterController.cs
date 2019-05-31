using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flowers_web.Models;

namespace Flowers_web.Controllers
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }

    }
    public class CallCenterController : Controller
    {
        public CallCenter model;

        public CallCenterController()
        {
            model = new CallCenter();
        }

        // GET: CallCenter
        public ActionResult Index()
        {
            var cookie = Request.Cookies["FlowersCookie"];
            if (cookie != null)
            {
                ViewBag.id = cookie.Value;
              
                model.GetBouqets();
                return View(model);
            }
            else
            {
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult Calculate(CallCenter model)
        {
            if (ModelState.IsValid)
            {
                model.SaveOrder(model);
                model.GetBouqets();
            }

            return View("Index",model);
        }
       
        [HttpPost]
        public JsonResult SearchUser(string search)
        {
            return Json(model.GetUsers(search), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult FindUsers(string Prefix)
        {
            var list = model.UsersFio(Prefix);
            return Json(list, JsonRequestBehavior.AllowGet);
        }


            public ActionResult Autocomplete(string term)
        {
            var items = new[] { "Apple", "Pear", "Banana", "Pineapple", "Peach" };

            var filteredItems = items.Where(
                item => item.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0
                );
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
        }
    }
}