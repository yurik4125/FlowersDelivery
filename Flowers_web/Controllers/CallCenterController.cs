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

        // GET: CallCenter
        public ActionResult Index()
        {
            var cookie = Request.Cookies["FlowersCookie"];
            if (cookie != null)
            {
                ViewBag.id = cookie.Value;
                model=new CallCenter();
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
        private List<Cust2> GetUsers()
        {
            var usersList = new List<Cust2>
            {
                new Cust2
                {
                  Cust_ID = 0,
                    Fname = "Ram0",
                    
                },
                new Cust2
                {
                    Cust_ID = 1,
                    Fname = "Ram1",
                },
                new Cust2
                {
                     Cust_ID = 2,
                    Fname = "Ram2",
                }
            };

            return usersList;
        }

        public ActionResult SearchUser(string search)
        {
            return Json(GetUsers(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Index(string Prefix)
        {
            //Note : you can bind same list from database  
            List<City> ObjList = new List<City>()
            {

                new City {Id=1,CityName="Latur" },
                new City {Id=2,CityName="Mumbai" },
                new City {Id=3,CityName="Pune" },
                new City {Id=4,CityName="Delhi" },
                new City {Id=5,CityName="Dehradun" },
                new City {Id=6,CityName="Noida" },
                new City {Id=7,CityName="New Delhi" }

        };//Searching records from list using LINQ query  
            var CityList = (from N in ObjList
                            where N.CityName.StartsWith(Prefix)
                            select new { N.CityName });
            return Json(CityList, JsonRequestBehavior.AllowGet);
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