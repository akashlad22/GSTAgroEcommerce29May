//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GSTAgroEcommerce
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblGSTGst
    {
        public int GSTId { get; set; }
        public string CategoryCode { get; set; }
        public Nullable<double> CGST { get; set; }
        public Nullable<double> SGST { get; set; }
        public Nullable<double> UGST { get; set; }
        public Nullable<double> IGST { get; set; }
    
        public virtual tblGSTCategory tblGSTCategory { get; set; }
    }
}