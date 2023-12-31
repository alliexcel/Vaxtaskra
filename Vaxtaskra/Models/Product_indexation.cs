//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vaxtaskra.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product_indexation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product_indexation()
        {
            this.ProductInterests = new HashSet<ProductInterest>();
            this.ProductPayments = new HashSet<ProductPayment>();
        }
    
        public int ProductIndexationID { get; set; }
        public int ProductID { get; set; }
        public bool is_Indexed { get; set; }
        public decimal MAX_number_payments { get; set; }
        public decimal MIN_number_payments { get; set; }
    
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductInterest> ProductInterests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPayment> ProductPayments { get; set; }
    }
}
