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
        public Cust2 Client{ get; set; }
        public List<Bouquet> Bouquets { get; set; }
        public List<int> Quantities{ get; set; }
        public List<string> Sizes{ get; set; }
        public string ComboBouqets { get; set; }
        public string ComboQuantities { get; set; }
        public string ComboSizes { get; set; }
        public string ComboPostalCode { get; set; }
        public string PictureElement { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateDelivery { get; set; }

        public string Sum { get; set; }
    
        public string TxbAddress { get; set; }
        public string TxbCity { get; set; }

        public string Txb1 { get; set; }
        /// <summary>
        /// Address_Numder_Appartment
        /// </summary>
        public string Txb2 { get; set; }
        public string Txb3 { get; set; }
        public string Txb4 { get; set; }
        public string Txb5 { get; set; }
        public string Txb6 { get; set; }
        public string Txb7 { get; set; }
        public string Txb8 { get; set; }

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
                Address_City = model.TxbCity,
                Address_ZIPCODE = model.ComboPostalCode,
                Address_Numder_Appartment = model.Txb2
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
                Size_Bouquets = model.ComboSizes
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