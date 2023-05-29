using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AgroEcommerceLibrary.Buyer
{
    public class Buyer
    {
        public List<Buyer> category { get; set; }
        public List<Buyer> MenuSubcategory { get; set; }
       public List<Buyer> MenuCategory { get; set; }
        public List<Buyer> megamenuproducts { get; set; }
        public List<Buyer> products { get; set; }
        public List<Buyer> Wishlist { get; set; }
        public List<Buyer> CatProd { get; set; }
        public List<Buyer> Buyers { get; set; }
        public List<Buyer> lstbuyer { get; set; }
        //Vitthal//
        [Required(ErrorMessage = "Please Enter Full Name")]
        [Display(Name = "Full Name")]
        public string BuyerFullName { get; set; }
        // public string EmailId { get; set; }
        // public string Password { get; set; }
        [Required(ErrorMessage = "Mobile No is required")]

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Select Address Type")]
        public string AddressType { get; set; }


        [Display(Name = "City ")]
        [Required(ErrorMessage = "Please select City ")]

        public int CityId { get; set; }
        [Display(Name = "HouseNo , Building Name")]
        [Required(ErrorMessage = "Please Fill HouseNo or building Name ")]
        public string HouseNo { get; set; }
       // public string ManufacturerName { get; set; }
        public string producttotalprice { get; set; }
        public decimal Discount { get; set; }
        public decimal discountprice { get; set; }
        public decimal SubTotal { get; set; }

        //Prathamesh//
        public List<Buyer> BestSeller { get; set; }
        public List<Buyer> Season { get; set; }
        //Prathamesh//

        ///  Login property/// 
        public string ReturnUrl { get; set; }
        public List<AuthenticationSchemes> ExternalLogin { get; set; }


        public int BuyerId { get; set; }
        public string BuyerCode { get; set; }
       // public string BuyerFullName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = " Enter Valid Email Required")]
        public string EmailId { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
       // public string MobileNo { get; set; }
       // public string Addresstype { get; set; }
        public string AlternaterMobileNo { get; set; }
         [DataType(DataType.Date)]
        [Display(Name="Date Of Birth")]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        [Display(Name = "AadhaarNo")]
        [Required(ErrorMessage = "Aadhaar Number is required.")]
        [RegularExpression(@"^([0-9]{4}[0-9]{4}[0-9]{4}$)|([0-9]{4}\s[0-9]{4}\s[0-9]{4}$)|([0-9]{4}-[0-9]{4}-[0-9]{4}$)", ErrorMessage = "Invalid Aadhaar Number.")]
        public string AadhaarNo { get; set; }
        [Display(Name = "PanCardNo")]
        [Required(ErrorMessage = "PanCardNo is required")]

        [StringLength(15, MinimumLength = 10)]
        public string PanCardNo { get; set; }
        [Required]
        [Display(Name = "AadhaarPhoto")]
        [AlllowFileSize()]
        public string AadhaarPhoto { get; set; }
        public string PanCardPhoto { get; set; }
        public float Salary { get; set; }
        public DateTime RegistrationDate { get; set; }

        ////////// //tblOrder
        public int OrderId { get; set; }
        //public string OrderNo { get; set; }
        public string OrderCode { get; set; }

        // public string BuyerCode { get; set; }
        public int MyProperty { get; set; }
        public string ProductCode { get; set; }

        public int ProductQuantity { get; set; }
        public int AddressId { get; set; }
        public int OrderStatusId { get; set; }
        [Display(Name = "Process Date ")]
        public DateTime ProcessDate { get; set; }
        public int Total { get; set; }      //

        ///Address prop
        public string Home { get; set; }
        public string Office { get; set; }
        public string Other { get; set; }
        [Display(Name = "Delivery Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter your Landmark")]

        public string Landmark { get; set; }
        [RegularExpression(@"^[0-9]{6,6}$", ErrorMessage = "Please Enter 6 Digit Pin code")]

        public int PinCode { get; set; }
        [Display(Name = "Country ")]
        public int CountryId { get; set; }

        public string CountryName { get; set; }
        [Display(Name = "State ")]
        public int StateId { get; set; }

        public string StateName { get; set; }

        public string CityName { get; set; }

        public int ShippingCharges { get; set; }
        public bool IsDelete { get; set; }
        public int ShareId { get; set; }
        public bool IsNotify { get; set; }
        [Display(Name = "Expected Delivery Date")]
        public DateTime ExpectedDeliveryDate { get; set; }
        public string RejectedByUserCode { get; set; }
        public string RejectionReason { get; set; }
        public string Sort { get; set; }  

        /////tblBuyerPayment

        public int PaymentId { get; set; }
        public string PaymentMode { get; set; }
        public DateTime PaymentDate { get; set; }
        public int StatusId { get; set; }
        public string TransactionId { get; set; }
        public string InvoiceNo { get; set; }

        /// </summary>
        //////Wallet
        public int WalletId { get; set; }
        public int RewardId { get; set; }
        public int TotalRewardPoints { get; set; }
        public int UseedRewardPoints { get; set; }
        public string CouponCode { get; set; }
        /// <vitthal>

        public decimal RewardConversionRate { get; set; }
        public int PointLimits { get; set; }
        public DateTime coupanexpdate { get; set; }
        public int CoupanPrice { get; set; }
        public int Reward { get; set; }
        /// </vitthal>
      

        ////RatingAndFeedback
        public int ReviewId { get; set; }
        public int RatingStarNo { get; set; }
        public string FeedbackOnProduct { get; set; }


        /// Product

        public int ProductId { get; set; }
        //public string ProductCode { get; set; }
        public string CategoryCode { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; }    //
        public string Description { get; set; }
        public Decimal MRP { get; set; }
        [Display(Name = "Product Image")]
        public string MainImage { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }

        public string ProductWeight { get; set; }
        public bool IsproductExpirable { get; set; }
        public bool IsProductReturnable { get; set; }
        public float Quantity { get; set; }


        //Category

        //public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        //public string CategoryCode { get; set; }

        //public int StatusId { get; set; }
        public float Commission { get; set; }
        //public string RejectionReason { get; set; }

        ///SubCategory
        public int SubCategory1Id { get; set; }
        public string SubCatagory1Name { get; set; }
        public string SubCategory1Code { get; set; }

        public int SubCategory2Id { get; set; }
        public string SubCategory2Name { get; set; }
        public string SubCategory2Code { get; set; }

        public int SubCategory3Id { get; set; }
        public string SubCategory3Name { get; set; }
        public string SubCategory3Code { get; set; }
        ///Dhanashri start
        public List<Buyer> Statuslst { get; set; }
        public List<Buyer> Users { get; set; }
        ///tblStatus
        public string Status { get; set; }
        ////Policy
        public string PolicyDescriptionPdf { get; set; }
        ///tblCoupon <summary>
        public int CouponAmount { get; set; }      //

        public string CouponRange { get; set; }
        public string ExpiryDays { get; set; }
        public string date { get; set; }
        public string DeliveryDate { get; set; }
        public DateTime CouponExpDate { get; set; }
        public string TotalPoints {get; set;} 
        ///Dhanashri end
    }
}
