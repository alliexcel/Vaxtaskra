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
    
    public partial class ProductPayment
    {
        public int ProductPaymentID { get; set; }
        public int ProductIndexationID { get; set; }
        public int PaymentMethodID { get; set; }
        public string TemplateID { get; set; }
    
        public virtual Product_indexation Product_indexation { get; set; }
    }
}
