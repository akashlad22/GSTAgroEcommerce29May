using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AgroEcommerceLibrary.Admin;


namespace GSTAgroEcommerce.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        BALAdmin objAdmin = new BALAdmin();
        BALAdmin obj = new BALAdmin();
        public decimal TotalCommission = 0;
        public decimal TotalOrders = 0;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }

        //-------------------Prathmesh Start---------------- 
        public async Task<ActionResult> ProductGrid()
        {


            CategoryName();
            SellerName();
            //if (categoryId == null)
            //{    
            BALAdmin OBjP = new BALAdmin();
            DataSet DSB = new DataSet();
            DSB = OBjP.GetProductAdmin();
            Admin objBUY = new Admin();
            List<Admin> listP = new List<Admin>();
            for (int i = 0; i < DSB.Tables[0].Rows.Count; i++)
            {
                Admin ObjB = new Admin();
                ObjB.SellerFullName = DSB.Tables[0].Rows[i]["SellerFullName"].ToString();
                ObjB.ProductName = DSB.Tables[0].Rows[i]["ProductName"].ToString();
                ObjB.MainImage = DSB.Tables[0].Rows[i]["MainImage"].ToString();
                ObjB.Quantity = Convert.ToInt32(DSB.Tables[0].Rows[i]["Quantity"].ToString());
                ObjB.CategoryName = DSB.Tables[0].Rows[i]["CategoryName"].ToString();
                ObjB.Status = DSB.Tables[0].Rows[i]["Status"].ToString();
                ObjB.ManufacturerName = DSB.Tables[0].Rows[i]["ManufacturerName"].ToString();

                listP.Add(ObjB);

            }
            objBUY.admins = listP;
            return await Task.Run(() => View(objBUY));





        }
        [HttpGet]
        public JsonResult SearchByCategory(int CategoryId)
        {

            /*if (CategoryId == 1)
            {*//*
                BALAdmin OBjP = new BALAdmin();
                DataSet DSB = new DataSet();
                DSB = OBjP.GetProductAdmin();
                Admin objBUY = new Admin();
                List<Admin> listP = new List<Admin>();
                for (int i = 0; i < DSB.Tables[0].Rows.Count; i++)
                {
                    Admin ObjB = new Admin();
                    ObjB.SellerFullName = DSB.Tables[0].Rows[i]["SellerFullName"].ToString();
                    ObjB.ProductName = DSB.Tables[0].Rows[i]["ProductName"].ToString();
                    string photo = DSB.Tables[0].Rows[i]["MainImage"].ToString();
                    ObjB.Quantity = Convert.ToInt32(DSB.Tables[0].Rows[i]["Quantity"].ToString());
                    ObjB.CategoryName = DSB.Tables[0].Rows[i]["CategoryName"].ToString();
                    ObjB.Status = DSB.Tables[0].Rows[i]["Status"].ToString();
                    ObjB.ManufacturerName = DSB.Tables[0].Rows[i]["ManufacturerName"].ToString();
                    string Path = "/Content/Images/Product/";
                    ObjB.MainImage = string.Concat(Path, photo);
                    listP.Add(ObjB);

                }
                objBUY.admins = listP;
                return Json(listP, JsonRequestBehavior.AllowGet);

            }
            else
            {*/
            BALAdmin OBjS = new BALAdmin();
            DataSet DSB = new DataSet();
            DSB = OBjS.GetSearchbyCategory(CategoryId);
            Admin objBUY = new Admin();
            List<Admin> listS = new List<Admin>();
            for (int i = 0; i < DSB.Tables[0].Rows.Count; i++)
            {
                Admin ObjB = new Admin();
                ObjB.SellerFullName = DSB.Tables[0].Rows[i]["SellerFullName"].ToString();
                ObjB.ProductName = DSB.Tables[0].Rows[i]["ProductName"].ToString();
                string Photo = DSB.Tables[0].Rows[i]["MainImage"].ToString();
                ObjB.Quantity = Convert.ToInt32(DSB.Tables[0].Rows[i]["Quantity"].ToString());
                ObjB.CategoryName = DSB.Tables[0].Rows[i]["CategoryName"].ToString();
                ObjB.Status = DSB.Tables[0].Rows[i]["Status"].ToString();
                ObjB.ManufacturerName = DSB.Tables[0].Rows[i]["ManufacturerName"].ToString();
                string Path = "/Content/Images/Product/";
                ObjB.MainImage = string.Concat(Path, Photo);

                listS.Add(ObjB);

            }
            //ViewBag.CategoryName = objBUY.CategoryName;
            objBUY.admins = listS;
            return Json(listS, JsonRequestBehavior.AllowGet);


        }
        public JsonResult CategoryName()
        {
            BALAdmin OBjC = new BALAdmin();
            DataSet DSB1 = new DataSet();
            DSB1 = OBjC.GetCatergory();
            Admin objBUY2 = new Admin();
            List<SelectListItem> listC = new List<SelectListItem>();
            foreach (DataRow dr in DSB1.Tables[0].Rows)
            {
                listC.Add(new SelectListItem
                {
                    Text = dr["CategoryName"].ToString(),
                    Value = dr["CategoryId"].ToString()
                });
            }
            //objBUY2.Category = listC;
            ViewBag.Category = listC;

            return Json(listC, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchBySeller(int SellerId)
        {

            BALAdmin OBjS = new BALAdmin();
            DataSet DSB = new DataSet();
            DSB = OBjS.GetSearchbySeller(SellerId);
            Admin objBUY = new Admin();
            List<Admin> listS = new List<Admin>();
            for (int i = 0; i < DSB.Tables[0].Rows.Count; i++)
            {
                Admin ObjB = new Admin();
                ObjB.SellerFullName = DSB.Tables[0].Rows[i]["SellerFullName"].ToString();
                ObjB.ProductName = DSB.Tables[0].Rows[i]["ProductName"].ToString();
                string Photo = DSB.Tables[0].Rows[i]["MainImage"].ToString();
                ObjB.Quantity = Convert.ToInt32(DSB.Tables[0].Rows[i]["Quantity"].ToString());
                ObjB.CategoryName = DSB.Tables[0].Rows[i]["CategoryName"].ToString();
                ObjB.Status = DSB.Tables[0].Rows[i]["Status"].ToString();
                ObjB.ManufacturerName = DSB.Tables[0].Rows[i]["ManufacturerName"].ToString();
                string Path = "/Content/Images/Product/";
                ObjB.MainImage = string.Concat(Path, Photo);

                listS.Add(ObjB);

            }
            //ViewBag.CategoryName = objBUY.CategoryName;
            objBUY.admins = listS;
            return Json(listS, JsonRequestBehavior.AllowGet);

        }
        public JsonResult SellerName()
        {
            BALAdmin OBjC = new BALAdmin();
            DataSet DSB1 = new DataSet();
            DSB1 = OBjC.GetsellerName();
            Admin objBUY2 = new Admin();
            List<SelectListItem> listC = new List<SelectListItem>();
            foreach (DataRow dr in DSB1.Tables[0].Rows)
            {
                listC.Add(new SelectListItem
                {
                    Text = dr["SellerFullName"].ToString(),
                    Value = dr["SellerId"].ToString()
                });
            }
            //objBUY2.Category = listC;
            // listC.Insert(0,new SelectListItem { Text = "-- Please Select --" });
            ViewBag.Seller = listC;

            return Json(listC, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> AdminProfData(Admin objA)//Admin Profile Data
        {
            if (Session["AdminId"] != null)
            {


                Country_Bind();
                BALAdmin OBjC = new BALAdmin();
                SqlDataReader dr;
                objA.AdminId = Convert.ToInt32(Session["AdminId"].ToString());
                dr = OBjC.GetAdminProfData(objA);
                Admin objBUY2 = new Admin();

                while (dr.Read())
                {
                    objBUY2.AdminId = Convert.ToInt32(dr["AdminId"].ToString());
                    objBUY2.AdminFullName = dr["AdminFullName"].ToString();
                    objBUY2.MobileNo = dr["MobileNo"].ToString();
                    objBUY2.Photo = dr["Photo"].ToString();
                    objBUY2.EmailId = dr["EmailId"].ToString();
                    objBUY2.Address = dr["Address"].ToString();
                    objBUY2.PinCode = Convert.ToInt32(dr["PinCode"].ToString());
                    objBUY2.CityId = Convert.ToInt32(dr["CityId"].ToString());
                    objBUY2.CityName = dr["CityName"].ToString();
                    objBUY2.StateId = Convert.ToInt32(dr["StateId"].ToString());
                    objBUY2.StateName = dr["StateName"].ToString();
                    objBUY2.CountryName = dr["CountryName"].ToString();
                    objBUY2.CountryId = Convert.ToInt32(dr["CountryId"].ToString());


                }
                dr.Close();
                ViewBag.State = objBUY2.StateName;
                ViewBag.StateId = objBUY2.StateId;
                ViewBag.City = objBUY2.CityName;
                ViewBag.CityId = objBUY2.CityId;

                return await Task.Run(() => View(objBUY2));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Account", "login"));

            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateProfileAdmin(Admin objA)//Update Profile data
        {
            BALAdmin objB = new BALAdmin();
            objB.ProfileUpdateSave(objA);
            /*Response.Write("<script>alert('Your Details Has Been Updated');</script>");*/

            return await Task.Run(() => RedirectToAction("AdminProfData", "Admin"));
        }
        public JsonResult City_Bind(int State_Id)//City

        {

            BALAdmin obj = new BALAdmin();
            DataSet ds = obj.GetCityPN(State_Id);
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
        public JsonResult Country_Bind() //Country
        {
            BALAdmin obj = new BALAdmin();
            DataSet ds = obj.GetCountryPN();
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
            return Json(CountryList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult State_Bind(int Country_Id) //State
        {
            Admin Obj = new Admin();
            BALAdmin obj = new BALAdmin();
            DataSet ds = obj.GetStatePN(Country_Id);
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

        public async Task<ActionResult> ManageCategorygrid()// Category Grid View
        {



            BALAdmin OBjP = new BALAdmin();
            DataSet DSB = new DataSet();
            DSB = OBjP.ManageCategorygrid();
            Admin objBUY = new Admin();
            List<Admin> listP = new List<Admin>();
            for (int i = 0; i < DSB.Tables[0].Rows.Count; i++)
            {
                Admin ObjB = new Admin();
                ObjB.CategoryName = DSB.Tables[0].Rows[i]["CategoryName"].ToString();
                ObjB.SubCategory2Code = DSB.Tables[0].Rows[i]["SubCategory2Code"].ToString();
                ObjB.CategoryCode = DSB.Tables[0].Rows[i]["CategoryCode"].ToString();
                ObjB.SubCategory1Code = DSB.Tables[0].Rows[i]["SubCategory1Code"].ToString();
                ObjB.SubCategory2Code = DSB.Tables[0].Rows[i]["SubCategory2Code"].ToString();
                ObjB.SubCatagory1Name = DSB.Tables[0].Rows[i]["SubCatagory1Name"].ToString();
                ObjB.SubCatagory2Name = DSB.Tables[0].Rows[i]["SubCatagory2Name"].ToString();
                ObjB.Commision = Convert.ToInt32(DSB.Tables[0].Rows[i]["Commission"].ToString());


                listP.Add(ObjB);

            }
            objBUY.CategoryGrid = listP;
            return await Task.Run(() => View(objBUY)); 
        }
        // ========== Add new Category ========== //
        [HttpGet]
        public async Task<ActionResult> AddCategory1()
        {

            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<ActionResult> AddCategory1(Admin oAd)//Add Category
        {
            BALAdmin bAd = new BALAdmin();

            oAd.CategoryCode = oAd.CategoryName.Substring(0, 3);
            // oAd.StatusId = 4;
            bAd.AddCategory(oAd);
            Response.Write("<JavaScript>alert'Category Added Successfully...!'</script>");
            return await Task.Run(() => RedirectToAction("ManageCategoryGrid", "Admin"));
        }
        public async Task<ActionResult> AddSubCategory1()
        {
            GetCategory();
            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<ActionResult> AddSubCategory1(Admin oAd)//Add Sub Category1
        {
            BALAdmin bAd = new BALAdmin();
            oAd.SubCategory1Code = oAd.CategoryCode + oAd.SubCategory1Name.Substring(0, 3);
            oAd.StatusId = 4;
            bAd.AddSubCategory1(oAd);
            Response.Write("<JavaScript>alert'Sub-Category Added Successfully...!'</script>");
            return await Task.Run(() => RedirectToAction("ManageCategoryGrid", "Admin"));
        }
        [HttpGet]
        public async Task<ActionResult> AddSubCategory2()
        {
            GetCategory();
            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<ActionResult> AddSubCategory2(Admin oAd)//Add Sub Category2
        {
            BALAdmin bAd = new BALAdmin();
            oAd.SubCategory2Code = oAd.SubCategory1Code + oAd.SubCategory2Name.Substring(0, 3);

            bAd.AddSubCategory2(oAd);
            Response.Write("<JavaScript>alert'Sub-Category Added Successfully...!'</script>");
            return await Task.Run(() => RedirectToAction("ManageCategoryGrid", "Admin"));
        }
        public void GetCategory()//Get Category
        {
            BALAdmin bSel = new BALAdmin();
            DataSet ds = new DataSet();
            ds = bSel.GetCategoryPN();
            List<SelectListItem> lstCategory = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstCategory.Add(new SelectListItem { Text = dr["CategoryName"].ToString(), Value = dr["CategoryCode"].ToString() });
            }
            ViewBag.Category = lstCategory;
        }
        public JsonResult BindSubCategory1(Admin oSel)//GetSub category1
        {

            BALAdmin objBal = new BALAdmin();
            DataSet ds = new DataSet();
            ds = objBal.GetSubCategory1PN(oSel);
            List<SelectListItem> lstSubCategory1 = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstSubCategory1.Add(new SelectListItem { Text = dr["SubCatagory1Name"].ToString(), Value = dr["SubCategory1Code"].ToString() });
            }
            return Json(lstSubCategory1, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> FetchCategoryGrid(Admin objA) //Fetch Edit Data
        {

            Admin objBUY = new Admin();
            objBUY.SubCategory2Code = objA.SubCategory2Code;
            BALAdmin OBjP = new BALAdmin();
            SqlDataReader dr;
            dr = OBjP.FetchCategorygrid(objA);


            while (dr.Read())
            {
                /*Admin ObjB = new Admin();*/
                objBUY.CategoryName = dr["CategoryName"].ToString();
                objBUY.SubCategory2Code = dr["SubCategory2Code"].ToString();
                objBUY.CategoryCode = dr["CategoryCode"].ToString();
                objBUY.SubCategory1Name = dr["SubCatagory1Name"].ToString();
                objBUY.SubCategory2Name = dr["SubCatagory2Name"].ToString();
                objBUY.Commision = Convert.ToInt32(dr["Commission"].ToString());




            }
            dr.Close();
            /* ViewBag.CategoryName = objBUY.CategoryName;
             ViewBag.SubCat1Name = objBUY.SubCategory1Name;*/

            return await Task.Run(() => PartialView(objBUY));

        }
        [HttpPost]
        public async Task<ActionResult> UpdateCommission(Admin objA)//Update Comission
        {
            BALAdmin objB = new BALAdmin();
            objB.UpdateComission(objA);
            /*Response.Write("<script>alert('Your Details Has Been Updated');</script>");*/

            return await Task.Run(() => RedirectToAction("ManageCategorygrid", "Admin"));
        }
        [HttpGet]
        public async Task<ActionResult> UpdateStatus(string id1, string id2, string id3)//update Status
        {

            Admin objA = new Admin();
            objA.CategoryCode = id1;
            objA.SubCategory1Code = id2;
            objA.SubCategory2Code = id3;
            BALAdmin objB = new BALAdmin();
            objB.UpdateCAtegoryStatus(objA);
            objB.UpdateSubCate1Status(objA);
            objB.UpdateSubCate2Status(objA);


            return await Task.Run(() => RedirectToAction("ManageCategorygrid", "Admin"));

        }



        //-------------------Prathmesh End---------------- 

        //////////-----Sagar Start--------------////////

        // ========== Add new Category ========== //
        public ActionResult AddCategory()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddCategory(Admin oAd)
        {
            BALAdmin bAd = new BALAdmin();
            //string s = oAd.CategoryName;
            //string[ ] subs = s.Split(' '); 
            //foreach(var sub in subs)
            //{
            //    oAd.CategoryCode = sub.Substring(0,1);
            //}
            oAd.CategoryCode = oAd.CategoryName.Substring(0, 1);
            oAd.StatusId = 1;
            bAd.AddCategory(oAd.CategoryCode, oAd.CategoryName, oAd.Commision, oAd.StatusId);
            Response.Write("<JavaScript>alert'Category Added Successfully...!'</script>");
            return PartialView("AddCategory", oAd);
        }

        // ========== Show Product And Seller approval request count on dashboard ========== //
        public async Task<ActionResult> AdminIndex()
        {
            //BALAdmin objAdmin = new BALAdmin();
            AdminGrid();
            ShowChart1();
            SqlDataReader dr;
            dr = objAdmin.ShowPendingSellers();
            while (dr.Read())
            {
                @ViewBag.Count = dr["PendingSellerApproval"].ToString();
            }
            dr.Close();
            BALAdmin objAdmin1 = new BALAdmin();
            SqlDataReader dt;
            dt = objAdmin1.ShowPendingProducts();
            while (dt.Read())
            {
                @ViewBag.Pro = dt["PendingProductApproval"].ToString();
            }
            dt.Close();
            return await Task.Run(() => View());
        }

        // ========== List View of Seller Approval Requests ========== //
        [HttpGet]
        public async Task<ActionResult> PendingSellerList()
        {
            //BALAdmin objAdmin = new BALAdmin();
            DataSet ds = new DataSet();
            ds = objAdmin.PendingSellerList();
            Admin objAd = new Admin();
            List<Admin> list = new List<Admin>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Admin obj = new Admin();
                obj.SellerCode = ds.Tables[0].Rows[i]["SellerCode"].ToString();
                obj.SellerFullName = ds.Tables[0].Rows[i]["SellerFullName"].ToString();
                obj.BusinessName = ds.Tables[0].Rows[i]["BusinessName"].ToString();
                obj.MobileNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();
                obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();

                list.Add(obj);
            }
            objAd.LstSeller = list;
            return await Task.Run(() => View(objAd));
        }

        // ========== List View of Product Approval Requests ========== //
        [HttpGet]
        public async Task<ActionResult> PendingProductList()
        {
            //BALAdmin objAdmin = new BALAdmin();
            DataSet ds = new DataSet();
            ds = objAdmin.PendingProductList();
            Admin objAd = new Admin();
            List<Admin> listpro = new List<Admin>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Admin obj = new Admin();
                obj.MainImage = ds.Tables[0].Rows[i]["MainImage"].ToString();
                obj.ProductCode = ds.Tables[0].Rows[i]["ProductCode"].ToString();
                obj.ProductName = ds.Tables[0].Rows[i]["ProductName"].ToString();
                obj.SellerFullName = ds.Tables[0].Rows[i]["SellerFullName"].ToString();
                obj.MobileNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();
                obj.OfficeAddress = ds.Tables[0].Rows[i]["Office"].ToString();

                listpro.Add(obj);
            }
            objAd.LstProduct = listpro;
            return await Task.Run(() => View(objAd));
        }

        // ========== Details View of Seller ========== //
        [HttpPost]
        public async Task<ActionResult> SellerDetails(Admin objA)
        {
            Admin obj = new Admin();
            obj.SellerCode = objA.SellerCode;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.SellerDetails(objA);
            while (dr.Read())
            {
                obj.SellerCode = dr["SellerCode"].ToString();
                obj.SellerFullName = dr["SellerFullName"].ToString();
                obj.BusinessName = dr["BusinessName"].ToString();
                obj.MobileNo = dr["MobileNo"].ToString();
                obj.Status = dr["Status"].ToString();
                obj.AadharNo = dr["AadharNo"].ToString();
                obj.AadharImage = dr["AadharImage"].ToString();
                obj.BusinessAadharNo = dr["BusinessAadharNo"].ToString();
                obj.BusinessAdharImage = dr["BusinessAdharImage"].ToString();
                obj.PanCardNo = dr["PanCardNo"].ToString();
                obj.PanImage = dr["PanImage"].ToString();
                obj.BusinessPanNo = dr["BusinessPanNo"].ToString();
                obj.BusinessPanImage = dr["BusinessPanImage"].ToString();
                obj.GSTIN = dr["GSTIN"].ToString();
            }
            dr.Close();
            return await Task.Run(() => PartialView("SellerDetails", obj));
        }

        // ========== Details View of Product ========== //
        [HttpPost]
        public async Task<ActionResult> ProductDetails(Admin objA)
        {
            Admin obj = new Admin();
            obj.ProductCode = objA.ProductCode;
            //BALAdmin objAdmin = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.ProductDetails(objA);
            while (dr.Read())
            {
                //obj.SellerId = Convert.ToInt32(dr["SellerId"].ToString());
                obj.ProductCode = dr["ProductCode"].ToString();
                obj.ProductName = dr["ProductName"].ToString();
                obj.SellerFullName = dr["SellerFullName"].ToString();
                obj.MobileNo = dr["MobileNo"].ToString();
                obj.OfficeAddress = dr["Office"].ToString();
                obj.Status = dr["Status"].ToString();
                obj.MainImage = dr["MainImage"].ToString();
                obj.Description = dr["Description"].ToString();
                obj.MRP = Convert.ToInt32(dr["MRP"].ToString());
                //obj.IsProductReturnable = dr["IsProductReturnable"].ToString();
                //obj.IsProductExpirable = dr["IsProductExpirable"].ToString();
                obj.ProductExpiryDuration = dr["ProductExpiryDuration"].ToString();
                //obj.ProductRegistrationDate = dr["ProductRegistrationDate"].ToString();
                obj.ManufacturerName = dr["ManufacturerName"].ToString();
                obj.MaximumStock = Convert.ToInt32(dr["MaximumStock"].ToString());
                obj.MinimumStock = Convert.ToInt32(dr["MinimumStock"].ToString());
                //obj.PanCardNo = dr["PanCardNo"].ToString();
                //obj.BusinessPanNo = dr["BusinessPanNo"].ToString();
                //obj.GSTIN = dr["GSTIN"].ToString();


            }
            dr.Close();
            return await Task.Run(() => PartialView("ProductDetails", obj));
        }

        // ========== Popup View for Seller Approval========== //
        [HttpGet]
        public async Task<ActionResult> ApproveSellerStatus(Admin objA)
        {
            //ViewBag.mssg = TempData["mssg"] as string;
            Admin obj = new Admin();
            obj.SellerCode = objA.SellerCode;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.SellerDetails(objA);
            while (dr.Read())
            {
                obj.SellerCode = dr["SellerCode"].ToString();
                obj.SellerFullName = dr["SellerFullName"].ToString();
                obj.BusinessName = dr["BusinessName"].ToString();
                obj.MobileNo = dr["MobileNo"].ToString();
                obj.Status = dr["Status"].ToString();
                //obj.AadharNo = dr["AadharNo"].ToString();
            }
            dr.Close();
            return await Task.Run(() => PartialView("ApproveSellerStatus", obj));
        }

        // ========== Update Seller Approval Status========== //
        [HttpPost]
        public async Task<ActionResult> ApproveSellerStatus1(Admin objA, string sellercode, string SellerFullName, string EmailId)
        {
            objA.SellerApprovalDate = DateTime.Now;
            objAdmin.ApproveSellerStatus(objA);


            objA.SellerCode = sellercode;
            objA.SellerFullName = SellerFullName;
            objA.EmailId = EmailId;
            DataSet ds = new DataSet();
            ds = objAdmin.GetEmail(objA);

            objA.SellerFullName = ds.Tables[0].Rows[0]["SellerFullName"].ToString();
            objA.EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString();

            MailMessage mail = new MailMessage();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<br />");
            sb.AppendFormat("Dear Seller,");
            sb.AppendFormat("<br />");
            sb.AppendLine("<b>Congratulations <b>" + " " + objA.SellerFullName + ",");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Welcome to <b>Agro E-Commerce,</b>");
            sb.AppendFormat("<br />");
            sb.AppendFormat("You Are <b>Successfully Approved!</b> and Now You Can Start Your Business With Us.");
            sb.AppendFormat("<br />");
            sb.AppendFormat("<b>Agro E-Commerce Blessing and Wishing You for Your Business With Lot of Success...!!!");
            sb.AppendFormat("<br />");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Thanks and Regards,");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Agro E-Commerce,");
            sb.AppendFormat("<br />");
            sb.AppendFormat("<b>Contact-Us : </b>+919960796660");

            mail.From = new MailAddress("sagarkoli219@gmail.com");
            mail.Subject = "Request For Seller Approval";
            mail.Body = sb.ToString();
            mail.To.Add(new MailAddress(objA.EmailId));
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("sagarkoli219@gmail.com", "pmvsoeqotqjybjij");
            smtp.EnableSsl = true;
            smtp.Send(mail);


            return await Task.Run(() => RedirectToAction("PendingSellerList"));
        }

        // ========== Popup View for Seller Rejection========== //
        public async Task<ActionResult> RejectSellerStatus(Admin objA)
        {
            Admin obj = new Admin();
            obj.SellerCode = objA.SellerCode;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.SellerDetails(objA);
            while (dr.Read())
            {
                obj.SellerCode = dr["SellerCode"].ToString();
                obj.SellerFullName = dr["SellerFullName"].ToString();
                obj.BusinessName = dr["BusinessName"].ToString();
                obj.MobileNo = dr["MobileNo"].ToString();
                obj.Status = dr["Status"].ToString();
            }
            dr.Close();
            ViewBag.RejectSellerReason = new List<SelectListItem>()
            {
                new SelectListItem(){ Value="Your Deposit Amount Isn't Big Enough",Text="Your Deposit Amount Isn't Big Enough"},
                new SelectListItem(){ Value="Your Commission rate is high",Text="Your Commission rate is high"},
                new SelectListItem(){ Value="Wrong Documentation Provided",Text="Wrong Documentation Provided"},
                new SelectListItem(){ Value="Agreement issue",Text="Agreement issue"}
            };
            return await Task.Run(() => PartialView("RejectSellerStatus", obj));
        }

        // ========== Update Seller Reject Status ========== //
        [HttpPost]
        public async Task<ActionResult> RejectSellerStatus1(Admin objA, string sellercode, string SellerFullName, string EmailId, string RejectionReason)
        {

            objAdmin.RejectSellerStatus(objA);
            Response.Write("<script>alert('Update Successfully...!');</script>");

            objA.SellerCode = sellercode;
            objA.SellerFullName = SellerFullName;
            objA.EmailId = EmailId;
            objA.RejectionReason = RejectionReason;
            DataSet ds = new DataSet();
            ds = objAdmin.GetEmail(objA);

            objA.SellerFullName = ds.Tables[0].Rows[0]["SellerFullName"].ToString();
            objA.EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString();
            //objA.RejectionReason = ds.Tables[0].Rows[0]["RejectionReason"].ToString();
            objA.RejectionReason = RejectionReason;

            MailMessage mail = new MailMessage();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<br />");
            sb.AppendFormat("Dear Seller,");
            sb.AppendFormat("<br />");
            sb.AppendLine("" + " " + objA.SellerFullName + ",");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Thank You for Taking Time to Send an Approval.");
            sb.AppendFormat("<br />");
            sb.AppendFormat("We Have Carefully Reviewed Your Approval Against Our Requirements. However We Deeply Regret For Our Inability to Go Ahead With Your Approval");
            sb.AppendFormat("<br />");
            sb.AppendFormat("<b>Agro E-Commerce Feel Sad to Reject Your Approval Requests</b>");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Because of" + "<b>" + objA.RejectionReason + "</b> ");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Again, Thanks For Your Interest & Time.");
            sb.AppendFormat("We May Discuss Again In Future For Any Of Our Requirements.");
            sb.AppendFormat("<br />");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Best Regards,");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Agro E-Commerce,");
            sb.AppendFormat("<br />");
            sb.AppendFormat("<b>Contact-Us : </b>+919960796660");

            mail.From = new MailAddress("sagarkoli219@gmail.com");
            mail.Subject = "Request For Seller Approval";
            mail.Body = sb.ToString();
            mail.To.Add(new MailAddress(objA.EmailId));
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("sagarkoli219@gmail.com", "pmvsoeqotqjybjij");
            smtp.EnableSsl = true;
            smtp.Send(mail);


            return await Task.Run(() => RedirectToAction("PendingSellerList"));
        }


        // ========== Popup View for Product Approval========== //
        [HttpGet]
        public async Task<ActionResult> ApproveProductStatus(Admin objA)
        {

            Admin obj = new Admin();
            obj.ProductCode = objA.ProductCode;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.ProductDetails(objA);
            while (dr.Read())
            {
                obj.ProductCode = dr["ProductCode"].ToString();
                obj.ProductName = dr["ProductName"].ToString();
                obj.SellerFullName = dr["SellerFullName"].ToString();
                obj.MobileNo = dr["MobileNo"].ToString();
                obj.OfficeAddress = dr["Office"].ToString();
                obj.Status = dr["Status"].ToString();
                obj.MRP = Convert.ToInt32(dr["MRP"].ToString());
                obj.MaximumStock = Convert.ToInt32(dr["MaximumStock"].ToString());
                obj.MinimumStock = Convert.ToInt32(dr["MinimumStock"].ToString());
            }
            dr.Close();
            return await Task.Run(() => PartialView("ApproveProductStatus", obj));
        }

        // ========== Update Product Approval Status ========== //
        [HttpPost]
        public async Task<ActionResult> ApproveProductStatus1(Admin objA, string productname, string sellercode, string SellerFullName, string EmailId, string productcode)
        {
            objA.ProductApprovalDate = DateTime.Now;
            objAdmin.ApproveProductStatus(objA);

            objA.SellerCode = sellercode;
            objA.SellerFullName = SellerFullName;
            objA.EmailId = EmailId;
            objA.ProductCode = productcode;
            objA.ProductName = productname;
            DataSet ds = new DataSet();
            ds = objAdmin.GetEmail1(objA);

            objA.SellerCode = ds.Tables[0].Rows[0]["SellerCode"].ToString();
            objA.SellerFullName = ds.Tables[0].Rows[0]["SellerFullName"].ToString();
            objA.EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString();
            objA.ProductCode = productcode;
            objA.ProductName = productname;

            MailMessage mail = new MailMessage();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<br />");
            sb.AppendFormat("<b>Dear Seller,<b/>");
            sb.AppendFormat("<br />");
            sb.AppendLine("<b>Congratulations <b>" + " " + objA.SellerFullName + ",");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Welcome to <b>Agro E-Commerce,</b>");
            sb.AppendFormat("<br />");
            sb.AppendFormat("<b>Your Product" + " " + objA.ProductName + " " + "is Successfully Approved!</b> and Now You Can Start Your Business With Us.");
            sb.AppendFormat("<br />");
            sb.AppendFormat("<b>Agro E-Commerce Blessing and Wishing You for Your Business With Lot of Success...!!!");
            sb.AppendFormat("<br />");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Thanks and Regards,");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Agro E-Commerce,");
            sb.AppendFormat("<br />");
            sb.AppendFormat("<b>Contact-Us : </b>+919960796660");

            mail.From = new MailAddress("sagarkoli219@gmail.com");
            mail.Subject = "Request For Product Approval";
            mail.Body = sb.ToString();
            mail.To.Add(new MailAddress(objA.EmailId));
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("sagarkoli219@gmail.com", "pmvsoeqotqjybjij");
            smtp.EnableSsl = true;
            smtp.Send(mail);


            return await Task.Run(() => RedirectToAction("PendingProductList"));
        }


        // ========== Popup View for Product Rejection========== //
        public async Task<ActionResult> RejectProductStatus(Admin objA)
        {
            Admin obj = new Admin();
            obj.ProductCode = objA.ProductCode;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.ProductDetails(objA);
            while (dr.Read())
            {
                obj.ProductCode = dr["ProductCode"].ToString();
                obj.ProductName = dr["ProductName"].ToString();
                obj.SellerFullName = dr["SellerFullName"].ToString();
                obj.MobileNo = dr["MobileNo"].ToString();
                obj.OfficeAddress = dr["Office"].ToString();
                obj.Status = dr["Status"].ToString();
                obj.MRP = Convert.ToInt32(dr["MRP"].ToString());
                obj.MaximumStock = Convert.ToInt32(dr["MaximumStock"].ToString());
                obj.MinimumStock = Convert.ToInt32(dr["MinimumStock"].ToString());
            }
            dr.Close();
            ViewBag.RejectProductReason = new List<SelectListItem>()
            {
                new SelectListItem(){ Value="Product Ouality is not good",Text="Product Ouality is not good"},
                new SelectListItem(){ Value="Your location is to far",Text="Your location is to far"},
                new SelectListItem(){ Value="Product is not standardised",Text="Product is not standardised"},
                new SelectListItem(){ Value="Expiry Period is short",Text="Expiry Period is short"},
                new SelectListItem(){ Value="Stock Provided is minimum",Text="Stock Provided is minimum"},
                new SelectListItem(){ Value="Product difficult to delivery",Text="Product difficult to delivery"}
            };
            return await Task.Run(() => PartialView("RejectProductStatus", obj));
        }

        // ========== Update Product Rejection Status ========== //
        [HttpPost]
        public async Task<ActionResult> RejectProductStatus1(Admin objA, string productcode, string productname, string sellercode, string SellerFullName, string EmailId, string RejectionReason)
        {
            objAdmin.RejectProductStatus(objA);
            Response.Write("<script>alert('Update Successfully...!');</script>");

            objA.SellerCode = sellercode;
            objA.SellerFullName = SellerFullName;
            objA.EmailId = EmailId;
            objA.ProductCode = productcode;
            objA.ProductName = productname;
            objA.RejectionReason = RejectionReason;
            DataSet ds = new DataSet();
            ds = objAdmin.GetEmail1(objA);

            objA.SellerCode = ds.Tables[0].Rows[0]["SellerCode"].ToString();
            objA.SellerFullName = ds.Tables[0].Rows[0]["SellerFullName"].ToString();
            objA.EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString();
            objA.ProductCode = productcode;
            objA.ProductName = productname;
            objA.RejectionReason = RejectionReason;

            MailMessage mail = new MailMessage();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<br />");
            sb.AppendFormat("Dear Seller,");
            sb.AppendFormat("<br />");
            sb.AppendLine("" + " " + objA.SellerFullName + ",");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Thank You for Taking Time to Send a Product Approval.");
            sb.AppendFormat("<br />");
            sb.AppendFormat("We Have Carefully Reviewed Your Product Approval Against Our Requirements. However We Deeply Regret For Our Inability to Go Ahead With Your Product");
            sb.AppendFormat("<br />");
            sb.AppendFormat("<b>Agro E-Commerce Feel Sad to Reject Your Product Approval Requests</b>");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Because of" + " " + "<b>" + objA.RejectionReason + "</b> ");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Again, Thanks For Your Interest & Time.");
            sb.AppendFormat("We May Discuss Again In Future For Any Of Our Requirements.");
            sb.AppendFormat("<br />");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Best Regards,");
            sb.AppendFormat("<br />");
            sb.AppendFormat("Agro E-Commerce,");
            sb.AppendFormat("<br />");
            sb.AppendFormat("<b>Contact-Us : </b>+919960796660");

            mail.From = new MailAddress("sagarkoli219@gmail.com");
            mail.Subject = "Request For Product Approval";
            mail.Body = sb.ToString();
            mail.To.Add(new MailAddress(objA.EmailId));
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("sagarkoli219@gmail.com", "pmvsoeqotqjybjij");
            smtp.EnableSsl = true;
            smtp.Send(mail);



            return await Task.Run(() => RedirectToAction("PendingProductList"));
        }

        // ========== List View of All Orders ========== //
        [HttpGet]
        public async Task<ActionResult> AllOrder(int? id)
        {

            //if (Session["BuyerCode"] != null)
            //{
            Admin objA = new Admin();
            //string buyercode = Session["BuyerCode"].ToString();
            //objU.BuyerCode = buyercode;
            DataSet ds = new DataSet();
            ds = objAdmin.FilterButtons();
            List<Admin> StatusFIlter = new List<Admin>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                StatusFIlter.Add(new Admin
                {
                    Status = dr["Status"].ToString(),
                    StatusId = Convert.ToInt32(dr["StatusId"].ToString())
                });
                objA.Statuslst = StatusFIlter;
            }

            if (id == null)
            {
                //BALAdmin objAdmin = new BALAdmin();
                //DataSet ds = new DataSet();
                ds = objAdmin.AllOrder();
                //Admin objAd = new Admin();
                List<Admin> listord = new List<Admin>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Admin obj = new Admin();
                    obj.SellerFullName = ds.Tables[0].Rows[i]["SellerFullName"].ToString();
                    obj.OrderCode = ds.Tables[0].Rows[i]["OrderCode"].ToString();
                    obj.ProcessDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ProcessDate"].ToString());
                    obj.Date = obj.ProcessDate.ToShortDateString();
                    //obj.ProductCode = ds.Tables[0].Rows[i]["ProductCode"].ToString();
                    obj.ProductName = ds.Tables[0].Rows[i]["ProductName"].ToString();
                    //obj.ProductQuantity =Convert.ToInt32( ds.Tables[0].Rows[i]["ProductQuantity"].ToString());
                    obj.TotalAmount = ds.Tables[0].Rows[i]["TotalAmount"].ToString();


                    listord.Add(obj);
                }
                objA.LstOrder = listord;
                return await Task.Run(() => View(objA)); 


            }
            else
            {
                ds = objAdmin.OrderStatus(objA, (int)id);
                List<Admin> listord = new List<Admin>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Admin obj = new Admin();
                    obj.SellerFullName = ds.Tables[0].Rows[i]["SellerFullName"].ToString();
                    obj.OrderCode = ds.Tables[0].Rows[i]["OrderCode"].ToString();
                    obj.ProcessDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ProcessDate"].ToString());
                    obj.Date = obj.ProcessDate.ToShortDateString();
                    //obj.ProductCode = ds.Tables[0].Rows[i]["ProductCode"].ToString();
                    obj.ProductName = ds.Tables[0].Rows[i]["ProductName"].ToString();
                    //obj.ProductQuantity = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductQuantity"].ToString());
                    obj.TotalAmount = ds.Tables[0].Rows[i]["TotalAmount"].ToString();

                    listord.Add(obj);
                }
                objA.LstOrder = listord;
                return await Task.Run(() => View(objA));
            }



        }
        // ========== Details View of All Order ========== //
        [HttpPost]
        public async Task<ActionResult> AllOrderDetails(Admin objA)
        {


            Admin obj = new Admin();
            obj.OrderCode = objA.OrderCode;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.AllOrderDetails(objA);
            while (dr.Read())
            {
                obj.MainImage = dr["MainImage"].ToString();
                obj.OrderCode = dr["OrderCode"].ToString();
                obj.ShippingCharges = Convert.ToInt32( dr["ShippingCharges"].ToString());
                obj.BusinessName = dr["BusinessName"].ToString();
                obj.ProductCode = dr["ProductCode"].ToString();
                obj.TotalAmount = dr["TotalAmount"].ToString();
                obj.ProductName = dr["ProductName"].ToString();
                obj.ProcessDate = Convert.ToDateTime(dr["ProcessDate"].ToString());
                obj.Date = obj.ProcessDate.ToShortDateString();
                obj.Status = dr["Status"].ToString();
                obj.BuyerFullName = dr["BuyerFullName"].ToString();
                obj.ProductQuantity = Convert.ToInt32(dr["ProductQuantity"].ToString());
                obj.ProductWeight = dr["ProductWeight"].ToString();
                obj.MobileNo = dr["MobileNo"].ToString();
                obj.EmailId = dr["EmailId"].ToString();
                obj.HomeAddress = dr["address"].ToString();
            }
            dr.Close();
            return await Task.Run(() => PartialView("AllOrderDetails", obj));
        }
        // ========== List View of Category Approval Requests ========== //
        [HttpGet]
        public async Task<ActionResult> CategoryApproval()
        {
            //BALAdmin objAdmin = new BALAdmin();
            DataSet ds = new DataSet();
            ds = objAdmin.CategoryApproval();
            Admin objAd = new Admin();
            List<Admin> listcat = new List<Admin>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Admin obj = new Admin();
                obj.CategoryCode = ds.Tables[0].Rows[i]["CategoryCode"].ToString();
                obj.CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();


                listcat.Add(obj);
            }
            objAd.LstCat = listcat;
            return await Task.Run(() => View(objAd));
        }
        // ========== Details View of Category ========== //
        [HttpPost]
        public async Task<ActionResult> CategoryDetails(Admin objA)
        {
            Admin obj = new Admin();
            obj.SellerCode = objA.SellerCode;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.CategoryDetails(objA);
            while (dr.Read())
            {
                obj.CategoryCode = dr["CategoryCode"].ToString();
                obj.CategoryName = dr["CategoryName"].ToString();
            }
            dr.Close();
            return await Task.Run(() => PartialView("CategoryDetails", obj));
        }
        // ========== Details View of Category Approval ========== //
        [HttpGet]
        public async Task<ActionResult> CategoryApprove(Admin objA)
        {

            Admin obj = new Admin();
            obj.CategoryCode = objA.CategoryCode;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.CategoryDetails(objA);
            while (dr.Read())
            {
                obj.CategoryCode = dr["CategoryCode"].ToString();
                obj.CategoryName = dr["CategoryName"].ToString();
            }
            dr.Close();
            return await Task.Run(() => PartialView("CategoryApprove", obj));
        }

        // ========== Update Category Approval Status ========== //
        [HttpPost]
        public async Task<ActionResult> CategoryApprove1(Admin objA)
        {
            objAdmin.CategoryApprove(objA);
            return await Task.Run(() => RedirectToAction("CategoryApproval"));
        }

        // ========== Details View of Category Reject ========== //
        [HttpGet]
        public async Task<ActionResult> CategoryReject(Admin objA)
        {

            Admin obj = new Admin();
            obj.CategoryCode = objA.CategoryCode;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.CategoryDetails(objA);
            while (dr.Read())
            {
                obj.CategoryCode = dr["CategoryCode"].ToString();
                obj.CategoryName = dr["CategoryName"].ToString();
            }
            dr.Close();
            ViewBag.RejectCategory = new List<SelectListItem>()
            {
                new SelectListItem(){ Value="This Category is Already Exist",Text="This Category is Already Exist"},
                new SelectListItem(){ Value="This Category is Not Valid",Text="This Category is Not Valid"},
                new SelectListItem(){ Value="This Category is Not Match to Our Portal",Text="This Category is Not Match to Our Portal"}
            };
            return await Task.Run(() => PartialView("CategoryReject", obj));
        }

        // ========== Update Category Rejection Status ========== //
        [HttpPost]
        public async Task<ActionResult> CategoryReject1(Admin objA)
        {
            objAdmin.CategoryReject(objA);
            return await Task.Run(() => RedirectToAction("CategoryApproval"));
        }
        // ========== List View of SubCategory1 Approval Requests ========== //
        [HttpGet]
        public async Task<ActionResult> SubCategory1Approval()
        {
            //BALAdmin objAdmin = new BALAdmin();
            DataSet ds = new DataSet();
            ds = objAdmin.SubCategory1Approval();
            Admin objAd = new Admin();
            List<Admin> listsubcat1 = new List<Admin>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Admin obj = new Admin();
                obj.SubCategory1Code = ds.Tables[0].Rows[i]["SubCategory1Code"].ToString();
                obj.SubCategory1Name = ds.Tables[0].Rows[i]["SubCatagory1Name"].ToString();
                obj.CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();

                listsubcat1.Add(obj);
            }
            objAd.LstSubCat1 = listsubcat1;
            return await Task.Run(() => View(objAd));
        }

        // ========== Details View of SubCategory1 ========== //
        [HttpPost]
        public async Task<ActionResult> SubCategory1Details(Admin objA)
        {
            Admin obj = new Admin();
            obj.SubCategory1Code = objA.SubCategory1Code;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.SubCategory1Details(objA);
            while (dr.Read())
            {
                obj.SubCategory1Code = dr["SubCategory1Code"].ToString();
                obj.SubCategory1Name = dr["SubCatagory1Name"].ToString();
                obj.CategoryName = dr["CategoryName"].ToString();
            }
            dr.Close();
            return await Task.Run(() => PartialView("SubCategory1Details", obj));
        }

        // ========== Details View of SubCategory1 Approval ========== //
        [HttpGet]
        public async Task<ActionResult> SubCategory1Approve(Admin objA)
        {

            Admin obj = new Admin();
            obj.SubCategory1Code = objA.SubCategory1Code;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.SubCategory1Details(objA);
            while (dr.Read())
            {
                obj.SubCategory1Code = dr["SubCategory1Code"].ToString();
                obj.SubCategory1Name = dr["SubCatagory1Name"].ToString();
                obj.CategoryName = dr["CategoryName"].ToString();
            }
            dr.Close();
            return await Task.Run(() => PartialView("SubCategory1Approve", obj));
        }

        // ========== Update SubCategory1 Approval Status ========== //
        [HttpPost]
        public async Task<ActionResult> SubCategory1Approve1(Admin objA)
        {
            objAdmin.SubCategory1Approve(objA);
            return await Task.Run(() => RedirectToAction("SubCategory1Approval"));
        }

        // ========== Details View of SubCategory1 Rejection ========== //
        [HttpGet]
        public async Task<ActionResult> SubCategory1Reject(Admin objA)
        {

            Admin obj = new Admin();
            obj.SubCategory1Code = objA.SubCategory1Code;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.SubCategory1Details(objA);
            while (dr.Read())
            {
                obj.SubCategory1Code = dr["SubCategory1Code"].ToString();
                obj.SubCategory1Name = dr["SubCatagory1Name"].ToString();
                obj.CategoryName = dr["CategoryName"].ToString();
            }
            dr.Close();

            return await Task.Run(() => PartialView("SubCategory1Reject", obj));
        }

        // ========== Update SubCategory1 Rejection Status ========== //
        [HttpPost]
        public async Task<ActionResult> SubCategory1Reject1(Admin objA)
        {
            objAdmin.SubCategory1Reject(objA);
            return await Task.Run(() => RedirectToAction("SubCategory1Approval"));
        }
        // ========== List View of SubCategory2 Approval Requests ========== //
        [HttpGet]
        public async Task<ActionResult> SubCategory2Approval()
        {
            //BALAdmin objAdmin = new BALAdmin();
            DataSet ds = new DataSet();
            ds = objAdmin.SubCategory2Approval();
            Admin objAd = new Admin();
            List<Admin> listsubcat2 = new List<Admin>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Admin obj = new Admin();
                obj.SubCategory2Code = ds.Tables[0].Rows[i]["SubCategory2Code"].ToString();
                obj.SubCategory2Name = ds.Tables[0].Rows[i]["SubCatagory2Name"].ToString();
                obj.SubCategory1Name = ds.Tables[0].Rows[i]["SubCatagory1Name"].ToString();
                obj.CategoryName = ds.Tables[0].Rows[i]["CategoryName"].ToString();


                listsubcat2.Add(obj);
            }
            objAd.LstSubCat2 = listsubcat2;
            return await Task.Run(() => View(objAd));
        }

        // ========== Details View of SubCategory2 ========== //
        [HttpPost]
        public async Task<ActionResult> SubCategory2Details(Admin objA)
        {
            Admin obj = new Admin();
            obj.SubCategory2Code = objA.SubCategory2Code;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.SubCategory2Details(objA);
            while (dr.Read())
            {
                obj.SubCategory2Code = dr["SubCategory2Code"].ToString();
                obj.SubCategory2Name = dr["SubCatagory2Name"].ToString();
                obj.SubCategory1Name = dr["SubCatagory1Name"].ToString();
                obj.CategoryName = dr["CategoryName"].ToString();
            }
            dr.Close();
            return await Task.Run(() => PartialView("SubCategory2Details", obj));
        }

        // ========== Details View of SubCategory2 Approval ========== //
        [HttpGet]
        public async Task<ActionResult> SubCategory2Approve(Admin objA)
        {

            Admin obj = new Admin();
            obj.SubCategory2Code = objA.SubCategory2Code;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.SubCategory2Details(objA);
            while (dr.Read())
            {
                obj.SubCategory2Code = dr["SubCategory2Code"].ToString();
                obj.SubCategory2Name = dr["SubCatagory2Name"].ToString();
                obj.SubCategory1Name = dr["SubCatagory1Name"].ToString();
                obj.CategoryName = dr["CategoryName"].ToString();
            }
            dr.Close();
            return await Task.Run(() => PartialView("SubCategory2Approve", obj));
        }

        // ========== Update SubCategory2 Approval Status ========== //
        [HttpPost]
        public async Task<ActionResult> SubCategory2Approve1(Admin objA)
        {
            objAdmin.SubCategory2Approve(objA);
            return await Task.Run(() => RedirectToAction("SubCategory2Approval"));
        }

        // ========== Details View of SubCategory2 Rejection ========== //
        [HttpGet]
        public async Task<ActionResult> SubCategory2Reject(Admin objA)
        {

            Admin obj = new Admin();
            obj.SubCategory2Code = objA.SubCategory2Code;
            //BALAdmin objBal = new BALAdmin();
            SqlDataReader dr;
            dr = objAdmin.SubCategory2Details(objA);
            while (dr.Read())
            {
                obj.SubCategory2Code = dr["SubCategory2Code"].ToString();
                obj.SubCategory2Name = dr["SubCatagory2Name"].ToString();
                obj.SubCategory1Name = dr["SubCatagory1Name"].ToString();
                obj.CategoryName = dr["CategoryName"].ToString();
            }
            dr.Close();

            return await Task.Run(() => PartialView("SubCategory2Reject", obj));
        }

        // ========== Update SubCategory2 Rejection Status ========== //
        [HttpPost]
        public async Task<ActionResult> SubCategory2Reject1(Admin objA)
        {
            objAdmin.SubCategory2Reject(objA);
            return await Task.Run(() => RedirectToAction("SubCategory2Approval"));
        }
        /////////////-----Sagar end--------------////////
        public async Task<ActionResult> BuyerDetails(Admin admin)
        {
            try
            {
                DataSet ds = objAdmin.AllBuyerDetail();
                List<Admin> buyerList = new List<Admin>();
                Admin objadmin = new Admin();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    buyerList.Add(new Admin
                    {
                        BuyerFullName = dr["BuyerFullName"].ToString(),
                        BuyerCode = dr["BuyerCode"].ToString(),
                        EmailId = dr["EmailId"].ToString(),
                        MobileNo = dr["MobileNo"].ToString(),
                        TotalOrder = Convert.ToInt32(dr["totalorder"].ToString()),

                    });

                }
                objadmin.Buyers = buyerList;
                return await Task.Run(() => View(objadmin));
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<ActionResult> BuyerOrderDetails(Admin objadm)
        {
            try
            {
                SellerName();
                Admin buyerorders = new Admin();
                DataSet ds = objAdmin.BuyerOrderDetails(objadm); 
            List<Admin> Orderdetails = new List<Admin>();
          
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Admin admin1 = new Admin();

                    admin1.BuyerFullName = (ds.Tables[0].Rows[i]["BuyerFullName"].ToString());
                    admin1.BuyerCode = (ds.Tables[0].Rows[i]["BuyerCode"].ToString());
                    admin1.OrderCode = (ds.Tables[0].Rows[i]["OrderCode"].ToString());
                    admin1.ProductCode = (ds.Tables[0].Rows[i]["ProductCode"].ToString());
                    admin1.ProductName = (ds.Tables[0].Rows[i]["ProductName"].ToString());
                    admin1.SellerFullName = (ds.Tables[0].Rows[i]["SellerFullName"].ToString());
                    admin1.ProductQuantity = Convert.ToInt32((ds.Tables[0].Rows[i]["ProductQuantity"].ToString()));
                    //admin1.ProcessDate = Convert.ToDateTime((ds.Tables[0].Rows[i]["ProcessDate"].ToString()));
                    admin1.ProcessDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ProcessDate"].ToString());
                    admin1.Date = admin1.ProcessDate.ToShortDateString(); 
                    admin1.PaymentMode = (ds.Tables[0].Rows[i]["PaymentMode"].ToString());
                    admin1.TransactionId = (ds.Tables[0].Rows[i]["TransactionId"].ToString());
                  string address = (ds.Tables[0].Rows[i]["address"].ToString());
                    admin1.Address = address.Replace("@", ",");





                    Orderdetails.Add(admin1);
                    ViewBag.buyerfullname = admin1.BuyerFullName.ToString();
                    ViewBag.buyercode = admin1.BuyerCode.ToString();
                }
                buyerorders.BuyerOrders = Orderdetails;
            
                return await Task.Run(() => View(buyerorders));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        ///////////////////////IndreJeet/////////////
        ///
        public async Task<ActionResult> SellerDetailsGrid()//////////Seller Details Grid
        {
            TotalSeller();
            activeseller();
            inactiveseller(); 
            BALAdmin objUser = new BALAdmin();
            DataSet ds = new DataSet();
            ds = objUser.SellerGrid();
            Admin objDetails = new Admin();
            List<Admin> LstUserDt1 = new List<Admin>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Admin obj = new Admin();
                obj.SellerCode = (ds.Tables[0].Rows[i]["SellerCode"].ToString());
                obj.SellerFullName = (ds.Tables[0].Rows[i]["SellerFullName"].ToString());
                obj.EmailId = ds.Tables[0].Rows[i]["EmailId"].ToString();
                obj.BusinessName = ds.Tables[0].Rows[i]["BusinessName"].ToString();
                obj.MobileNo = (ds.Tables[0].Rows[i]["MobileNo"].ToString());
                obj.GSTIN = ds.Tables[0].Rows[i]["GSTIN"].ToString();
                obj.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                obj.HomeAddress = ds.Tables[0].Rows[i]["Home"].ToString();
                obj.OfficeAddress= ds.Tables[0].Rows[i]["Office"].ToString();
                obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                // obj. = ds.Tables[0].Rows[i]["Password"].ToString();
                LstUserDt1.Add(obj);

            }
            objDetails.ListUser = LstUserDt1;

            return await Task.Run(()=> View(objDetails));
        }
        public async Task<ActionResult> Delete(Admin Obj, string Applylist)////////Seller Multiple Delete
        {
            BALAdmin obj = new BALAdmin();
            if (Applylist != null)
            {
                string temp = Applylist;
                string[] sellerCode = temp.Split(',');

                for (int i = 0; i < sellerCode.Length; i++)
                {
                    string sellercode = sellerCode[i];
                    obj.SellerDelete(sellercode);
                }
                return RedirectToAction("Index");
            }
            obj.SellerDelete(Obj.SellerCode);
            TotalSeller();
            return await Task.Run(() => RedirectToAction("SellerDetailsGrid"));
            // ViewBag.message("Delete sucessfulluy");
        }
        [HttpGet]
        public async Task<ActionResult> Detail(string SellerCode)/////////////Seller Details
        {
            try
            {


                Admin obj = new Admin();
                obj.SellerCode = SellerCode;
                BALAdmin obj1 = new BALAdmin();
                SqlDataReader dr;
                dr = obj1.GetData(SellerCode);
                while (dr.Read())
                {
                    // obj.Id = Convert.ToInt32(dr["id"].ToString());
                    obj.SellerCode = (dr["SellerCode"].ToString());
                    obj.SellerFullName = (dr["SellerFullName"].ToString());
                    obj.EmailId = dr["EmailId"].ToString();
                    obj.BusinessName = dr["BusinessName"].ToString();
                    obj.MobileNo = (dr["MobileNo"].ToString());
                    obj.GSTIN = dr["GSTIN"].ToString();
                    obj.Gender = dr["Gender"].ToString();
                    obj.HomeAddress = dr["Home"].ToString();
                    obj.OfficeAddress = dr["Office"].ToString();
                }
                dr.Close();
                return await Task.Run(() => PartialView("Detail", obj));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ActionResult> Updateseller(string SellerCode, int statusid)
        {
            activeseller();
            inactiveseller();
            Admin objAdmin = new Admin();
            objAdmin.SellerCode = SellerCode;
            objAdmin.StatusId = statusid;
            BALAdmin obj1 = new BALAdmin();

            // if (objAdmin.StatusId == 1)
            // {
            //     obj1.ActiveSeller(objAdmin);
            // }
            //if(objAdmin.StatusId == 2)
            // {
            //     obj1.Reactive(objAdmin);
            // }
            obj1.ActiveSeller(objAdmin);


            return await Task.Run(() => RedirectToAction("SellerDetailsGrid"));
            // ViewBag.message("Delete sucessfulluy");
        }


        public void TotalSeller()

        {

            //if (Session["AdminId"] != null)
            //{
            Admin sellercode = new Admin();


            BALAdmin obj1 = new BALAdmin();
            SqlDataReader dr;
            dr = obj1.TotalSeller();
            while (dr.Read())
            {
              //  ViewBag.Sellers = dr["TotalSeller"].ToString();
                Session["TotalSeller"] = (dr["TotalSeller"].ToString());

            }
            dr.Close();
            //eturn View();
            //}else 
            //{ 
            //    return RedirectToAction("Login");
            //}
        }
        public void activeseller()

        {
            //if (Session["AdminId"] != null)
            //{
            Admin sellercode = new Admin();


            BALAdmin obj1 = new BALAdmin();
            SqlDataReader dr;
            dr = obj1.activeseller();
            while (dr.Read())
            {
                //ViewBag.Sellers = dr["ActiveSeller"].ToString();
                Session["ActiveSeller"] = (dr["ActiveSeller"].ToString());

            }
            dr.Close();
            // return View();
            //}else 
            //{ 
            //    return RedirectToAction("Login");
            //}
        }
        public void inactiveseller()

        {
            //if (Session["AdminId"] != null)
            //{
            Admin sellercode = new Admin();


            BALAdmin obj1 = new BALAdmin();
            SqlDataReader dr;
            dr = obj1.reactiveseller();
            while (dr.Read())
            {
                //ViewBag.Sellers = dr["ActiveSeller"].ToString();
                Session["InActiveSeller"] = (dr["InActiveSeller"].ToString());

            }
            dr.Close();
            // return View();
            //}else 
            //{ 
            //    return RedirectToAction("Login");
            //}
        }
        /////////////--------------Vittal Start---------///////////
        //-----------Add new Coupon---------
        [HttpGet]
        public async Task<ActionResult> ManageCoupon()
        {
            if (Session["AdminFullName"] != null)
            {
                return await Task.Run(() => PartialView("ManageCoupon"));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //----------- post method Add new Coupon---------
        [HttpPost]
        public async Task<ActionResult> ManageCoupon(Admin ObjAdmin)
        {
            if (Session["AdminFullName"] != null)
            {
                String min = ObjAdmin.CouponMinimumAmount.ToString();
                string max = ObjAdmin.CouponMaximumAmount.ToString();
                ObjAdmin.CouponRange = (min + "-" + max);
                obj.SaveCoupon(ObjAdmin);

                return await Task.Run(() => RedirectToAction("FetchCoupon"));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //-----------Show List of Coupon---------
        public async Task<ActionResult> FetchCoupon()
        {
            if (Session["AdminFullName"] != null)
            {
                Admin objad = new Admin();
                List<Admin> listS = new List<Admin>();
                DataSet dt = new DataSet();

                dt = obj.FetchCoupon();

                foreach (DataRow item in dt.Tables[0].Rows)
                {
                    Admin objadmin = new Admin();
                    objadmin.CouponId = Convert.ToInt32(item["CouponId"].ToString());
                    objadmin.Status = item["Status"].ToString();
                    objadmin.CouponCode = item["CouponCode"].ToString();
                    objadmin.CouponAmount = Convert.ToInt32(item["CouponAmount"].ToString());
                    objadmin.CouponRange = item["CouponRange"].ToString();
                    objadmin.Expirydays = item["ExpiryDays"].ToString();
                    listS.Add(objadmin);
                }
                objad.admins = listS;
                return await Task.Run(() => View(objad));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //-----------Chane status of Coupon active or inactive---------
        public async Task<ActionResult> ChangeCouponStatus(string CouponCode, int statusid)
        {
            if (Session["AdminFullName"] != null)
            {
                Admin objadmin = new Admin();
                objadmin.StatusId = statusid;
                objadmin.CouponCode = CouponCode;
                obj.ChangeCouponStatus(objadmin);
                return await Task.Run(() => RedirectToAction("FetchCoupon"));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //-----------chane status of Reward active or Inactive---------
        public async Task<ActionResult> ChangeRewardStatus(int Reawardid, int statusid)
        {
            if (Session["AdminFullName"] != null)
            {
                Admin objadmin = new Admin();
                objadmin.StatusId = statusid;
                objadmin.RewardId = Reawardid;
                obj.ChangeRewardStatus(objadmin);
                return await Task.Run(() => RedirectToAction("FetchReward"));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //-----------Details of Coupon Coupon---------

        public async Task<ActionResult> DetailsCoupon(string CouponCode)
        {
            if (Session["AdminFullName"] != null)
            {
                Admin objadmin = new Admin();
                objadmin.CouponCode = CouponCode;
                SqlDataReader dr;
                dr = obj.DetailsCoupon(objadmin);
                while (dr.Read())
                {
                    objadmin.CouponCode = dr["CouponCode"].ToString();
                    objadmin.CouponAmount = Convert.ToInt32(dr["CouponAmount"].ToString());
                    String CouponRange = dr["CouponRange"].ToString();
                    string[] Range = CouponRange.Split('-');
                    objadmin.CouponMaximumAmount = Convert.ToInt32(Range[1]);
                    objadmin.CouponMinimumAmount = Convert.ToInt32(Range[0]);
                    objadmin.Expirydays = dr["ExpiryDays"].ToString();
                }
                return await Task.Run(() => PartialView("DetailsCoupon", objadmin));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //-----------Edit  Coupon---------
        [HttpGet]
        public async Task<ActionResult> EditCoupon(String CouponCode)
        {
            if (Session["AdminFullName"] != null)
            {
                Admin objadmin = new Admin();

                objadmin.CouponCode = CouponCode;
                SqlDataReader dr;
                dr = obj.DetailsCoupon(objadmin);
                while (dr.Read())
                {
                    objadmin.CouponId = Convert.ToInt32(dr["CouponId"].ToString());
                    objadmin.CouponCode = dr["CouponCode"].ToString();
                    objadmin.CouponAmount = Convert.ToInt32(dr["CouponAmount"].ToString());
                    String CouponRange = dr["CouponRange"].ToString();
                    string[] Range = CouponRange.Split('-');
                    objadmin.CouponMaximumAmount = Convert.ToInt32(Range[1]);
                    objadmin.CouponMinimumAmount = Convert.ToInt32(Range[0]);
                    objadmin.Expirydays = dr["ExpiryDays"].ToString();
                }
                return await Task.Run(() => PartialView("EditCoupon", objadmin));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //-----------Edit  Coupon post method---------
        [HttpPost]
        public async Task<ActionResult> EditCoupon(Admin objAdmin)
        {
            if (Session["AdminFullName"] != null)
            {
                String min = objAdmin.CouponMinimumAmount.ToString();
                string max = objAdmin.CouponMaximumAmount.ToString();
                objAdmin.CouponRange = (min + "-" + max);
                obj.EditCoupon(objAdmin);

                return await Task.Run(() => RedirectToAction("FetchCoupon"));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }

        }
        //-----Delete Coupon---------------
        [HttpGet]
        public async Task<ActionResult> DeleteCoupon(int couponid)
        {
            if (Session["AdminFullName"] != null)
            {
                Admin objAdmin = new Admin();
                objAdmin.CouponId = couponid;
                obj.DeleteCoupon(objAdmin);
                return await Task.Run(() => RedirectToAction("FetchCoupon"));
            }

            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //--------Show list of Reward------
        public async Task<ActionResult> FetchReward()
        {
            if (Session["AdminFullName"] != null)
            {
                Session["Pagedetail"] = "";
                Admin objad = new Admin();
                List<Admin> listS = new List<Admin>();
                DataSet dt = new DataSet();

                dt = obj.FetchReward();

                foreach (DataRow item in dt.Tables[0].Rows)
                {
                    Admin objadmin = new Admin();
                    objadmin.RewardId = Convert.ToInt32(item["RewardId"].ToString());
                    objadmin.rewid = objadmin.RewardId;
                    objadmin.Status = item["Status"].ToString();
                    objadmin.RewardPoints = Convert.ToInt32(item["RewardPoint"].ToString());
                    objadmin.RewardConversionRate = Convert.ToSingle(item["RewardConversionRate"].ToString());
                    objadmin.RewardRange = item["RewardRange"].ToString();
                    objadmin.PointLimits = Convert.ToInt32(item["PointLimits"].ToString());
                    objadmin.RewardId = Convert.ToInt32(item["RewardId"].ToString());
                    listS.Add(objadmin);
                }
                objad.admins = listS;
                return await Task.Run(() => View(objad));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //----------Add  new Reward--------------
        [HttpGet]
        public async Task<ActionResult> ManageReward()
        {
            if (Session["AdminFullName"] != null)
            {
                return await Task.Run(() => PartialView("ManageReward"));
            }

            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //-----Add new Reward Post Method--------
        [HttpPost]
        public async Task<ActionResult> ManageReward(Admin ObjAdmin)
        {
            if (Session["AdminFullName"] != null)
            {
                Admin objAdmin = new Admin();
                String min = ObjAdmin.RewardMinimumAmount.ToString();
                string max = ObjAdmin.RewardMaximumAmount.ToString();
                ObjAdmin.RewardRange = (min + "-" + max);
                obj.SaveReward(ObjAdmin);

                return await Task.Run(() => RedirectToAction("FetchReward"));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //----------detail view of reward---------
        [HttpGet]
        public async Task<ActionResult> DetailsReward(string RewardId)
        {
            if (Session["AdminFullName"] != null)
            {
                Session["Pagedetail"] = "Detail Reward";
                Admin objadmin = new Admin();
                //objadmin.PointLimits = pointlimit;
                objadmin.RewardId = Convert.ToInt32(RewardId);
                SqlDataReader dr;
                dr = obj.DetailsReward(objadmin);
                while (dr.Read())
                {
                    objadmin.RewardId = Convert.ToInt32(dr["RewardId"].ToString());
                    objadmin.RewardPoints = Convert.ToInt32(dr["RewardPoint"].ToString());
                    objadmin.RewardConversionRate = Convert.ToSingle(dr["RewardConversionRate"].ToString());
                    String CouponRange = dr["RewardRange"].ToString();
                    string[] Range = CouponRange.Split('-');
                    objadmin.RewardMaximumAmount = Convert.ToInt32(Range[1]);
                    objadmin.RewardMinimumAmount = Convert.ToInt32(Range[0]);
                    objadmin.PointLimits = Convert.ToInt32(dr["PointLimits"].ToString());

                }
                return await Task.Run(() => PartialView("DetailsReward", objadmin));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //-------Edit reward get Method------
        [HttpGet]
        public async Task<ActionResult> EditReward(string RewardId)
        {
            if (Session["AdminFullName"] != null)
            {
                try
                {


                    Admin objadmin = new Admin();
                    //objadmin.PointLimits = pointlimit;
                    objadmin.RewardId = Convert.ToInt32(RewardId);
                    SqlDataReader dr;
                    dr = obj.DetailsReward(objadmin);
                    while (dr.Read())
                    {
                        objadmin.RewardId = Convert.ToInt32(dr["RewardId"].ToString());
                        objadmin.RewardPoints = Convert.ToInt32(dr["RewardPoint"].ToString());
                        objadmin.RewardConversionRate = Convert.ToSingle(dr["RewardConversionRate"].ToString());
                        String CouponRange = dr["RewardRange"].ToString();
                        string[] Range = CouponRange.Split('-');
                        objadmin.RewardMaximumAmount = Convert.ToInt32(Range[1]);
                        objadmin.RewardMinimumAmount = Convert.ToInt32(Range[0]);
                        objadmin.PointLimits = Convert.ToInt32(dr["PointLimits"].ToString());

                    }
                    dr.Close();
                    return await Task.Run(() => PartialView("EditReward", objadmin));
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //--------- Edit rewrad post Method--------
        [HttpPost]
        public async Task<ActionResult> EditReward(Admin objAdmin)
        {
            if (Session["AdminFullName"] != null)
            {
                String min = objAdmin.RewardMinimumAmount.ToString();
                string max = objAdmin.RewardMaximumAmount.ToString();
                objAdmin.RewardRange = (min + "-" + max);
                obj.EditReward(objAdmin);

                return await Task.Run(() => RedirectToAction("FetchReward"));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }

        }
        //--------Delete Reward -----------
        [HttpGet]
        public async Task<ActionResult> DeleteReward(int RewardId)
        {
            if (Session["AdminFullName"] != null)
            {
                Admin objAdmin = new Admin();
                objAdmin.RewardId = RewardId;
                obj.DeleteReward(objAdmin);
                return await Task.Run(() => RedirectToAction("FetchReward"));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        /////////////--------------Vittal End--------//////////////////
        ///

        ////------------Dhanashri Start -----////

        [HttpGet]
        public async Task<ActionResult> PaymentHistory(Admin objAd)
        {
            DataSet ds = new DataSet();
            ds = objAdmin.PaymentHistory();
            List<Admin> listpro = new List<Admin>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Admin obj = new Admin();
                obj.SellerCode = ds.Tables[0].Rows[i]["SellerCode"].ToString();
                obj.SellerFullName = ds.Tables[0].Rows[i]["SellerFullName"].ToString();
                obj.TotalOrders = ds.Tables[0].Rows[i]["TotalOrders"].ToString();
                obj.TotalAmountReceived = Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalAmountReceived"].ToString());
                obj.TotalShippingCharges = Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalShippingCharges"].ToString());
                obj.PaidAmt = Convert.ToDecimal(ds.Tables[0].Rows[i]["PaidAmt"].ToString());
                obj.PreviousBalanceAmt = Convert.ToDecimal(ds.Tables[0].Rows[i]["PreviousBalanceAmt"].ToString());
                listpro.Add(obj);
            }
            objAd.admins = listpro;
            return await Task.Run(() => View(objAd));
        }
        [HttpGet]
        public JsonResult FilterPaymentHistory(Admin objAd, DateTime startdate, DateTime enddate)
        {
            objAd.FromDate = startdate;
            objAd.ToDate = enddate;
            DataSet ds = new DataSet();
            ds = objAdmin.FilterPaymentHistory(objAd);
            List<Admin> listpro = new List<Admin>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Admin obj = new Admin();
                obj.SellerCode = ds.Tables[0].Rows[i]["SellerCode"].ToString();
                obj.SellerFullName = ds.Tables[0].Rows[i]["SellerFullName"].ToString();
                obj.TotalOrders = ds.Tables[0].Rows[i]["TotalOrders"].ToString();
                obj.TotalAmountReceived = Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalAmountReceived"].ToString());
                obj.TotalShippingCharges = Convert.ToDecimal(ds.Tables[0].Rows[i]["TotalShippingCharges"].ToString());
                obj.PaidAmt = Convert.ToDecimal(ds.Tables[0].Rows[i]["PaidAmt"].ToString());
                obj.PreviousBalanceAmt = Convert.ToDecimal(ds.Tables[0].Rows[i]["PreviousBalanceAmt"].ToString());
                listpro.Add(obj);
            }
            objAd.admins = listpro;
            return Json(listpro, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> PaymentDetails(string sellercode)
        {
            Admin obj = new Admin();
            obj.SellerCode = sellercode;
            SqlDataReader dr;
            dr = objAdmin.PaymentDetailsDD(obj);
            while (dr.Read())
            {
                obj.SellerCode = dr["SellerCode"].ToString();
                obj.SellerFullName = dr["SellerFullName"].ToString();
                obj.TotalOrders = dr["TotalOrders"].ToString();
                obj.TotalAmountReceived = Convert.ToDecimal(dr["TotalAmountReceived"].ToString());
                obj.TotalShippingCharges = Convert.ToDecimal(dr["TotalShippingCharges"].ToString());
                obj.PaidAmt = Convert.ToDecimal(dr["PaidAmt"].ToString());
                obj.PreviousBalanceAmt = Convert.ToDecimal(dr["PreviousBalanceAmt"].ToString());
            }
            ViewBag.SellerFullName = obj.SellerFullName;
            ViewBag.TotalOrders = obj.TotalOrders;
            ViewBag.TotalAmountReceived = obj.TotalAmountReceived;
            ViewBag.TotalShippingCharges = obj.TotalShippingCharges;
            ViewBag.PaidAmt = obj.PaidAmt;
            ViewBag.PreviousBalanceAmt = obj.PreviousBalanceAmt;
            dr.Close();
            DataSet ds = new DataSet();
            ds = objAdmin.RefundedAmount(obj);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                obj.RefundedAmount += Convert.ToDecimal(ds.Tables[0].Rows[i]["RefundedAmount"].ToString());
            }
            if (obj.RefundedAmount == null)
            {
                obj.RefundedAmount = 0;
            }
            ViewBag.RefundedAmount = obj.RefundedAmount;

            ds = objAdmin.PaymentDetails(obj);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Admin objA = new Admin();

                objA.SellerFullName = ds.Tables[0].Rows[i]["SellerFullName"].ToString();

                objA.CommissiontoAdmin = ds.Tables[0].Rows[i]["CommissiontoAdmin"].ToString();
                if (objA.CommissiontoAdmin == "")
                {
                    TotalCommission += 0;
                }
                else
                {
                    TotalCommission += Convert.ToDecimal(ds.Tables[0].Rows[i]["CommissiontoAdmin"].ToString());
                }
            }
            ViewBag.TotalCommission = TotalCommission;
            ViewBag.TotalPayToSeller = ViewBag.TotalAmountReceived - ViewBag.TotalShippingCharges -
                ViewBag.TotalCommission - ViewBag.RefundedAmount + ViewBag.PreviousBalanceAmt;
            return await Task.Run(() => PartialView(obj));

        }
        [HttpGet]
        public async Task<ActionResult> FilterPaymentDetails(string sellercode, DateTime startdate, DateTime enddate)
        {
            Admin obj = new Admin();
            obj.FromDate = startdate;
            obj.ToDate = enddate;
            obj.SellerCode = sellercode;
            SqlDataReader dr;
            dr = objAdmin.FilterPaymentDetailsDD(obj);
            while (dr.Read())
            {
                obj.SellerCode = dr["SellerCode"].ToString();
                obj.SellerFullName = dr["SellerFullName"].ToString();
                obj.TotalOrders = dr["TotalOrders"].ToString();
                obj.TotalAmountReceived = Convert.ToDecimal(dr["TotalAmountReceived"].ToString());
                obj.TotalShippingCharges = Convert.ToDecimal(dr["TotalShippingCharges"].ToString());
                obj.PaidAmt = Convert.ToDecimal(dr["PaidAmt"].ToString());
                obj.PreviousBalanceAmt = Convert.ToDecimal(dr["PreviousBalanceAmt"].ToString());
            }
            ViewBag.SellerFullName = obj.SellerFullName;
            ViewBag.TotalOrders = obj.TotalOrders;
            ViewBag.TotalAmountReceived = obj.TotalAmountReceived;
            ViewBag.TotalShippingCharges = obj.TotalShippingCharges;
            ViewBag.PaidAmt = obj.PaidAmt;
            ViewBag.PreviousBalanceAmt = obj.PreviousBalanceAmt;
            dr.Close();
            DataSet ds = new DataSet();
            ds = objAdmin.FilterRefundedAmount(obj);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                obj.RefundedAmount += Convert.ToDecimal(ds.Tables[0].Rows[i]["RefundedAmount"].ToString());
            }
            if (obj.RefundedAmount == null)
            {
                obj.RefundedAmount = 0;
            }
            ViewBag.RefundedAmount = obj.RefundedAmount;

            ds = objAdmin.FilterPaymentDetails(obj);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Admin objA = new Admin();

                objA.SellerFullName = ds.Tables[0].Rows[i]["SellerFullName"].ToString();

                objA.CommissiontoAdmin = ds.Tables[0].Rows[i]["CommissiontoAdmin"].ToString();
                if (objA.CommissiontoAdmin == "")
                {
                    TotalCommission += 0;
                }
                else
                {
                    TotalCommission += Convert.ToDecimal(ds.Tables[0].Rows[i]["CommissiontoAdmin"].ToString());
                }
            }
            ViewBag.TotalCommission = TotalCommission;
            ViewBag.TotalPayToSeller = ViewBag.TotalAmountReceived - ViewBag.TotalShippingCharges -
                ViewBag.TotalCommission - ViewBag.RefundedAmount + ViewBag.PreviousBalanceAmt;
            return await Task.Run(() => PartialView(obj));

        }
        [HttpGet]
        public async Task<ActionResult> RefundRequest(Admin objAd)
        {

            DataSet ds = new DataSet();
            ds = objAdmin.RefundRequest();

            List<Admin> listpro = new List<Admin>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Admin obj = new Admin();
                obj.SellerFullName = ds.Tables[0].Rows[i]["SellerFullName"].ToString();
                obj.OrderCode = ds.Tables[0].Rows[i]["OrderCode"].ToString();
                obj.BuyerFullName = ds.Tables[0].Rows[i]["BuyerFullName"].ToString();
                obj.RejectionReason = ds.Tables[0].Rows[i]["RejectionReason"].ToString();
                obj.MobileNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();
                obj.EmailId = ds.Tables[0].Rows[i]["EmailId"].ToString();
                //obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                obj.Total = Convert.ToInt32(ds.Tables[0].Rows[i]["Total"].ToString());
                listpro.Add(obj);
            }
            objAd.admins = listpro;
            return await Task.Run(() => View(objAd)); 
        }
        [HttpPost]
        public async Task<ActionResult> RefundToBuyer(Admin objAd, string orderno)
        {
            objAd.OrderCode = orderno;
            objAdmin.RefundToBuyer(objAd);
            var Status = new { data = "success" };
            return await Task.Run(() => Json(Status, JsonRequestBehavior.AllowGet));
        }
        [HttpGet]
        public JsonResult FilterForRefundRequests(Admin objAd, DateTime startdate, DateTime enddate)
        {
            objAd.FromDate = startdate;
            objAd.ToDate = enddate;
            DataSet ds = new DataSet();
            ds = objAdmin.FilterForRefundRequests(objAd);

            List<Admin> listpro = new List<Admin>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Admin obj = new Admin();
                obj.SellerFullName = ds.Tables[0].Rows[i]["SellerFullName"].ToString();
                obj.OrderCode = ds.Tables[0].Rows[i]["OrderCode"].ToString();
                obj.BuyerFullName = ds.Tables[0].Rows[i]["BuyerFullName"].ToString();
                obj.RejectionReason = ds.Tables[0].Rows[i]["RejectionReason"].ToString();
                obj.MobileNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();
                obj.EmailId = ds.Tables[0].Rows[i]["EmailId"].ToString();
                //obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                obj.Total = Convert.ToInt32(ds.Tables[0].Rows[i]["Total"].ToString());
                listpro.Add(obj);
            }
            objAd.admins = listpro;
            return Json(listpro, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult Index(DateTime? start, DateTime? end)
        //{
        //    var ExpenseDetails = _context.ExpenseDetails.Include(s => s.expenses).ToList();

        //    return View(ExpenseDetails);
        //}

        ////------------------------Dhanashri End -----////
        //////////------------------Ankita Start------------///////////
        public ActionResult AdminGrid()
        {
            //TotalSeller
            SqlDataReader dr;
            dr = objAdmin.Seller();//functionname from BALAdmin
            while (dr.Read())
            {
                Session["TotalSeller"] = dr["TotalSeller"].ToString();//colomname from sql query
            }
            dr.Close();
            ////Total Product
            //BALAdmin objAddmin = new BALAdmin();
            SqlDataReader dt;
            dt = objAdmin.TotalProducts();//functionname from bal
            while (dt.Read())
            {
                Session["TotalProduct"] = dt["Totalproduct"].ToString();
            }
            dt.Close();
            //For TotalCoustmore

            SqlDataReader ds;
            ds = objAdmin.Coustmore();//functionname from BALAdmin
            while (ds.Read())
            {
                Session["TotalBuyer"] = ds["TotalBuyer"].ToString();
            }
            ds.Close();


            SqlDataReader dm;
            dm = objAdmin.SuccessfullOrder();//functionname from BALAdmin
            while (dm.Read())
            {
                Session["SuccessfullOrder"] = dm["SuccessfullOrder"].ToString();//colomname from sql query
            }
            dm.Close();


            SqlDataReader dv;
            dv = objAdmin.Returned();//functionname from BALAdmin
            while (dv.Read())
            {
                Session["Returend"] = dv["Returend"].ToString();//colomname from sql query
            }
            dv.Close();


            SqlDataReader dg;
            dg = objAdmin.Refund();//functionname from BALAdmin
            while (dg.Read())
            {
                Session["Refund"] = dg["Refund"].ToString();//colomname from sql query
            }
            dg.Close();


            SqlDataReader dn;
            dn = objAdmin.Replaced();//functionname from BALAdmin
            while (dn.Read())
            {
                Session["Replaced"] = dn["Replaced"].ToString();//colomname from sql query
            }
            dn.Close();

            SqlDataReader dp;
            dp = objAdmin.Canelled();
            while (dp.Read())
            {
                Session["Canccaled"] = dp["Canccaled"].ToString();
            }
            dp.Close();

            SqlDataReader da;
            da = objAdmin.Refund1();
            while (da.Read())
            {
                Session["Refund1"] = da["Refund"].ToString();
            }
            da.Close();




            return View();

        }
       
        public JsonResult ShowChart1()

        {

            Admin objsell = new Admin();
            // objsell.SellerCode = Session["SellerCode"].ToString();
            BALAdmin obj = new BALAdmin();
            DataSet ds = new DataSet();
            ds = obj.Chart1(objsell);
            List<SelectListItem> CityList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                CityList.Add(new SelectListItem
                {
                    Text = dr["Status"].ToString(),
                    Value = dr["Count"].ToString()
                });
            }
            // ViewBag.StateName = StatesList;
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }


    }
    ////////////////--------------Ankita End-----------////////////
}
