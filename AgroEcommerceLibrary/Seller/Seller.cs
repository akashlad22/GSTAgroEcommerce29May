using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroEcommerceLibrary.Seller
{
    public class Seller
    {


        ////////////indrajeet start//////
        public string SellerCode { get; set; } 
        [Required(ErrorMessage = "Name is required")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 3)]
        // [RegularExpression(@"^[a - zA - Z] * $", ErrorMessage = "Please enter correct Name")]
        [Display(Name = "Seller FullName")]
        public string SellerFullName { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter BusinessName"), MaxLength(30)]
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }
        [Display(Name = "Business PinCode")]
        public int BusinessPinCode { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Password")]
        [StringLength(10, MinimumLength = 4)]

        public string Password { get; set; }
        [Required(ErrorMessage = "Contact is required")]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]

        public string MobileNo { get; set; }
        public string Gender { get; set; }
        public int CityId { get; set; }
        public int PinCode { get; set; }
        // public string RejectionReasonFromAdmin { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        public DateTime RegistrationDate { get; set; }
        [Required(ErrorMessage = "AlternateMobileNo is required")]
        [Display(Name = "Alternate MobileNo")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]

        public string AlternateMobileNo { get; set; }
        public int StatusId { get; set; }
      
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
        [Display(Name = "State Name")]
        public string StateName { get; set; }
        [Required(ErrorMessage = "HomeAddress is required")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Home Address")]
        public string Home { get; set; }
        [Required(ErrorMessage = "OfficeAddress is required")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Office Address")]
        public string Office { get; set; }
        [Required(ErrorMessage = "OtherAddress is required")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Other Address")]
        public string Other { get; set; }

        public DateTime SellerApprovalDate { get; set; }

        /////tblSellerPayment
        public int SellerPaymentId { get; set; }
        public string PaymentMode { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaidAmount { get; set; }
        public string TransactionId { get; set; }
        public string PaymentDoneFile { get; set; }
        public bool IsDelete { get; set; }
        ///tblProduct
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        [Required]
        public string CategoryCode { get; set; }
        //public string ProductName { get; set; }
       //
       //public string Description { get; set; }
      //  public double CurrentStock { get; set; }
       // public double MinRangeDiscount { get; set; }
       // public double MRP { get; set; }
       // public double ProductWeight { get; set; }

       // public double Discount { get; set; }
       // public bool IsProductReturnable { get; set; }
       // public bool IsproductExpirable { get; set; }
      //  public string PrductExpiryDuration { get; set; }
      //  public bool IsProductSeasonable { get; set; }
       // public string SeasonName { get; set; }
        // public string ProductWeightRange { get; set; }
       // public DateTime ProductRegistrationDate { get; set; }
       // public DateTime ProductApprovalDate { get; set; }
       // public string ManufacturerName { get; set; }
       // public double MaximumStock { get; set; }
       // public double MinimumStock { get; set; }
       // public string RejectionReasonfromAdmin { get; set; }

        ////tblTransactionSeller

        public int SellerTransactionId { get; set; }
        public double TotalAmount { get; set; }
        public double PartialPayment { get; set; }
        public int TotalOrder { get; set; }

        ///tblSellerDocument

        public int SellerDocumentId { get; set; }
        [Required(ErrorMessage = "Aadhaar Number is required.")]
        [RegularExpression(@"^([0-9]{4}[0-9]{4}[0-9]{4}$)|([0-9]{4}\s[0-9]{4}\s[0-9]{4}$)|([0-9]{4}-[0-9]{4}-[0-9]{4}$)", ErrorMessage = "Invalid Aadhaar Number.")]

        public string AadharNo { get; set; }
        [Required(ErrorMessage = "PancardNo is required")]

        [StringLength(15, MinimumLength = 10)]
        public string PanCardNo { get; set; }
        public string AadharImage { get; set; }

        public string PanImage { get; set; }
        [Required(ErrorMessage = "GSTIN is required")]

        [StringLength(15, MinimumLength = 10)]
        public string GSTIN { get; set; }
        [Required(ErrorMessage = "BusinessAadhaar Number is required.")]
        [RegularExpression(@"^([0-9]{4}[0-9]{4}[0-9]{4}$)|([0-9]{4}\s[0-9]{4}\s[0-9]{4}$)|([0-9]{4}-[0-9]{4}-[0-9]{4}$)", ErrorMessage = "Invalid Aadhaar Number.")]

        public string BusinessAadharNo { get; set; }
        [Required(ErrorMessage = "BusinessPanNo is required")]

        [StringLength(15, MinimumLength = 10)]

        public string BusinessPanNo { get; set; }
        public string BusinessAdharImage { get; set; }
        public string BusinessPanImage { get; set; }



        ////////////indrajeet end////////

        //[Required]
        //public string CategoryCode { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Required]
        public string SubCategory1Code { get; set; }
        [Required]
        [Display(Name = "SubCategory1 Name")]
        public string SubCategory1Name { get; set; }
        [Required]
        public string SubCategory2Code { get; set; }
        [Required]
        [Display(Name = "SubCategory2 Name")]
        public string SubCategory2Name { get; set; }
        public string SubCategory3Code { get; set; }
        public string SubCategory3Name { get; set; }
      
       

        [Required(ErrorMessage = "Product Name Is Required")]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Description Is Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Product Current Stock Is Required")]
        [DisplayName("Current Stock")]
        public float CurrentStock { get; set; }
        [Required(ErrorMessage = "Product Discount Is Required (in Kg or Ltr)")]
        [DisplayName("Min Range Discount (Rs)")]
        public double MinRangeDiscount { get; set; }
        [Required(ErrorMessage = "Product MRP Is Required")]
        [DisplayName("MRP(Rs)")]
        public float MRP { get; set; }
        [Required(ErrorMessage = "Product Weight Is Required")]
        [DisplayName("Product Weight (in Kg or Ltr)")]
        public string ProductWeight { get; set; }
        [Required(ErrorMessage = "Product Discount Is Required")]

        public float Discount { get; set; }
        [Required(ErrorMessage = "Product Retunable Is Required")]
        [DisplayName("Product Returnable")]
        public string ProductReturnable { get; set; }
        [Required(ErrorMessage = "Product Expirable Is Required")]
        [DisplayName("Product Expirable")]
        public string productExpirable { get; set; }
        // [Required(ErrorMessage = "Product Seasonable Is Required")]
        [DisplayName("Product seasonable")]
        public string ProductSeasonable { get; set; }
        [Required(ErrorMessage = "Product Returnable Is Required")]

        [DisplayName("Product Returnable")]
        public bool IsProductReturnable { get; set; }
        [Required(ErrorMessage = "Product Expirable Is Required")]
        [DisplayName("Product Expirable")]
        public bool IsproductExpirable { get; set; }
        [DisplayName("Product Expiry Duration")]
        public string PrductExpiryDuration { get; set; }
        [DisplayName("Product Seasonable")]
        public bool IsProductSeasonable { get; set; }
        [DisplayName("Season Name")]
        public string SeasonName { get; set; }
        // public string ProductWeightRange { get; set; }
        [DisplayName("Product Registration Date")]
        public string ProductRegiDate { get; set; }
        [DisplayName("Product Registration Date")]
        public DateTime ProductRegistrationDate { get; set; }
        [DisplayName("Product Approval Date")]

        public DateTime ProductApprovalDate { get; set; }
        [DisplayName("Manuifacture Name")]
        [Required(ErrorMessage = "Product Manufacturer name Is Required")]
        public string ManufacturerName { get; set; }
        [DisplayName("Maximum Stock (in Kg or Ltr)")]
        [Required(ErrorMessage = "Product maximum Is Required")]
        public double MaximumStock { get; set; }
        [Required(ErrorMessage = "Product minimum Is Required ")]
        [DisplayName("Product Minimum Stock (in Kg or Ltr)")]
        public double MinimumStock { get; set; }
        [DisplayName(" Rejection Reason from Admin ")]
        public string RejectionReasonfromAdmin { get; set; }




     
        [DataType(DataType.Date)]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }
        public int OfferId { get; set; }
        // public int StatusId { get; set; }
        public int AdminOfferId { get; set; }
        public string OfferName { get; set; }
        [Display(Name = "Main Image")]
        public string MainImage { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public float Commision { get; set; }
        
        public string RejectionReason { get; set; }
       
        public List<Seller> Product { get; set; }
        [DisplayName("Product Weight Range (in Kg)")]
        public string ProductWeightRange { get; set; }


        public string OrderCode { get; set; }

        [Display(Name = "Buyer Name")]
        public string BuyerFullName { get; set; }
        public Nullable<System.DateTime> ProcessDate { get; set; }
        public string Status { get; set; }
        public string ProductQuantity { get; set; }

        public Nullable<int> OrderStatusId { get; set; }

        public Nullable<int> AddressStatus { get; set; }
        public string Address { get; set; }
        [Display(Name = "Rejected By")]
        public string RejectedByUserCode { get; set; }
        public string Date { get; set; }


        public string SellerType { get; set; }

        [Required(ErrorMessage = "Bank Holder Name is required")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[a - zA - Z] * $", ErrorMessage = "Please enter correct Name")]
        [Display(Name = "Bank Holder Name")]

        public string BankHolderName { get; set; }
        [Required(ErrorMessage = "Bank Name is required")]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 3)]
        // [RegularExpression(@"^[a - zA - Z] * $", ErrorMessage = "Please enter correct Name")]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Display(Name = "IFSC Code")]
        [Required(ErrorMessage = "IFSC Code is required")]
        public string IFSCCode { get; set; }
        [Display(Name = "Branch Name")]
        [Required(ErrorMessage = "Branch Name is required")]
        public string BrachName { get; set; }
        public string AccountType { get; set; }
        [Required(ErrorMessage = "Account Number is required")]
        [Display(Name = "Account Number")]

        [StringLength(15, MinimumLength = 10)]
        public string AccountNo { get; set; }
        public int BankdetailsId { get; set; }

        //----------------------BankDetail end-------
    }
}
