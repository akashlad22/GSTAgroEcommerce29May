using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using System.Web.WebPages;
using AgroEcommerceLibrary.Buyer;
using System.Web.Security;
using System.Threading.Tasks;
using System.Net;
using GoogleAuthentication.Services;
using System.Web.Script.Serialization;
using System.Security.Cryptography;
using System.Drawing;
using System.IO;

namespace GSTAgroEcommerce.Controllers
{
    public class BuyerController : Controller
    {
        BALBuyer obj = new BALBuyer();
        string Code;
        public string add;
        public decimal totaldiscount = 0;
        public decimal totalprice = 0;
        public decimal subtotal = 0;
        string AllAdress;
        Buyer obja = new Buyer();
        // GET: Buyer

        //Prathamesh Start..............//
        public ActionResult Index()
        {                                                   // summerProducts
            Buyer objU = new Buyer();
            int Months = Convert.ToInt32(DateTime.Now.Month.ToString());
            if (Months >= 2 && Months <= 5)
            {
                BALBuyer objBa = new BALBuyer();
                DataSet DS1 = new DataSet();
                DS1 = objBa.GetSUmmerProducts();

                List<Buyer> listBuy1 = new List<Buyer>();
                for (int i = 0; i < DS1.Tables[0].Rows.Count; i++)
                {
                    Buyer ObjB = new Buyer();
                    ObjB.ProductName = DS1.Tables[0].Rows[i]["ProductName"].ToString();
                    ObjB.MRP = Convert.ToInt32(DS1.Tables[0].Rows[i]["MRP"].ToString());
                    ObjB.ProductCode = DS1.Tables[0].Rows[i]["ProductCode"].ToString();
                    ObjB.Quantity = Convert.ToInt32(DS1.Tables[0].Rows[i]["Quantity"].ToString());
                    string Image = DS1.Tables[0].Rows[i]["MainImage"].ToString();
                    string path = "/Content/Images/Product/";
                    ObjB.MainImage = string.Concat(path, Image);
                    listBuy1.Add(ObjB);
                }
                objU.Season = listBuy1;
                //return View(objU);

            }
            else if (Months >= 6 && Months <= 9)
            {                                              //WinterProducts
                BALBuyer objBa = new BALBuyer();
                DataSet DS1 = new DataSet();
                DS1 = objBa.GetWinterProducts();
                // Buyer objU = new Buyer();
                List<Buyer> listBuy1 = new List<Buyer>();
                for (int i = 0; i < DS1.Tables[0].Rows.Count; i++)
                {
                    Buyer ObjB = new Buyer();
                    ObjB.ProductName = DS1.Tables[0].Rows[i]["ProductName"].ToString();
                    ObjB.MRP = Convert.ToInt32(DS1.Tables[0].Rows[i]["MRP"].ToString());
                    ObjB.ProductCode = DS1.Tables[0].Rows[i]["ProductCode"].ToString();
                    ObjB.Quantity = Convert.ToInt32(DS1.Tables[0].Rows[i]["Quantity"].ToString());
                    string Img = DS1.Tables[0].Rows[i]["MainImage"].ToString();
                    string path = "/Content/Images/Product/";
                    ObjB.MainImage = string.Concat(path, Img);
                    listBuy1.Add(ObjB);
                }
                objU.Season = listBuy1;
                // return View(objU);

            }
            else if (Months >= 10 && Months <= 1)
            {                                                  //RainyProducts
                BALBuyer objBa = new BALBuyer();
                DataSet DS1 = new DataSet();
                DS1 = objBa.GetRainyProducts();
                //  Buyer objU = new Buyer();
                List<Buyer> listBuy1 = new List<Buyer>();
                for (int i = 0; i < DS1.Tables[0].Rows.Count; i++)
                {
                    Buyer ObjB = new Buyer();
                    ObjB.ProductName = DS1.Tables[0].Rows[i]["ProductName"].ToString();
                    ObjB.MRP = Convert.ToInt32(DS1.Tables[0].Rows[i]["MRP"].ToString());
                    ObjB.ProductCode = DS1.Tables[0].Rows[i]["ProductCode"].ToString();
                    ObjB.Quantity = Convert.ToInt32(DS1.Tables[0].Rows[i]["Quantity"].ToString());
                    string Image = DS1.Tables[0].Rows[i]["MainImage"].ToString();
                    string path = "/Content/Images/Product/";
                    ObjB.MainImage = string.Concat(path, Image);
                    listBuy1.Add(ObjB);
                }
                objU.Season = listBuy1;
                // return View(objU);

            }
            //ProductsDetails
            BALBuyer OBjA = new BALBuyer();
            DataSet DSB = new DataSet();
            DSB = OBjA.GetProductDetails();  /////////////Get Top Selling Products
            // Buyer objBUY = new Buyer();
            List<Buyer> listBuy = new List<Buyer>();
            for (int i = 0; i < DSB.Tables[0].Rows.Count; i++)
            {
                Buyer ObjB = new Buyer();
                ObjB.ProductName = DSB.Tables[0].Rows[i]["ProductName"].ToString();
                ObjB.MRP = Convert.ToInt32(DSB.Tables[0].Rows[i]["MRP"].ToString());
                ObjB.ProductCode = DSB.Tables[0].Rows[i]["ProductCode"].ToString();
                ObjB.Quantity = Convert.ToInt32(DSB.Tables[0].Rows[i]["Quantity"].ToString());
                string Image = DSB.Tables[0].Rows[i]["MainImage"].ToString();
                string path = "/Content/Images/Product/";
                ObjB.MainImage = string.Concat(path, Image);



                listBuy.Add(ObjB);


            }
            objU.BestSeller = listBuy;

            //DataSet ds1 = new DataSet();
            //ds1 = obj.ShowCategory();
            //List<Buyer> CatList = new List<Buyer>();

            //foreach (DataRow dr in ds1.Tables[0].Rows)
            //{
            //    CatList.Add(new Buyer
            //    {

            //        CategoryCode = dr["CategoryCode"].ToString(),
            //        CategoryName = dr["CategoryName"].ToString(),

            //    });

            //}
            //objU.MenuCategory = CatList;

            //DataSet ds2 = new DataSet();
            //ds2 = obj.ShowSubCategory();
            //List<Buyer> SubCatList = new List<Buyer>();

            //foreach (DataRow dr in ds2.Tables[0].Rows)
            //{
            //    SubCatList.Add(new Buyer
            //    {

            //        CategoryCode = dr["CategoryCode"].ToString(),
            //        SubCategory1Code = dr["SubCategory1Code"].ToString(),
            //        SubCatagory1Name = dr["SubCatagory1Name"].ToString(),


            //    });

            //}
            //objU.MenuSubcategory = SubCatList;

            return View(objU);



        }

        //----------------Prathamesh End----------------//


        public  BuyerController()
        {
            Buyer objU = new Buyer();
            DataSet ds1 = new DataSet();
            ds1 = obj.ShowCategory();
            List<Buyer> CatList = new List<Buyer>();

            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                CatList.Add(new Buyer
                {

                    CategoryCode = dr["CategoryCode"].ToString(),
                    CategoryName = dr["CategoryName"].ToString(),

                });

            }
            objU.MenuCategory = CatList;
            ViewData["Cat"] = CatList;

            DataSet ds2 = new DataSet();
            ds2 = obj.ShowSubCategory();
            List<Buyer> SubCatList = new List<Buyer>();

            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                SubCatList.Add(new Buyer
                {

                    CategoryCode = dr["CategoryCode"].ToString(),
                    SubCategory1Code = dr["SubCategory1Code"].ToString(),
                    SubCatagory1Name = dr["SubCatagory1Name"].ToString(),


                });

            }
            objU.MenuSubcategory = SubCatList;
            ViewData["SubCat"] = SubCatList;
            // Session["SubCat"]= objU.MenuSubcategory;
        }
        public async Task<ActionResult> MegaMenu(Buyer buyer)
        {
            Buyer ObjU = new Buyer();
            DataSet ds = new DataSet();
            ds = obj.GetMegaMenuProduct(buyer);
            if (ds != null)
            {
               
                List<Buyer> ProductList = new List<Buyer>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ProductList.Add(new Buyer
                    {
                        ProductName = dr["ProductName"].ToString(),
                        ProductCode = dr["ProductCode"].ToString(),
                        MRP = Convert.ToInt32(dr["MRP"].ToString()),
                        MainImage = dr["MainImage"].ToString(),
                        StatusId = Convert.ToInt32(dr["StatusId"].ToString()),
                        Quantity = Convert.ToInt32(dr["Quantity"].ToString()),
                    });
                  
                }
                ObjU.megamenuproducts = ProductList;
            }
            else 
            {
                ViewBag.NoProduct = "No Product Available Try Another Product";
            }


            return await Task.Run(() => View(ObjU));
        }
        public async Task<ActionResult> SearchProducts(string prosearch)////Search Product In Search engin////
        {
            DataSet ds = new DataSet();
            ds = obj.SearchData(prosearch);
            Buyer objU = new Buyer();
            List<Buyer> productlist = new List<Buyer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                productlist.Add(new Buyer
                {

                    ProductName = dr["ProductName"].ToString(),
                    ProductCode = dr["ProductCode"].ToString(),
                    MRP = Convert.ToInt32(dr["MRP"].ToString()),
                    MainImage = dr["MainImage"].ToString(),
                    StatusId = Convert.ToInt32(dr["StatusId"].ToString()),
                    Quantity = Convert.ToInt32(dr["Quantity"].ToString()),

                });

                objU.products = productlist;
            }


            return await Task.Run(() => View(objU));
        }
        public async Task<ActionResult> ShowProdDetails(Buyer buyer)/////Show Product Details///
        {
            Buyer AllProducts = new Buyer();
            string productcode = buyer.ProductCode;
            DataSet ds = new DataSet();
            ds = obj.ViewProductDetails(buyer);
            List<Buyer> prodDetails = new List<Buyer>();
            Buyer objU = new Buyer();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                objU.ProductCode = dr["ProductCode"].ToString();
                objU.ProductName = dr["ProductName"].ToString();
                objU.MainImage = dr["MainImage"].ToString();
                objU.Image1 = dr["Image1"].ToString();
                objU.Image2 = dr["Image2"].ToString();
                objU.Image3 = dr["Image3"].ToString();
                objU.MRP = Convert.ToInt32(dr["MRP"].ToString());
                objU.Description = dr["Description"].ToString();
                objU.ProductWeight = dr["ProductWeight"].ToString();
                objU.IsproductExpirable = dr["IsproductExpirable"].ToString() == "True";
                objU.IsProductReturnable = dr["IsProductReturnable"].ToString() == "True";
                objU.StatusId = Convert.ToInt32(dr["StatusId"].ToString());
                objU.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                objU.SubCategory1Code = dr["SubCategory1Code"].ToString();
                prodDetails.Add(objU);
            }

            AllProducts.products = prodDetails;

            DataSet ds1 = new DataSet();
            ds1 = obj.ShowReleterdProd(objU);
            List<Buyer> reletProd = new List<Buyer>();
            Buyer prodrelete = new Buyer();
            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                reletProd.Add(new Buyer
                {

                    ProductName = dr["ProductName"].ToString(),
                    ProductCode = dr["ProductCode"].ToString(),
                    MRP = Convert.ToInt32(dr["MRP"].ToString()),
                    MainImage = dr["MainImage"].ToString(),
                    StatusId = Convert.ToInt32(dr["StatusId"].ToString()),
                    Quantity = Convert.ToInt32(dr["Quantity"].ToString()),

                });
            }

            AllProducts.CatProd = reletProd;


            Session["url"] = HttpContext.Request.Url.AbsoluteUri;      ///// Get page url
            //Buyer productObj = new Buyer()
            //{
            //    products = prodDetails,
            //    CatProd = reletProd, 
            //};


            return await Task.Run(() => View(AllProducts));
        }
        public async Task<ActionResult> AddToWishList(string jsonproductcode, int qty)/////Add to WishList/////
        {
            try
            {
                if (Session["BuyerCode"] != null)
                {
                    //var serializer = new JavaScriptSerializer();
                    //dynamic productcode = serializer.Deserialize(jsonproductcode, typeof(object));
                    //Get your variables here from AJAX call
                    // var productcode = Convert.ToInt32(jsondata["id"]);

                    Buyer obj1 = new Buyer();
                    obj1.BuyerCode = Session["BuyerCode"].ToString();
                    obj1.ProductCode = jsonproductcode;

                    obj1.OrderStatusId = 18;
                    SqlDataReader dr;
                    dr = obj.CheckProductInwishList(obj1);
                    if (dr.Read())
                    {
                        obj1.BuyerCode = dr["BuyerCode"].ToString();
                        obj1.ProductCode = dr["ProductCode"].ToString();
                        obj1.OrderStatusId = Convert.ToInt32(dr["OrderStatusId"].ToString());
                        obj1.OrderCode = dr["OrderCode"].ToString();
                    }
                    // Session["OrderCodeShowWishlistProduct"] = obj1.OrderCode;

                    dr.Close();
                    if (obj1.OrderCode != null)
                    {
                        string ordercode = obj1.OrderCode;

                        obj.RemoveFromWishList(obj1);

                        return await Task.Run(() => Json(new { status = "false", msg = "Remove From WishList" }));
                    }
                    if (obj1.OrderCode == null)
                    {
                        SqlDataReader dr1;
                        dr1 = obj.GenerateOrderCode();
                        while (dr1.Read())
                        {
                            int generatecode = Convert.ToInt32(dr1["Id"].ToString());
                            generatecode = generatecode + 1;
                            string Id = "OD0";
                            Code = Id + generatecode;
                        }
                        dr1.Close();

                        obj1.OrderCode = Code;
                        string addordercode = obj1.OrderCode;
                        bool isnotify;
                        isnotify = obj1.IsNotify;
                        if (qty == 0)        ////////////////////////Update IsNotify when Product OutOf Stock
                        {
                            obj1.IsNotify = true;
                            obj.AddToWishList(obj1);
                            ////Add Product In WishList with Notify
                        }
                        else
                        {
                            obj1.IsNotify = false;
                            obj.AddToWishList(obj1);
                            ////Add Product In WishList with Notify
                        }

                        return await Task.Run(() => Json(new { status = "true", msg = "Added To WishList" }));
                    }
                    //Session["OrderCodeForWishList"] = obj1.OrderCode;

                    //Session["OrderStatusForWishList"] = 18;


                }
                else
                {
                    //var result = new { data = "error" };
                    //return Json (result,JsonRequestBehavior.AllowGet);
                    return await Task.Run(() => RedirectToAction("Login", "Account"));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return await Task.Run(() => View());
        }

        public async Task<ActionResult> WishListGrid(Buyer buyers)////// Buyer WishList View////
        {
            if (Session["BuyerCode"] != null)
            {
                buyers.BuyerCode = Session["BuyerCode"].ToString();
                DataSet ds = new DataSet();
                ds = obj.WishList(buyers);
                Buyer prdDetails = new Buyer();
                List<Buyer> LstProducts = new List<Buyer>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Buyer obj1 = new Buyer();

                    obj1.MainImage = (ds.Tables[0].Rows[i]["MainImage"].ToString());
                    obj1.ProductCode = (ds.Tables[0].Rows[i]["ProductCode"].ToString());
                    obj1.ProductName = (ds.Tables[0].Rows[i]["ProductName"].ToString());
                    obj1.MRP = Convert.ToInt32(ds.Tables[0].Rows[i]["MRP"].ToString());
                    obj1.StatusId = Convert.ToInt32(ds.Tables[0].Rows[i]["StatusId"].ToString());
                    obj1.Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"].ToString());
                    LstProducts.Add(obj1);

                }
                prdDetails.products = LstProducts;


                return await Task.Run(() => View(prdDetails));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }

        [HttpGet]
        public async Task<ActionResult> DeleteFromWishList(string productcode)/////Delete From WishList///
        {
            if (Session["BuyerCode"] != null)
            {
                Buyer obj1 = new Buyer();
                string buyercode = Session["BuyerCode"].ToString();

                obj.DeleteWishlist(buyercode, productcode);
            }
            var result = new { data = "Delete" };
            // return RedirectToAction("WishListGrid");
            return await Task.Run(() => Json(result, JsonRequestBehavior.AllowGet));
        }

        public async Task<ActionResult> AddToCart(string productcode)//////Add to Cart////
        {
            if (Session["BuyerCode"] != null)
            {
                Buyer obj1 = new Buyer();
                obj1.BuyerCode = Session["BuyerCode"].ToString();
                obj1.ProductCode = productcode;
                SqlDataReader dr = obj.CheckProductInOrder(obj1);

                if (dr.Read())
                {
                    obj1.BuyerCode = dr["BuyerCode"].ToString();
                    obj1.OrderCode = dr["OrderCode"].ToString();
                    obj1.ProductCode = dr["ProductCode"].ToString();
                    obj1.OrderStatusId = Convert.ToInt32(dr["OrderStatusId"].ToString());
                }
                dr.Close();
                if (obj1.OrderStatusId == 18)
                {
                    SqlDataReader dr2 = obj.CheckProductInCart(obj1);
                    if (dr2.Read())
                    {
                        obj1.BuyerCode = dr2["BuyerCode"].ToString();
                        obj1.OrderCode = dr2["OrderCode"].ToString();
                        obj1.ProductCode = dr2["ProductCode"].ToString();
                        obj1.OrderStatusId = Convert.ToInt32(dr2["OrderStatusId"].ToString());
                    }
                    dr2.Close();
                    if (obj1.OrderStatusId == 19)
                    {
                        return await Task.Run(() => Json(new { status = "true", msg = "Already In Cart" }));

                    }
                    if (obj1.OrderStatusId == 18)
                    {

                        //int orderstatusid = 19;
                        obj.UpdateStatusAndAddToCart(obj1);
                        return await Task.Run(() => Json(new { status = "New", msg = "Added To Cart" }));
                    }

                }
                if (obj1.OrderStatusId == 19)
                {
                    return await Task.Run(() => Json(new { status = "true", msg = "Already In Cart" }));
                }
                if (obj1.OrderCode == null)
                {
                    SqlDataReader dr1;
                    dr1 = obj.GenerateOrderCode();
                    while (dr1.Read())
                    {
                        int generatecode = Convert.ToInt32(dr1["Id"].ToString());
                        generatecode = generatecode + 1;
                        string Id = "OD0";
                        Code = Id + generatecode;
                    }
                    dr1.Close();

                    obj1.OrderCode = Code;
                    // string addordercode = obj1.OrderCode;
                    // int orderstatusid = 19;
                    obj1.OrderStatusId = 19;
                    obj.AddToCart(obj1);

                    return await Task.Run(() => Json(new { status = "New", msg = "Added To Cart" }));
                }


            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
            return await Task.Run(() => View());
        }

        public async Task<ActionResult> SideBarShop(Buyer objU, int? id, string prosearch)////Gallary///

        {

            DataSet ds = new DataSet();
            ds = obj.CategoeryShow();
            // Buyer objU = new Buyer();
            List<Buyer> categorylist = new List<Buyer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                categorylist.Add(new Buyer
                {
                    CategoryName = dr["CategoryName"].ToString(),
                    CategoryId = Convert.ToInt32(dr["CategoryId"].ToString())

                });
                objU.category = categorylist;

            }
            if (id == null)
            {
                DataSet ds1 = new DataSet();
                ds1 = obj.ShowAllProducts();
                // Buyer objU = new Buyer();

                List<Buyer> prodlist = new List<Buyer>();
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    prodlist.Add(new Buyer
                    {
                        ProductName = dr["ProductName"].ToString(),
                        ProductCode = dr["ProductCode"].ToString(),
                        MRP = Convert.ToInt32(dr["MRP"].ToString()),
                        MainImage = dr["MainImage"].ToString(),
                        StatusId = Convert.ToInt32(dr["StatusId"].ToString()),
                        Quantity = Convert.ToInt32(dr["Quantity"].ToString()),
                    });
                }

                objU.products = prodlist;
                //return await Task.Run(() => View(objU));

            }
            if (id != null)
            {
                DataSet ds2 = new DataSet();
                ds2 = obj.ShowCatProducts((int)id);
                // Buyer objU = new Buyer();
                List<Buyer> prodlist = new List<Buyer>();
                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    prodlist.Add(new Buyer
                    {
                        ProductName = dr["ProductName"].ToString(),
                        ProductCode = dr["ProductCode"].ToString(),
                        MRP = Convert.ToInt32(dr["MRP"].ToString()),
                        MainImage = dr["MainImage"].ToString(),
                        StatusId = Convert.ToInt32(dr["StatusId"].ToString()),
                        Quantity = Convert.ToInt32(dr["Quantity"].ToString()),
                    });
                }

                objU.products = prodlist;
                // return await Task.Run(() => View(objU));
            }
            if (prosearch != null)
            {
                DataSet ds3 = new DataSet();
                ds3 = obj.SearchData(prosearch);

                List<Buyer> productlist = new List<Buyer>();
                foreach (DataRow dr in ds3.Tables[0].Rows)
                {
                    productlist.Add(new Buyer
                    {
                        ProductName = dr["ProductName"].ToString(),
                        ProductCode = dr["ProductCode"].ToString(),
                        MRP = Convert.ToInt32(dr["MRP"].ToString()),
                        MainImage = dr["MainImage"].ToString(),
                        StatusId = Convert.ToInt32(dr["StatusId"].ToString()),
                        Quantity = Convert.ToInt32(dr["Quantity"].ToString()),

                    });
                }
                objU.products = productlist;
                // return await Task.Run(() => View(objU));
            }
            if (objU.Sort != null)
            {
                DataSet ds4 = new DataSet();
                List<Buyer> filterproduct = new List<Buyer>();
                Buyer objFilter = new Buyer();
                if (objU.Sort == "Low Price→High Price")///////////////Low Price→High Price
                {
                    ds4 = obj.PriceAsc();

                }
                if (objU.Sort == "High Price→Low Price")//////////////////High Price→Low Price
                {
                    ds4 = obj.PriceDesc();
                }
                if (objU.Sort == "Best Selling")
                {
                    ds4 = obj.GetProductDetails();///////////Top Selling Product

                }
                for (int i = 0; i < ds4.Tables[0].Rows.Count; i++)
                {
                    Buyer obj1 = new Buyer();

                    obj1.MainImage = (ds4.Tables[0].Rows[i]["MainImage"].ToString());
                    obj1.ProductCode = (ds4.Tables[0].Rows[i]["ProductCode"].ToString());
                    obj1.ProductName = (ds4.Tables[0].Rows[i]["ProductName"].ToString());
                    obj1.MRP = Convert.ToInt32(ds4.Tables[0].Rows[i]["MRP"].ToString());
                    obj1.StatusId = Convert.ToInt32(ds4.Tables[0].Rows[i]["StatusId"].ToString());
                    obj1.Quantity = Convert.ToInt32(ds4.Tables[0].Rows[i]["Quantity"].ToString());
                    filterproduct.Add(obj1);

                }
                objU.products = filterproduct;

            }
            var sortlist = new List<string>() { "Low Price→High Price", "High Price→Low Price", "Best Selling" };
            ViewBag.Sortlist = sortlist;

            return await Task.Run(() => View(objU));
        }
        /////////////////////Dhanashri start

        public async Task<ActionResult> OrderHistory(int? id)
        {
            if (Session["BuyerCode"] != null)
            {
                Buyer objU = new Buyer();
                string buyercode = Session["BuyerCode"].ToString();
                objU.BuyerCode = buyercode;
                DataSet ds = new DataSet();
                ds = obj.FilterButtons();
                List<Buyer> StatusFIlter = new List<Buyer>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    StatusFIlter.Add(new Buyer
                    {
                        Status = dr["Status"].ToString(),
                        StatusId = Convert.ToInt32(dr["StatusId"].ToString())
                    });
                    objU.Statuslst = StatusFIlter;
                }

                if (id == null)
                {
                    ds = obj.OrderHistory(objU);
                    List<Buyer> lstUserDt1 = new List<Buyer>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Buyer obj1 = new Buyer();
                        obj1.OrderCode = ds.Tables[0].Rows[i]["OrderCode"].ToString();
                        obj1.MainImage = ds.Tables[0].Rows[i]["MainImage"].ToString();
                        obj1.ProductName = ds.Tables[0].Rows[i]["ProductName"].ToString();
                        obj1.ProductQuantity = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductQuantity"].ToString());
                        obj1.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                        obj1.ManufacturerName = ds.Tables[0].Rows[i]["ManufacturerName"].ToString();
                        obj1.ProcessDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ProcessDate"].ToString());
                        obj1.date = obj1.ProcessDate.ToShortDateString();
                        obj1.ExpectedDeliveryDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ExpectedDeliveryDate"].ToString());
                        obj1.DeliveryDate = obj1.ExpectedDeliveryDate.ToShortDateString();
                        obj1.Total = Convert.ToInt32(ds.Tables[0].Rows[i]["Total"].ToString());
                        //ViewBag.status = obj1.Status;
                        lstUserDt1.Add(obj1);

                    }

                    objU.Users = lstUserDt1;
                    return await Task.Run(() => View(objU));
                }
                else
                {
                    ds = obj.ShowStatusWiseOrders(objU, (int)id);
                    List<Buyer> lstUserDt1 = new List<Buyer>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Buyer obj1 = new Buyer();
                        obj1.OrderCode = ds.Tables[0].Rows[i]["OrderCode"].ToString();
                        obj1.MainImage = ds.Tables[0].Rows[i]["MainImage"].ToString();
                        obj1.ProductName = ds.Tables[0].Rows[i]["ProductName"].ToString();
                        obj1.ProductQuantity = Convert.ToInt32(ds.Tables[0].Rows[i]["ProductQuantity"].ToString());
                        obj1.Status = ds.Tables[0].Rows[i]["Status"].ToString();
                        obj1.ManufacturerName = ds.Tables[0].Rows[i]["ManufacturerName"].ToString();
                        obj1.ProcessDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ProcessDate"].ToString());
                        obj1.date = obj1.ProcessDate.ToShortDateString();
                        obj1.ExpectedDeliveryDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ExpectedDeliveryDate"].ToString());
                        obj1.DeliveryDate = obj1.ExpectedDeliveryDate.ToShortDateString();
                        obj1.Total = Convert.ToInt32(ds.Tables[0].Rows[i]["Total"].ToString());
                        lstUserDt1.Add(obj1);
                        //ViewBag.status = obj1.Status;
                    }

                    objU.Users = lstUserDt1;
                    return await Task.Run(() => View(objU));
                }
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        [HttpGet]
        public async Task<ActionResult> TrackOrder(Buyer objU)
        {
            SqlDataReader dr;
            dr = obj.TrackOrder(objU);

            while (dr.Read())
            {
                objU.OrderStatusId = Convert.ToInt32(dr["OrderStatusId"].ToString());
                objU.Status = dr["Status"].ToString();
                objU.OrderCode = dr["OrderCode"].ToString();
                objU.MainImage = dr["MainImage"].ToString();
                objU.ProductName = dr["ProductName"].ToString();
                objU.ProductQuantity = Convert.ToInt32(dr["ProductQuantity"].ToString());
                objU.Total = Convert.ToInt32(dr["Total"].ToString());
                objU.StatusId = Convert.ToInt32(dr["StatusId"].ToString());
                objU.BuyerFullName = dr["BuyerFullName"].ToString();
                objU.MobileNo = dr["MobileNo"].ToString();
                add = dr["DeliveryAddress"].ToString();
                objU.PaymentMode = dr["PaymentMode"].ToString();
                objU.RejectionReason = dr["RejectionReason"].ToString();

            }

            dr.Close();
            string[] Address = add.Split('@');
            objU.Address = Address[0] + " " + Address[1] + " " + Address[2] + " " + Address[3];
            ViewBag.statusId = objU.OrderStatusId;
            ViewBag.RejectionReason = objU.RejectionReason;
            ViewBag.PayMode = objU.StatusId;
            return await Task.Run(() => View(objU));

        }
        [HttpGet]
        public async Task<ActionResult> OrderDetails(Buyer objU)
        {

            SqlDataReader dr;
            dr = obj.OrderDetails(objU);

            while (dr.Read())
            {
                objU.OrderCode = dr["OrderCode"].ToString();
                objU.MainImage = dr["MainImage"].ToString();
                objU.ProductName = dr["ProductName"].ToString();
                objU.ProductQuantity = Convert.ToInt32(dr["ProductQuantity"].ToString());
                objU.ManufacturerName = dr["ManufacturerName"].ToString();
                objU.Total = Convert.ToInt32(dr["Total"].ToString());
                objU.ShippingCharges = Convert.ToInt32(dr["ShippingCharges"].ToString());

            }
            dr.Close();
            var list = new List<string>() { "Wrong contact number entered", "Incorrect Payment method selected", "Ordered by mistake" };
            ViewBag.list = list;
            return await Task.Run(() => PartialView(objU));
        }

        public async Task<ActionResult> Cancel(string orderno, string reason)
        {

            if (reason == "")
            {
                var Status = new { data = "Failure" };
                return await Task.Run(() => Json(Status, JsonRequestBehavior.AllowGet));
            }
            else
            {
                var Status = new { data = "Success" };
                return await Task.Run(() => Json(Status, JsonRequestBehavior.AllowGet));
            }
        }
        [HttpPost]
        public async Task<ActionResult> CancelOrder(string orderno, string reason)
        {

            string buyercode = Session["BuyerCode"].ToString();

            obj.CancelOrder(orderno, buyercode, reason);
            return await Task.Run(() => RedirectToAction("OrderHistory"));
        }
        [HttpGet]
        public async Task<ActionResult> MyWallet(Buyer objU)

        {
            if (Session["BuyerCode"] != null)
            {
                string buyercode = Session["BuyerCode"].ToString();
                objU.BuyerCode = buyercode;
                DataSet ds = new DataSet();
                ds = obj.MyWallet(objU);
                // Buyer objUser = new Buyer();
                List<Buyer> lstUserDt1 = new List<Buyer>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (DateTime.Now <= Convert.ToDateTime(ds.Tables[0].Rows[i]["CouponExpDate"].ToString()))
                    {
                        Buyer obj1 = new Buyer();
                        obj1.CouponCode = ds.Tables[0].Rows[i]["CouponCode"].ToString();
                        obj1.CouponAmount = Convert.ToInt32(ds.Tables[0].Rows[i]["CouponAmount"].ToString());
                        obj1.CouponRange = ds.Tables[0].Rows[i]["CouponRange"].ToString();
                        obj1.ExpiryDays = ds.Tables[0].Rows[i]["ExpiryDays"].ToString();

                        obj1.CouponExpDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["CouponExpDate"].ToString());
                        obj1.date = obj1.CouponExpDate.ToShortDateString();
                        lstUserDt1.Add(obj1);
                    }

                }
                objU.Users = lstUserDt1;
                SqlDataReader dr;
                dr = obj.WalletCount(objU);

                while (dr.Read())
                {

                    objU.TotalPoints = dr["TotalPoints"].ToString();
                    if (objU.TotalPoints == "")
                    {
                        objU.TotalPoints = "0";
                    }

                }
                dr.Close();
                ViewBag.RewardPoints = objU.TotalPoints;
                SqlDataReader dr1;
                dr1 = obj.ViewTandC();
                while (dr1.Read())
                {
                    objU.PolicyDescriptionPdf = dr1["PolicyDescriptionPdf"].ToString();

                }
                dr1.Close();
                ViewBag.PolicyDescriptionPdf = objU.PolicyDescriptionPdf;
                return await Task.Run(() => View(objU));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        public async Task<ActionResult> RefundRequest(Buyer objU)
        {
            string buyercode = Session["BuyerCode"].ToString();
            obj.RefundRequest(objU);
            var Status = new { data = "success" };
            return await Task.Run(() => Json(Status, JsonRequestBehavior.AllowGet));
        }


        [HttpGet]
        public async Task<ActionResult> Feedback(string ProductCode)
        {
            Session["Productcode"] = ProductCode;
            return await Task.Run(()=> PartialView());
        }
        [HttpPost]
        public async Task<ActionResult> Feedback(Buyer objbuy, FormCollection objform)
        {
            objbuy.BuyerCode = Session["BuyerCode"].ToString();
            objbuy.ProductCode = Session["Productcode"].ToString();
            objbuy.RatingStarNo = Convert.ToInt32(objform["ratings"].ToString());
            obj.SaveFeedback(objbuy);

            return await Task.Run(() => RedirectToAction("OrderHistory", "Buyer")); 
        }
        /////////////////////Dhanashri end
        ///////-----------------------------Vitthal Start-------------------------------////////
        ///------------------Checkout View ------------------------//
        public async Task<ActionResult> Checkout()
        {
            if (Session["BuyerCode"] != null)
            {
                obja.BuyerCode = Session["BuyerCode"].ToString();
                SqlDataReader dr1;
                dr1 = obj.GetAddress(obja);
                while (dr1.Read())
                {
                    obja.Home = dr1["Home"].ToString();
                    obja.Office = dr1["Office"].ToString();
                    obja.Other = dr1["Other"].ToString();
                    ViewBag.mobile = dr1["MobileNo"].ToString();
                    ViewBag.BuyerFullName = dr1["BuyerFullName"].ToString();

                }
                string[] HOME = obja.Home.Split('@');
                if (HOME.Length >= 4)
                {
                    string a = HOME[0];
                    string b = HOME[1];
                    string c = HOME[2];
                    string d = HOME[3];

                    string f = a + "," + b + "," + c + "," + d;
                    ViewBag.HOME = f;
                }
                else
                {
                    ViewBag.HOME = "";
                }


                string[] OFFICE = obja.Office.Split('@');
                if (OFFICE.Length >= 4)
                {
                    string G = OFFICE[0];
                    string H = OFFICE[1];
                    string I = OFFICE[2];
                    string J = OFFICE[3];

                    string L = G + "," + H + "," + I + "," + J;
                    ViewBag.OFFICE = L;
                }
                else
                {
                    ViewBag.OFFICE = "";
                }

                string[] OTHER = obja.Other.Split('@');
                if (OTHER.Length >= 4)
                {
                    string M = OTHER[0];
                    string N = OTHER[1];
                    string O = OTHER[2];
                    string P = OTHER[3];

                    string R = M + "," + N + "," + O + "," + P;
                    ViewBag.OTHER = R;
                }
                else
                {
                    ViewBag.OTHER = "";
                }
                if (obja.Home != "" && obja.Home != "Null" && dr1.HasRows != false || obja.Office != "" && obja.Office != "Null" && dr1.HasRows != false || obja.Other != "" && obja.Other != "Null" && dr1.HasRows != false)
                {

                    dr1.Close();

                    DataSet ds1 = new DataSet();
                    ds1 = obj.Checkout(obja);
                    Buyer objb = new Buyer();

                    List<Buyer> chrckoutlist = new List<Buyer>();
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        Buyer objc = new Buyer();
                        obja.ProductName = dr["ProductName"].ToString();
                        //ProductCode = dr["ProductCode"].ToString(),
                        objc.OrderCode = dr["OrderCode"].ToString();
                        objc.MRP = Convert.ToDecimal(dr["MRP"].ToString());
                        objc.MainImage = dr["MainImage"].ToString();
                        objc.EmailId = dr["EmailId"].ToString();
                        objc.BuyerFullName = dr["BuyerFullName"].ToString();
                        objc.Home = dr["Home"].ToString();
                        objc.Office = dr["Office"].ToString();
                        objc.Other = dr["Other"].ToString();
                        objc.ProductQuantity = Convert.ToInt32(dr["ProductQuantity"].ToString());
                        objc.SubTotal = Convert.ToDecimal(dr["SubTotal"].ToString());
                        string discount1 = dr["Discount"].ToString();
                        if (discount1 != "") { obja.Discount = Convert.ToDecimal(dr["Discount"].ToString()); } else { obja.Discount = 0; };
                        string disprice = dr["DiscountPrice"].ToString();
                        if (disprice != "") { obja.discountprice = Convert.ToDecimal(dr["DiscountPrice"].ToString()); } else { obja.discountprice = 0; };
                        string totaodis = dr["TotalDiscount"].ToString();
                        if (totaodis != "") { totaldiscount += Convert.ToDecimal(dr["TotalDiscount"].ToString()); } else { totaldiscount += 0; };
                        totalprice += Convert.ToDecimal(dr["totalprice"].ToString());
                        chrckoutlist.Add(objc);

                    }

                    objb.lstbuyer = chrckoutlist;
                    subtotal = totalprice - totaldiscount;
                    ViewBag.totaldiscount = totaldiscount; ViewBag.totalprice = totalprice; ViewBag.subtotal = subtotal;
                    return await Task.Run(() => View(objb));
                }
                else
                {
                    dr1.Close();
                    return RedirectToAction("AddAddress");
                };
            }
            else
            {
                return RedirectToAction("Login", "Account");

            }
        }
        // -----------------View Cart -------------\\
        public async Task<ActionResult> ViewCart()
        {
            if (Session["BuyerCode"] != null)
            {
                obja.BuyerCode = Session["BuyerCode"].ToString();
                decimal totaldiscount = 0;
                decimal carttotal = 0;
                string discount;
                DataSet DSB = new DataSet();
                DSB = obj.ProductDetails(obja);
                Buyer objBuy = new Buyer();
                List<Buyer> objList = new List<Buyer>();

                for (int i = 0; i < DSB.Tables[0].Rows.Count; i++)
                {
                    Buyer objB = new Buyer();
                    objB.ProductName = DSB.Tables[0].Rows[i]["ProductName"].ToString();
                    objB.OrderCode = DSB.Tables[0].Rows[i]["OrderCode"].ToString();
                    objB.ProductCode = DSB.Tables[0].Rows[i]["ProductCode"].ToString();
                    objB.MRP = Convert.ToDecimal(DSB.Tables[0].Rows[i]["MRP"].ToString());
                    objB.ManufacturerName = DSB.Tables[0].Rows[i]["ManufacturerName"].ToString();
                    objB.MainImage = DSB.Tables[0].Rows[i]["MainImage"].ToString();
                    objB.ProductWeight = DSB.Tables[0].Rows[i]["ProductWeight"].ToString();
                    objB.producttotalprice = DSB.Tables[0].Rows[i]["ToatlPrice"].ToString();
                    discount = DSB.Tables[0].Rows[i]["Discount"].ToString();
                    if (discount != "") { objB.Discount = Convert.ToDecimal(DSB.Tables[0].Rows[i]["Discount"].ToString()); }
                    else { objB.Discount = 0; }
                    //objB.Doscount = Convert.ToDecimal(DSB.Tables[0].Rows[i]["Discount"].ToString());
                    carttotal += Convert.ToDecimal(DSB.Tables[0].Rows[i]["ToatlPrice"].ToString());
                    string discounteprice = DSB.Tables[0].Rows[i]["discountedprice"].ToString();
                    if (discounteprice != "") { objB.discountprice = Convert.ToDecimal(DSB.Tables[0].Rows[i]["discountedprice"].ToString()); }
                    else { objB.discountprice = 0; }
                    // objB.discountprice= Convert.ToDecimal(DSB.Tables[0].Rows[i]["discountedprice"].ToString());
                    objB.ProductQuantity = Convert.ToInt32(DSB.Tables[0].Rows[i]["ProductQuantity"].ToString());
                    string totaldis = DSB.Tables[0].Rows[i]["discountprice"].ToString();
                    if (totaldis != "") { totaldiscount += Convert.ToDecimal(DSB.Tables[0].Rows[i]["discountprice"].ToString()); }
                    else { totaldiscount += 0; }
                    //totaldiscount += Convert.ToDecimal(DSB.Tables[0].Rows[i]["discountprice"].ToString());
                    // objB.Discount = Convert.ToInt32(DSB.Tables[0].Rows[i]["Discount"].ToString());
                    objList.Add(objB);
                }
                objBuy.Buyers = objList;
                ViewBag.carttotal = carttotal;
                ViewBag.grandtotal = carttotal - totaldiscount;
                ViewBag.totaldiscount = totaldiscount;
                return await Task.Run(() => View(objBuy));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));

            }

        }
        [HttpGet]
        //---------------- To Check Coupan Available for buyer-------------//
        public async Task<ActionResult> CheckCupan(string coupan)
        {
            if (Session["BuyerCode"] != null)
            {
                obja.CouponCode = coupan;
                obja.BuyerCode = Session["BuyerCode"].ToString();
                DataSet ds = new DataSet();
                ds = obj.CheckCoupan(obja);
                Buyer objb = new Buyer();
                List<Buyer> Coupanlist = new List<Buyer>();
                foreach (DataRow item in ds.Tables[0].Rows)
                {

                    objb.coupanexpdate = Convert.ToDateTime(item["CouponExpDate"].ToString());
                    if (objb.coupanexpdate > DateTime.Now)
                    {
                        objb.CoupanPrice = Convert.ToInt32(item["CouponAmount"].ToString());

                        Session["coupanordercode"] = item["OrderCode"].ToString();
                    }
                    else { objb.CoupanPrice = 0; }
                }
                var result = new { data = objb.CoupanPrice };
                return await Task.Run(() => Json(result, JsonRequestBehavior.AllowGet));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));

            }

        }
        //-----------Add Address  Get Method -----------\\
        [HttpGet]
        public async Task<ActionResult> AddAddress()
        {
            if (Session["BuyerCode"] != null)
            {
                GetCountry();
                Buyer objb = new Buyer();
                obja.BuyerCode = Session["BuyerCode"].ToString();
                // To Check Already Added Adress//
                SqlDataReader dr1;
                dr1 = obj.GetAddress(obja);
                while (dr1.Read())
                {
                    objb.Home = dr1["Home"].ToString();
                    if (objb.Home != null && objb.Home != "")
                    {
                        ViewBag.home = "home";
                    }
                    else { ViewBag.home = ""; }
                    objb.Office = dr1["Office"].ToString();
                    if (objb.Office != null && objb.Office != "")
                    {
                        ViewBag.Office = "Office";
                    }
                    else { ViewBag.Office = ""; }
                    objb.Other = dr1["Other"].ToString();
                    if (objb.Other != null && objb.Other != "")
                    {
                        ViewBag.other = "Other";
                    }
                    else
                    {
                        ViewBag.other = "";
                    }

                }
                dr1.Close();
                return await Task.Run(() => View());
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));

            }
        }
        //--------------Post Method for Add Address-------------\\\\
        [HttpPost]
        public async Task<ActionResult> AddAddress(Buyer OBJBUYER, FormCollection formobj)
        {
            if (Session["BuyerCode"] != null)
            {

                obja.BuyerCode = Session["BuyerCode"].ToString();

                // To Check Already Added Adress//
                SqlDataReader dr1;
                dr1 = obj.GetAddress(obja);

                OBJBUYER.CityName = formobj["hidden1"].ToString();
                string Address = OBJBUYER.HouseNo + "@" + OBJBUYER.Landmark + "@" + OBJBUYER.CityName + "@" + OBJBUYER.PinCode;
                obja.Address = Address;
                if (OBJBUYER.AddressType == "Home")
                {
                    if (dr1.HasRows == true)
                    {
                        dr1.Close();
                        obj.UpdateAddressHome(obja);
                    }
                    else
                    {
                        obj.SaveAddressHome(obja);
                    }
                    return await Task.Run(() => RedirectToAction("Checkout"));
                }
                else
                if (OBJBUYER.AddressType == "Office")
                {
                    if (dr1.HasRows == true)
                    {
                        dr1.Close();
                        obj.UpdateAddressOffice(obja);
                    }
                    else
                    {
                        obj.SaveAddressOffice(obja);
                    }
                    return await Task.Run(() => RedirectToAction("Checkout"));
                }
                else if
                    (OBJBUYER.AddressType == "Other")
                {
                    if (dr1.HasRows == true)
                    {
                        dr1.Close();
                        obj.UpdateAddressOther(obja);
                    }
                    else
                    {
                        obj.SaveAddressOther(obja);
                    }
                    return await Task.Run(() => RedirectToAction("Checkout"));
                }

                return await Task.Run(() => RedirectToAction("Checkout"));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }
        //----------------Update Address Buyer Get Method-------------//
        [HttpGet]
        public async Task<ActionResult> UpdateAddress(int id)
        {
            if (Session["BuyerCode"] != null)
            {
                GetCountry();
                Buyer objb = new Buyer();
                obja.BuyerCode = Session["BuyerCode"].ToString();

                SqlDataReader dr1;
                dr1 = obj.GetAddress(obja);
                while (dr1.Read())
                {
                    if (id == 1)
                    {
                        AllAdress = dr1["Home"].ToString();
                        ViewBag.AddressType = "Home";
                    }
                    else if (id == 2)
                    {
                        AllAdress = dr1["Office"].ToString();
                        ViewBag.AddressType = "Office";

                    }
                    else if (id == 3)
                    {

                        AllAdress = dr1["Other"].ToString();
                        ViewBag.AddressType = "Other";

                    }
                    obja.BuyerFullName = dr1["BuyerFullName"].ToString();
                    obja.MobileNo = dr1["MobileNo"].ToString();
                }
                dr1.Close();
                string[] HOME = AllAdress.Split('@');

                objb.HouseNo = HOME[0];
                objb.Landmark = HOME[1];
                objb.CityName = HOME[2];
                objb.PinCode = Convert.ToInt32(HOME[3]);
                objb.BuyerFullName = obja.BuyerFullName;
                objb.MobileNo = obja.MobileNo;

                SqlDataReader dr2;
                dr2 = obj.GetCity(objb);
                while (dr2.Read())
                {
                    objb.CountryId = Convert.ToInt32(dr2["CountryId"].ToString());
                    objb.StateId = Convert.ToInt32(dr2["StateId"].ToString());
                    objb.CityId = Convert.ToInt32(dr2["CityId"].ToString());
                    objb.CountryName = dr2["CountryName"].ToString();
                    objb.StateName = dr2["StateName"].ToString();
                    objb.CityName = dr2["CityName"].ToString();
                }
                dr2.Close();
                ViewBag.State = objb.StateName;
                TempData["City"] = objb.CityName;
                Session["city"] = objb.CityName;
                ViewBag.stateid = objb.StateId;
                ViewBag.cityid = objb.CityId;
                return await Task.Run(() => View("UpdateAddress", objb));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));

            }
        }
        //----------------------------Update Buyer Address   post Method   ----------//
        [HttpPost]
        public async Task<ActionResult> UpdateAddress(Buyer OBJBUYER, FormCollection Formobj)
        {
            if (Session["BuyerCode"] != null)
            {
                obja.MobileNo = OBJBUYER.MobileNo;
                obja.BuyerCode = Session["BuyerCode"].ToString();
                if (Formobj["hidden"].ToString() == "")
                {
                    OBJBUYER.CityName = Session["city"].ToString();
                }
                else
                {
                    OBJBUYER.CityName = Formobj["hidden"].ToString();
                }
                OBJBUYER.AddressType = Formobj["hidden1"].ToString();
                obja.Address = OBJBUYER.HouseNo + "@" + OBJBUYER.Landmark + "@" + OBJBUYER.CityName + "@" + OBJBUYER.PinCode;

                obj.UpdateInfo(obja);
                if (OBJBUYER.AddressType == "Home")
                {
                    obj.UpdateAddressHome(obja);
                }
                else
                if (OBJBUYER.AddressType == "Office")
                {
                    obj.UpdateAddressOffice(obja);
                }
                else if
                    (OBJBUYER.AddressType == "Other")
                {
                    obj.UpdateAddressOther(obja);
                }
                return await Task.Run(() => RedirectToAction("Checkout"));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }
        }


        //-------------------------Country Binding---------------//
        public void GetCountry()
        {
            DataSet ds = obj.GetCountry();
            List<SelectListItem> countrylist = new List<SelectListItem>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                countrylist.Add(new SelectListItem
                {
                    Text = item["CountryName"].ToString(),
                    Value = item["CountryId"].ToString()

                });

                ViewBag.country = countrylist;
            }
        }
        //--------------State Binding--------------------////////
        [HttpGet]
        public async Task<JsonResult> GetState(int countryid)
        {

            obja.CountryId = countryid;
            DataSet ds = obj.GetState(obja);
            List<SelectListItem> Statelist = new List<SelectListItem>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Statelist.Add(new SelectListItem
                {
                    Text = item["StateName"].ToString(),
                    Value = item["StateId"].ToString()

                });
            }
            return await Task.Run(() => Json(Statelist, JsonRequestBehavior.AllowGet));
        }
        //--------------------City Binding-----------------
        public async Task<JsonResult> Get_City(int stateid)
        {
            obja.StateId = stateid;
            DataSet ds = obj.Getcity(obja);
            List<SelectListItem> Citylist = new List<SelectListItem>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Citylist.Add(new SelectListItem
                {
                    Text = item["CityName"].ToString(),
                    Value = item["CityId"].ToString()

                });
            }
            return await Task.Run(() => Json(Citylist, JsonRequestBehavior.AllowGet));
        }
        // --------------------Delete Product From Cart
        [HttpPost]
        public async Task<ActionResult> DeleteProduct(string orderno)
        {
            obja.OrderCode = orderno;
            obj.deleteOrder(obja);
            return await Task.Run(() => Json(new { data = "Deleted" }, JsonRequestBehavior.AllowGet));
        }

        ///------------------------Place Order-----------------/
        //public async Task<ActionResult> PlaceOrder(string[] orderno, string Totals, string address, string applypoints)
        //{
        //    if (Session["BuyerCode"] != null)
        //    {
        //        if (address != "" && address != null)
        //        {
        //            obja.UseedRewardPoints = Convert.ToInt32(applypoints);
        //            int Total = Convert.ToInt32(Totals);
        //            obja.BuyerCode = Session["BuyerCode"].ToString();
        //            if (orderno.Length > 0)
        //            {
        //                for (int i = 0; i < orderno.Length; i++)
        //                {
        //                    obja.OrderCode = orderno[i];

        //                    obj.PlaceOrder(obja);
        //                    obja.OrderCode = orderno[0];
        //                }

        //                DataSet dtc = new DataSet();
        //                dtc = obj.GetReward();
        //                foreach (DataRow dr in dtc.Tables[0].Rows)
        //                {
        //                    string[] range = dr["RewardRange"].ToString().Split('-');
        //                    if (range.Length >= 2)
        //                    {
        //                        if (Convert.ToInt32(range[0]) < Total && Convert.ToInt32(range[1]) > Total)
        //                        {
        //                            obja.Reward = Convert.ToInt32(dr["RewardPoint"].ToString());
        //                            obja.RewardId = Convert.ToInt32(dr["RewardId"].ToString());
        //                        }
        //                        //// else { obja.Reward = 0; obja.RewardId = 0; }

        //                    }
        //                    //else { obja.Reward = 0; obja.RewardId = 0; }
        //                }
        //                DataSet dt = new DataSet();
        //                dt = obj.Getcoupan();

        //                foreach (DataRow dr in dt.Tables[0].Rows)
        //                {
        //                    string[] range = dr["CouponRange"].ToString().Split('-');
        //                    if (range.Length >= 2)
        //                    {
        //                        if (Convert.ToInt32(range[0]) < Total && Convert.ToInt32(range[1]) > Total)
        //                        {
        //                            obja.CouponCode = dr["CouponCode"].ToString();
        //                            int days = Convert.ToInt32(dr["ExpiryDays"].ToString());
        //                            obja.coupanexpdate = DateTime.Now.AddDays(days);
        //                        }
        //                        //    else { obja.CouponCode = ""; obja.coupanexpdate = DateTime.Now; }

        //                    }
        //                    //else { obja.CouponCode = ""; obja.coupanexpdate = DateTime.Now; }
        //                }

        //                if (obja.Reward > 0 && obja.CouponCode != "")
        //                {

        //                    obj.AddCopan(obja);

        //                }

        //                else if (obja.Reward == 0 && obja.CouponCode != "")
        //                {
        //                    obja.Reward = 0; obja.RewardId = 0;
        //                    obj.AddCopan(obja);
        //                }
        //                else if (obja.Reward > 0 && obja.CouponCode == "")
        //                {
        //                    obja.CouponCode = ""; obja.coupanexpdate = DateTime.Now;

        //                    obj.AddCopan(obja);
        //                }



        //                if (Session["coupanordercode"] != null)
        //                {
        //                    obja.OrderCode = Session["coupanordercode"].ToString();
        //                    obj.RemoveCoupan(obja);
        //                }

        //                if (address == "Office")
        //                {
        //                    obja.StatusId = 22;
        //                    obj.SetDeliveryAddress(obja);

        //                }
        //                else if (address == "Other")
        //                {
        //                    obja.StatusId = 23;
        //                    obj.SetDeliveryAddress(obja);
        //                }
        //                else
        //                {
        //                    obja.StatusId = 21;
        //                    obj.SetDeliveryAddress(obja);
        //                }
        //                return await Task.Run(() => RedirectToAction("Index"));
        //            }
        //            else
        //            {
        //                return await Task.Run(() => RedirectToAction("Index"));
        //            }

        //        }
        //        else
        //        {
        //            return await Task.Run(() => RedirectToAction("Index"));
        //        }
        //    }
        //    else
        //    {
        //        return await Task.Run(() => RedirectToAction("Login", "Account"));
        //    }


        //}
        [HttpPost]
        public async Task<ActionResult> PlaceOrder(string ordercode, string address)
        {

            if (Session["BuyerCode"] != null)
            {
                if (address == "Office")
                {
                    obja.StatusId = 22;


                }
                else if (address == "Other")
                {
                    obja.StatusId = 23;
                }
                else
                {
                    obja.StatusId = 21;

                };
                string[] ordercodes = ordercode.Split(',');

                obja.BuyerCode = Session["BuyerCode"].ToString();
                if (ordercodes.Length > 0)
                {
                    for (int i = 0; i < ordercodes.Length; i++)
                    {
                        obja.OrderCode = ordercodes[i];

                        obj.PlaceOrder(obja);
                        obj.SetDeliveryAddress(obja);

                    }

                }
                if (Session["coupanordercode"] != null)
                {
                    obja.OrderCode = Session["coupanordercode"].ToString();
                    obj.RemoveCoupan(obja);
                }

                return await Task.Run(() => Json(new { status = "true", msg = "Your Order Is Placed" }));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Login", "Account"));
            }


        }


        [HttpPost]
        public async Task<ActionResult> SaveDeleveryAddress(string address)
        {
            obja.BuyerCode = Session["BuyerCode"].ToString();
            if (address == "Office")
            {
                obja.StatusId = 22;
                obj.SetDeliveryAddress(obja);

            }
            else if (address == "Other")
            {
                obja.StatusId = 23;
                obj.SetDeliveryAddress(obja);
            }
            else
            {
                obja.StatusId = 21;
                obj.SetDeliveryAddress(obja);
            }

            return await Task.Run(() => Json(new { status = "Save", msg = "Your Order Is Placed" }));

        }
        [HttpPost]
        public async Task<ActionResult> SavePaymentMode(string ordercode, string paymentmode)
        {
            obja.BuyerCode = Session["BuyerCode"].ToString();
            string order = "";
            obja.StatusId = 15;
            string[] ordercodes = ordercode.Split(',');
            for (int i = 0; i < ordercodes.Length; i++)
            {
                order += ordercodes[i] + ",";
            }
            obja.OrderCode = order;
            if (paymentmode == "Credit card")
            {
                obja.PaymentDate = DateTime.Now;
                obja.PaymentMode = "Credit card";
                obj.SavePayment(obja);


            }
            else if (paymentmode == "Debit card")
            {
                obja.PaymentMode = "Debit card";
                obja.PaymentDate = DateTime.Now;
                obj.SavePayment(obja);


            }
            else if (paymentmode == "COD")
            {
                obja.PaymentMode = "COD";
                obja.StatusId = 4;
                obj.SavePaymentc(obja);


            }
            else
            {
                obja.PaymentMode = "PayPal";
                obja.PaymentDate = DateTime.Now;
                obj.SavePayment(obja);
            }
            return await Task.Run(() => Json(new { status = "Save", msg = "" }));

        }
        [HttpPost]
        public async Task<ActionResult> AddCoupon(string ordercode, string Totals, string applypoints)
        {
            int days = 0;
            obja.BuyerCode = Session["BuyerCode"].ToString();
            obja.OrderCode = ordercode;
            obja.UseedRewardPoints = Convert.ToInt32(applypoints);
            int Total = Convert.ToInt32(Totals);
            DataSet dt = new DataSet();
            dt = obj.Getcoupan();

            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                string[] range = dr["CouponRange"].ToString().Split('-');
                if (range.Length >= 2)
                {
                    if (Convert.ToInt32(range[0]) <= Total && Convert.ToInt32(range[1]) >= Total)
                    {
                        obja.CouponCode = dr["CouponCode"].ToString();
                         days = Convert.ToInt32(dr["ExpiryDays"].ToString());
                        obja.coupanexpdate = DateTime.Now.AddDays(days);
                    }


                }

            }
            DataSet dtc = new DataSet();
            dtc = obj.GetReward();
            foreach (DataRow dr in dtc.Tables[0].Rows)
            {
                string[] range = dr["RewardRange"].ToString().Split('-');
                if (range.Length >= 2)
                {
                    if (Convert.ToInt32(range[0]) <= Total && Convert.ToInt32(range[1]) >= Total)
                    {
                        obja.Reward = Convert.ToInt32(dr["RewardPoint"].ToString());
                        obja.RewardId = Convert.ToInt32(dr["RewardId"].ToString());
                    }

                }

            }
            if (days<0)
            {
                obja.coupanexpdate = System.DateTime.Now;
            }
            if (obja.Reward > 0 && obja.CouponCode != "")
            {
               // obja.coupanexpdate = DateTime.Now;
                obj.AddCopan(obja);

            }
            else if (obja.Reward == 0 && obja.CouponCode != "" && obja.CouponCode != null)
            {
                obja.Reward = 0; obja.RewardId = 0;
                obj.AddCopan(obja);
            }
            else if (obja.Reward > 0 && obja.CouponCode == "")
            {
                obja.CouponCode = ""; obja.coupanexpdate = DateTime.Now;

                obj.AddCopan(obja);
            }
            else
            {
                obja.Reward = 0; obja.RewardId = 0; obja.CouponCode = ""; obja.coupanexpdate = DateTime.Now;
                obj.AddCopan(obja);
            }


            return await Task.Run(() => Json(new { status = "true" }));

        }
        //---------------------Update Cart Quantity-------------
        public async Task<ActionResult> UpdateQuantity(string orderno, int quantity)
        {
            obja.BuyerCode = Session["BuyerCode"].ToString();
            obja.ProductQuantity = quantity;
            obja.OrderCode = orderno;
            obj.UpdateQuantity(obja);
            return await Task.Run(() => View());
        }

        ///------------------To Check Available Reward Point ---------------/
        public async Task<JsonResult> BalancePoint()
        {

            obja.BuyerCode = Session["BuyerCode"].ToString();

            DataSet ds = new DataSet();
            ds = obj.BalancePoint(obja);
            Buyer objb = new Buyer();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                if (item["balancePoint"].ToString() != "")
                {
                    objb.Reward = Convert.ToInt32(item["balancePoint"].ToString());
                    objb.RewardConversionRate = Convert.ToDecimal(item["RewardConversionRate"].ToString());
                    objb.PointLimits = Convert.ToInt32(item["pointlimit"].ToString());
                }
                else { objb.Reward = 0; objb.RewardConversionRate = 0; objb.PointLimits = 0; }

            }
            var result = new { data = objb.Reward, data1 = objb.RewardConversionRate, data2 = objb.PointLimits };
            return await Task.Run(() => Json(result, JsonRequestBehavior.AllowGet));
        }
        ////////////---------------------------------Vitthal End-------------------////////////

        ////////////////---------Akshada Start-----------------////////////////
        [HttpGet]
        public ActionResult Registration()
        {
            GetCountry();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Registration(HttpPostedFileBase Photo, HttpPostedFileBase AadhaarP, HttpPostedFileBase PancardP, Buyer Obj)
        {

            BALBuyer objbuyer = new BALBuyer();
            SqlDataReader drb;
            drb = objbuyer.CheckEmailAlreadyExist(Obj);
            BALBuyer objSeller = new BALBuyer();
            SqlDataReader drs;
            drs = objSeller.CheckEmailAlreadyExistsS(Obj);
            BALBuyer objAdmin = new BALBuyer();
            SqlDataReader drA;
            drA = objAdmin.CheckEmailAlreadyExistsA(Obj);
            if (drb.HasRows || drs.HasRows || drA.HasRows)
            {
                ViewBag.Message = "Registration Already Created...!";
                TempData["EmailError"] = " Your Registration Email Already Exist!!!";
                //return await Task.Run(() => View("Registration"));
            }
            else
            {



                Buyer_Code();
                // Buyer Obj = new Buyer();
                Obj.BuyerCode = Code;

                //BALBuyer objcheckemail = new BALBuyer();
                //Buyer objemail = new Buyer();
                //DataSet dsemail = new DataSet();
                //dsemail = objcheckemail.CheckEmailAlreadyExists(objemail.EmailId);
                //for(int i = 0;i <= dsemail.Tables[0].Rows.Count; i++)
                //{
                //    Buyer objchckmail = new Buyer();
                //    objchckmail.EmailId = dsemail.Tables[0].Rows[i]["EmailId"].ToString();
                //}



                if (Photo != null && Photo.ContentLength > 0)
                {
                    string Photo1 = Path.GetFileName(Photo.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/Content/Images/DocImages"), Photo1);
                    Photo.SaveAs(imgpath);

                }
                if (AadhaarP != null && AadhaarP.ContentLength > 0)
                {
                    string AdharImage1 = Path.GetFileName(AadhaarP.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/Content/Images/DocImages"), AdharImage1);
                    AadhaarP.SaveAs(imgpath);
                    Obj.AadhaarPhoto = AdharImage1;

                }
                if (PancardP != null && PancardP.ContentLength > 0)
                {
                    string PanCardPhoto1 = Path.GetFileName(PancardP.FileName);
                    string imgpath = Path.Combine(Server.MapPath("~/Content/Images/DocImages"), PanCardPhoto1);
                    PancardP.SaveAs(imgpath);
                    Obj.PanCardPhoto = PanCardPhoto1;

                }

                BALBuyer objBal = new BALBuyer();
                objBal.BuyerReg(Obj);


            }
            var status = new { data = "success" };
            //  return await Task.Run(() =>Json(status , JsonRequestBehavior.AllowGet));
            return await Task.Run(() => RedirectToAction("Registration"));
        }
        public ActionResult Buyer_Code()
        {
            Buyer obj = new Buyer();
            BALBuyer b = new BALBuyer();
            SqlDataReader dr;
            dr = b.BuyerCode();
            while (dr.Read())
            {
                int BuyerCode = Convert.ToInt32(dr["Id"].ToString());
                BuyerCode = BuyerCode + 1;
                string Id = "B0";
                Code = Id + BuyerCode;
            }
            dr.Close();
            return View(obj);
        }

        ////////////////---------Akshada end-----------------////////////////
    }
}