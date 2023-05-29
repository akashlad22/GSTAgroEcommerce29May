using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroEcommerceLibrary.Admin
{
    public class Admin
    {

        public List<Admin> admins { get; set; }
        public List<Admin> Category { get; set; }
        public List<Admin> Products { get; set; }

        public List<Admin> Buyers { get; set; }
        public List<Admin> BuyerOrders { get; set; }
        public List<Admin> LstOrder { get; set; }
        public List<Admin> Statuslst { get; set; }
        public List<Admin> ListUser { get; set; }

        public List<Admin> CategoryGrid { get; set; }


        [Display(Name = "Admin Full Name")]
        public string AdminFullName { get; set; }

        public int AdminId { get; set; }
        [DisplayName("Buyer Name")]
      
        public string BuyerFullName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        [DisplayName("Buyer Code")]
        public string BuyerCode { get; set; }
        [DisplayName("Total Order")]
        public int TotalOrder { get; set; }
        [Display(Name = "Process Date ")]
        public DateTime ProcessDate { get; set; }
        [Display(Name = "Process Date ")]
        public string Date { get; set; }
        public string OrderCode { get; set; }
        [Display(Name = "Total Amount")]
        public string TotalAmount { get; set; }
        public int ProductQuantity { get; set; }
        [Display(Name = "Address")]
        public string HomeAddress { get; set; }
        [Display(Name = "Shipping Charges")]
        public int ShippingCharges { get; set; }
        [Display(Name = "Product Weight")]
        public string ProductWeight { get; set; }
        public string PaymentMode { get; set; }
        public string TransactionId { get; set; }
        public string AlternateMobileNo { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public int PinCode { get; set; }
        public int StatusId { get; set; }

      

        //[DisplayName("Product Name")]
        //public string ProductName { get; set; }
        //[DisplayName("Image")]
        //public string MainImage { get; set; }

        public float Quantity { get; set; }
      
        public string Status { get; set; }
      //  public int CategoryId { get; set; }
        public string SellerName { get; set; }
        //[DisplayName("Manufacturer Name")]
        //public string ManufacturerName { get; set; }


        ///////////---------sagar-------///////////////
        public int CategoryId { get; set; }
     
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public float Commision { get; set; }
        //public string CategoryCode { get; set; }

        public List<Admin> LstCat { get; set; }
        public List<Admin> LstSubCat1 { get; set; }
        public List<Admin> LstSubCat2 { get; set; }


        [Display(Name = "Category Code")]
        public string CategoryCode { get; set; }
     
        [Display(Name = "Sub-Category1 Code")]
        public string SubCategory1Code { get; set; }
        [Display(Name = "Sub-Category1 Name")]
        public string SubCategory1Name { get; set; }
        [Display(Name = "Sub-Category2 Code")]
        public string SubCategory2Code { get; set; }
        [Display(Name = "Sub-Category2 Name")]
        public string SubCategory2Name { get; set; }
      




        //  public int AdminId { get; set; }
        public string FullName { get; set; }
       // public string EmailId { get; set; }
        [Display(Name = "Mobile No.")]
        public string MobileNo { get; set; }
        //public string AlternateMobileNo { get; set; }
        //public string Photo { get; set; }
        //public string Address { get; set; }
        //public int CityId { get; set; }
        //public int PinCode { get; set; }
        //public int StatusId { get; set; }
        public int SellerId { get; set; }
        public List<Admin> LstSeller { get; set; }
        [Display(Name = "Seller Code")]
        public string SellerCode { get; set; }
        [Display(Name = "Seller Full Name")]
        public string SellerFullName { get; set; }
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }
        [Display(Name = "Aadhar No")]
        //public string MobileNo { get; set; }
        public string AadharNo { get; set; }
        [Display(Name = "Aadhar Image")]
        public string AadharImage { get; set; }
        [Display(Name = "Business Aadhar No")]
        public string BusinessAadharNo { get; set; }
        [Display(Name = "Business Aadhar Image")]
        public string BusinessAdharImage { get; set; }
        [Display(Name = "Business Pan No")]
        public string BusinessPanNo { get; set; }
        [Display(Name = "Business Pan Image")]
        public string BusinessPanImage { get; set; }
        [Display(Name = "Pan Card No")]
        public string PanCardNo { get; set; }
        [Display(Name = "Pan Card Image")]
        public string PanImage { get; set; }
        public string GSTIN { get; set; }

        public string Gender { get; set; }  
        public List<Admin> LstProduct { get; set; }
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        //public string SellerFullName { get; set; }
        //public string MobileNo { get; set; }
        [Display(Name = "Office Address")]
        public string OfficeAddress { get; set; }

       // public string Status { get; set; }
        [Display(Name = "Rejection Reason")]
        public string RejectionReason { get; set; }
       // public int StatusId { get; set; }
        public float MRP { get; set; }
        [Display(Name = "Maximum Stock")]
        public float MaximumStock { get; set; }
        [Display(Name = "Minimum Stock")]
        public float MinimumStock { get; set; }
        [Display(Name = "Product Image")]
        public string MainImage { get; set; }
        public string Description { get; set; }
        [Display(Name = "Is Product Returnable")]
        public bool IsProductReturnable { get; set; }
        [Display(Name = "Is Product Expirable")]
        public bool IsProductExpirable { get; set; }
        [Display(Name = "Product Expiry Duration")]
        public string ProductExpiryDuration { get; set; }
        [Display(Name = "Product Registration Date")]
        public DateTime ProductRegistrationDate { get; set; }
        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; }
        ///////////---------sagar end-----////////////
        public DateTime ProductApprovalDate { get; set; }
        public DateTime SellerApprovalDate { get; set; }



        [Required(ErrorMessage = "Coupon Code Required")]
        [DisplayName("Coupon Code")]
        public string CouponCode { get; set; }
        [Required(ErrorMessage = "Coupon Amount Required")]
        [DisplayName(" Coupon Amount")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Amount")]

        public int CouponAmount { get; set; }
        [Required(ErrorMessage = "Coupon Min Amount Required")]
        [DisplayName(" Coupon min Amount")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Amount")]

        public int CouponMinimumAmount { get; set; }
        public int CouponId { get; set; }
        public string CouponRange { get; set; }
        [Required(ErrorMessage = "Coupon Max Amount Required")]
        [DisplayName(" Coupon Max Amount")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Amount")]

        public int CouponMaximumAmount { get; set; }
        [Required(ErrorMessage = "Coupon Expriry days Required")]
        [DisplayName(" Expiry Days ")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Days")]

        public string Expirydays { get; set; }
        public int WalletId { get; set; }
        public int RewardId { get; set; }
        public int rewid { get; set; }
        [Required(ErrorMessage = "Reward Min Amount Required")]


        [DisplayName(" Reward min Amount")]
        public int RewardMinimumAmount { get; set; }
        [Required(ErrorMessage = "Reward Max Amount Required")]
        [DisplayName(" Reward Max Amount")]
        public int RewardMaximumAmount { get; set; }
        [Required(ErrorMessage = "Reward Point Max Limit Required")]
        [DisplayName(" Reward Point Max Limit ")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Amount")]

        public int PointLimits { get; set; }
        [DisplayName("Reward Range")]
        public string RewardRange { get; set; }
        [Required(ErrorMessage = "Reward Conversion Rate Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Amount")]

        [DisplayName(" Reward Conversion Rate ")]
        public float RewardConversionRate { get; set; }
        [Required(ErrorMessage = "Reward Point Required")]
        [DisplayName(" Reward point")]
        public int RewardPoints { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public decimal Total { get; set; }
        [DisplayName("Total Orders")]
        public string TotalOrders { get; set; }
        [DisplayName("Total Amount Received")]
        public decimal TotalAmountReceived { get; set; }
        [DisplayName("Total Shipping Charges(-)")]
        public decimal TotalShippingCharges { get; set; }
        [DisplayName("Commission to Admin(-)")]
        public string CommissiontoAdmin { get; set; }
        [DisplayName("Paid Amount")]
        public decimal PaidAmt { get; set; }
        [DisplayName("Previous Balance Amount(+)")]
        public decimal PreviousBalanceAmt { get; set; }
        [DisplayName("Total Amount To Pay Seller")]
        public decimal TotalAmountToPaySeller { get; set; }
        [DisplayName("Customer Refunded Amount(-)")]
        public decimal CustomerRefundedAmount { get; set; }
        public decimal RefundedAmount { get; set; }



        public int StateId { get; set; }
        public int CountryId { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        [Display(Name = "State Name")]
        public string StateName { get; set; }

        [Display(Name = "City Name")]
        public string CityName { get; set; }

        public string SubCatagory1Name { get; set; }

        public string SubCatagory2Name { get; set; }



        //public string SubCategory1Code { get; set; }
        //public string SubCategory2Code { get; set; }
        //[Required]
        //[Display(Name = "SubCategory1 Name")]
        //public string SubCategory1Name { get; set; }
        //[Required]
        //[Display(Name = "SubCategory2 Name")]
        //public string SubCategory2Name { get; set; }


        //[Display(Name = "Mobile No.")]
        //public string MobileNo { get; set; }

    }
}
