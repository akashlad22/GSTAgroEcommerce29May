using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroEcommerceLibrary.Buyer
{

    public class BALBuyer
    {
        // SqlConnection con = new SqlConnection("Data Source=AKASH\\SQLEXPRESS;Initial Catalog=GSTAgroE-Commerce;Integrated Security=True");
        // SqlConnection con = new SqlConnection("Data Source=DESKTOP-G0RI5B8;Initial Catalog=GSTAgroE-Commerce;Integrated Security=True");
        //  SqlConnection con = new SqlConnection("Data Source=MAULI;Initial Catalog=GSTAgroE-Commerce;Integrated Security=True");
       // SqlConnection con = new SqlConnection("Data Source=PRATHAMESH\\SQLEXPRESS;Initial Catalog=GSTAgroE-Commerce;Integrated Security=True;Max Pool Size=5000000;Pooling=True;");

        static string CS = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(CS);

        public void ManageConnection()
        {
            if (con.State ==System.Data.ConnectionState.Closed)
            {
                con.Open();

            }
            //else
            //{
            //    con.Close();
            //}
        }


        public void AddToWishList(Buyer buyers)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddToCartAndWishList");
            cmd.Parameters.AddWithValue("@OrderCode",buyers.OrderCode );
            cmd.Parameters.AddWithValue("@buyercode",buyers.BuyerCode );
            cmd.Parameters.AddWithValue("@productcode",buyers.ProductCode);
            cmd.Parameters.AddWithValue("@OrderStatusId",buyers.OrderStatusId);
            cmd.Parameters.AddWithValue("@IsNotify",buyers.IsNotify);

            cmd.ExecuteNonQuery();

        }

        public void AddToCart(Buyer buyers)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddToCartAndWishList");
            cmd.Parameters.AddWithValue("@OrderCode",buyers.OrderCode );
            cmd.Parameters.AddWithValue("@buyercode",buyers.BuyerCode );
            cmd.Parameters.AddWithValue("@productcode",buyers.ProductCode );
            cmd.Parameters.AddWithValue("@OrderStatusId",buyers.OrderStatusId);
            cmd.ExecuteNonQuery();

        }
        public void UpdateStatusAndAddToCart(Buyer buyers) 
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateOrderAndToCart");
            cmd.Parameters.AddWithValue("@buyercode",buyers.BuyerCode);
            cmd.Parameters.AddWithValue("@productcode",buyers.ProductCode);
            //cmd.Parameters.AddWithValue("@OrderStatusId", orderstatusid);
            cmd.ExecuteNonQuery();

        }

        public SqlDataReader CheckProductInwishList(Buyer buyers)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "CheckProductInWishList");
            cmd.Parameters.AddWithValue("@buyercode",buyers.BuyerCode);
            cmd.Parameters.AddWithValue("@productcode", buyers.ProductCode);

            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
           // con.Close();
        }
            public SqlDataReader CheckProductInCart(Buyer buyers) 
            {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "CheckProductInCart");
                cmd.Parameters.AddWithValue("@buyercode", buyers.BuyerCode );
                cmd.Parameters.AddWithValue("@productcode",buyers.ProductCode);

                SqlDataReader dr2 = cmd.ExecuteReader();
                return dr2;
                con.Close();
            }

            public void RemoveFromWishList(Buyer buyer)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RemoveFromWishList");
            cmd.Parameters.AddWithValue("@OrderCode", buyer.OrderCode);
            cmd.Parameters.AddWithValue("@buyercode",buyer.BuyerCode);
            cmd.Parameters.AddWithValue("@productcode",buyer.ProductCode);
            cmd.Parameters.AddWithValue("@OrderStatusId", buyer.OrderStatusId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public SqlDataReader GenerateOrderCode()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GenerateOrderCode");
            SqlDataReader dr1;
            dr1 = cmd.ExecuteReader();
            return dr1;
            con.Close();


        }

        public SqlDataReader CheckProductInOrder(Buyer buyers) 
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "CheckPoductInOrder");
            ////Check Product in Order Table And Update OrderStatusId And set product in Cart  
            cmd.Parameters.AddWithValue("@buyercode",buyers.BuyerCode);
            cmd.Parameters.AddWithValue("@productcode",buyers.ProductCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }

       
        public DataSet SearchData(string prosearch)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SerarchWithImage");
            cmd.Parameters.AddWithValue("@productname", prosearch);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
        public DataSet CategoeryShow()
        {
            ManageConnection();

            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetCategory");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
            con.Close();


        }
        ///All Product Show\\\
        public DataSet ShowAllProducts()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ShowAllProducts");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
       
        public DataSet ShowCatProducts(int id)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ShowCatProd");
            cmd.Parameters.AddWithValue("@categoryid", id);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet ShowCategory()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetCategory");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.SelectCommand = cmd;
            DataSet ds1 = new DataSet();
            adpt.Fill(ds1);
            return ds1;
            con.Close();
        }
        public DataSet ShowSubCategory()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetSubCat1");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        public DataSet GetMegaMenuProduct(Buyer buyer)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "MegaMenuCatProd");
            cmd.Parameters.AddWithValue("@categorycode", buyer.CategoryCode);
            cmd.Parameters.AddWithValue("@subcategory1code", buyer.SubCategory1Code);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.SelectCommand= cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }

        //////View Product Details
        public DataSet ViewProductDetails(Buyer buyer)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ViewProductDetails");
            cmd.Parameters.AddWithValue("@productcode", buyer.ProductCode);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }
        ////View Releted Product

        public DataSet ShowReleterdProd(Buyer buyer)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ShowReletProd");
            cmd.Parameters.AddWithValue("@subcategory1code", buyer.SubCategory1Code);
            SqlDataAdapter adpt =new SqlDataAdapter(cmd);
            adpt.SelectCommand=cmd;
            DataSet ds1=new DataSet();
            adpt.Fill(ds1);
            return ds1;
        }



        /// //GET CATEGORY

        public DataSet GetCategory()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetCategory");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();


        }

        public DataSet WishList(Buyer buyers)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "WishList");
            cmd.Parameters.AddWithValue("@BuyerCode",buyers.BuyerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

            con.Close();
        }
        public void AddCart(string buyercode, string productcode)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Cart");
            cmd.Parameters.AddWithValue("@BuyerCode", buyercode);
            cmd.Parameters.AddWithValue("@ProductCode", productcode);
            cmd.ExecuteNonQuery();
            con.Close();




        }
        public void DeleteWishlist( string buyercode,string productcode)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RemoveFromWishList");
            cmd.Parameters.AddWithValue("@ProductCode", productcode);
            cmd.Parameters.AddWithValue("@buyercode", buyercode);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataSet PriceAsc()/////////////////Asending MRP
        {
            ManageConnection();

            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "MRPasc");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds4 = new DataSet();
            adpt.Fill(ds4);
            return (ds4);
            con.Close();
        }
        public DataSet PriceDesc() 
        {
            ManageConnection();

            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "MRPdesc");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();

        }

        //Prathamesh Start//
        public DataSet GetProductDetails()/////////////////Top selling Product
        {
            ManageConnection();

            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetProductDetailPN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }

        //SummerProducts
        public DataSet GetSUmmerProducts()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetSummerPN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }

        //WinterProducts
        public DataSet GetWinterProducts()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetWinterProductPN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }

        //RainyProducts
        public DataSet GetRainyProducts()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetRainyProductPN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }
        //Prathamesh End//
        ///Dhanashri start
        ///
         /////Dhanashri start
        public DataSet OrderHistory(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RemainingOrders");
            cmd.Parameters.AddWithValue("@BuyerCode", obj.BuyerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
        public DataSet FilterButtons()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "StatusWiseFilter");

            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
        public DataSet ShowStatusWiseOrders(Buyer obj, int StatusId)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ShowStatusWiseOrders");
            cmd.Parameters.AddWithValue("@BuyerCode", obj.BuyerCode);
            cmd.Parameters.AddWithValue("@OrderStatusId", StatusId);

            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
        public SqlDataReader TrackOrder(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "TrackOrder");
            cmd.Parameters.AddWithValue("@OrderCode", obj.OrderCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

            con.Close();

        }
        public SqlDataReader OrderDetails(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "fetchOrderDetails");
            cmd.Parameters.AddWithValue("@OrderCode", obj.OrderCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

            con.Close();

        }
        public void CancelOrder(string OrderNo, string buyercode, string RejectionReason)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CancelOrder");
            cmd.Parameters.AddWithValue("@OrderCode", OrderNo);
            cmd.Parameters.AddWithValue("@RejectedByUserCode", buyercode);
            cmd.Parameters.AddWithValue("@RejectionReason", RejectionReason);
            cmd.Parameters.AddWithValue("@ProcessDate", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void RefundRequest(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RefundRequest");
            cmd.Parameters.AddWithValue("@OrderCode", obj.OrderCode);
            cmd.Parameters.AddWithValue("@ProcessDate", DateTime.Now);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public SqlDataReader WalletCount(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "WalletCount");
            cmd.Parameters.AddWithValue("@BuyerCode", obj.BuyerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

            con.Close();

        }
        public DataSet MyWallet(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "MyWallet");
            cmd.Parameters.AddWithValue("@BuyerCode", obj.BuyerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
        public SqlDataReader ViewTandC()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ViewTandC");
            // cmd.Parameters.AddWithValue("@BuyerCode", buyercode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

            con.Close();

        }

        public void SaveFeedback(Buyer objb)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SaveFeeddBack");
            cmd.Parameters.AddWithValue("@ProductCode", objb.ProductCode);
            cmd.Parameters.AddWithValue("@BuyerCode", objb.BuyerCode);
            cmd.Parameters.AddWithValue("@RatingStarNo", objb.RatingStarNo);
            cmd.Parameters.AddWithValue("@FeedbackOnProduct", objb.FeedbackOnProduct);
            cmd.ExecuteNonQuery();
        }
        ///Dhanashri End
          ////---------------------------------Vitthal Start---------------------------------///
        ///-----------------Checkout View-----------------------//
        public DataSet Checkout(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Checkout");
            cmd.Parameters.AddWithValue("@usercode", obj.BuyerCode);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }

        //Country binding

        public DataSet GetCountry()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "getCountry");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;



        }

        //----------State Binding
        public DataSet GetState(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "getState");
            cmd.Parameters.AddWithValue("@countryid", obj.CountryId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;


        }
        //--------------City Binding-----------
        public DataSet Getcity(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "getCity");
            cmd.Parameters.AddWithValue("@stateid", obj.StateId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;


        }

        //------------Save Buyer Address Home----------
        public void SaveAddressHome(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SaveAddressHome");
            cmd.Parameters.AddWithValue("@UserCode", obj.BuyerCode);
            cmd.Parameters.AddWithValue("@Home", obj.Address);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //------------Save Buyer Address Office----------
        public void SaveAddressOffice(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SaveAddressHome");
            cmd.Parameters.AddWithValue("@UserCode", obj.BuyerCode);
            cmd.Parameters.AddWithValue("@Office", obj.Address);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //------------Save Buyer Address Other----------
        public void SaveAddressOther(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SaveAddressHome");
            cmd.Parameters.AddWithValue("@UserCode", obj.BuyerCode);
            cmd.Parameters.AddWithValue("@Other", obj.Address);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //------------Update Buyer Address Home----------
        public void UpdateAddressHome(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateAddressHome");
            cmd.Parameters.AddWithValue("@UserCode", obj.BuyerCode);
            cmd.Parameters.AddWithValue("@Home", obj.Address);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //------------Update Buyer Address Office----------
        public void UpdateAddressOffice(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateAddressOffice");
            cmd.Parameters.AddWithValue("@UserCode", obj.BuyerCode);
            cmd.Parameters.AddWithValue("@Office", obj.Address);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //------------Update Buyer Address Office----------
        public void UpdateAddressOther(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateaddressOther");
            cmd.Parameters.AddWithValue("@UserCode", obj.BuyerCode);
            cmd.Parameters.AddWithValue("@Other", obj.Address);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //------------Update Buyer Mobile No ----------
        public void UpdateInfo(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateInfo");
            cmd.Parameters.AddWithValue("@UserCode", obj.BuyerCode);
            cmd.Parameters.AddWithValue("@mobileno", obj.MobileNo);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        //------------ Fetch Adress-------
        public SqlDataReader GetAddress(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetAddress");
            cmd.Parameters.AddWithValue("@usercode", obj.BuyerCode);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;

        }
        //------------City Binding-----------
        public SqlDataReader GetCity(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Getcity1");
            cmd.Parameters.AddWithValue("@usercode", obj.CityName);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;

        }

        //---------------------update Quantity of Order Product in cart ----------------
        public void UpdateQuantity(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateQuantity");
            cmd.Parameters.AddWithValue("@UserCode", obj.BuyerCode);
            cmd.Parameters.AddWithValue("@quantity", obj.ProductQuantity);
            cmd.Parameters.AddWithValue("@ordercode", obj.OrderCode);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //---------------------Check coupon ----------
        public DataSet CheckCoupan(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CheckCoupan");
            cmd.Parameters.AddWithValue("@usercode", obj.BuyerCode);
            cmd.Parameters.AddWithValue("@Couponcode", obj.CouponCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;



        }
        public DataSet ProductDetails(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ProductDetails");
            cmd.Parameters.AddWithValue("@usercode", obj.BuyerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }

        //---------------------delete buyer Order-----------
        public void deleteOrder(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DeleteOrder");
            cmd.Parameters.AddWithValue("@ordercode", obj.OrderCode);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //-------------------Place order -----------------

        public void PlaceOrder(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "PlaceOrder");
            cmd.Parameters.AddWithValue("@ordercode", obj.OrderCode);
            cmd.Parameters.AddWithValue("@AddressStatus", obj.StatusId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //----------------Giving coupon on Place order----------------
        public DataSet Getcoupan()
        {

            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Getcoupan");

            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        //----------------Giving Reward point on Place order----------------
        public DataSet GetReward()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetcReward");

            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }

        //---------------add Buyer Earn coupon and earn reward-----------
        public void AddCopan(Buyer obj)
        {

            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddCoupan");
            cmd.Parameters.AddWithValue("@ordercode", obj.OrderCode);
            cmd.Parameters.AddWithValue("@usercode", obj.BuyerCode);
            cmd.Parameters.AddWithValue("@Couponcode", obj.CouponCode);
            cmd.Parameters.AddWithValue("@CoupanexpDate", obj.coupanexpdate);
            cmd.Parameters.AddWithValue("@TotalReward", obj.Reward);
            cmd.Parameters.AddWithValue("@RewardId", obj.RewardId);
            cmd.Parameters.AddWithValue("@UsedReward", obj.UseedRewardPoints);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //-------------used coupon remove---------------
        public void RemoveCoupan(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Removecoupan");
            cmd.Parameters.AddWithValue("@ordercode", obj.OrderCode);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //--------------------Add Delevery address-----------
        public void SetDeliveryAddress(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SetDeliveryAddress");
            cmd.Parameters.AddWithValue("@usercode", obj.BuyerCode);
            cmd.Parameters.AddWithValue("@statusid", obj.StatusId);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        ///------------to check Buyer Available points---------
        public DataSet BalancePoint(Buyer obj)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "BalancePoint");
            cmd.Parameters.AddWithValue("@usercode", obj.BuyerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }
        public void SavePayment(Buyer objb)
        {
            try
            {
                ManageConnection();
                SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Flag", "SavePayment");
                cmd.Parameters.AddWithValue("@PaymentMode", objb.PaymentMode);
                cmd.Parameters.AddWithValue("@BuyerCode", objb.BuyerCode);
                cmd.Parameters.AddWithValue("@PaymentDate", objb.PaymentDate);
                cmd.Parameters.AddWithValue("@OrderCode", objb.OrderCode);
                cmd.Parameters.AddWithValue("@statusid", objb.StatusId);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public void SavePaymentc(Buyer objb)
        {
            try
            {
                ManageConnection();
                SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Flag", "SavePayment");
                cmd.Parameters.AddWithValue("@PaymentMode", objb.PaymentMode);
                cmd.Parameters.AddWithValue("@BuyerCode", objb.BuyerCode);
                cmd.Parameters.AddWithValue("@OrderCode", objb.OrderCode);
                cmd.Parameters.AddWithValue("@statusid", objb.StatusId);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        /////////////---------------------Vitthal End-----------------///////////

        ///-------------Akshda start ------------------//
        public void BuyerReg(Buyer objUser)
        {
            ManageConnection();

            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "APSaveBuyerReg");
            cmd.Parameters.AddWithValue("@BuyerCode", objUser.BuyerCode);
            cmd.Parameters.AddWithValue("@BuyerFullName", objUser.BuyerFullName);
            cmd.Parameters.AddWithValue("@EmailId", objUser.EmailId);
           // cmd.Parameters.AddWithValue("@EmailId", EmailId);
            cmd.Parameters.AddWithValue("@Password", objUser.Password);
            cmd.Parameters.AddWithValue("@MobileNo", objUser.MobileNo);
            cmd.Parameters.AddWithValue("@AlternateMobileNo", objUser.AlternaterMobileNo);
            cmd.Parameters.AddWithValue("@CityId", objUser.CityId);
            cmd.Parameters.AddWithValue("@DOB", objUser.DOB);
            cmd.Parameters.AddWithValue("@Gender", objUser.Gender);
            cmd.Parameters.AddWithValue("@AdhaarNo", objUser.AadhaarNo);
            cmd.Parameters.AddWithValue("@PancardNo", objUser.PanCardNo);
            cmd.Parameters.AddWithValue("@AdharPhoto", objUser.AadhaarPhoto);
            cmd.Parameters.AddWithValue("@PanCardPhoto", objUser.PanCardPhoto);
            cmd.Parameters.AddWithValue("@Salary", objUser.Salary);
            cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
            cmd.ExecuteNonQuery();
            con .Close();
        }
        public SqlDataReader BuyerCode()
        {
            ManageConnection();

            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "APBuyerCode");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        public SqlDataReader CheckEmailAlreadyExist(Buyer objUser)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CheckEmailAlreadyExistsB");
            cmd.Parameters.AddWithValue("@EmailId", objUser.EmailId);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

            con.Close();
        }

        public SqlDataReader CheckEmailAlreadyExistsS(Buyer objUser)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CheckEmailAlreadyExistsS");
            cmd.Parameters.AddWithValue("@EmailId", objUser.EmailId);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

            con.Close();
        }

        public SqlDataReader CheckEmailAlreadyExistsA(Buyer objUser)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CheckEmailAlreadyExistsA");
            cmd.Parameters.AddWithValue("@EmailId", objUser.EmailId);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

            con.Close();
        }

        public SqlDataReader ForgotPasswordBuyer(string email)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "APForgotPassword");
            cmd.Parameters.AddWithValue("@EmailId", email);
            //cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
            con.Close();

        }
    }
}
