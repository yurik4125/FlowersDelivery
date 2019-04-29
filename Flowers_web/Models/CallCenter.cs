using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flowers_web.Models
{
    public class CallCenter
    {
        private a206yuriyEntities db = new a206yuriyEntities();
        public List<Bouquet> Bouquets { get; set; }
        public List<int> Quantities{ get; set; }
        public List<string> Sizes{ get; set; }
        public string ComboBouqets { get; set; }
        public string ComboQuantities { get; set; }
        public string ComboSizes { get; set; }
        public string ComboPostalCode { get; set; }
        public string PictureElement { get; set; }



        public string TxbAddress { get; set; }
        public string TxbCity { get; set; }

        public string Txb1 { get; set; }
        public string Txb2 { get; set; }
        public string Txb3 { get; set; }
        public string Txb4 { get; set; }
        public string Txb5 { get; set; }
        public string Txb6 { get; set; }
        public string Txb7 { get; set; }
        public string Txb8 { get; set; }

        public CallCenter()
        {
            Quantities= new List<int>();
            Sizes = new List<string>();
            for (int i = 1; i < 11; i++)
            {
                Quantities.Add(i);
            }

            Sizes.Add("S");
            Sizes.Add("M");
            Sizes.Add("L");
           
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
    }
}