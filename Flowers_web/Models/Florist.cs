//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Flowers_web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Florist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Florist()
        {
            this.Flo_Order = new HashSet<Flo_Order>();
            this.Order_Del = new HashSet<Order_Del>();
            this.Warehouses = new HashSet<Warehouse>();
        }
    
        public int Florist_ID { get; set; }
        public string Frorist_Fname { get; set; }
        public string Frorist_Lname { get; set; }
        public string Frorist_Address { get; set; }
        public decimal Frorist_Phone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flo_Order> Flo_Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Del> Order_Del { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
