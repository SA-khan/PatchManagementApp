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

        // Environment Settings Start

        public List<ClientEnvironment> getClientEnvironmentInfo(int ProductID)
        {
            List<ClientEnvironment> matchingPatch = new List<ClientEnvironment>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spGetClientEnvironmentByProduct]";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.AddWithValue("@ProductID", ProductID);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        ClientEnvironment item = new ClientEnvironment();
                        item.ClientName = oReader["ClientName"].ToString();
                        item.EnvironmentTitle= oReader["EnvTitle"].ToString();
                        item.EnvironmentAppServerEnvType = oReader["EnvAppServerEnvironmentType"].ToString();
                        item.EnvironmentAppServerIsX86Version = oReader["EnvAppServerIsX86Version"].ToString();
                        item.EnvironmentAppServerIsVirtual = oReader["EnvAppServerIsVirtual"].ToString();
                        item.EnvironmentAppServerMemory = oReader["EnvAppServerMemory"].ToString();
                        item.EnvironmentAppServerProcessor = oReader["EnvAppServerProcessor"].ToString();
                        item.EnvironmentAppServerOSBuild = oReader["EnvAppServerOSBuild"].ToString();
                        item.EnvironmentAppServerOS = oReader["EnvAppServerOS"].ToString();
                        item.EnvironmentAppServerWebBrowser = oReader["EnvAppServerWebBrowser"].ToString();
                        item.EnvironmentAppServerWebBrowserVersion = oReader["EnvAppServerWebBrowserVersion"].ToString();
                        item.EnvironmentAppServerWorkingDirectoryLocation = oReader["EnvAppServerWorkingDirectoryLocation"].ToString();
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