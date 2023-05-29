using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AgroEcommerceLibrary.Admin
{
    public class BALAdmin
    {

        //SqlConnection con = new SqlConnection("Data Source=AKASH\\SQLEXPRESS;Initial Catalog=GSTAgroE-Commerce;Integrated Security=True");
        //  SqlConnection con = new SqlConnection("Data Source=DESKTOP-G0RI5B8;Initial Catalog=GSTAgroE-Commerce;Integrated Security=True");
        // SqlConnection con = new SqlConnection("Data Source=MAULI;Initial Catalog=GSTAgroE-Commerce;Integrated Security=True");
        // SqlConnection con = new SqlConnection("Data Source=PRATHAMESH\\SQLEXPRESS;Initial Catalog=GSTAgroE-Commerce;Integrated Security=True;Max Pool Size=5000000;Pooling=True;");
        static string CS = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(CS);

        public void ManageConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();

            }
            //else
            //{
            //    con.Close();
            //}
        }

        /////////-----------Prathmesh Start-----------////////
        public DataSet GetProductAdmin()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetProductAdminPN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }
        public DataSet GetSearchbyCategory(int CategoryId)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SearchByCategoryPN");
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }
        public DataSet GetCatergory()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CategorynamePN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }
        public DataSet GetSearchbySeller(int SellerId)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SearchBySellerPN");
            cmd.Parameters.AddWithValue("@SellerId", SellerId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }
        public DataSet GetsellerName()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SellerNamePN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }
        public SqlDataReader GetAdminProfData(Admin objA) //Admin Profile data
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AdminProfDataPN");
            cmd.Parameters.AddWithValue("@AdminId", objA.AdminId);
            // cmd.Parameters.AddWithValue("@AdminId",objA.AdminId );
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;

            con.Close();
        }

        public DataSet GetCityPN(int stateId)//get city
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CityPN");
            cmd.Parameters.AddWithValue("@StateId", stateId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

            con.Close();
        }
        public DataSet GetCountryPN()// get country
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CountryPN");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;



            con.Close();
        }
        public DataSet GetStatePN(int CountryId)//get state
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "StatePN");
            cmd.Parameters.AddWithValue("@CountryId", CountryId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;



            con.Close();
        }

        public void ProfileUpdateSave(Admin objA)//Profile Admin Update
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ProfileUpdatePN");
            cmd.Parameters.AddWithValue("@AdminFullName", objA.AdminFullName);
            cmd.Parameters.AddWithValue("@EmailId", objA.EmailId);
            cmd.Parameters.AddWithValue("@MobileNo", objA.MobileNo);
            cmd.Parameters.AddWithValue("@Address", objA.Address);
            cmd.Parameters.AddWithValue("@Pincode", objA.PinCode);
            cmd.Parameters.AddWithValue("@CityId", objA.CityId);
            cmd.Parameters.AddWithValue("@AdminId", objA.AdminId);

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public DataSet ManageCategorygrid() // List Of Category Grid View
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ManageCategoryGrid");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return (ds);
            con.Close();
        }

        public void AddCategory(Admin objAd) // Add Category
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddCategories");
            cmd.Parameters.AddWithValue("@CategoryCode", objAd.CategoryCode);
            cmd.Parameters.AddWithValue("@CategoryName", objAd.CategoryName);
            cmd.Parameters.AddWithValue("@RejectionReason", objAd.RejectionReason);
            cmd.Parameters.AddWithValue("@Commission", objAd.Commision);
            // cmd.Parameters.AddWithValue("@StatusId", objAd.StatusId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AddSubCategory1(Admin objAd) //Add Sub Category1
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddSubCategory1");
            cmd.Parameters.AddWithValue("@CategoryCode", objAd.CategoryCode);
            cmd.Parameters.AddWithValue("@SubCategory1Code", objAd.SubCategory1Code);
            cmd.Parameters.AddWithValue("@SubCategory1Name", objAd.SubCategory1Name);
            // cmd.Parameters.AddWithValue("@StatusId", objAd.StatusId);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AddSubCategory2(Admin objAd) // Add SunCategory2
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddSubCategory2");
            cmd.Parameters.AddWithValue("@SubCategory1Code", objAd.SubCategory1Code);
            cmd.Parameters.AddWithValue("@SubCategory2Code", objAd.SubCategory2Code);
            cmd.Parameters.AddWithValue("@SubCategory2Name", objAd.SubCategory2Name);
            //  cmd.Parameters.AddWithValue("@StatusId", objAd.StatusId);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet GetCategoryPN() //get Category
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetCategory");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet GetSubCategory1PN(Admin ObjAd) //get SubCategory1
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetSubCategory1");
            cmd.Parameters.AddWithValue("@CategoryCode", ObjAd.CategoryCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet GetSubCategory2PN(Admin ObjAd)//GetSubCategory2
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetSubCategory2");
            cmd.Parameters.AddWithValue("@SubCategory1Code", ObjAd.SubCategory1Code);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        public SqlDataReader FetchCategorygrid(Admin ObjA)//fetch CategoryGrid
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "FetchCategoryGrid");
            cmd.Parameters.AddWithValue("@SubCategory2Code", ObjA.SubCategory2Code);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;

            con.Close();
        }
        public void UpdateComission(Admin objA)//Update Comission
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateCommisonPN");
            cmd.Parameters.AddWithValue("@Commission", objA.Commision);
            cmd.Parameters.AddWithValue("@CategoryCode", objA.CategoryCode);

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void UpdateCAtegoryStatus(Admin objA)//Update Category Status
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateCAtegoryStatus");
            // cmd.Parameters.AddWithValue("@Commission", objA.Commision);
            cmd.Parameters.AddWithValue("@CategoryCode", objA.CategoryCode);

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void UpdateSubCate1Status(Admin objA)//Update Subcategory 1 Status
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateSubCate1Status");
            //cmd.Parameters.AddWithValue("@Commission", objA.Commision);
            cmd.Parameters.AddWithValue("@SubCategory1Code", objA.SubCategory1Code);

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void UpdateSubCate2Status(Admin objA)//Update Subcategory 2 Status
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateSubCate2Status");
            // cmd.Parameters.AddWithValue("@Commission", objA.Commision);
            cmd.Parameters.AddWithValue("@SubCategory2Code", objA.SubCategory2Code);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        //////----------Prathmesh End-----------////////

        //////////-----Sagar Start--------------////////

        //==========AddCategory====//
        public void AddCategory(string CategoryCode, string CategoryName, float Commision, int StatusId)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddCategory");
            cmd.Parameters.AddWithValue("@CategoryCode", CategoryCode);
            cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
            cmd.Parameters.AddWithValue("@Commision", Commision);
            cmd.Parameters.AddWithValue("@StatusId", StatusId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        // ========== Show Seller Pending Count on Dashboard ==========//
        public SqlDataReader ShowPendingSellers()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ShowPendingSellers");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }

        // ========== Show Product Pending Count on Dashboard ==========//
        public SqlDataReader ShowPendingProducts()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ShowPendingProducts");
            SqlDataReader dt;
            dt = cmd.ExecuteReader();
            return dt;
            con.Close();
        }

        // ========== List View For Seller Approval ==========//
        public DataSet PendingSellerList()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SellerApprovalList");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        // ========== List View For Product Approval ==========//
        public DataSet PendingProductList()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ProductApprovalList");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        // ========== Detail Popup View For Seller Approval ==========//
        public SqlDataReader SellerDetails(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SellerDetails");
            cmd.Parameters.AddWithValue("@SellerCode", objA.SellerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }

        // ========== Detail Popup View For Product Approval ==========//
        public SqlDataReader ProductDetails(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ProductDetails");
            cmd.Parameters.AddWithValue("@ProductCode", objA.ProductCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }

        // ========== Popup View For Seller Approval Status ==========//
        public void ApproveSellerStatus(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ApproveSellerStatus");
            cmd.Parameters.AddWithValue("@SellerCode", objA.SellerCode);
            cmd.Parameters.AddWithValue("@SellerFullName", objA.SellerFullName);
            cmd.Parameters.AddWithValue("@BusinessName", objA.BusinessName);
            cmd.Parameters.AddWithValue("@MobileNo", objA.MobileNo);
            cmd.Parameters.AddWithValue("@Date", objA.SellerApprovalDate);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        // ========== Popup View For Seller Reject Status ==========//
        public void RejectSellerStatus(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RejectSellerStatus");
            cmd.Parameters.AddWithValue("@RejectionReason", objA.RejectionReason);
            cmd.Parameters.AddWithValue("@SellerCode", objA.SellerCode);
            cmd.Parameters.AddWithValue("@SellerFullName", objA.SellerFullName);
            cmd.Parameters.AddWithValue("@BusinessName", objA.BusinessName);
            cmd.Parameters.AddWithValue("@MobileNo", objA.MobileNo);
            cmd.Parameters.AddWithValue("@Status", objA.Status);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // ========== Popup View For Product Approval Status ==========//
        public void ApproveProductStatus(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ApproveProductStatus");
            cmd.Parameters.AddWithValue("@ProductCode", objA.ProductCode);
            cmd.Parameters.AddWithValue("@ProductName", objA.ProductName);
            cmd.Parameters.AddWithValue("@MRP", objA.MRP);
            cmd.Parameters.AddWithValue("@MaxStock", objA.MaximumStock);
            cmd.Parameters.AddWithValue("@MinStock", objA.MinimumStock);
            cmd.Parameters.AddWithValue("@Date", objA.ProductApprovalDate);
            cmd.Parameters.AddWithValue("@Status", objA.Status);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        // ==========  Popup View For Product Reject Status ==========//
        public void RejectProductStatus(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RejectProductStatus");
            cmd.Parameters.AddWithValue("@ProductCode", objA.ProductCode);
            cmd.Parameters.AddWithValue("@ProductName", objA.ProductName);
            cmd.Parameters.AddWithValue("@MRP", objA.MRP);
            cmd.Parameters.AddWithValue("@MaxStock", objA.MaximumStock);
            cmd.Parameters.AddWithValue("@MinStock", objA.MinimumStock);
            cmd.Parameters.AddWithValue("@RejectionReason", objA.RejectionReason);
            cmd.Parameters.AddWithValue("@Status", objA.Status);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // ========== List View For All Orders ==========//
        public DataSet AllOrder()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AllOrders");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        // ========== Detail Popup View For All Order Details ==========//
        public SqlDataReader AllOrderDetails(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AllOrderDetails");
            cmd.Parameters.AddWithValue("@OrderCode", objA.OrderCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        // ========== List View For All Orders ==========//
        public DataSet OrderStatus(Admin objA, int StatusId)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "OrderStatus");
            cmd.Parameters.AddWithValue("@StatusId", StatusId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet FilterButtons()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "FilterButtons");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        // ========== List View For Category Approval ==========//
        public DataSet CategoryApproval()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CategoryApproval");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        // ========== Detail Popup View For Category ==========//
        public SqlDataReader CategoryDetails(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CategoryDetails");
            cmd.Parameters.AddWithValue("@CategoryCode", objA.CategoryCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        // ========== Popup View For Category Approval Status ==========//
        public void CategoryApprove(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CategoryApprove");
            cmd.Parameters.AddWithValue("@CategoryCode", objA.CategoryCode);
            //cmd.Parameters.AddWithValue("@StatusId", objA.StatusId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        // ========== Popup View For Category Rejection Status ==========//
        public void CategoryReject(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "CategoryReject");
            cmd.Parameters.AddWithValue("@CategoryCode", objA.CategoryCode);
            cmd.Parameters.AddWithValue("@RejectionReason", objA.RejectionReason);
            //cmd.Parameters.AddWithValue("@StatusId", objA.StatusId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        // ========== List View For SubCategory1 Approval ==========//
        public DataSet SubCategory1Approval()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SubCategory1Approval");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        // ========== Detail Popup View For SubCategory1 ==========//
        public SqlDataReader SubCategory1Details(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SubCategory1Details");
            cmd.Parameters.AddWithValue("@SubCategory1Code", objA.SubCategory1Code);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }

        // ========== Popup View For SubCategory1 Approval Status ==========//
        public void SubCategory1Approve(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SubCategory1Approve");
            cmd.Parameters.AddWithValue("@SubCategory1Code", objA.SubCategory1Code);
            //cmd.Parameters.AddWithValue("@StatusId", objA.StatusId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // ========== Popup View For SubCategory1 Rejection Status ==========//
        public void SubCategory1Reject(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SubCategory1Reject");
            cmd.Parameters.AddWithValue("@SubCategory1Code", objA.SubCategory1Code);
            //cmd.Parameters.AddWithValue("@StatusId", objA.StatusId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        // ========== List View For SubCategory2 Approval Requests ==========//
        public DataSet SubCategory2Approval()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SubCategory2Approval");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        // ========== Detail Popup View For SubCategory2 ==========//
        public SqlDataReader SubCategory2Details(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SubCategory2Details");
            cmd.Parameters.AddWithValue("@SubCategory2Code", objA.SubCategory2Code);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        // ========== Popup View For SubCategory2 Approval Status ==========//
        public void SubCategory2Approve(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SubCategory2Approve");
            cmd.Parameters.AddWithValue("@SubCategory2Code", objA.SubCategory2Code);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // ========== Popup View For SubCategory2 Rejection Status ==========//
        public void SubCategory2Reject(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SubCategory2Reject");
            cmd.Parameters.AddWithValue("@SubCategory2Code", objA.SubCategory2Code);
            //cmd.Parameters.AddWithValue("@StatusId", objA.StatusId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet GetEmail(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetEmail");
            cmd.Parameters.AddWithValue("@SellerCode", objA.SellerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet GetEmail1(Admin objA)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetEmail1");
            cmd.Parameters.AddWithValue("@SellerCode", objA.SellerCode);
            cmd.Parameters.AddWithValue("@ProductCode", objA.ProductCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        /////////////-----Sagar end--------------////////
        public DataSet AllBuyerDetail()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "BuyerOrderDetail");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet BuyerOrderDetails(Admin objadmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "BuyerOrderDetails");
            cmd.Parameters.AddWithValue("@BuyerCode", objadmin.BuyerCode);
            SqlDataAdapter adpt =new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds =new DataSet();
            adpt.Fill(ds);
            return ds; 

        }
        /////////////////////////Indrjeet/////////////////

        public DataSet SellerGrid()
        {

            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Sellergrid");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;



            con.Close();
        }
        public void SellerDelete(string SellerCode)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DeleteSeller");
            cmd.Parameters.AddWithValue("@SellerCode", SellerCode);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public SqlDataReader GetData(string SellerCode)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "FeatchDetail");
            cmd.Parameters.AddWithValue("@SellerCode", SellerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;



            con.Close();
        }
        //public DataSet selleractive(string SellerCode)
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@flag", "SellerActive");
        //    cmd.Parameters.AddWithValue("@SellerCode", SellerCode);
        //    SqlDataReader dr;
        //    dr = cmd.ExecuteReader();
        //    return dr;



        //    con.Close();
        //}
        public void ActiveSeller(Admin objUser)/////////Active Seller
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SellerActive");
            cmd.Parameters.AddWithValue("@SellerCode", objUser.SellerCode);
            cmd.Parameters.AddWithValue("@StatusId", objUser.StatusId);


            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void Reactive(Admin objUser)///////////////Reactive Seller
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ReActive");
            cmd.Parameters.AddWithValue("@SellerCode", objUser.SellerCode);


            cmd.ExecuteNonQuery();
            con.Close();

        }

        public SqlDataReader TotalSeller()/////////////TotalSeller Count
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "totalSeller");
            // cmd.Parameters.AddWithValue("@SellerCode", SellerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;



            con.Close();
        }
        public SqlDataReader activeseller()///////////Active Seller
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Activeseller");
            // cmd.Parameters.AddWithValue("@SellerCode", SellerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;



            con.Close();
        }
        public SqlDataReader reactiveseller()/////////////Reactive Seller
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "inActiveseller");
            // cmd.Parameters.AddWithValue("@SellerCode", SellerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }

        //////////////-------------Vittal Start-------////////////
        public void SaveCoupon(Admin objadmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SaveCoupon");
            cmd.Parameters.AddWithValue("@CouoponCode", objadmin.CouponCode);
            cmd.Parameters.AddWithValue("@CouponAmount", objadmin.CouponAmount);
            cmd.Parameters.AddWithValue("@CouponRange", objadmin.CouponRange);
            cmd.Parameters.AddWithValue("@ExpiryDays", objadmin.Expirydays);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet FetchCoupon()
        {
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "FetchCoupon");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet dt = new DataSet();
            adpt.Fill(dt);
            return (dt);
        }
        public void ChangeCouponStatus(Admin objadmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ChangeCouponStatus");
            cmd.Parameters.AddWithValue("@CouoponCode", objadmin.CouponCode);
            cmd.Parameters.AddWithValue("@StatusId", objadmin.StatusId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataSet FetchReward()
        {
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "FetchReward");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet dt = new DataSet();
            adpt.Fill(dt);
            return (dt);
        }
        public void ChangeRewardStatus(Admin objadmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ChangeRewardtatus");
            cmd.Parameters.AddWithValue("@rewardid", objadmin.RewardId);
            cmd.Parameters.AddWithValue("@StatusId", objadmin.StatusId);
            cmd.ExecuteNonQuery();

        }
        public void SaveReward(Admin objadmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SaveReward");
            cmd.Parameters.AddWithValue("@rewardPoint", objadmin.RewardPoints);
            cmd.Parameters.AddWithValue("@RewardconvesionRate", objadmin.RewardConversionRate);
            cmd.Parameters.AddWithValue("@Rewardrange", objadmin.RewardRange);
            cmd.Parameters.AddWithValue("@pointlimit", objadmin.PointLimits);
            cmd.ExecuteNonQuery();

        }
        public SqlDataReader DetailsCoupon(Admin objadmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DetailsCoupon");
            cmd.Parameters.AddWithValue("@CouoponCode", objadmin.CouponCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }
        public void EditCoupon(Admin objadmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "EditCoupon");
            cmd.Parameters.AddWithValue("@CouoponCode", objadmin.CouponCode);
            cmd.Parameters.AddWithValue("@CouponAmount", objadmin.CouponAmount);
            cmd.Parameters.AddWithValue("@CouponRange", objadmin.CouponRange);
            cmd.Parameters.AddWithValue("@ExpiryDays", objadmin.Expirydays);
            cmd.Parameters.AddWithValue("@couponId", objadmin.CouponId);
            cmd.ExecuteNonQuery();

        }
        public void DeleteCoupon(Admin objAdmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DeleteCoupon");
            cmd.Parameters.AddWithValue("@CouponId", objAdmin.CouponId);
            cmd.ExecuteNonQuery();
        }
        public SqlDataReader DetailsReward(Admin objadmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DetailsReward");
            // cmd.Parameters.AddWithValue("@pointlimit", objadmin.PointLimits);
            cmd.Parameters.AddWithValue("@rewardid", objadmin.RewardId);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;

        }
        public void EditReward(Admin objadmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "EditReward");
            cmd.Parameters.AddWithValue("@RewardconvesionRate", objadmin.RewardConversionRate);
            cmd.Parameters.AddWithValue("@rewardPoint", objadmin.RewardPoints);
            cmd.Parameters.AddWithValue("@Rewardrange", objadmin.RewardRange);
            cmd.Parameters.AddWithValue("@pointlimit", objadmin.PointLimits);
            cmd.Parameters.AddWithValue("@rewardid", objadmin.RewardId);
            cmd.ExecuteNonQuery();
        }
        public void DeleteReward(Admin objAdmin)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DeleteReward");
            cmd.Parameters.AddWithValue("@rewardid", objAdmin.RewardId);
            cmd.ExecuteNonQuery();
        }
        //////////////--------------Vittal End---------///////////
        /// //////////////--------------Dhanashri Satrt---------///////////

        public DataSet PaymentHistory()//////////////PaymentHistory Seller
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "PaymentHistory");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

            con.Close();
        }
        public DataSet FilterPaymentHistory(Admin objAd)///////////////date FilterPaymentHistory
        {
            try
            {

                ManageConnection();
                SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Flag", "FilterPaymentHistory");
                cmd.Parameters.AddWithValue("@FromDate", objAd.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", objAd.ToDate);
                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                return ds;

                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public SqlDataReader PaymentDetailsDD(Admin objAd)//////////////PaymentDetailsDD
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "PaymentDetailsDD");
            cmd.Parameters.AddWithValue("@SellerCode", objAd.SellerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        public DataSet RefundedAmount(Admin objAd)////////////Seller RefundedAmount
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RefundedAmount");
            cmd.Parameters.AddWithValue("@SellerCode", objAd.SellerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet PaymentDetails(Admin objAd)//////////Seller PaymentDetails
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "PaymentDetails");
            cmd.Parameters.AddWithValue("@SellerCode", objAd.SellerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

            con.Close();
        }
        public SqlDataReader FilterPaymentDetailsDD(Admin objAd)/////////Date wise FilterPaymentDetails
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "FilterPaymentDetailsDD");
            cmd.Parameters.AddWithValue("@SellerCode", objAd.SellerCode);
            cmd.Parameters.AddWithValue("@FromDate", objAd.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", objAd.ToDate);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        public DataSet FilterRefundedAmount(Admin objAd)/////////////Seller FilterRefundedAmount
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "FilterRefundedAmount");
            cmd.Parameters.AddWithValue("@SellerCode", objAd.SellerCode);
            cmd.Parameters.AddWithValue("@FromDate", objAd.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", objAd.ToDate);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet FilterPaymentDetails(Admin objAd)////////////////// Seller FilterPaymentDetails
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "FilterPaymentDetails");
            cmd.Parameters.AddWithValue("@SellerCode", objAd.SellerCode);
            cmd.Parameters.AddWithValue("@FromDate", objAd.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", objAd.ToDate);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

            con.Close();
        }
        public DataSet RefundRequest()/////////////Buyers RefundRequest
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RefundRequest");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

            con.Close();
        }
        public DataSet FilterForRefundRequests(Admin objAd)///////////////FilterForRefundRequests
        {
            try
            {


                ManageConnection();
                SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Flag", "FilterForRefundRequests");
                cmd.Parameters.AddWithValue("@FromDate", objAd.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", objAd.ToDate);
                SqlDataAdapter adpt = new SqlDataAdapter();
                adpt.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                return ds;

                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void RefundToBuyer(Admin objAd)//////////// Buyer RefundToBuyer
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RefundToBuyer");
            cmd.Parameters.AddWithValue("@OrderCode", objAd.OrderCode);
            cmd.Parameters.AddWithValue("@ProcessDate", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /////////////////--------------Dhanshri End---------///////////
        /////////////////////----------Ankita Start ---------////////////

        public SqlDataReader Seller()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "TotalCoustmore");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();

        }
        public SqlDataReader TotalProducts()//Function Name
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "TotalProducts");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        public SqlDataReader Coustmore()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "TotalBuyer");//as TotalBuyer
                                                               // cmd.Parameters.AddWithValue("@Flag", "Refund");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        //===============B(Two)=============
        public SqlDataReader SuccessfullOrder()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SuccessfullOrder");
            //  cmd.Parameters.AddWithValue("@OrderStatusId", orderstatusid);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        //==================SB(Three)=============
        public SqlDataReader Returned()
        {

            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Returned");
            // cmd.Parameters.AddWithValue("OrderStatusId", orderstatusid);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        //**************Anki1***************
        public SqlDataReader Refund()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Refund");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            // con.Close();
        }
        //=========================Anki2======================================
        public SqlDataReader Replaced()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Replaced");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            // con.Close();
        }

        //===============ThirdBlock================================
        public SqlDataReader Canelled()
        {
            try
            {
                ManageConnection();
                SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "Canelled");
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            con.Close();
        }
        public SqlDataReader Refund1()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.Parameters.AddWithValue("Flag", "Refund1");
            // cmd.Parameters.AddWithValue("OrderStatusId", obj.StatusId);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();

        }

        public DataSet Chart1(Admin ObjUser)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Chart1");
            // cmd.Parameters.AddWithValue("@SellerCode", ObjUser.SellerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;



            con.Close();
        }

        ///////////////////////--------Ankita End------------////////////
    }
}
