using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flowers_web.Models;

namespace Flowers_web.Controllers
{
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
       // [HttpPost]
        public ActionResult SearchUser(string search)
        {
            return Json("chamara", JsonRequestBehavior.AllowGet);
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
    }
}