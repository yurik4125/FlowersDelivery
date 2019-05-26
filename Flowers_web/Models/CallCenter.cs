using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flowers_web.Models
{
    public class CallCenter
    {
        private a206yuriyEntities1 db;
        public Cust2 Client { get; set; }
        public List<Bouquet> Bouquets { get; set; }
        public List<int> Quantities { get; set; }
        public List<string> Sizes { get; set; }
        public string ComboBouqets { get; set; }
        public string ComboQuantities { get; set; }
        public string ComboSizes { get; set; }
        public string FindUser { get; set; }
        
        public string PictureElement { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateDelivery { get; set; }

        public string Sum { get; set; }

        public string Address_Numder_Appartment { get; set; }
        public string Address_Number_Street { get;set;}
        public string Address_Name_Street { get; set; }
        public string Address_City { get; set; }
        public string Address_ZIPCODE { get; set; }
        public string Address_State { get; set; }
        public string Address_Country { get; set; }
        public string Address_line1 { get; set; }
        public string Address_line2 { get; set; }

      

        public CallCenter()
        {
            db = new a206yuriyEntities1();
            Quantities = new List<int>();
            Sizes = new List<string>();
            for (int i = 1; i < 11; i++)
            {
                Quantities.Add(i);
            }

            Sizes.Add("S");
            Sizes.Add("M");
            Sizes.Add("L");
            DateDelivery=DateTime.Today;
        }
        /// <summary>
        /// Возвращает список букетов
        /// </summary>
        /// <returns></returns>
        public List<Bouquet> GetBouqets()
        {
            Bouquets = new List<Bouquet>();
            Bouquets = db.Bouquets.ToList();
            ComboBouqets = Bouquets[0].Bouquet_ID.ToString();
            return Bouquets;
        }

        public bool SaveOrder(CallCenter model)
        {
            bool result = false;
            //create address
            
            Address address = new Address()
            {
                Address_City = model.Address_City,
                Address_ZIPCODE = model.Address_ZIPCODE,
                Address_Numder_Appartment = model.Address_Numder_Appartment,
                Address_Country=model.Address_Country,
                Address_line1=model.Address_line1,
                Address_line2=model.Address_line2,
                Address_Name_Street=model.Address_Name_Street,
                Address_Number_Street=model.Address_Number_Street,
                Address_State=model.Address_State
            };
            db.Addresses.Add(address);
            //create customer
            Cust2 cust2 = new Cust2()
            {
                Lname = model.Client.Lname,
                Fname = model.Client.Fname,
                Address = address
            };
            db.Cust2.Add(cust2);

            //create order
            int id = 0;
            int.TryParse(model.ComboBouqets,out id);
            int quantities = 0;
            int.TryParse(model.ComboQuantities, out quantities);
            decimal summ = 0;
            decimal.TryParse(model.Sum, out summ);

            Order_Del order = new Order_Del()
            {
                Bouquet_ID = id,
                Florist_ID = 25,
                Cust2 = cust2,
                Order_Date = DateTime.Today,
                Bouquet_Quontity = quantities,
                Date_Delived = DateDelivery,
                Total_Price = summ,
                Size_Bouquets = model.ComboSizes,
                Order_Status="Payed"
            };
            db.Order_Del.Add(order);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return result;
            }
           

        }
    }
}