using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AgroEcommerceLibrary.Seller;
using AgroEcommerceLibrary.Buyer;
using AgroEcommerceLibrary.Admin;
using System.Collections;
using GSTAgroEcommerce.Models;
using System.Web.UI.WebControls.Expressions;
using Owin;
using Microsoft.Owin.BuilderProperties;
using System.Web.WebPages;

namespace GSTAgroEcommerce.Controllers
{
    
    public class SellerController : Controller
    {
        Entities dbcontext =new Entities(); 

        string Code;
        BALSeller obj = new BALSeller();
        // GET: Seller
        [HttpGet]
        public ActionResult Index()
        {

            TodayOrder();
            pendingOrder();
            ReturnOrder();
            ReplaceOrder();
            CancelOrder();
            productApprovel();
            Rejected();
           
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Registration()
        {
            Country_Bind();
            var list = new List<string>() { "Farmer ", "Shopkeeper", "Retailers", "Manufacturers" };
            ViewBag.list = list;

            return await Task.Run(() => View());

        }
        [HttpPost]
        public async Task<ActionResult> Registration(Seller Obj, HttpPostedFileBase Photo, HttpPostedFileBase AadharImage, HttpPostedFileBase Pancard, HttpPostedFileBase businessAdhar, HttpPostedFileBase BusinessPan)
        {
            BALSeller objseller = new BALSeller();
            SqlDataReader drs;
            drs = objseller.getGmail(Obj);
            BALSeller objbuyer = new BALSeller();
            SqlDataReader drb;
            drb = objbuyer.getGmailb(Obj);
            if (drs.HasRows || drb.HasRows)
            {
                // ViewBag.Message = "Registration Already Created...!";
                TempData["EmailError"] = "Your Registration Email Already Exist!!!";
                //return await Task.Run(() => View("Registration"));
            }
            else
            {

                Seller_Code();
                Obj.SellerCode = Code;
                DateTime DOB = Obj.DOB;
                Obj.RegistrationDate = DateTime.Now;
                if (Photo != null && Photo.ContentLength > 0)
                {

                    //string[] str = { "abc.png", "im.jpg", "abc.jpeg" };
                    string image = Path.GetFileName(Photo.FileName);
                    string path = Server.MapPath("~/Content/SellerImage");
                    string imgpath = Path.Combine(path, image);
                    Photo.SaveAs(imgpath);


                }
                if (AadharImage != null && AadharImage.ContentLength > 0)
                {
                    string adharimage = Path.GetFileName(AadharImage.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/Content/SellerDoc"), adharimage);
                    AadharImage.SaveAs(imgpath);

                    Obj.AadharImage = adharimage;

                }
                if (Pancard != null && Pancard.ContentLength > 0)
                {
                    string panimage = Path.GetFileName(Pancard.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/Content/SellerDoc"), panimage);
                    Pancard.SaveAs(imgpath);
                    Obj.PanImage = panimage;
                }
                if (businessAdhar != null && businessAdhar.ContentLength > 0)
                {
                    string badharimage = Path.GetFileName(businessAdhar.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/Content/SellerDoc"), badharimage);
                    businessAdhar.SaveAs(imgpath);
                    Obj.BusinessAdharImage = badharimage;
                }
                if (BusinessPan != null && BusinessPan.ContentLength > 0)
                {
                    string bPanimag = Path.GetFileName(BusinessPan.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/Content/SellerDoc"), bPanimag);
                    BusinessPan.SaveAs(imgpath);
                    Obj.BusinessPanImage = bPanimag;
                }

                BALSeller obj = new BALSeller();


                obj.SellerReg(Obj);
                obj.SellerRegAdd(Obj);
                obj.SellerBankDetail(Obj);
                obj.SellerAddDoc(Obj);
            }

            return await Task.Run(() => RedirectToAction("Registration", "Seller"));
            //return View();
        }
        public JsonResult City_Bind(int State_Id)

        {

            BALSeller obj = new BALSeller();
            DataSet ds = obj.GetCity(State_Id);
            List<SelectListItem> CityList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                CityList.Add(new SelectListItem
                {
                    Text = dr["cityName"].ToString(),
                    Value = dr["CityId"].ToString()
                });
            }
            // ViewBag.StateName = StatesList;
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }
        public void Country_Bind()
        {
            BALSeller obj = new BALSeller();
            DataSet ds = obj.GetCountry();
            List<SelectListItem>
                CountryList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                CountryList.Add(new SelectListItem
                {
                    Text = dr["CountryName"].ToString(),
                    Value = dr["CountryId"].ToString()
                });
            }
            ViewBag.Country = CountryList;
        }
        public JsonResult State_Bind(int Country_Id)
        {
            Seller Obj = new Seller();
            BALSeller obj = new BALSeller();
            DataSet ds = obj.GetState(Country_Id);
            List<SelectListItem>
                StatesList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                StatesList.Add(new SelectListItem
                {
                    Text = dr["StateName"].ToString(),
                    Value = dr["StateId"].ToString()
                });
            }
            // ViewBag.StateName = StatesList;
            return Json(StatesList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Seller_Code()

        {
            Seller obj = new Seller();

            BALSeller obj1 = new BALSeller();
            SqlDataReader dr;
            dr = obj1.SellerCode();
            while (dr.Read())
            {
                int SellerCode = Convert.ToInt32(dr["Id"].ToString());
                SellerCode = SellerCode + 1;
                String Id = "S0";
                Code = Id + SellerCode;
            }
            dr.Close();
            return View(obj);
        }

        //--------------------------------------seller controoler--------dashborad-----------//
        public ActionResult TodayOrder()

        {
            Seller sellercode = new Seller();
            sellercode.SellerCode = Session["SellerCode"].ToString();

            BALSeller obj1 = new BALSeller();
            SqlDataReader dr;
            dr = obj1.TodayOrder(sellercode);
            while (dr.Read())
            {
                //ViewBag.TodayOrder = Convert.ToInt32(dr["TodayOrder"].ToString());
                Session["TodayOrder"] = (dr["TodayOrder"].ToString());

            }
            dr.Close();
            return View();

        }
        public ActionResult pendingOrder()

        {
            Seller sellercode = new Seller();
            sellercode.SellerCode = Session["SellerCode"].ToString();

            BALSeller obj1 = new BALSeller();
            SqlDataReader dr;
            dr = obj1.pendingOrder(sellercode);
            while (dr.Read())
            {
                //ViewBag.TodayOrder = Convert.ToInt32(dr["TodayOrder"].ToString());
                Session["PendingOrder"] = (dr["PendingOrder"].ToString());

            }
            dr.Close();
            return View();

        }
        public ActionResult ReturnOrder()

        {
            Seller sellercode = new Seller();
            sellercode.SellerCode = Session["SellerCode"].ToString();

            BALSeller obj1 = new BALSeller();

            SqlDataReader dr;
            dr = obj1.ReturnOrder(sellercode);
            while (dr.Read())
            {
                //ViewBag.TodayOrder = Convert.ToInt32(dr["TodayOrder"].ToString());
                Session["ReturnOrder"] = (dr["ReturnOrder"].ToString());

            }
            dr.Close();
            return View();

        }
        public ActionResult ReplaceOrder()

        {
            Seller sellercode = new Seller();
            sellercode.SellerCode = Session["SellerCode"].ToString();

            BALSeller obj1 = new BALSeller();
            SqlDataReader dr;
            dr = obj1.ReplaceOrder(sellercode);
            while (dr.Read())
            {
                Session["RePlacedOrder"] = (dr["RePlacedOrder"].ToString());

            }
            dr.Close();
            return View();

        }
        public ActionResult CancelOrder()

        {
            Seller sellercode = new Seller();
            sellercode.SellerCode = Session["SellerCode"].ToString();

            BALSeller obj1 = new BALSeller();
            SqlDataReader dr;
            dr = obj1.CancelOrder(sellercode);
            while (dr.Read())
            {
                Session["CancelledOrder"] = (dr["CancelledOrder"].ToString());

            }
            dr.Close();
            return View();

        }
        public ActionResult productApprovel()

        {
            Seller sellercode = new Seller();
            sellercode.SellerCode = Session["SellerCode"].ToString();

            BALSeller obj1 = new BALSeller();
            SqlDataReader dr;
            dr = obj1.productApprovel(sellercode);
            while (dr.Read())
            {
                Session["ProductPendingforApprovel"] = (dr["ProductPendingforApprovel"].ToString());

            }
            dr.Close();
            return View();

        }
        public ActionResult Rejected()

        {
            Seller sellercode = new Seller();
            sellercode.SellerCode = Session["SellerCode"].ToString();

            BALSeller obj1 = new BALSeller();
            SqlDataReader dr;
            dr = obj1.Reject(sellercode);
            while (dr.Read())
            {
                Session["RejectedProduct"] = (dr["RejectedProduct"].ToString());

            }
            dr.Close();
            return View();

        }
        //--------------------------------------seller controoler--------dashborad end-----------//


        //public async Task<ActionResult> GetAllProduct()
        //{
        //    if (Session["SellerCode"] != null)
        //    {
        //        Seller obj = new Seller();
        //        obj.SellerCode = Session["SellerCode"].ToString();
        //        BALSeller objA = new BALSeller();
        //        DataSet yg = new DataSet();
        //        yg = objA.GetAllProduct(obj);
        //        Seller objS = new Seller();
        //        List<Seller> sellers = new List<Seller>();
        //        for (int i = 0; i < yg.Tables[0].Rows.Count; i++)
        //        {
        //            Seller objB = new Seller();
        //            objB.MainImage = yg.Tables[0].Rows[i]["MainImage"].ToString();
        //            objB.SellerCode = yg.Tables[0].Rows[i]["SellerCode"].ToString();
        //            objB.ProductCode = yg.Tables[0].Rows[i]["ProductCode"].ToString();
        //            objB.ProductName = yg.Tables[0].Rows[i]["ProductName"].ToString();
        //            // objB.Description = yg.Tables[0].Rows[i]["Description"].ToString();
        //            objB.CurrentStock = Convert.ToInt32(yg.Tables[0].Rows[i]["Quantity"].ToString());
        //            objB.MRP = Convert.ToInt32(yg.Tables[0].Rows[i]["MRP"].ToString());
        //            objB.ProductWeight = yg.Tables[0].Rows[i]["ProductWeight"].ToString();
        //            //     objB.Discount = Convert.ToInt32(yg.Tables[0].Rows[i]["Discount"].ToString());
        //            //  objB.IsproductExpirable = (yg.Tables[0].Rows[i]["IsproductExpirable"].ToString());
        //            //  objB.PrductExpiryDuration = Convert.ToInt32(yg.Tables[0].Rows[i]["PrductExpiryDuration"].Tostring());
        //            // objB.ProductRegistrationDate = Convert.ToDateTime(yg.Tables[0].Rows[i]["ProductRegistrationDate"].ToString());
        //            // objB.ProductApprovalDate = Convert.ToDateTime(yg.Tables[0].Rows[i]["ProductApprovalDate"].ToString());
        //            objB.ManufacturerName = yg.Tables[0].Rows[i]["ManufacturerName"].ToString();
        //            sellers.Add(objB);

        //        }
        //        ViewBag.MainImage = obj.MainImage;
        //        objS.Product = sellers;
        //        return View(objS);
        //    }
        //    else
        //    {
        //        return await Task.Run(() => RedirectToAction("Login", "Account"));
        //    }
        //}
        [HttpGet]
        public async Task<ActionResult> UpdateProduct(string ProductCode)
        {
            if (Session["SellerCode"] != null)
            {
                Seller objsell = new Seller();
                SqlDataReader dr;
                objsell.ProductCode = ProductCode;
                dr = obj.UpdateProduct(objsell);
                while (dr.Read())
                {
                    objsell.ProductName = dr["ProductName"].ToString();
                    objsell.Description = dr["Description"].ToString();
                    ViewBag.description = dr["Description"].ToString();
                    objsell.CurrentStock = Convert.ToInt32(dr["Quantity"].ToString());
                    objsell.MinRangeDiscount = Convert.ToDouble(dr["MinRangeDiscount"].ToString());
                    objsell.MRP = Convert.ToSingle(dr["MRP"].ToString());
                    objsell.StatusId = Convert.ToInt32(dr["StatusId"].ToString());
                    objsell.ProductWeight = dr["ProductWeight"].ToString();
                    if (dr["Discount"].ToString() != "")
                    {
                        objsell.Discount = Convert.ToSingle(dr["Discount"].ToString());
                    }
                    else { objsell.Discount = 0; }
                    objsell.IsProductReturnable = Convert.ToBoolean(dr["IsProductReturnable"].ToString());
                    if (objsell.IsProductReturnable == true)
                    {
                        objsell.ProductReturnable = "Yes";
                    }
                    else { objsell.ProductReturnable = "No"; }
                    objsell.IsproductExpirable = Convert.ToBoolean(dr["IsproductExpirable"].ToString());
                    if (objsell.IsproductExpirable == true)
                    {
                        objsell.productExpirable = "Yes";
                    }
                    else { objsell.productExpirable = "No"; }
                    objsell.ProductWeightRange = dr["ProductWeightRange"].ToString();
                    objsell.PrductExpiryDuration = dr["ProductExpiryDuration"].ToString();
                    objsell.IsProductSeasonable = Convert.ToBoolean(dr["IsProductSeasonable"].ToString());
                    if (objsell.IsProductSeasonable == true)
                    {
                        objsell.ProductSeasonable = "Yes";
                    }
                    else { objsell.ProductSeasonable = "No"; }
                    objsell.SeasonName = dr["SeasonName"].ToString();
                    objsell.ManufacturerName = dr["ManufacturerName"].ToString();
                    objsell.MaximumStock = Convert.ToInt32(dr["MaximumStock"].ToString());
                    objsell.MinimumStock = Convert.ToInt32(dr["MinimumStock"].ToString());
                    ViewBag.MainImage = dr["MainImage"].ToString();
                    ViewBag.Image1 = dr["Image1"].ToString();
                    ViewBag.Image2 = dr["Image2"].ToString();
                    ViewBag.Image3 = dr["Image3"].ToString();


                }
                return await Task.Run(() => View(objsell));
            }

            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        [HttpPost]
        public async Task<ActionResult> UpdateProduct(Seller objsell)
        {
            if (Session["SellerCode"] != null)
            {
                string prdctexp;
                string prdctseasonable;
                string prdctreturnable;
                prdctexp = objsell.productExpirable.ToLower();
                if (prdctexp == "yes")
                {
                    objsell.IsproductExpirable = true;
                }
                else { objsell.IsproductExpirable = false; }
                prdctseasonable = objsell.ProductSeasonable.ToLower();
                if (prdctseasonable == "yes")
                {

                    objsell.IsProductSeasonable = true;
                }
                else
                {
                    objsell.IsProductSeasonable = false;
                    objsell.SeasonName = "";
                }
                prdctreturnable = objsell.ProductReturnable.ToLower();
                if (prdctreturnable == "yes")
                {
                    objsell.IsProductReturnable = true;
                }
                else { objsell.IsProductReturnable = false; }


                objsell.SellerCode = Session["SellerCode"].ToString();
                obj.UpdateProductInfo(objsell);
                return View();
            }

            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //--------------------------------------PendingGridview-----------------------------------------
        public async Task<ActionResult> PendingProduct(Seller objsell)
        {
            if (Session["SellerCode"] != null)
            {
                objsell.SellerCode = Session["SellerCode"].ToString();
                BALSeller objA = new BALSeller();
                DataSet yg = new DataSet();
                yg = objA.PendingProduct(objsell);
                Seller objS = new Seller();
                List<Seller> sellers = new List<Seller>();
                for (int i = 0; i < yg.Tables[0].Rows.Count; i++)
                {
                    Seller objB = new Seller();
                    objB.MainImage = yg.Tables[0].Rows[i]["MainImage"].ToString();
                    objB.ProductCode = yg.Tables[0].Rows[i]["ProductCode"].ToString();
                    objB.ProductName = yg.Tables[0].Rows[i]["ProductName"].ToString();
                    // objB.Description = yg.Tables[0].Rows[i]["Description"].ToString();
                    objB.CurrentStock = Convert.ToInt32(yg.Tables[0].Rows[i]["Quantity"].ToString());
                    objB.MRP = Convert.ToInt32(yg.Tables[0].Rows[i]["MRP"].ToString());
                    objB.ProductWeight = yg.Tables[0].Rows[i]["ProductWeight"].ToString();
                    //objB.Discount = Convert.ToInt32(yg.Tables[0].Rows[i]["Discount"].ToString());
                    //  objB.IsproductExpirable = (yg.Tables[0].Rows[i]["IsproductExpirable"].ToString());
                    //  objB.PrductExpiryDuration = Convert.ToInt32(yg.Tables[0].Rows[i]["PrductExpiryDuration"].Tostring());
                    //objB.ProductRegistrationDate = Convert.ToDateTime(yg.Tables[0].Rows[i]["ProductRegistrationDate"].ToString());
                    // objB.ProductApprovalDate = Convert.ToDateTime(yg.Tables[0].Rows[i]["ProductApprovalDate"].ToString());
                    objB.ManufacturerName = yg.Tables[0].Rows[i]["ManufacturerName"].ToString();
                    sellers.Add(objB);

                }
                ViewBag.MainImage = objsell.MainImage;
                objS.Product = sellers;
                return View(objS);
            }

            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //-------------------------------------------RejectedProductGridview-------------------------------
        public ActionResult RejectedProduct(Seller obj)
        {
            // string sellercode = "S001";
            BALSeller objA = new BALSeller();
            DataSet yg = new DataSet();
            yg = objA.RejectedProduct(obj);
            Seller objS = new Seller();
            List<Seller> sellers = new List<Seller>();
            for (int i = 0; i < yg.Tables[0].Rows.Count; i++)
            {
                Seller objB = new Seller();
                objB.MainImage = yg.Tables[0].Rows[i]["MainImage"].ToString();
                objB.ProductCode = yg.Tables[0].Rows[i]["ProductCode"].ToString();
                objB.ProductName = yg.Tables[0].Rows[i]["ProductName"].ToString();
                //objB.Description = yg.Tables[0].Rows[i]["Decription"].ToString();
                objB.CurrentStock = Convert.ToInt32(yg.Tables[0].Rows[i]["Quantity"].ToString());
                objB.MRP = Convert.ToInt32(yg.Tables[0].Rows[i]["MRP"].ToString());
                objB.ProductWeight = yg.Tables[0].Rows[i]["ProductWeight"].ToString();
                // objB.Discount = Convert.ToDecimal(yg.Tables[0].Rows[i]["Discount"].ToString());
                //  objB.IsproductExpirable = (yg.Tables[0].Rows[i]["IsproductExpirable"].ToString());
                //  objB.PrductExpiryDuration = Convert.ToInt32(yg.Tables[0].Rows[i]["PrductExpiryDuration"].Tostring());
                //objB.ProductRegistrationDate = Convert.ToDateTime(yg.Tables[0].Rows[i]["ProductRegistrationDate"].ToString());
                // objB.ProductApprovalDate = Convert.ToDateTime(yg.Tables[0].Rows[i]["ProductApprovalDate"].ToString());
                objB.ManufacturerName = yg.Tables[0].Rows[i]["ManufacturerName"].ToString();
                sellers.Add(objB);

            }
            ViewBag.MainImage = obj.MainImage;
            objS.Product = sellers;
            return View(objS);
        }
        //-----------------------------------------------AddOffer----------------------------------
        //[HttpGet]
        //public ActionResult AddOffer(Seller obj2, string SellerCode)
        //{
        //    GetOfferDrop(obj2);
        //    SellerCode = "S001";
        //    Seller obj = new Seller();
        //    obj.SellerCode = SellerCode;
        //    BALSeller obj1 = new BALSeller();
        //    SqlDataReader dr;
        //    dr = obj1.PopOffer(obj.SellerCode);
        //    while (dr.Read())
        //    {
        //        obj.SellerCode = dr["SellerCode"].ToString();
        //        obj.ProductName = dr["ProductName"].ToString();
        //        obj.MRP = Convert.ToInt32(dr["MRP"].ToString());
        //    }
        //    dr.Close();
        //    return PartialView("AddOffer", obj);

        //}
        //[HttpPost]
        //public ActionResult AddOffer(Seller obj)
        //{
        //    BALSeller objA = new BALSeller();
        //    objA.AddOffer(obj.ProductCode, obj.StartDate, obj.EndDate, obj.OfferId, obj.StatusId);
        //    return RedirectToAction("GetAllProduct");
        //}

        public ActionResult AddnewOffer()
        {

            return View();
        }
        [HttpGet] 
        public async Task<ActionResult> DeleteProduct(string ProductCode)
        {
            if (Session["SellerCode"] != null)
            {
                Seller objsell = new Seller();
                objsell.ProductCode = ProductCode;
                obj.DeleteProduct(objsell);
                return await Task.Run(() => RedirectToAction("Seller", "PendingProduct"));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }

        public async Task<ActionResult> DetailProduct(string ProductCode)
        {
            if (Session["SellerCode"] != null)
            {
                Seller objsell = new Seller();
                SqlDataReader dr;
                objsell.ProductCode = ProductCode;
                dr = obj.UpdateProduct(objsell);
                while (dr.Read())
                {
                    objsell.ProductName = dr["ProductName"].ToString();
                    objsell.Description = dr["Description"].ToString();
                    objsell.RegistrationDate = Convert.ToDateTime(dr["ProductRegistrationDate"].ToString());
                    objsell.ProductRegiDate = objsell.RegistrationDate.ToShortDateString();
                    objsell.CurrentStock = Convert.ToInt32(dr["Quantity"].ToString());
                    objsell.MinRangeDiscount = Convert.ToDouble(dr["MinRangeDiscount"].ToString());
                    objsell.MRP = Convert.ToSingle(dr["MRP"].ToString());
                    objsell.RejectionReasonfromAdmin = dr["RejectionReasonfromAdmin"].ToString();
                    //objsell.StatusId = Convert.ToInt32(dr["StatusId"].ToString());
                    objsell.ProductWeight = dr["ProductWeight"].ToString();
                    if (dr["Discount"].ToString() != "")
                    {
                        objsell.Discount = Convert.ToSingle(dr["Discount"].ToString());
                    }
                    else { objsell.Discount = 0; }
                    objsell.IsProductReturnable = Convert.ToBoolean(dr["IsProductReturnable"].ToString());
                    if (objsell.IsProductReturnable == true)
                    {
                        objsell.ProductReturnable = "Yes";
                    }
                    else { objsell.ProductReturnable = "No"; }
                    objsell.IsproductExpirable = Convert.ToBoolean(dr["IsproductExpirable"].ToString());
                    if (objsell.IsproductExpirable == true)
                    {
                        objsell.productExpirable = "Yes";
                    }
                    else { objsell.productExpirable = "No"; }
                    objsell.ProductWeightRange = dr["ProductWeightRange"].ToString();
                    objsell.PrductExpiryDuration = dr["ProductExpiryDuration"].ToString();
                    objsell.IsProductSeasonable = Convert.ToBoolean(dr["IsProductSeasonable"].ToString());
                    if (objsell.IsProductSeasonable == true)
                    {
                        objsell.ProductSeasonable = "Yes";
                    }
                    else { objsell.ProductSeasonable = "No"; }
                    objsell.SeasonName = dr["SeasonName"].ToString();
                    objsell.ManufacturerName = dr["ManufacturerName"].ToString();
                    objsell.MaximumStock = Convert.ToInt32(dr["MaximumStock"].ToString());
                    objsell.MinimumStock = Convert.ToInt32(dr["MinimumStock"].ToString());
                    ViewBag.MainImage = dr["MainImage"].ToString();
                    ViewBag.Image1 = dr["Image1"].ToString();
                    ViewBag.Image2 = dr["Image2"].ToString();
                    ViewBag.Image3 = dr["Image3"].ToString();


                }
                return await Task.Run(() => View(objsell));
            }

            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //public ActionResult GetOfferDrop(Seller obj)
        //{
        //    BALSeller objBal = new BALSeller();
        //    DataSet ds = new DataSet();
        //    ds = objBal.YGGetOffer(obj);
        //    List<SelectListItem> OfferList = new List<SelectListItem>();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        OfferList.Add(new SelectListItem
        //        {
        //            Text = dr["OfferName"].ToString(),
        //            Value = dr["AdminOfferId"].ToString()
        //        });
        //    }
        //    ViewBag.Offer = OfferList;
        //    return RedirectToAction("AddnewOffer");
        //}
        [HttpGet]
        public async Task<ActionResult> AddProductInfo()
        {
            if (Session["SellerCode"] != null)
            {
                
                var list = new List<string>() { "Yes", "No" };
                ViewBag.list = list;
                var Season = new List<string>() { "Summer", "Winter", "Rainy" };
                ViewBag.Season = Season;
                GetCategory();
                return await Task.Run(() => View());
            }

            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddProductInfo(Seller oSel, string ProductWeight, string IsProductReturnable, string IsProductSeasonable, string IsProductExpirable, HttpPostedFileBase MainImage, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3)
        {
            if (Session["SellerCode"] != null)
            {
                oSel.SellerCode = Session["SellerCode"].ToString();
                //ProductCode();
                if (MainImage != null && MainImage.ContentLength > 0)
                {

                    string extension = Path.GetExtension(MainImage.FileName);
                    if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                    {


                        string ImgName = Path.GetFileName(MainImage.FileName);
                        string ImgPath = Path.Combine(Server.MapPath("~/Content/Images/Product"), ImgName);
                        MainImage.SaveAs(ImgPath);
                        oSel.MainImage = ImgName;
                    }
                    else
                    {
                        ViewBag.Errormsg = "Required jpg,jpeg,png images only";
                    }
                }
                if (Image1 != null && Image1.ContentLength > 0)
                {
                    string extension = Path.GetExtension(MainImage.FileName);
                    if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                    {
                        string ImgName1 = Path.GetFileName(Image1.FileName);
                        string ImgPath1 = Path.Combine(Server.MapPath("~/Content/Images/Product"), ImgName1);
                        Image1.SaveAs(ImgPath1);
                        oSel.Image1 = ImgName1;

                    }
                }
                if (Image2 != null && Image2.ContentLength > 0)
                {
                    string extension = Path.GetExtension(MainImage.FileName);
                    if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                    {
                        string ImgName2 = Path.GetFileName(Image2.FileName);
                        string ImgPath2 = Path.Combine(Server.MapPath("~/Content/Images/Product"), ImgName2);
                        Image2.SaveAs(ImgPath2);
                        oSel.Image2 = ImgName2;
                    }
                }
                if (Image3 != null && Image3.ContentLength > 0)
                {
                    string extension = Path.GetExtension(MainImage.FileName);
                    if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                    {
                        string ImgName3 = Path.GetFileName(Image3.FileName);
                        string ImgPath3 = Path.Combine(Server.MapPath("~/Content/Images/Product"), ImgName3);
                        Image3.SaveAs(ImgPath3);
                        oSel.Image3 = ImgName3;
                    }
                }
                if (IsProductExpirable == "Yes")
                {
                    oSel.IsproductExpirable = true;
                }
                else
                {
                    oSel.IsproductExpirable = false;
                }
                if (IsProductReturnable == "Yes")
                {
                    oSel.IsProductReturnable = true;
                }
                else
                {
                    oSel.IsProductReturnable = false;
                }
                if (IsProductSeasonable == "Yes")
                {
                    oSel.IsProductSeasonable = true;
                }
                else
                {
                    oSel.IsProductSeasonable = false;
                }
               // oSel.ProductWeight = Convert.ToDecimal(ProductWeight);
                oSel.StatusId = 4;
                BALSeller bSel = new BALSeller();


                if (oSel.SubCategory2Code != null)
                {

                    //Code = oSel.SubCategory2Code + oSel.ProductName.Substring(0, 3);
                    //string ProductCode = Code + 1;
                    // ProductCode = oSel.ProductCode;
                    SqlDataReader dr;
                    dr = bSel.GetProductCode();
                    while (dr.Read())
                    {
                        oSel.ProductId = Convert.ToInt32(dr["PCode"].ToString());
                    }
                    oSel.ProductCode = oSel.SubCategory2Code + oSel.ProductId + oSel.ProductName.Substring(0, 3);
                    dr.Close();
                }
                
                    bSel.AddProductInfo(oSel);

                bSel.AddProductImage(oSel);
                Response.Write("<JavaScript>alert'Category Added Successfully...!'</script>");
                return RedirectToAction("AddProductInfo", "Seller");
            }

            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        public void GetCategory()
        {
            BALSeller bSel = new BALSeller();
            DataSet ds = new DataSet();
            ds = bSel.GetCategory();
            List<SelectListItem> lstCategory = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstCategory.Add(new SelectListItem { Text = dr["CategoryName"].ToString(), Value = dr["CategoryCode"].ToString() });
            }
            ViewBag.Category = lstCategory;
        }
        public JsonResult BindSubCategory1(Seller oSel)
        {
            
            BALSeller objBal = new BALSeller();
            DataSet ds = new DataSet();
            ds = objBal.GetSubCategory1(oSel);
            List<SelectListItem> lstSubCategory1 = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstSubCategory1.Add(new SelectListItem { Text = dr["SubCatagory1Name"].ToString(), Value = dr["SubCategory1Code"].ToString() });
            }
            return Json(lstSubCategory1, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BindSubCategory2(Seller oSel)
        {
           
            BALSeller objBal = new BALSeller();
            DataSet ds = new DataSet();
            ds = objBal.GetSubCategory2(oSel);
            List<SelectListItem> lstSubCategory2 = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstSubCategory2.Add(new SelectListItem { Text = dr["SubCatagory2Name"].ToString(), Value = dr["SubCategory2Code"].ToString() });
            }
            return Json(lstSubCategory2, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductCode(Seller oSel)
        {

            BALSeller bSel = new BALSeller();
            if (oSel.SubCategory2Code != null)
            {

                //Code = oSel.SubCategory2Code + oSel.ProductName.Substring(0, 3);
                //string ProductCode = Code + 1;
                // ProductCode = oSel.ProductCode;
                SqlDataReader dr;
                dr = bSel.GetProductCode();
                while (dr.Read())
                {
                    oSel.ProductId = Convert.ToInt32(dr["PCode"].ToString());
                }
                oSel.ProductCode = oSel.SubCategory2Code + oSel.ProductId + oSel.ProductName.Substring(0, 3);


                //if (dr.FieldCount == 0   )
                //{
                //    oSel.ProductCode = oSel.SubCategory2Code + oSel.ProductName.Substring(0, 3);
                //}
                //else if(dr.FieldCount > 0 ) 
                //{
                //    oSel.ProductCode = Code + 1;
                //}
                //dr.Close();

            }
            // var Status = new { data = oSel.ProductCode };
            return Json(new { data = oSel.ProductCode }, JsonRequestBehavior.AllowGet);
            //else if(oSel.SubCategory3Code == null)
            //{
            //    oSel.ProductCode = oSel.SubCategory2Code + oSel.ProductName.Substring(0, 1);
            //}
            //else if (oSel.SubCategory3Code == null && oSel.SubCategory2Code==null)
            //{
            //    oSel.ProductCode = oSel.SubCategory1Code + oSel.ProductName.Substring(0, 1);
            //}
            //else if (oSel.SubCategory3Code == null && oSel.SubCategory2Code == null && oSel.SubCategory1Code==null)
            //{
            //    oSel.ProductCode = oSel.CategoryCode + oSel.ProductName.Substring(0, 1);
            //}
        }
        // ========== Add new Category ========== //
        [HttpGet]
        public async Task<ActionResult> AddCategory()
        {
           
            return await Task.Run(() => PartialView());
        }
        [HttpPost]
        public async Task<ActionResult> AddCategory(Seller oAd)
        {
            BALSeller bAd = new BALSeller();

            oAd.CategoryCode = oAd.CategoryName.Substring(0, 3);
            oAd.StatusId = 4;
            bAd.AddCategory(oAd);
            Response.Write("<JavaScript>alert'Category Added Successfully...!'</script>");
            return await Task.Run(() => RedirectToAction("AddProductInfo", "Seller"));
        }
        public async Task<ActionResult> AddSubCategory1()
        {
            GetCategory();
            return  await Task.Run(() => PartialView());
        }
        [HttpPost]
        public async Task<ActionResult> AddSubCategory1(Seller oAd)
        {
            BALSeller bAd = new BALSeller();
            oAd.SubCategory1Code = oAd.CategoryCode + oAd.SubCategory1Name.Substring(0, 3);
            oAd.StatusId = 4;
            bAd.AddSubCategory1(oAd);
            Response.Write("<JavaScript>alert'Sub-Category Added Successfully...!'</script>");
            return await Task.Run(() => RedirectToAction("AddProductInfo", "Seller"));
        }
        [HttpGet]
        public async Task<ActionResult> AddSubCategory2()
        {
            GetCategory();
            return await Task.Run(() => PartialView()); 
        }
        [HttpPost]
        public async Task<ActionResult> AddSubCategory2(Seller oAd)
        {
            BALSeller bAd = new BALSeller();
            oAd.SubCategory2Code = oAd.SubCategory1Code + oAd.SubCategory2Name.Substring(0, 3);

            bAd.AddSubCategory2(oAd);
            Response.Write("<JavaScript>alert'Sub-Category Added Successfully...!'</script>");
            return await Task.Run(() => RedirectToAction("AddProductInfo", "Seller"));
        }


         public JsonResult ShowChart()

        {
            
            Seller objsell = new Seller();
           objsell.SellerCode= Session["SellerCode"].ToString();
            BALSeller obj = new BALSeller();
            DataSet ds = new DataSet();
               ds= obj.Chart(objsell);
            List<SelectListItem> monthorder = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                monthorder.Add(new SelectListItem
                {
                    Text = dr["Status"].ToString(),
                    Value = dr["Count"].ToString()
                });
            }
            // ViewBag.StateName = StatesList;
            return Json(monthorder, JsonRequestBehavior.AllowGet);  
        }
        public JsonResult totalSaleseller()

        {

            Seller objsell = new Seller();
            objsell.SellerCode = Session["SellerCode"].ToString();
            BALSeller obj = new BALSeller();
            DataSet ds = new DataSet();
            ds = obj.TotalSaleseller(objsell);
            List<SelectListItem> Monthsell = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Monthsell.Add(new SelectListItem
                {
                    Text = dr["month"].ToString(),
                    Value = dr["totalSale"].ToString()
                });
            }
            // ViewBag.StateName = StatesList;
            return Json(Monthsell, JsonRequestBehavior.AllowGet);
        }

        /////Yash Start/////////////////////
        //----------------------------------------AllProductGridview--------------------------------------
        public async Task<ActionResult> GetAllProduct(Seller obj)
        {
            if (Session["SellerCode"] != null)
            {

                obj.SellerCode = Session["SellerCode"].ToString();
                // string sellercode = "S003";
                BALSeller objA = new BALSeller();
                DataSet yg = new DataSet();
                yg = objA.GetAllProduct(obj);
                Seller objS = new Seller();
                List<Seller> sellers = new List<Seller>();
                for (int i = 0; i < yg.Tables[0].Rows.Count; i++)
                {

                    Seller objB = new Seller();
                    objB.MainImage = yg.Tables[0].Rows[i]["MainImage"].ToString();
                    objB.SellerCode = yg.Tables[0].Rows[i]["SellerCode"].ToString();
                    objB.ProductName = yg.Tables[0].Rows[i]["ProductName"].ToString();
                    objB.ProductCode = yg.Tables[0].Rows[i]["ProductCode"].ToString();
                    objB.CurrentStock = Convert.ToInt32(yg.Tables[0].Rows[i]["Quantity"].ToString());
                    objB.MRP = Convert.ToInt32(yg.Tables[0].Rows[i]["MRP"].ToString());
                    objB.ProductWeight = yg.Tables[0].Rows[i]["ProductWeight"].ToString();
                    objB.ProductRegistrationDate = Convert.ToDateTime(yg.Tables[0].Rows[i]["ProductRegistrationDate"].ToString());
                    objB.ProductApprovalDate = Convert.ToDateTime(yg.Tables[0].Rows[i]["ProductApprovalDate"].ToString());
                    objB.ManufacturerName = yg.Tables[0].Rows[i]["ManufacturerName"].ToString();
                    sellers.Add(objB);

                }
                // ViewBag.MainImage = obj.MainImage;
                objS.Product = sellers;

                return await Task.Run(() => View(objS));
            }
            return await Task.Run(() => View());
        }

        //-----------------------------------------------AddOffer----------------------------------
        [HttpGet]
        public async Task<ActionResult> AddOffer(Seller obj2, string ProductCode)
        {
            GetOfferDrop(obj2);
            string SellerCode = "S003";
            Seller obj = new Seller();
            obj.SellerCode = SellerCode;
            obj.ProductCode = ProductCode;
            BALSeller obj1 = new BALSeller();
            SqlDataReader dr;
            dr = obj1.PopOffer(obj.ProductCode);
            while (dr.Read())
            {
                obj.SellerCode = dr["SellerCode"].ToString();
                obj.ProductName = dr["ProductName"].ToString();
                obj.MRP = Convert.ToInt32(dr["MRP"].ToString());
                obj.ProductCode = dr["ProductCode"].ToString();
            }
            dr.Close();
            return await Task.Run(() => PartialView("AddOffer", obj));

        }
        [HttpPost]
        public async Task<ActionResult> AddOffer(Seller obj, FormContext formContext)
        {
            GetOfferDrop(obj);
            BALSeller objA = new BALSeller();
            objA.AddOffer(obj.ProductCode, obj.StartDate, obj.EndDate, obj.AdminOfferId, obj.StatusId);
            return await Task.Run(() => RedirectToAction("GetAllProduct"));
        }



        //------------------------------------------OfferDropDown--------------------------------------

        public async Task<ActionResult> GetOfferDrop(Seller obj)
        {
            BALSeller objBal = new BALSeller();
            DataSet ds = new DataSet();
            ds = objBal.YGGetOffer(obj);
            List<SelectListItem> OfferList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                OfferList.Add(new SelectListItem
                {
                    Text = dr["OfferName"].ToString(),
                    Value = dr["AdminOfferId"].ToString()
                });
            }
            ViewBag.Offer = OfferList;
            return await Task.Run(() => RedirectToAction("AddnewOffer"));
        }
        ///////Yash End//////////////////

        //////---------------Using--Entities-------------////////////////////////////
        ////////////////////////////////////////////////////////////////

        public async Task<ActionResult>SellerAllOrder( int? StatusId)///////////Seller All Orders
        {
         // var orderslist =new SellerViewModel();
            if (Session["SellerCode"] != null)
            {
                var SellerCode = Session["SellerCode"].ToString();

              //var   orders =  dbcontext.tblGSTStatus.ToList();

                List<tblGSTOrder> Orders = dbcontext.tblGSTOrders.ToList();
                List<tblGSTProduct> Products = dbcontext.tblGSTProducts.ToList();
                List<tblGSTBuyer> Buyers = dbcontext.tblGSTBuyers.ToList();

                ViewBag.OrderStatus = dbcontext.tblGSTStatus.Where(st => st.StatusId == 6 || st.StatusId == 8|| st.StatusId == 11                
                || st.StatusId == 12|| st.StatusId == 13 || st.StatusId == 14 ||  st.StatusId == 25);

                if (StatusId == null)
                {
                    var orderslist = (from o in Orders
                                      join p in Products on o.ProductCode equals p.ProductCode
                                      join b in Buyers on o.BuyerCode equals b.BuyerCode
                                      join pay in dbcontext.tblGSTBuyerPayments on o.OrderCode equals pay.OrderCode
                                      join s in dbcontext.tblGSTStatus on o.OrderStatusId equals s.StatusId
                                      join i in dbcontext.tblGSTProductImages on o.ProductCode equals i.ProductCode
                                      

                                      where p.SellerCode == SellerCode && (o.OrderStatusId == 6 || o.OrderStatusId == 8
                                      || o.OrderStatusId == 11 || o.OrderStatusId == 12 || o.OrderStatusId == 13 || o.OrderStatusId == 14 || o.OrderStatusId == 25)
                                      select new SellerViewModel
                                      {
                                          OrderCode = o.OrderCode, SellerCode = p.SellerCode,
                                          BuyerFullName = b.BuyerFullName, ProductCode = p.ProductCode,
                                          ProductName = p.ProductName,  ProcessDate = o.ProcessDate,
                                          OrderStatusId = o.OrderStatusId, Status = s.Status,
                                          ProductQuantity = o.ProductQuantity, PaymentDate = Convert.ToDateTime(pay.PaymentDate),
                                          PaymentMode = pay.PaymentMode,
                                          MRP = (Convert.ToInt32(p.MRP)),
                                       
                                      }).ToList();
                    return await Task.Run(() => View(orderslist));
                }
                else
                {
                    var orderslist = (from o in Orders
                                      join p in Products on o.ProductCode equals p.ProductCode
                                      join b in Buyers on o.BuyerCode equals b.BuyerCode
                                      join pay in dbcontext.tblGSTBuyerPayments on o.OrderCode equals pay.OrderCode
                                      join s in dbcontext.tblGSTStatus on o.OrderStatusId equals s.StatusId
                                      join i in dbcontext.tblGSTProductImages on o.ProductCode equals i.ProductCode


                                      where p.SellerCode == SellerCode && (o.OrderStatusId == StatusId)
                                      select new SellerViewModel
                                      {
                                          OrderCode = o.OrderCode, SellerCode = p.SellerCode, BuyerFullName = b.BuyerFullName,
                                          ProductCode = p.ProductCode,ProductName = p.ProductName,
                                          ProcessDate = o.ProcessDate, OrderStatusId = o.OrderStatusId,
                                          Status = s.Status, ProductQuantity = o.ProductQuantity,
                                          PaymentDate = Convert.ToDateTime(pay.PaymentDate), PaymentMode = pay.PaymentMode,
                                          MRP = (Convert.ToInt32(p.MRP)),
                                      }).ToList();
                    return await Task.Run(() => View(orderslist));
                }
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
                
        }
          
        public async Task<ActionResult> SellersOrderDetails( SellerViewModel seller)
        {
            try
            {
                SellerViewModel OrderDetails = (from  o in dbcontext.tblGSTOrders 
                                join p in dbcontext.tblGSTProducts on o.ProductCode equals p.ProductCode
                                join i in dbcontext.tblGSTProductImages on o.ProductCode equals i.ProductCode
                                join b in dbcontext.tblGSTBuyers on o.BuyerCode equals b.BuyerCode
                                join pay in dbcontext.tblGSTBuyerPayments on o.OrderCode equals pay.OrderCode 
                                join s in dbcontext.tblGSTStatus on o.OrderStatusId equals s.StatusId
                                join a in dbcontext.tblGSTAddresses on b.BuyerCode equals a.UserCode

                                where o.OrderCode==seller.OrderCode 
                                select new SellerViewModel  
                                {
                                    OrderCode = o.OrderCode, BuyerFullName = b.BuyerFullName,
                                    ProductCode = p.ProductCode,ProductName = p.ProductName, Date =((o.ProcessDate).ToString().TrimEnd()),
                                    OrderStatusId = o.OrderStatusId, Status = s.Status, ProductQuantity = o.ProductQuantity,
                                    /*Date = Convert.ToDateTime(pay.PaymentDate),*/ PaymentMode = pay.PaymentMode,TransactionId=pay.TransactionId,
                                    MRP = p.MRP,
                                    MainImage=i.MainImage,EmailId=b.EmailId,MobileNo=b.MobileNo,ProductWeight=p.ProductWeight,
                                    AddressStatus=o.AddressStatus,RejectionReason=o.RejectionReason,
                                    RejectedByUserCode=o.RejectedByUserCode,
                                    //Total = Convert.ToInt32(p.MRP + o.ProductQuantity),
                                    Address = (o.AddressStatus.Value==21? a.Home:o.AddressStatus.Value==22? a.Office:o.AddressStatus.Value==23? a.Other:"").Replace("@",","),
                                    
                                }).FirstOrDefault(); 

               ViewBag.RejectedByUserCode = OrderDetails.RejectedByUserCode;

               // SellerViewModel seller = new SellerViewModel(); 
               // ViewBag.RejectionReason=sellerView.RejectionReason;
                return await Task.Run(() => PartialView(OrderDetails));

            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }

        public async Task<ActionResult> ConfirmOrder(int id,SellerViewModel objseller)
        {
            string OrderCode = objseller.OrderCode;
            try
            {
                    var UpdateOrder = dbcontext.tblGSTOrders.FirstOrDefault(x => x.OrderCode == OrderCode);
                    UpdateOrder.OrderStatusId = 8;
                    dbcontext.SaveChanges();
               
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return await Task.Run(() => RedirectToAction("SellerAllOrder","Seller"));
        }
        //public async Task<ActionResult> SellerCancelOrder( SellerViewModel objseller) 
        //{
        //    string OrderCode = objseller.OrderCode;
        //            var CanselOrder = dbcontext.tblGSTOrders.FirstOrDefault(x => x.OrderCode == OrderCode);
        //            CanselOrder.OrderStatusId = 14;
        //            dbcontext.SaveChanges();
        //    return await Task.Run(() => RedirectToAction("SellerAllOrder", "Seller"));
        //}

    }
}