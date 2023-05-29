using AgroEcommerceLibrary.Seller;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Collections;
using AgroEcommerceLibrary.Buyer;

namespace GSTAgroEcommerce.Models
{
    public class SellerViewModel
    {
        public IEnumerable<tblGSTOrder> Orders { get; set; }
        public IEnumerable<tblGSTProduct> Products { get; set; }
        public IEnumerable<tblGSTBuyer> Buyers { get; set; }
        public IEnumerable<tblGSTStatu> Statuslist { get; set; }
        public IEnumerable<SellerViewModel> sellerviewmodel { get; set; }

  

        public tblGSTOrder order { get; set; }
        public tblGSTProduct product { get; set; }

        public tblGSTBuyer buyer { get; set; }
        public List<Buyer> lstorder { get; set; }
        /// <summary>
        /// ///////TblOrder
        /// </summary> 
        public string OrderCode { get; set; }
        public string BuyerCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductQuantity { get; set; }
        public Nullable<int> AddressStatus { get; set; }
        public Nullable<int> OrderStatusId { get; set; }
        public Nullable<System.DateTime> ProcessDate { get; set; }
        public Nullable<int> ShippingCharges { get; set; }
        // public Nullable<int> ShareId { get; set; }
        // public Nullable<bool> IsNotify { get; set; }
        //  public Nullable<System.DateTime> ExpectedDeliveryDate { get; set; }
        [Display(Name= "Rejected By")]
         public string RejectedByUserCode { get; set; }
       
        public string RejectionReason { get; set; }
        //  public Nullable<bool> IsDelete { get; set; }



        /// <summary>
        /// //////////TblProduct
        /// </summary>
        public string CategoryCode { get; set; }
        public string ProductName { get; set; }
        // public string Description { get; set; }
        public Nullable<double> Quantity { get; set; }
        //  public Nullable<double> MinRangeDiscount { get; set; }
        public Nullable<double> MRP { get; set; }
        public string SellerCode { get; set; }
        // public Nullable<int> StatusId { get; set; }
        public string ProductWeight { get; set; }
        public Nullable<double> Discount { get; set; }
        //  public Nullable<bool> IsProductReturnable { get; set; }
        //  public Nullable<bool> IsproductExpirable { get; set; }
        //  public string ProductExpiryDuration { get; set; }
        //  public Nullable<bool> IsProductSeasonable { get; set; }
        //  public string SeasonName { get; set; }
        //  public string ProductWeightRange { get; set; }
        //  public Nullable<System.DateTime> ProductRegistrationDate { get; set; }
        //  public Nullable<System.DateTime> ProductApprovalDate { get; set; }
        // public string ManufacturerName { get; set; }
        //  public Nullable<double> MaximumStock { get; set; }
        //  public Nullable<double> MinimumStock { get; set; }
        //  public string RejectionReasonfromAdmin { get; set; }
        public virtual tblGSTStatu tblGSTStatu { get; set; }


        /// <summary>
        /// ///////////TBLBuyers
        /// </summary>
        [Display(Name = "Buyer Name")]
        public string BuyerFullName { get; set; }
        public string EmailId { get; set; }
        //  public string Password { get; set; }
        public string MobileNo { get; set; }
        //  public string AlternateMobileNo { get; set; }
        //  public Nullable<int> CityId { get; set; }
        //  public Nullable<System.DateTime> DOB { get; set; }
        //  public string Gender { get; set; }
        //public string AadhaarNo { get; set; }
        //public string PanCardNo { get; set; }
        //public string AdharPhoto { get; set; }
        //public string PanCardPhoto { get; set; }
        //public Nullable<double> Salary { get; set; }
        //public Nullable<System.DateTime> RegistrationDate { get; set; }

        /// <summary>
        /// ///////tblBuyerPayment
        /// </summary>
        public int PaymentId { get; set; }
        public string PaymentMode { get; set; }

        public Nullable<System.DateTime> PaymentDate { get; set; }

        public Nullable<int> StatusId { get; set; }
        public string TransactionId { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public virtual tblGSTBuyer tblGSTBuyer { get; set; }

        public decimal Total { get; set; }
        /// <summary>
        /// ///tblStatus
        /// </stri>
        public string Date { get; set; }
       // public int StatusId { get; set; }
        public string Status { get; set; }

        /////////////
        ///TblGSt ProductImage <summary>
        /// TblGSt ProductImage
        /// </summary>        /////////
        [Display(Name = "Product Image")]
        public string MainImage { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }

        public string  Address { get; set; }
    }
}