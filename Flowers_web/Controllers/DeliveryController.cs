using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flowers_web.Models;


namespace Flowers_web.Controllers
{
    public class DeliveryController : Controller
    {
        Delivery model;
        flowersEntities1 db = new flowersEntities1();
        public DeliveryController()
        {
            model =  Delivery.Instance();
        }

        // GET: Delivery
        public ActionResult Index()
        {
            var order = from o in db.Order_Del select o;
            //if (!String.IsNullOrEmpty(searching))
            //{
            //    order = order.Where(s => s.Order_Status.Contains(searching));
            //}
            return View(order.ToList());
        }
        [HttpPost]
        public ActionResult GetOrders(string searching)
        {          
            
            if (!String.IsNullOrEmpty(searching))
            {
                return View("Index",model.GetOrderList(searching));               
            }
            return View();
        }
    }
}