using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace HelloWorld.App_Code
{
    public class DatabaseConnectivity
    {
        String con = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

        //Getting Client in String List

        public string[] getClientListString()
        {
            List<string> _clientList = new List<string>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spNumberOfPatchesForGraph]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        //string item = new string();
                        //item._clientID = oReader["ClientID"].ToString();
                        string item = oReader["ClientName"].ToString();
                        _clientList.Add(item);
                    }

                    myConnection.Close();
                }
            }
            string[] res = new string[_clientList.Count];
            for (int i = 0; i < _clientList.Count; i++) {
                res[i] = _clientList[i];
            }
                return res;
        }

        //Getting Client List in String End

        //Getting Client in Int List

        public int[] getClientListInt()
        {
            List<int> _clientList = new List<int>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spNumberOfPatchesForGraph]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        //string item = new string();
                        //item._clientID = oReader["ClientID"].ToString();
                        int item = Convert.ToInt32(oReader["NumberOfPatches"]);
                        _clientList.Add(item);
                    }

                    myConnection.Close();
                }
            }
            int[] res = new int[_clientList.Count];
            for (int i = 0; i < _clientList.Count; i++)
            {
                res[i] = _clientList[i];
            }
            return res;
        }

        //Getting Client List in Int End

        //Getting Client List

        public List<Client> getClientList()
        {
            List<Client> _clientList = new List<Client>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spGetAllClient]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Client item = new Client();
                        item._clientID = oReader["ClientID"].ToString();
                        item._clientName = oReader["ClientName"].ToString();
                        item._clientType = oReader["ClientType"].ToString();
                        item._clientDesc = oReader["ClientDesc"].ToString();
                        item._clientStill = oReader["ClientStill"].ToString();
                        item._clientPOCName = oReader["ClientPOCName"].ToString();
                        item._clientPOCEmail = oReader["ClientPOCEmail"].ToString();
                        item._clientPOCPhone = oReader["ClientPOCContact"].ToString();
                        _clientList.Add(item);
                    }

                    myConnection.Close();
                }
            }
            return _clientList;
        }

        //Getting Client List End

        //Setting A Client 

        public int setAClient(int ClientID, string ClientName, string ClientType, string ClientDesc, bool ClientStill, string POCName, string POCEmail, string POCPhone)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spUpdateClient]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@ClientID", ClientID);
                oCmd.Parameters.AddWithValue("@ClientName", ClientName);
                oCmd.Parameters.AddWithValue("@ClientType", ClientType);
                oCmd.Parameters.AddWithValue("@ClientDesc", ClientDesc);
                oCmd.Parameters.AddWithValue("@ClientStill", ClientStill);
                oCmd.Parameters.AddWithValue("@POCName", POCName);
                oCmd.Parameters.AddWithValue("@POCEmail", POCEmail);
                oCmd.Parameters.AddWithValue("@POCContact", POCPhone);
                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        //Setting A Client End

        public int deleteAClient(int ClientID)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spDeleteClient]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@ClientID", ClientID);
                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        //Delete A Client End

        // GET User Role

        public List<UserRole> getUserRole()
        {
            List<UserRole> _userRoleList = new List<UserRole>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spGetUserRole]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        UserRole item = new UserRole();
                        item.Role_ID = Convert.ToInt32(oReader["ROLE_ID"]);
                        item.Role_Title= oReader["ROLE_TITLE"].ToString();
                        item.Role_Desc = oReader["ROLE_DESC"].ToString();
                        _userRoleList.Add(item);
                    }

                    myConnection.Close();
                }
            }
            return _userRoleList;
        }

        // GET User Role End

        // ADD User Role

        public int insertUserRole(string Role_Title, string Role_Desc)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spInsertUserRole]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@ROLE_TITLE", Role_Title);
                oCmd.Parameters.AddWithValue("@ROLE_DESC", Role_Desc);
                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        // ADD User Role End

        // SET User Role

        public int setUserRole(int Role_ID, string Role_Title, string Role_Desc) {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spUpdateUserRole]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@Role_ID", Role_ID);
                oCmd.Parameters.AddWithValue("@Role_Title", Role_Title);
                oCmd.Parameters.AddWithValue("@Role_Desc", Role_Desc);
                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        // SET User Role End

        // Delete A User Role

        public int deleteUserRole(int UserRoleID) {
            int result = 0;
            SqlConnection myConnection;
            try
            {
                using (myConnection = new SqlConnection(con))
                {
                    string oString = "[dbo].[spDeleteUserRole]";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.Parameters.AddWithValue("@UserRoleID", UserRoleID);
                    oCmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    result = oCmd.ExecuteNonQuery();
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error occured in Method: \'deleteUserRole\'\t Class: \'DatabaseConnectivity\' while deleting a user role, Error Code: \'" + ex.Message + "\' ");
                result = -1;
            }
            finally
            {

            }

            return result;
        }

        // Delete A User Role End

        // Add Environment Type

        public int insertEnvironmentType(string EnvTitle, string EnvDesc) {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spInsertEnvironmentType]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@EnvTitle", EnvTitle);
                oCmd.Parameters.AddWithValue("@EnvDesc", EnvDesc);
                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        // Add Environment Type End

        //Update An Environment Type 

        public int setEnvType(int ClientID, string ClientName, string ClientDesc)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spUpdateEnvType]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@EnvTypeID", ClientID);
                oCmd.Parameters.AddWithValue("@EnvTypeTitle", ClientName);
                oCmd.Parameters.AddWithValue("@EnvTypeDesc", ClientDesc);
                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        //Update An Environment Type End

        //Getting Environment Type List

        public List<EnvironmentType> getEnvTypeList()
        {
            List<EnvironmentType> _envList = new List<EnvironmentType>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spGetEnvTypeList]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        EnvironmentType item = new EnvironmentType();
                        item.Environment_ID = oReader["EnvID"].ToString();
                        item.Environment_Title = oReader["EnvTitle"].ToString();
                        item.Environment_Desc = oReader["EnvDesc"].ToString();
                        _envList.Add(item);
                    }

                    myConnection.Close();
                }
            }
            return _envList;
        }

        //Getting Environment Type List End

        //Delete Environment Type TxSnQcGMh0/s1nKD7vvrlQ==

        public int deleteEnvironmentType(int EnvTypeID) {
            int result = 0;
            SqlConnection myConnection;
            try
            {
                using (myConnection = new SqlConnection(con))
                {
                    string oString = "[dbo].[spDeleteEnvironmentType]";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.Parameters.AddWithValue("@EnvTypeID", EnvTypeID);
                    oCmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    result = oCmd.ExecuteNonQuery();
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error occured in Method: \'deleteEnvironmentType\'\t Class: \'DatabaseConnectivity\' while deleting an environment type. Error Code: \'" + ex.Message + "\' ");
                result = -1;
            }
            finally {

            }

            return result;
        }

        //Delete Environment Type End

        // Add Product

        public int insertProduct(string productName, string productDesc, string productVersion, string productType, string productCategory, string productRating, string productDemoUserID, string productDemoPassword, string productPOC, string productSupportEmail, string productComments) {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spInsertProduct]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@ProductName", productName);
                oCmd.Parameters.AddWithValue("@ProductDesc", productDesc);
                oCmd.Parameters.AddWithValue("@ProductVersion", productVersion);
                oCmd.Parameters.AddWithValue("@ProductType", productType);
                oCmd.Parameters.AddWithValue("@ProductCategory", productCategory);
                oCmd.Parameters.AddWithValue("@ProductRating", productRating);
                oCmd.Parameters.AddWithValue("@ProductUserID", productDemoUserID);
                oCmd.Parameters.AddWithValue("@ProductPassword", productDemoPassword);
                oCmd.Parameters.AddWithValue("@ProductPOC", productPOC);
                oCmd.Parameters.AddWithValue("@ProductSupportEmail", productSupportEmail);
                oCmd.Parameters.AddWithValue("@ProductComments", productComments);
                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        // Add Product End

        //Getting Product List

        public List<Product> getProductList()
        {
            List<Product> _productList = new List<Product>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spGetProductList]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Product item = new Product();
                        item.ProductID = oReader["ProductID"].ToString();
                        item.ProductName = oReader["ProductName"].ToString();
                        item.ProductDesc = oReader["ProductDesc"].ToString();
                        item.ProductVersion = oReader["ProductVersion"].ToString();
                        item.ProductType = oReader["ProductType"].ToString();
                        item.ProductCategory = oReader["ProductCategory"].ToString();
                        item.ProductRating = oReader["ProductRating"].ToString();
                        item.ProductDemoUserId = oReader["ProductDemoUserId"].ToString();
                        item.ProductDemoPasscode = oReader["ProductDemoPasscode"].ToString();
                        item.ProductPOC = oReader["ProductPOC"].ToString();
                        item.ProductSupportEmail = oReader["ProductSupportEmail"].ToString();
                        item.ProductComments = oReader["ProductComments"].ToString();
                        _productList.Add(item);
                    }

                    myConnection.Close();
                }
            }
            return _productList;
        }

        //Getting Product List End


        //Delete Product 

        public int deleteProduct(int productID)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spDeleteProduct]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@ProductID", productID);
                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        //Delete Product End

        //Delete User

        public int deleteUser(int userID) {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spDeleteUser]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@UserID", userID);
                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        //Delete User End

        // Add User

        public int insertUser(string Username, string Userrole, string Passcode) {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spInsertUser]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@Username", Username);
                oCmd.Parameters.AddWithValue("@Role", Userrole);
                oCmd.Parameters.AddWithValue("@Passcode", Passcode);
                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        // Add User End

        public List<Patch> getAllUpdatedClientPatches(int ProductID, int EnvType)
        {
            List<Patch> matchingPatch = new List<Patch>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[GetUpdatedPatchListClientWise]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@ProductID", ProductID);
                oCmd.Parameters.AddWithValue("@EnvType", EnvType);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Patch item = new Patch();
                        item.clientName = oReader["ClientName"].ToString();
                        item.clientType = oReader["ClientType"].ToString();
                        item.clientEnvType = oReader["EnvType"].ToString();
                        item.clientPOCName = oReader["POC"].ToString();
                        item.numberOfPatches = oReader["NumberOfPatches"].ToString();
                        item.patchHotNumber = oReader["PatchHotNumber"].ToString();
                        item.clientAppLink = oReader["Link"].ToString();
                        item.patchQATested = oReader["PatchQATested"].ToString();
                        item.patchDeployedBy = oReader["PatchDeployedBy"].ToString();
                        item.patchCreatedDate = oReader["PatchCreatedDate"].ToString();
                        item.patchDeployedDate = oReader["PatchDeployedDate"].ToString();
                        item.patchProductID = oReader["ProductID"].ToString();
                        item.patchNumberOfDaysPassed = oReader["NumberOfDaysPassed"].ToString();
                        item.patchStatus = oReader["PatchStatus"].ToString();
                        matchingPatch.Add(item);
                        //matchingPatch.clientName = oReader["ClientName"].ToString();
                        //matchingPatch.patchHotNumber = oReader["PatchHotNumber"].ToString();
                    }

                    myConnection.Close();
                }
            }
            return matchingPatch;
        }

        ///
        ///<param name="ClientName">String</param>
        ///<summary>Get Client ID Method</summary>
        ///<returns>Int</returns>
        ///
        public int getClientId(String clientName) {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(con)) {
                conn.Open();
                //string query = "SELECT [ClientID] FROM [ClientDetail] WHERE ClientName = '" +clientName+ "'";
                //SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.CommandType = CommandType.Text;
                //result = cmd.ExecuteNonQuery();
                //SqlDataAdapter da = new SqlDataAdapter(conn);
                //da.Fill(dt); 
                SqlCommand com = new SqlCommand("SELECT [ClientID] FROM [ClientDetail] WHERE ClientName = '" + clientName + "'");
                com.CommandType = CommandType.Text;
                com.Connection = conn;
                using (SqlDataAdapter da = new SqlDataAdapter(com))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    result = Convert.ToInt32(dt.Rows[0]["ClientID"]);
                }
                conn.Close();
            }
            return result;
        }

        ///
        ///<param name="ProductName">String</param>
        ///<summary>Get Product ID Method</summary>
        ///<returns>Int</returns>
        ///
        public int getProductId(String productName)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                //string query = "SELECT [ClientID] FROM [ClientDetail] WHERE ClientName = '" +clientName+ "'";
                //SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.CommandType = CommandType.Text;
                //result = cmd.ExecuteNonQuery();
                //SqlDataAdapter da = new SqlDataAdapter(conn);
                //da.Fill(dt); 
                SqlCommand com = new SqlCommand("SELECT [ProductID] FROM [Products] WHERE ProductName = '" + productName + "'");
                com.CommandType = CommandType.Text;
                com.Connection = conn;
                using (SqlDataAdapter da = new SqlDataAdapter(com))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    result = Convert.ToInt32(dt.Rows[0]["ProductID"]);
                }
                conn.Close();
            }
            return result;
        }

        // Set Product

        public int setAProduct(int ProductID, string ProductName, string ProductDesc, string ProductVersion, string ProductType, string ProductCategory, string ProductRating, string ProductUserID, string ProductPassword, string ProductPOC, string ProductEmail, string ProductComment)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spUpdateProduct]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@ProductID", ProductID);
                oCmd.Parameters.AddWithValue("@ProductName", ProductName);
                oCmd.Parameters.AddWithValue("@ProductDesc", ProductDesc);
                oCmd.Parameters.AddWithValue("@ProductVersion", ProductVersion);
                oCmd.Parameters.AddWithValue("@ProductType", ProductType);
                oCmd.Parameters.AddWithValue("@ProductCategory", ProductCategory);
                oCmd.Parameters.AddWithValue("@ProductRating", ProductRating);
                oCmd.Parameters.AddWithValue("@ProductUserID", ProductUserID);
                oCmd.Parameters.AddWithValue("@ProductPassword", ProductPassword);
                oCmd.Parameters.AddWithValue("@ProductPOC", ProductPOC);
                oCmd.Parameters.AddWithValue("@ProductEmail", ProductEmail);
                oCmd.Parameters.AddWithValue("@ProductComment", ProductComment);
                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        // Set Product End

        ///
        ///<param name="ClientName">String</param>
        ///<summary>Update Patch Method</summary>
        ///<returns>Bool</returns>
        ///

        public int updateClientPatches(String clientName, String productName)
        {
            int result = 0;
            string latestPatchNumber = String.Empty;
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                SqlCommand com = new SqlCommand("SELECT MAX([PatchHotNumber]) As [PatchHotNumber] FROM [PATCH] WHERE ClientID = '" + getClientId(clientName) + "'");
                com.CommandType = CommandType.Text;
                com.Connection = conn;
                using (SqlDataAdapter da = new SqlDataAdapter(com))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    latestPatchNumber = dt.Rows[0]["PatchHotNumber"].ToString();
                }
                conn.Close();
            }
            int StartIndex = latestPatchNumber.LastIndexOf('_');
            string data = latestPatchNumber.Substring(StartIndex+1);
            Debug.WriteLine(data);
            int patchNumber = Convert.ToInt32(data) + 1;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                //string oString = "UPDATE PatchDetail SET [PatchHotNumber] = '" + "Patch_Hot_Number_" + patchNumber + "', [PatchDeployedDate] = getdate() where ClientID = " + getClientId(clientName);
                //string oString = String.Format("EXECUTE AddPatchDetail @PatchTitle = {0}, @PatchDesc = {1}, @PatchHotNumber = {2}, @PatchDeployedBy = {3}, @PatchCreatedDate = {4}, @PatchDeployedDate = {5}, @IsQAPassed = {6}, @Remarks_Dependencies = {7}, @ClientID = {8}, @ProductID = {9}", "Demo Title Auto Generator", "Demo Desc Auto Generator", patchNumber, "MSA", DateTime.Now, DateTime.Now, 1, "Auto Updater Remarks / Dependencies", getClientId(clientName),1);
                string oString = String.Format("[dbo].[AddPatchDetail]");
                SqlDataAdapter adp = new SqlDataAdapter();
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@PatchTitle", "Demo Title Auto Generator");
                oCmd.Parameters.AddWithValue("@PatchDesc", "Demo Desc Auto Generator");
                oCmd.Parameters.AddWithValue("@PatchHotNumber", patchNumber);
                oCmd.Parameters.AddWithValue("@PatchDeployedBy", "MSA");
                oCmd.Parameters.AddWithValue("@PatchCreatedDate", DateTime.Now);
                oCmd.Parameters.AddWithValue("@PatchDeployedDate", DateTime.Now);
                oCmd.Parameters.AddWithValue("@IsQAPassed", 1);
                oCmd.Parameters.AddWithValue("@Remarks_Dependencies", "Auto Updater Remarks / Dependencies");
                oCmd.Parameters.AddWithValue("@ClientID", getClientId(clientName));
                oCmd.Parameters.AddWithValue("@ProductID", getProductId(productName));
                oCmd.Parameters.AddWithValue("@EnvID", 2);
                myConnection.Open();
                //adp.UpdateCommand = new SqlCommand(oString, myConnection);
                //result = adp.UpdateCommand.ExecuteNonQuery();
                result = oCmd.ExecuteNonQuery();
                oCmd.Dispose();
                myConnection.Close();
            }
            return result;
        }

        ///
        ///<param name="ClientName">String</param>
        ///<summary>Update Patch Method</summary>
        ///<returns>Bool</returns>
        ///

        public int updateClientPatches2(int clientID, int productID,int EnvType)
        {
            int result = 0;
            string latestPatchNumber = String.Empty;
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                SqlCommand com = new SqlCommand("SELECT MAX([PAT_HotNumber]) As [PatchHotNumber] FROM [PATCH] WHERE PAT_ClientID = " + clientID + " AND PAT_ProductID = " + productID + " AND PAT_EnvType = (SELECT ENV_ID FROM Environment WHERE ENV_AppServerEnvironmentType = " + EnvType + " AND ENV_Client_ID = " + clientID + " AND ENV_Product_ID = " + productID + ")");
                com.CommandType = CommandType.Text;
                com.Connection = conn;
                using (SqlDataAdapter da = new SqlDataAdapter(com))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    latestPatchNumber = dt.Rows[0]["PatchHotNumber"].ToString();
                }
                conn.Close();
            }
            //int StartIndex = latestPatchNumber.LastIndexOf('_');
            //string data = latestPatchNumber.Substring(StartIndex + 1);
            //Debug.WriteLine(data);
            //int patchNumber = Convert.ToInt32(data) + 1;
            Debug.WriteLine("\n Latest Patch Number: " + latestPatchNumber);
            int patchNumber = 0;
            if (latestPatchNumber != "")
            {
                patchNumber = Convert.ToInt32(latestPatchNumber) + 1;
            }
            else { }
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                //string oString = "UPDATE PatchDetail SET [PatchHotNumber] = '" + "Patch_Hot_Number_" + patchNumber + "', [PatchDeployedDate] = getdate() where ClientID = " + getClientId(clientName);
                //string oString = String.Format("EXECUTE AddPatchDetail @PatchTitle = {0}, @PatchDesc = {1}, @PatchHotNumber = {2}, @PatchDeployedBy = {3}, @PatchCreatedDate = {4}, @PatchDeployedDate = {5}, @IsQAPassed = {6}, @Remarks_Dependencies = {7}, @ClientID = {8}, @ProductID = {9}", "Demo Title Auto Generator", "Demo Desc Auto Generator", patchNumber, "MSA", DateTime.Now, DateTime.Now, 1, "Auto Updater Remarks / Dependencies", getClientId(clientName),1);
                string oString = String.Format("[dbo].[AddPatchDetail]");
                SqlDataAdapter adp = new SqlDataAdapter();
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@PatchTitle", "Demo Title Auto Generator");
                oCmd.Parameters.AddWithValue("@PatchDesc", "Demo Desc Auto Generator");
                oCmd.Parameters.AddWithValue("@PatchHotNumber", patchNumber);
                oCmd.Parameters.AddWithValue("@PatchDeployedBy", "MSA");
                oCmd.Parameters.AddWithValue("@PatchCreatedDate", DateTime.Now);
                oCmd.Parameters.AddWithValue("@PatchDeployedDate", DateTime.Now);
                oCmd.Parameters.AddWithValue("@IsQAPassed", 1);
                oCmd.Parameters.AddWithValue("@Remarks_Dependencies", "Auto Updater Remarks / Dependencies");
                oCmd.Parameters.AddWithValue("@ClientID", clientID);
                oCmd.Parameters.AddWithValue("@ProductID", productID);
                oCmd.Parameters.AddWithValue("@EnvType", EnvType);
                myConnection.Open();
                //adp.UpdateCommand = new SqlCommand(oString, myConnection);
                //result = adp.UpdateCommand.ExecuteNonQuery();
                try
                {
                    result = oCmd.ExecuteNonQuery();
                }
                catch (Exception ex) {
                    Debug.WriteLine("\nException Occured With Details: " + ex.Message);
                }
                oCmd.Dispose();
                myConnection.Close();
            }
            return result;
        }

        //Update A Patch Manual

        public int updatePatcheManually(string title, string desc, string patchNumber1, string deployedBy, string createdDate, string deployedDate, string status, int clientID, int productID, int EnvType)
        {
            int result = 0;
            string latestPatchNumber = String.Empty;
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                SqlCommand com = new SqlCommand("SELECT MAX([PAT_HotNumber]) As [PatchHotNumber] FROM [PATCH] WHERE PAT_ClientID = " + clientID + " AND PAT_ProductID = " + productID + " AND PAT_EnvType = (SELECT ENV_ID FROM Environment WHERE ENV_AppServerEnvironmentType = " + EnvType + " AND ENV_Client_ID = " + clientID + " AND ENV_Product_ID = " + productID + ")");
                com.CommandType = CommandType.Text;
                com.Connection = conn;
                using (SqlDataAdapter da = new SqlDataAdapter(com))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    latestPatchNumber = dt.Rows[0]["PatchHotNumber"].ToString();
                }
                conn.Close();
            }
            //int StartIndex = latestPatchNumber.LastIndexOf('_');
            //string data = latestPatchNumber.Substring(StartIndex + 1);
            //Debug.WriteLine(data);
            //int patchNumber = Convert.ToInt32(data) + 1;
            Debug.WriteLine("\n Latest Patch Number: " + latestPatchNumber);
            int patchNumber = 0;
            if (latestPatchNumber != "")
            {
                patchNumber = Convert.ToInt32(latestPatchNumber) + 1;
            }
            else { }
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                //string oString = "UPDATE PatchDetail SET [PatchHotNumber] = '" + "Patch_Hot_Number_" + patchNumber + "', [PatchDeployedDate] = getdate() where ClientID = " + getClientId(clientName);
                //string oString = String.Format("EXECUTE AddPatchDetail @PatchTitle = {0}, @PatchDesc = {1}, @PatchHotNumber = {2}, @PatchDeployedBy = {3}, @PatchCreatedDate = {4}, @PatchDeployedDate = {5}, @IsQAPassed = {6}, @Remarks_Dependencies = {7}, @ClientID = {8}, @ProductID = {9}", "Demo Title Auto Generator", "Demo Desc Auto Generator", patchNumber, "MSA", DateTime.Now, DateTime.Now, 1, "Auto Updater Remarks / Dependencies", getClientId(clientName),1);
                string oString = String.Format("[dbo].[AddPatchDetail]");
                SqlDataAdapter adp = new SqlDataAdapter();
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@PatchTitle", title);
                oCmd.Parameters.AddWithValue("@PatchDesc", desc);
                oCmd.Parameters.AddWithValue("@PatchHotNumber", patchNumber1);
                oCmd.Parameters.AddWithValue("@PatchDeployedBy", deployedBy);
                oCmd.Parameters.AddWithValue("@PatchCreatedDate", createdDate);
                oCmd.Parameters.AddWithValue("@PatchDeployedDate", deployedDate);
                oCmd.Parameters.AddWithValue("@IsQAPassed", 1);
                oCmd.Parameters.AddWithValue("@Remarks_Dependencies", status);
                oCmd.Parameters.AddWithValue("@ClientID", clientID);
                oCmd.Parameters.AddWithValue("@ProductID", productID);
                oCmd.Parameters.AddWithValue("@EnvType", EnvType);
                myConnection.Open();
                //adp.UpdateCommand = new SqlCommand(oString, myConnection);
                //result = adp.UpdateCommand.ExecuteNonQuery();
                try
                {
                    result = oCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("\nException Occured With Details: " + ex.Message);
                }
                oCmd.Dispose();
                myConnection.Close();
            }
            return result;
        }

        //Update A Patch Manual End

        // Delete A Patch

        public int deleteARelease(string title, string patchNumber1, string createdDate, string deployedDate, string clientID, string environment, string product) {
            int result = 0;
            string latestPatchNumber = String.Empty;
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                SqlCommand com = new SqlCommand("SELECT MAX([PAT_HotNumber]) As [PatchHotNumber] FROM [PATCH] WHERE PAT_ClientID = " + clientID + " AND PAT_ProductID = " + product + " AND PAT_EnvType = (SELECT ENV_ID FROM Environment WHERE ENV_AppServerEnvironmentType = " + environment + " AND ENV_Client_ID = " + clientID + " AND ENV_Product_ID = " + product + ")");
                com.CommandType = CommandType.Text;
                com.Connection = conn;
                using (SqlDataAdapter da = new SqlDataAdapter(com))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    latestPatchNumber = dt.Rows[0]["PatchHotNumber"].ToString();
                }
                conn.Close();
            }
            //int StartIndex = latestPatchNumber.LastIndexOf('_');
            //string data = latestPatchNumber.Substring(StartIndex + 1);
            //Debug.WriteLine(data);
            //int patchNumber = Convert.ToInt32(data) + 1;
            Debug.WriteLine("\n Latest Patch Number: " + latestPatchNumber);
            //int patchNumber = 0;
            //if (latestPatchNumber != "")
            //{
            //    patchNumber = Convert.ToInt32(latestPatchNumber) + 1;
            //}
            //else { }
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                //string oString = "UPDATE PatchDetail SET [PatchHotNumber] = '" + "Patch_Hot_Number_" + patchNumber + "', [PatchDeployedDate] = getdate() where ClientID = " + getClientId(clientName);
                //string oString = String.Format("EXECUTE AddPatchDetail @PatchTitle = {0}, @PatchDesc = {1}, @PatchHotNumber = {2}, @PatchDeployedBy = {3}, @PatchCreatedDate = {4}, @PatchDeployedDate = {5}, @IsQAPassed = {6}, @Remarks_Dependencies = {7}, @ClientID = {8}, @ProductID = {9}", "Demo Title Auto Generator", "Demo Desc Auto Generator", patchNumber, "MSA", DateTime.Now, DateTime.Now, 1, "Auto Updater Remarks / Dependencies", getClientId(clientName),1);
                string oString = String.Format("[dbo].[spDeleteRelease]");
                SqlDataAdapter adp = new SqlDataAdapter();
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@PatchTitle", title);
                oCmd.Parameters.AddWithValue("@PatchHotNumber", patchNumber1);
                oCmd.Parameters.AddWithValue("@PatchCreatedDate", createdDate);
                oCmd.Parameters.AddWithValue("@PatchDeployedDate", deployedDate);
                oCmd.Parameters.AddWithValue("@ClientID", clientID);
                oCmd.Parameters.AddWithValue("@ProductID", product);
                oCmd.Parameters.AddWithValue("@EnvType", environment);
                myConnection.Open();
                //adp.UpdateCommand = new SqlCommand(oString, myConnection);
                //result = adp.UpdateCommand.ExecuteNonQuery();
                try
                {
                    result = oCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("\nException Occured With Details: " + ex.Message);
                }
                oCmd.Dispose();
                myConnection.Close();
            }
            return result;
        }

        // Delete A Patch End

        // User Auth Start
        public List<User> getAuthUsers()
        {
            List<User> matchingUser = new List<User>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "Select * from [UsersAuth]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                //oCmd.Parameters.AddWithValue("@Fname", fName);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        User item = new User();
                        item.UserID = oReader["UserID"].ToString();
                        item.Password = oReader["Passcode"].ToString();
                        matchingUser.Add(item);
                        //matchingPatch.clientName = oReader["ClientName"].ToString();
                        //matchingPatch.patchHotNumber = oReader["PatchHotNumber"].ToString();
                    }

                    myConnection.Close();
                }
            }
            return matchingUser;
        }
        // User Auth End

        //Getting User List

        public List<User> getUserList()
        {
            List<User> _userList = new List<User>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spGetAllUser]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        User item = new User();
                        item.UserID = oReader["USER_ID"].ToString();
                        item.UserName = oReader["USER_NAME"].ToString();
                        item.UserRole = oReader["USER_ROLE"].ToString();
                        item.UserStatus = oReader["USER_STATUS"].ToString();
                        item.Password = oReader["USER_PASSCODE"].ToString();
                        item.UserLoginDate = oReader["USER_LOGINDATE"].ToString();
                        item.UserWrongAttempt = oReader["USER_WRONG_ATTEMPTS"].ToString();
                        _userList.Add(item);
                    }

                    myConnection.Close();
                }
            }
            return _userList;
        }

        //Getting User List End

        //Setting User

        public int setAUser(int userID, string userName, string userRole, string userStatus, string userLoginDate, string wrongAttempts) {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spUpdateUser]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@UserID", userID);
                oCmd.Parameters.AddWithValue("@Username", userName);
                oCmd.Parameters.AddWithValue("@UserRole", userRole);
                oCmd.Parameters.AddWithValue("@UserStatus", userStatus);
                oCmd.Parameters.AddWithValue("@UserLoginDate", userLoginDate);
                oCmd.Parameters.AddWithValue("@UserWrongAttempts", wrongAttempts);
                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        //Setting User End

        // Get All Environments

        public List<Environment> getAllEnvironments()
        {
            List<Environment> _envList = new List<Environment>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spGetAllEnvironment]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Environment item = new Environment();
                        item.EnvironmentID = oReader["ENV_ID"].ToString();
                        item.ClientName = oReader["ENV_Client_ID"].ToString();
                        item.ProductName = oReader["ENV_Product_ID"].ToString();
                        item.EnvironmentAppServerEnvType = oReader["ENV_AppServerEnvironmentType"].ToString();
                        item.EnvironmentDBServerEnvType = oReader["ENV_DBServerEnvironmentType"].ToString();
                        item.EnvironmentAppServerName = oReader["ENV_AppServerName"].ToString();
                        item.EnvironmentAppServerOS = oReader["ENV_AppServerOS"].ToString();
                        item.EnvironmentAppServerOSBuild = oReader["ENV_AppServerOSBuild"].ToString();
                        item.EnvironmentAppServerIsX86Version = oReader["ENV_AppServerIsX86Version"].ToString();
                        item.EnvironmentAppServerIsVirtual = oReader["ENV_AppServerIsVirtual"].ToString();
                        item.EnvironmentAppServerProcessor = oReader["ENV_AppServerProcessor"].ToString();
                        item.EnvironmentAppServerMemory = oReader["ENV_AppServerMemory"].ToString();
                        item.EnvironmentAppServerWebBrowser = oReader["ENV_AppServerWebBrowser"].ToString();
                        item.EnvironmentAppServerWebBrowserVersion = oReader["ENV_AppServerWebBrowserVersion"].ToString();

                        item.EnvironmentAppServerWorkingDirectoryLocation = oReader["ENV_AppServerWorkingDirectoryLocation"].ToString();
                        item.EnvironmentAppHyperLink = oReader["ENV_AppHyperLink"].ToString();
                        item.EnvironmentAppServerIP= oReader["ENV_AppServerIP"].ToString();
                        item.EnvironmentAppServerPort = oReader["ENV_AppServerPort"].ToString();
                        item.EnvironmentAppServerDependency = oReader["ENV_AppServerDependency"].ToString();
                        item.EnvironmentDBServerName = oReader["ENV_DBServerName"].ToString();
                        item.EnvironmentDBServerOS = oReader["ENV_DBServerOS"].ToString();
                        item.EnvironmentDBServerOSBuild = oReader["ENV_DBServerOSBuild"].ToString();
                        item.EnvironmentDBServerIsX86Version = oReader["ENV_DBServerIsX86Version"].ToString();
                        item.EnvironmentDBServerIsVirtual = oReader["ENV_DBServerIsVirtual"].ToString();
                        item.EnvironmentDBServerProcessor = oReader["ENV_DBServerProcessor"].ToString();
                        item.EnvironmentDBServerMemory = oReader["ENV_DBServerMemory"].ToString();
                        item.EnvironmentDBServerDirectoryLocation = oReader["ENV_DBServerDirectoryLocation"].ToString();
                        item.EnvironmentDBMDFFileLocation = oReader["ENV_DBMDFFileLocation"].ToString();
                        item.EnvironmentDBMDFFileSize= oReader["ENV_DBMDFFileSize"].ToString();
                        item.EnvironmentDBLDFFileLocation = oReader["ENV_DBLDFFileLocation"].ToString();
                        item.EnvironmentDBLDFFileSize = oReader["ENV_DBLDFFileSize"].ToString();
                        item.EnvironmentEnvDBServerIP = oReader["ENV_DBServerIP"].ToString();
                        item.EnvironmentDBServerPort = oReader["ENV_DBServerPort"].ToString();
                        item.EnvironmentDBServerDependency = oReader["ENV_DBServerDependency"].ToString();
                        _envList.Add(item);
                    }

                    myConnection.Close();
                }
            }
            return _envList;
        }

        // Get All Environments End

        //Set an Environment

        public int setAnEnvironment(int EnvID, int ClientName, int ProductName, int EnvironmentAppServerEnvType, int DBServerEnvType, string AppServerName, string AppServerOS, Int64 AppServerOSBuild, Boolean AppServerIsX86Version, Boolean AppServerIsVirtual, string AppServerProcessor, int AppServerMemory, string AppServerWebBrowser, int AppServerWebBrowserVersion, string AppServerWorkingDirectoryLocation, string AppHyperLink, string AppServerIP, int AppServerPort, string AppServerDependency, string DBServerName, Boolean DBServerIsX86Version, Boolean DBServerIsVirtual, int DBServerMemory, string DBServerProcessor, string DBServerOS, Int64 DBServerOSBuild, string DBServerDirectoryLocation, string DBMDFFileLocation, Int64 DBMDFFileSize, string DBLDFFileLocation, Int64 DBLDFFileSize, string DBServerIP, int DBServerPort, string DBServerDependency)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spUpdateEnvironment]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@EnvID", EnvID);
                oCmd.Parameters.AddWithValue("@ClientName", ClientName);
                oCmd.Parameters.AddWithValue("@ProductName", ProductName);
                oCmd.Parameters.AddWithValue("@AppServerEnvType", EnvironmentAppServerEnvType);
                oCmd.Parameters.AddWithValue("@DBServerEnvType", DBServerEnvType);
                oCmd.Parameters.AddWithValue("@AppServerName", AppServerName);
                oCmd.Parameters.AddWithValue("@AppServerOS", AppServerOS);
                oCmd.Parameters.AddWithValue("@AppServerOSBuild", AppServerOSBuild);
                oCmd.Parameters.AddWithValue("@AppServerIsX86Version", AppServerIsX86Version);
                oCmd.Parameters.AddWithValue("@AppServerIsVirtual", AppServerIsVirtual);
                oCmd.Parameters.AddWithValue("@AppServerProcessor", AppServerProcessor);
                oCmd.Parameters.AddWithValue("@AppServerMemory", AppServerMemory);
                oCmd.Parameters.AddWithValue("@AppServerWebBrowser", AppServerWebBrowser);
                oCmd.Parameters.AddWithValue("@AppServerWebBrowserVersion", AppServerWebBrowserVersion);
                oCmd.Parameters.AddWithValue("@AppServerWorkingDirectoryLocation", AppServerWorkingDirectoryLocation);
                oCmd.Parameters.AddWithValue("@AppHyperLink", AppHyperLink);
                oCmd.Parameters.AddWithValue("@AppServerIP", AppServerIP);
                oCmd.Parameters.AddWithValue("@AppServerPort", AppServerPort);
                oCmd.Parameters.AddWithValue("@AppServerDependency", AppServerDependency);
                oCmd.Parameters.AddWithValue("@DBServerName", DBServerName);
                oCmd.Parameters.AddWithValue("@DBServerOS", DBServerOS);
                oCmd.Parameters.AddWithValue("@DBerverOSBuild", DBServerOSBuild);
                oCmd.Parameters.AddWithValue("@DBServerIsX86Version", DBServerIsX86Version);
                oCmd.Parameters.AddWithValue("@DBServerIsVirtual", DBServerIsVirtual);
                oCmd.Parameters.AddWithValue("@DBServerProcessor", DBServerProcessor);
                oCmd.Parameters.AddWithValue("@DBServerMemory", DBServerMemory);
                oCmd.Parameters.AddWithValue("@DBServerWorkingDirectoryLocation", DBServerDirectoryLocation);
                oCmd.Parameters.AddWithValue("@DBMDFFileLocation", DBMDFFileLocation);
                oCmd.Parameters.AddWithValue("@DBMDFFileSize", DBMDFFileSize);
                oCmd.Parameters.AddWithValue("@DBLDFFileLocation", DBLDFFileLocation);
                oCmd.Parameters.AddWithValue("@DBLDFFileSize", DBLDFFileSize);
                oCmd.Parameters.AddWithValue("@DBServerIP", DBServerIP);
                oCmd.Parameters.AddWithValue("@DBServerPort", DBServerPort);
                oCmd.Parameters.AddWithValue("@DBServerDependency", DBServerDependency);

                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        //Set an Environment End

        // Environment Settings Start

        public List<Environment> getClientEnvironmentInfo(int ProductID, int EnvType, int ClientID)
        {
            List<Environment> matchingPatch = new List<Environment>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spGetClientEnvironmentByProduct]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@ProductID", ProductID);
                oCmd.Parameters.AddWithValue("@EnvType", EnvType);
                oCmd.Parameters.AddWithValue("@ClientID", ClientID);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Environment item = new Environment();
                        item.ClientName = oReader["ClientName"].ToString();
                        item.ProductName = oReader["ENV_Product_ID"].ToString();
                        item.EnvironmentAppServerEnvType = oReader["ENV_AppServerEnvironmentType"].ToString();
                        item.EnvironmentAppServerIsX86Version = oReader["ENV_AppServerIsX86Version"].ToString();
                        item.EnvironmentAppServerIsVirtual = oReader["ENV_AppServerIsVirtual"].ToString();
                        item.EnvironmentAppServerMemory = oReader["ENV_AppServerMemory"].ToString();
                        item.EnvironmentAppServerProcessor = oReader["ENV_AppServerProcessor"].ToString();
                        item.EnvironmentAppServerOSBuild = oReader["ENV_AppServerOSBuild"].ToString();
                        item.EnvironmentAppServerOS = oReader["ENV_AppServerOS"].ToString();
                        item.EnvironmentAppServerWebBrowser = oReader["ENV_AppServerWebBrowser"].ToString();
                        item.EnvironmentAppServerWebBrowserVersion = oReader["ENV_AppServerWebBrowserVersion"].ToString();
                        item.EnvironmentAppServerIsX86Version = oReader["ENV_AppServerIsX86Version"].ToString();
                        item.EnvironmentAppServerWorkingDirectoryLocation = oReader["ENV_AppServerWorkingDirectoryLocation"].ToString();
                        item.EnvironmentAppServerIP = oReader["ENV_AppServerIP"].ToString();
                        item.EnvironmentAppServerPort = oReader["ENV_AppServerPort"].ToString();
                        item.EnvironmentEnvDBServerIP = oReader["ENV_DBServerIP"].ToString();
                        item.EnvironmentDBServerPort = oReader["ENV_DBServerPort"].ToString();
                        item.EnvironmentAppServerName = oReader["ENV_AppServerName"].ToString();
                        item.EnvironmentDBServerName = oReader["ENV_DBServerName"].ToString();
                        item.EnvironmentAppServerDependency = oReader["ENV_AppServerDependency"].ToString();
                        item.EnvironmentDBServerEnvType = oReader["ENV_DBServerEnvironmentType"].ToString();
                        item.EnvironmentDBServerIsX86Version = oReader["ENV_DBServerIsX86Version"].ToString();
                        item.EnvironmentDBServerIsVirtual = oReader["ENV_DBServerIsVirtual"].ToString();
                        item.EnvironmentDBServerMemory = oReader["ENV_DBServerMemory"].ToString();
                        item.EnvironmentDBServerProcessor = oReader["ENV_DBServerProcessor"].ToString();
                        item.EnvironmentDBServerOSBuild = oReader["ENV_DBServerOSBuild"].ToString();
                        item.EnvironmentDBServerOS = oReader["ENV_DBServerOS"].ToString();
                        item.EnvironmentDBServerDirectoryLocation = oReader["ENV_DBServerDirectoryLocation"].ToString();
                        item.EnvironmentDBMDFFileLocation = oReader["ENV_DBMDFFileLocation"].ToString();
                        item.EnvironmentDBMDFFileSize = oReader["ENV_DBMDFFileSize"].ToString();
                        item.EnvironmentDBLDFFileLocation = oReader["ENV_DBLDFFileLocation"].ToString();
                        item.EnvironmentDBLDFFileSize = oReader["ENV_DBLDFFileSize"].ToString();
                        item.EnvironmentDBServerDependency = oReader["ENV_DBServerDependency"].ToString();
                        matchingPatch.Add(item);
                        //matchingPatch.clientName = oReader["ClientName"].ToString();
                        //matchingPatch.patchHotNumber = oReader["PatchHotNumber"].ToString();
                    }

                    myConnection.Close();
                }
            }
            return matchingPatch;
        }

        //Environment Settings End

        // Inserting Data into Client Table

        public int insertClient(string ClientName, string ClientType, string ClientDescription, string POCName, string POCEmail, string POCPhone) {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spInsertClient]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@ClientName", ClientName);
                oCmd.Parameters.AddWithValue("@ClientType", ClientType);
                oCmd.Parameters.AddWithValue("@ClientDesc", ClientDescription);
                oCmd.Parameters.AddWithValue("@POCName", POCName);
                oCmd.Parameters.AddWithValue("@POCEmail", POCEmail);
                oCmd.Parameters.AddWithValue("@POCPhone", POCPhone);
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        // End Inserting Data into Client Table


        // Inserting Data into Patch Table

        public int insertPatch(string PatchTitle, string PatchDesc, string PatchHotNumber, string PatchDeployedBy, DateTime PatchCreatedDate, DateTime PatchDeployedDate, int IsQAPassed, string Dependency, int ClientID, int ProductID, int EnvironmentType)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spInsertPatch]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@PatchTitle", PatchTitle);
                oCmd.Parameters.AddWithValue("@PatchDesc", PatchDesc);
                oCmd.Parameters.AddWithValue("@PatchHotNumber", PatchHotNumber);
                oCmd.Parameters.AddWithValue("@PatchDeployedBy", PatchDeployedBy);
                oCmd.Parameters.AddWithValue("@PatchCreatedDate", PatchCreatedDate);
                oCmd.Parameters.AddWithValue("@PatchDeployedDate", PatchDeployedDate);
                oCmd.Parameters.AddWithValue("@IsQAPassed", IsQAPassed);
                oCmd.Parameters.AddWithValue("@Dependency", Dependency);
                oCmd.Parameters.AddWithValue("@ClientID", ClientID);
                oCmd.Parameters.AddWithValue("@ProductID", ProductID);
                oCmd.Parameters.AddWithValue("@EnvironmentType", EnvironmentType);
                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        // End Inserting Data into Patch Table

        // Inserting Data into Environment Table

        public int insertEnvironment(int ClientID, int ProductID, int AppEnvType, int DBEnvType, string AppServerName, string AppServerOS, double AppServerOSBuild, int AppServerIsX86Version, int AppServerIsVirtual, string AppServerProcessor, double AppServerMemory, string AppServerWebBrowser, string AppServerWebBrowserVersion, string AppServerWorkingDirectoryLocation, string AppHyperLink, string AppServerIP, double AppServerPort, string AppServerDependency, string DBServerName, string DBServerOS, double DBerverOSBuild, int DBServerIsX86Version, int DBServerIsVirtual, string DBServerProcessor, double DBServerMemory, string DBServerWorkingDirectoryLocation, string DBMDFFileLocation, double DBMDFFileSize, string DBLDFFileLocation, double DBLDFFileSize, string DBServerIP, double DBServerPort, string DBServerDependency)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spInsertEnvironment]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@ClientID", ClientID);
                oCmd.Parameters.AddWithValue("@ProductID", ProductID);
                oCmd.Parameters.AddWithValue("@AppServerEnvType", AppEnvType);
                oCmd.Parameters.AddWithValue("@DBServerEnvType", DBEnvType);
                oCmd.Parameters.AddWithValue("@AppServerName", AppServerName);
                oCmd.Parameters.AddWithValue("@AppServerOS", AppServerOS);
                oCmd.Parameters.AddWithValue("@AppServerOSBuild", AppServerOSBuild);
                oCmd.Parameters.AddWithValue("@AppServerIsX86Version", AppServerIsX86Version);
                oCmd.Parameters.AddWithValue("@AppServerIsVirtual", AppServerIsVirtual);
                oCmd.Parameters.AddWithValue("@AppServerProcessor", AppServerProcessor);
                oCmd.Parameters.AddWithValue("@AppServerMemory", AppServerMemory);
                oCmd.Parameters.AddWithValue("@AppServerWebBrowser", AppServerWebBrowser);
                oCmd.Parameters.AddWithValue("@AppServerWebBrowserVersion", AppServerWebBrowserVersion);
                oCmd.Parameters.AddWithValue("@AppServerWorkingDirectoryLocation", AppServerWorkingDirectoryLocation);
                oCmd.Parameters.AddWithValue("@AppHyperLink", AppHyperLink);
                oCmd.Parameters.AddWithValue("@AppServerIP", AppServerIP);
                oCmd.Parameters.AddWithValue("@AppServerPort", AppServerPort);
                oCmd.Parameters.AddWithValue("@AppServerDependency", AppServerDependency);
                oCmd.Parameters.AddWithValue("@DBServerName", DBServerName);
                oCmd.Parameters.AddWithValue("@DBServerOS", DBServerOS);
                oCmd.Parameters.AddWithValue("@DBerverOSBuild", DBerverOSBuild);
                oCmd.Parameters.AddWithValue("@DBServerIsX86Version", DBServerIsX86Version);
                oCmd.Parameters.AddWithValue("@DBServerIsVirtual", DBServerIsVirtual);
                oCmd.Parameters.AddWithValue("@DBServerProcessor", DBServerProcessor);
                oCmd.Parameters.AddWithValue("@DBServerMemory", DBServerMemory);
                oCmd.Parameters.AddWithValue("@DBServerWorkingDirectoryLocation", DBServerWorkingDirectoryLocation);
                oCmd.Parameters.AddWithValue("@DBMDFFileLocation", DBMDFFileLocation);
                oCmd.Parameters.AddWithValue("@DBMDFFileSize", DBMDFFileSize);
                oCmd.Parameters.AddWithValue("@DBLDFFileLocation", DBLDFFileLocation);
                oCmd.Parameters.AddWithValue("@DBLDFFileSize", DBLDFFileSize);
                oCmd.Parameters.AddWithValue("@DBServerIP", DBServerIP);
                oCmd.Parameters.AddWithValue("@DBServerPort", DBServerPort);
                oCmd.Parameters.AddWithValue("@DBServerDependency", DBServerDependency);

                myConnection.Open();
                result = oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
            return result;
        }

        // End Inserting Data into Environment Table

    }
}