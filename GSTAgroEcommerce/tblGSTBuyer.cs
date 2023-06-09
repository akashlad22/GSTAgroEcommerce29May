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
    
    public partial class tblGSTBuyer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblGSTBuyer()
        {
            this.tblGSTBuyerPayments = new HashSet<tblGSTBuyerPayment>();
            this.tblGSTRatingandFeedbacks = new HashSet<tblGSTRatingandFeedback>();
            this.tblGSTWallets = new HashSet<tblGSTWallet>();
        }
    
        public int BuyerId { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerFullName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string AlternateMobileNo { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Gender { get; set; }
        public string AadhaarNo { get; set; }
        public string PanCardNo { get; set; }
        public string AdharPhoto { get; set; }
        public string PanCardPhoto { get; set; }
        public Nullable<double> Salary { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
    
        public virtual tblGSTCity tblGSTCity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGSTBuyerPayment> tblGSTBuyerPayments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGSTRatingandFeedback> tblGSTRatingandFeedbacks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblGSTWallet> tblGSTWallets { get; set; }
    }
}
