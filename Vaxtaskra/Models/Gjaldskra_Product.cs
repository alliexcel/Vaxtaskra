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
    
    public partial class Gjaldskra_Product
    {
        public int GjaldskraProductID { get; set; }
        public int ProductID { get; set; }
        public int GjaldskraID { get; set; }
        public int TegundGjaldID { get; set; }
    
        public virtual Gjaldskra Gjaldskra { get; set; }
        public virtual Product Product { get; set; }
        public virtual Tegund_gjalds Tegund_gjalds { get; set; }
    }
}