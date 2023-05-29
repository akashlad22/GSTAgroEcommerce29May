using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroEcommerceLibrary.AccountUser 
{
    public class AccountUser
    {
        ///Admin
        public int AdminId { get; set; }
        public string AdminFullName { get; set; }
       

        //Buyer
        public int BuyerId { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerFullName { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "email is required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string EmailId { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }

        ///Seller
        public int SellerId { get; set; }
        public string SellerCode { get; set; }
        public string SellerFullName { get; set; }
        public string BusinessName { get; set; }
        public int BusinessPinCode { get; set; }
      
    }
}
