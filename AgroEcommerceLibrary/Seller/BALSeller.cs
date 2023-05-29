using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AgroEcommerceLibrary.Seller
{
    public class BALSeller
    {
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
        public void SellerReg(Seller objUser)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SaveSellerReg");
            cmd.Parameters.AddWithValue("@SellerCode", objUser.SellerCode);
            cmd.Parameters.AddWithValue("@SellerType", objUser.SellerType);
            cmd.Parameters.AddWithValue("@SellerFullName", objUser.SellerFullName);
            cmd.Parameters.AddWithValue("@BusinessName", objUser.BusinessName);
            cmd.Parameters.AddWithValue("@BusinessPinCode", objUser.BusinessPinCode);
            cmd.Parameters.AddWithValue("@EmailId", objUser.EmailId);
            cmd.Parameters.AddWithValue("@Password", objUser.Password);
            cmd.Parameters.AddWithValue("@MobileNo", objUser.MobileNo);
            cmd.Parameters.AddWithValue("@AlternateMobileNo", objUser.AlternateMobileNo);
            cmd.Parameters.AddWithValue("@Gender", objUser.Gender);
            cmd.Parameters.AddWithValue("@CityId", objUser.CityId);
            cmd.Parameters.AddWithValue("@Pincode", objUser.PinCode);
            cmd.Parameters.AddWithValue("@DOB", objUser.DOB);
            cmd.Parameters.AddWithValue("@RegistrationDate", objUser.RegistrationDate);
            //   cmd.Parameters.AddWithValue("@RejectionReason", RejectionReason);
            //   cmd.Parameters.AddWithValue("@SellerApprovalDate", SellerApprovalDate);
            // cmd.Parameters.AddWithValue("@StatusId", StatusId);

            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataSet GetCity(int stateId)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "City");
            cmd.Parameters.AddWithValue("@stateId", stateId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

            con.Close();
        }

        //public DataSet CityBind()
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@flag", "City");
        //    SqlDataAdapter adpt = new SqlDataAdapter();
        //    adpt.SelectCommand = cmd;
        //    DataSet ds = new DataSet();
        //    adpt.Fill(ds);
        //    return ds;
        //    con.Close();
        //}
        public DataSet GetCountry()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Country");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;



            con.Close();
        }
        public DataSet GetState(int CountryId)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "State");
            cmd.Parameters.AddWithValue("@CountryId", CountryId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;



            con.Close();
        }
        public SqlDataReader SellerCode()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SellerCode");
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();

        }
        public void SellerRegAdd(Seller objUser)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SaveSellerAdd");
            cmd.Parameters.AddWithValue("@UserCode", objUser.SellerCode);
            cmd.Parameters.AddWithValue("@Home", objUser.Home);
            cmd.Parameters.AddWithValue("@Office", objUser.Office);
            cmd.Parameters.AddWithValue("@Other", objUser.Other);
            // cmd.Parameters.AddWithValue("", StatusId);



            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void SellerAddDoc(Seller objUser)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SaveSellerDoc");
            cmd.Parameters.AddWithValue("@SellerCode", objUser.SellerCode);
            cmd.Parameters.AddWithValue("@AadharNo", objUser.AadharNo);
            cmd.Parameters.AddWithValue("@PanCardNo", objUser.PanCardNo);
            cmd.Parameters.AddWithValue("@AadharImage", objUser.AadharImage);
            cmd.Parameters.AddWithValue("@PanImage", objUser.PanImage);
            cmd.Parameters.AddWithValue("@BusinessName", objUser.BusinessName);
            cmd.Parameters.AddWithValue("@GSTIN", objUser.GSTIN);
            cmd.Parameters.AddWithValue("@BusinessPinCode", objUser.BusinessPinCode);
            cmd.Parameters.AddWithValue("@BusinessAadharNo", objUser.BusinessAadharNo);
            cmd.Parameters.AddWithValue("@BusinessPanNo", objUser.BusinessPanNo);
            cmd.Parameters.AddWithValue("@BusinessAdharImage", objUser.BusinessAdharImage);
            cmd.Parameters.AddWithValue("@BusinessPanImage", objUser.BusinessPanImage);
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public void SellerBankDetail(Seller objUser)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "SellerBackDetail");
            cmd.Parameters.AddWithValue("@UserCode", objUser.SellerCode);
            cmd.Parameters.AddWithValue("@BankHolderName", objUser.BankHolderName);
            cmd.Parameters.AddWithValue("@BankName", objUser.BankName);
            cmd.Parameters.AddWithValue("@AccountNo", objUser.AccountNo);
            cmd.Parameters.AddWithValue("@IFSCCode", objUser.IFSCCode);
            cmd.Parameters.AddWithValue("@BrachName", objUser.BrachName);
            cmd.Parameters.AddWithValue("@AccountType", objUser.AccountType);
            cmd.Parameters.AddWithValue("@MobileNo", objUser.MobileNo);

            cmd.ExecuteNonQuery();
            con.Close();


        }
        public SqlDataReader getGmail(Seller ObjUser)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetEmails");
            cmd.Parameters.AddWithValue("@EmailId", ObjUser.EmailId);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        public SqlDataReader getGmailb(Seller ObjUser)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroBuyer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetEmailb");
            cmd.Parameters.AddWithValue("@EmailId", ObjUser.EmailId);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }

        //-------------------------------------bal seller count------------------//

        public SqlDataReader TodayOrder(Seller ObjUser)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "TodayOrder");
            cmd.Parameters.AddWithValue("@SellerCode", ObjUser.SellerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        public SqlDataReader pendingOrder(Seller ObjUser)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "PendingOrder");
            cmd.Parameters.AddWithValue("@SellerCode", ObjUser.SellerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        public SqlDataReader ReturnOrder(Seller ObjUser)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ReturnOrder");
            cmd.Parameters.AddWithValue("@SellerCode", ObjUser.SellerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        public SqlDataReader ReplaceOrder(Seller ObjUser)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "RePlacedOrder");
            cmd.Parameters.AddWithValue("@SellerCode", ObjUser.SellerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        public SqlDataReader CancelOrder(Seller ObjUser)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Cancelorder");
            cmd.Parameters.AddWithValue("@SellerCode", ObjUser.SellerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        public SqlDataReader productApprovel(Seller ObjUser)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ProductPendingForApprovel");
            cmd.Parameters.AddWithValue("@SellerCode", ObjUser.SellerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
        public SqlDataReader Reject(Seller ObjUser)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Reject");
            cmd.Parameters.AddWithValue("@SellerCode", ObjUser.SellerCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();
        }
      
        //-------------------------------------bal seller count end ------------------//

        //-------------------------GridView For AllProduct-------------------------------
        public DataSet GetAllProduct(Seller objsell)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "YGAllProdGrdvw");
            cmd.Parameters.AddWithValue("@SellerCode", objsell.SellerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
        //---------------------------------GridView For PendingProduct--------------------------
        public DataSet PendingProduct(Seller obj)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "YGPendGrdvw");
            //cmd.Parameters.AddWithValue("@StatusId", obj.StatusId);
            cmd.Parameters.AddWithValue("@SellerCode", obj.SellerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
           

        }
        //-------------------------GridView For RejectedProduct---------------------------

        public DataSet RejectedProduct(Seller obj)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "YGRejGrdvw");
            cmd.Parameters.AddWithValue("@StatusId", obj.StatusId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
        //--------------------------AddOfferButton-----------------------------------
        //public void AddOffer(string productCode, DateTime startDate, DateTime endDate, int offerId, int statusId)
        //{
        //    if (con.State == System.Data.ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }

        //    SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Flag", "YGAddOffer");
        //    cmd.Parameters.AddWithValue("@OfferId", offerId);
        //    cmd.Parameters.AddWithValue("@ProductCode", productCode);
        //    cmd.Parameters.AddWithValue("@StartDate", startDate);
        //    cmd.Parameters.AddWithValue("@EndDate", endDate);
        //    cmd.Parameters.AddWithValue("@StatusId", statusId);
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //}
        ////-------------------------------AddOfferUpdate-------------------------
        //public SqlDataReader PopOffer(string sellercode)
        //{
        //    if (con.State == System.Data.ConnectionState.Closed)
        //    {
        //        con.Open();
        //    }

        //    SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Flag", "YGAPopup");
        //    cmd.Parameters.AddWithValue("@SellerCode", sellercode);
        //    SqlDataReader dr;
        //    dr = cmd.ExecuteReader();
        //    return dr;
        //    con.Close();

        //}
        ////---------------------------------------AddOffer-----------------------------------

        //public DataSet YGGetOffer(Seller obj)
        //{
        //    ManageConnection();
        //    SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Flag", "YGGetOffer");
        //    cmd.Parameters.AddWithValue("@AdminOfferId", obj.AdminOfferId);
        //    SqlDataAdapter adpt = new SqlDataAdapter();
        //    adpt.SelectCommand = cmd;
        //    DataSet ds = new DataSet();
        //    adpt.Fill(ds);
        //    return ds;

        //    con.Close();
        //}
        //------------------------------ADD CAT------------------------------------------
        public void AddCategories(string categoryCode, string categoryName, string rejectionReason, float commission, int statusId)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddCategories");
            cmd.Parameters.AddWithValue("@CategoryCode", categoryCode);
            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
            cmd.Parameters.AddWithValue("@RejectionReason", rejectionReason);
            cmd.Parameters.AddWithValue("@Commission", commission);
            cmd.Parameters.AddWithValue("@StatusId", statusId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public SqlDataReader UpdateProduct(Seller ObjSell)
        {
            ManageConnection();

            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetProduct");
            cmd.Parameters.AddWithValue("@ProductCode", ObjSell.ProductCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();

        }
        public void UpdateProductInfo(Seller objsell)
        {
            ManageConnection();

            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateProductInfo");
            cmd.Parameters.AddWithValue("@ProductName", objsell.ProductName);
            cmd.Parameters.AddWithValue("@Description", objsell.Description);
            cmd.Parameters.AddWithValue("@Quantity", objsell.CurrentStock);
            cmd.Parameters.AddWithValue("@MinRangeDiscount", objsell.MinRangeDiscount);
            cmd.Parameters.AddWithValue("@Mrp", objsell.MRP);
            cmd.Parameters.AddWithValue("@ProductWeight", objsell.ProductWeight);
            cmd.Parameters.AddWithValue("@Discount", objsell.Discount);
            cmd.Parameters.AddWithValue("@IsProductReturnable", objsell.IsProductReturnable);
            cmd.Parameters.AddWithValue("@IsproductExpirable", objsell.IsproductExpirable);
            cmd.Parameters.AddWithValue("@ProductExpiryDuration", objsell.PrductExpiryDuration);
            cmd.Parameters.AddWithValue("@IsProductSeasonable", objsell.IsProductSeasonable);
            cmd.Parameters.AddWithValue("@SeasonName", objsell.SeasonName);
            cmd.Parameters.AddWithValue("@ProductWeightRange", objsell.ProductWeightRange);
            cmd.Parameters.AddWithValue("@ManufacturerName", objsell.ManufacturerName);
            cmd.Parameters.AddWithValue("@MinimumStock", objsell.MinimumStock);
            cmd.Parameters.AddWithValue("@MaximumStock", objsell.MaximumStock);
            cmd.Parameters.AddWithValue("@ProductCode", objsell.ProductCode);
            cmd.ExecuteNonQuery();


        }
        public void DeleteProduct(Seller objsell)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DeleteProduct");
            cmd.Parameters.AddWithValue("@ProductCode", objsell.ProductCode);
            cmd.ExecuteNonQuery();
        }
       
        /// /Rajashri////
       
        public DataSet GetCategory()
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
        public DataSet GetSubCategory1(Seller ObjSeller)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetSubCategory1");
            cmd.Parameters.AddWithValue("@CategoryCode", ObjSeller.CategoryCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        public DataSet GetSubCategory2(Seller ObjSeller)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetSubCategory2");
            cmd.Parameters.AddWithValue("@SubCategory1Code", ObjSeller.SubCategory1Code);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        public SqlDataReader GetProductCode()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetProductCode");
            //cmd.Parameters.AddWithValue("@PCode", ProdutId);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
        }
        public void AddProductInfo(Seller ObjSeller)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddProductInfo");
            cmd.Parameters.AddWithValue("@ProductCode", ObjSeller.ProductCode);
            cmd.Parameters.AddWithValue("@CategoryCode", ObjSeller.SubCategory2Code);
            cmd.Parameters.AddWithValue("@ProductName", ObjSeller.ProductName);
            cmd.Parameters.AddWithValue("@Description", ObjSeller.Description);
            cmd.Parameters.AddWithValue("@CurrentStock", ObjSeller.CurrentStock);
            cmd.Parameters.AddWithValue("@MinRangeDiscount", ObjSeller.MinRangeDiscount);
            cmd.Parameters.AddWithValue("@MRP", ObjSeller.MRP);
            cmd.Parameters.AddWithValue("@SellerCode", ObjSeller.SellerCode);
            cmd.Parameters.AddWithValue("@StatusId", ObjSeller.StatusId);
            cmd.Parameters.AddWithValue("@ProductWeight", ObjSeller.ProductWeight);
            cmd.Parameters.AddWithValue("@Discount", ObjSeller.Discount);
            cmd.Parameters.AddWithValue("@IsProductReturnable", ObjSeller.IsProductReturnable);
            cmd.Parameters.AddWithValue("@IsProductExpirable", ObjSeller.IsproductExpirable);
            cmd.Parameters.AddWithValue("@ProductExpiryDuration", ObjSeller.PrductExpiryDuration);
            cmd.Parameters.AddWithValue("@IsProductSeasonable", ObjSeller.IsProductSeasonable);
            cmd.Parameters.AddWithValue("@SeasonName", ObjSeller.SeasonName);
            cmd.Parameters.AddWithValue("@ProductWeightRange", ObjSeller.ProductWeightRange);
            cmd.Parameters.AddWithValue("@ProductRegistrationDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ManufacturerName", ObjSeller.ManufacturerName);
            cmd.Parameters.AddWithValue("@MaximumStock", ObjSeller.MaximumStock);
            cmd.Parameters.AddWithValue("@MinimumStock", ObjSeller.MinimumStock);
            cmd.Parameters.AddWithValue("@RejectionReasonfromAdmin", ObjSeller.RejectionReasonfromAdmin);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void AddProductImage(Seller ObjSeller)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddProductImage");
            cmd.Parameters.AddWithValue("@ProductCode", ObjSeller.ProductCode);
            cmd.Parameters.AddWithValue("@MainImage", ObjSeller.MainImage);
            cmd.Parameters.AddWithValue("@Image1", ObjSeller.Image1);
            cmd.Parameters.AddWithValue("@Image2", ObjSeller.Image2);
            cmd.Parameters.AddWithValue("@Image3", ObjSeller.Image3);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        //==========AddCategory====//
        //public void AddCategory(Seller objseller)
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Flag", "AddCategory");
        //    cmd.Parameters.AddWithValue("@CategoryCode", objseller.CategoryCode);
        //    cmd.Parameters.AddWithValue("@CategoryName", objseller.CategoryName);
        //    cmd.Parameters.AddWithValue("@StatusId", objseller.StatusId);
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

        public void AddCategory(Seller objseller)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddCategory");
            cmd.Parameters.AddWithValue("@CategoryCode", objseller.CategoryCode);
            cmd.Parameters.AddWithValue("@CategoryName", objseller.CategoryName);
            cmd.Parameters.AddWithValue("@RejectionReason", objseller.RejectionReason);
            cmd.Parameters.AddWithValue("@Commision", objseller.Commision);
            cmd.Parameters.AddWithValue("@StatusId", objseller.StatusId);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AddSubCategory1(Seller objseller)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddSubCategory1");
            cmd.Parameters.AddWithValue("@CategoryCode", objseller.CategoryCode);
            cmd.Parameters.AddWithValue("@SubCategory1Code", objseller.SubCategory1Code);
            cmd.Parameters.AddWithValue("@SubCategory1Name", objseller.SubCategory1Name);
            cmd.Parameters.AddWithValue("@StatusId", objseller.StatusId);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AddSubCategory2(Seller objseller)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddSubCategory2");
            cmd.Parameters.AddWithValue("@SubCategory1Code", objseller. SubCategory1Code);
            cmd.Parameters.AddWithValue("@SubCategory2Code", objseller.SubCategory2Code);
            cmd.Parameters.AddWithValue("@SubCategory2Name", objseller.SubCategory2Name);
            cmd.Parameters.AddWithValue("@StatusId", objseller.StatusId);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet Chart(Seller ObjUser)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "Chart");
            cmd.Parameters.AddWithValue("@SellerCode", ObjUser.SellerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }

        public DataSet TotalSaleseller(Seller ObjUser)
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "TotalSaleSeller");
            cmd.Parameters.AddWithValue("@SellerCode", ObjUser.SellerCode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();
        }
        ///////////////Yash start//////////////
        ///


        //-------------------------GridView For AllProduct-------------------------------
        public DataSet GetAllProduct(string sellercode)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "YGAllProdGrdvw");
            cmd.Parameters.AddWithValue("@SellerCode", sellercode);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
            con.Close();

        }
        //--------------------------AddOfferButton-----------------------------------
        public void AddOffer(string productCode, DateTime startDate, DateTime endDate, int offerId, int statusId)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "YGAddOffer");
            cmd.Parameters.AddWithValue("@OfferId", offerId);
            cmd.Parameters.AddWithValue("@ProductCode", productCode);
            cmd.Parameters.AddWithValue("@StartDate", startDate);
            cmd.Parameters.AddWithValue("@EndDate", endDate);
            cmd.Parameters.AddWithValue("@StatusId", statusId);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        //-------------------------------AddOfferUpdate-------------------------
        public SqlDataReader PopOffer(string ProductCode)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "YGAPopup");
            cmd.Parameters.AddWithValue("@ProductCode", ProductCode);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            return dr;
            con.Close();

        }
        //---------------------------------------AddOffer-----------------------------------

        public DataSet YGGetOffer(Seller obj)
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SPAgroSeller", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "YGGetOffer");
            cmd.Parameters.AddWithValue("@AdminOfferId", obj.AdminOfferId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

            con.Close();
        }

        ///////////////Yash End//////////////////

    }
}
