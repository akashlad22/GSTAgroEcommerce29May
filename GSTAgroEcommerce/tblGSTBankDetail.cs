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
    
    public partial class tblGSTBankDetail
    {
        public int BankdetailsId { get; set; }
        public string UserCode { get; set; }
        public string BankHolderName { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string BrachName { get; set; }
        public string AccountType { get; set; }
        public string MobileNo { get; set; }
        public Nullable<int> StatusId { get; set; }
    
        public virtual tblGSTStatu tblGSTStatu { get; set; }
    }
}
