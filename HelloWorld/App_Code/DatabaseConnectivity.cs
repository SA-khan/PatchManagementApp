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

        public List<Patch> getAllUpdatedClientPatches(int ProductID, int EnvType)
        {
            List<Patch> matchingPatch = new List<Patch>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "[dbo].[spGetUpdatedPatchListClientWise]";
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
                SqlCommand com = new SqlCommand("SELECT MAX([PatchHotNumber]) As [PatchHotNumber] FROM [PatchDetail] WHERE ClientID = '" + getClientId(clientName) + "'");
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
        // User Auth Start
        public List<User> getAuthUsers()
        {
            List<User> matchingUser = new List<User>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "Select * from [SHMAPortal].[dbo].[UsersAuth]";
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
    }
}