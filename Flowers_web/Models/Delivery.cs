using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Flowers_web.Models
{
    public class Delivery
    {
        flowersEntities1 db;
        List<Order_Del> OrderList { get; set; }
        static Delivery Delivery2 { get; set; }
        protected Delivery()
        {
            db = new flowersEntities1();
            OrderList = new List<Order_Del>();
        }

        public static Delivery Instance()
        {
            if (Delivery2 == null)
            {
                Delivery2=new Delivery();
                return Delivery2;
            }
            else
            {
                return Delivery2;
            }
        }

        public List<Order_Del> GetOrderList(string searching)
        {
            DateTime date;
            DateTime.TryParse(searching, out date);
            OrderList = db.Order_Del.Where(s => s.Date_Delived.Value.Year == date.Year &&
            s.Date_Delived.Value.Month == date.Month &&
            s.Date_Delived.Value.Day == date.Day).ToList();
            return OrderList;
        }
    }
}