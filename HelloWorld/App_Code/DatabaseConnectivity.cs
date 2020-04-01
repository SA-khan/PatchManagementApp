using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using HelloWorld.App_Code;

namespace HelloWorld.App_Code
{
    public class DatabaseConnectivity
    {
        String con = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

        //Setting Log Object
        Log log = new Log();

        //Getting Client in String List

        public string[] getClientListString()
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getClientListString", STATE.INITIALIZED, "Method: getClientListString in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "getClientListString", STATE.COMPLETED, "Method: getClientListString in Class: DatabaseConnectivity has completed its execution Successfully.");
                return res;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getClientListString", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getClientListString", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getClientListString", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getClientListString", STATE.INTERRUPTED, ex.Message);
                return null;
            }
        }

        //Getting Client List in String End

        //Getting Client in Int List

        public int[] getClientListInt()
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getClientListInt", STATE.INITIALIZED, "Method: getClientListInt in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "getClientListInt", STATE.COMPLETED, "Method: getClientListInt in Class: DatabaseConnectivity has completed its execution Successfully.");
                return res;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getClientListInt", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getClientListInt", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getClientListInt", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getClientListInt", STATE.INTERRUPTED, ex.Message);
                return null;
            }
        }

        //Getting Client List in Int End

        //Getting Client List

        public List<Client> getClientList()
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getClientList", STATE.INITIALIZED, "Method: getClientList in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "getClientList", STATE.COMPLETED, "Method: getClientList in Class: DatabaseConnectivity has completed its execution Successfully.");
                return _clientList;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getClientList", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getClientList", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getClientList", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getClientList", STATE.INTERRUPTED, ex.Message);
                return null;
            }
        }

        //Getting Client List End

        //Setting A Client 

        public int setAClient(int ClientID, string ClientName, string ClientType, string ClientDesc, bool ClientStill, string POCName, string POCEmail, string POCPhone)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "setAClient", STATE.INITIALIZED, "Method: setAClient in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "setAClient", STATE.COMPLETED, "Method: setAClient in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setAClient", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setAClient", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setAClient", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setAClient", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        //Setting A Client End

        public int deleteAClient(int ClientID)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "deleteAClient", STATE.INITIALIZED, "Method: deleteAClient in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "deleteAClient", STATE.COMPLETED, "Method: getClientType in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteAClient", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteAClient", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteAClient", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteAClient", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        //Delete A Client End

        // GET Client Type

        public List<ClientType> getClientType()
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getClientType", STATE.INITIALIZED, "Method: getClientType in Class: DatabaseConnectivity has Initialized.");
                List<ClientType> _clientTypeList = new List<ClientType>();
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string oString = "[dbo].[spGetClientType]";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);

                    oCmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            ClientType item = new ClientType();
                            item.ClientType_ID = Convert.ToInt32(oReader["CTYPE_ID"]);
                            item.ClientType_Title = oReader["CTYPE_TITLE"].ToString();
                            item.ClientType_Desc = oReader["CTYPE_DESCRIPTION"].ToString();
                            _clientTypeList.Add(item);
                        }

                        myConnection.Close();
                    }
                }
                log.DetailLog("DatabaseConnectivity.cs", "getClientType", STATE.COMPLETED, "Method: getClientType in Class: DatabaseConnectivity has completed its execution Successfully.");
                return _clientTypeList;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getClientType", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getClientType", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getClientType", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getClientType", STATE.INTERRUPTED, ex.Message);
                return null;
            }
        }

        // GET Client Type End

        // ADD Client Type

        public int insertClientType(string clientTypeTitle, string clientTypeDesc)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "insertClientType", STATE.INITIALIZED, "Method: insertClientType in Class: DatabaseConnectivity has Initialized.");
                int result = 0;
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string oString = "[dbo].[spInsertClientType]";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.Parameters.AddWithValue("@ClientTypeTitle", clientTypeTitle);
                    oCmd.Parameters.AddWithValue("@ClientTypeDesc", clientTypeDesc);
                    oCmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    result = oCmd.ExecuteNonQuery();
                    myConnection.Close();
                }
                log.DetailLog("DatabaseConnectivity.cs", "insertClientType", STATE.COMPLETED, "Method: insertClientType in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "insertClientType", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertClientType", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "insertClientType", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertClientType", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // ADD Client Type End

        // SET Client Type

        public int setClientType(int clientTypeID, string clientTypeTitle, string clientTypeDesc)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "setClientType", STATE.INITIALIZED, "Method: setClientType in Class: DatabaseConnectivity has Initialized.");
                int result = 0;
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string oString = "[dbo].[spUpdateClientType]";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.Parameters.AddWithValue("@ClientTypeID", clientTypeID);
                    oCmd.Parameters.AddWithValue("@ClientTypeTitle", clientTypeTitle);
                    oCmd.Parameters.AddWithValue("@ClientTypeDesc", clientTypeDesc);
                    oCmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    result = oCmd.ExecuteNonQuery();
                    myConnection.Close();
                }
                log.DetailLog("DatabaseConnectivity.cs", "setClientType", STATE.COMPLETED, "Method: setClientType in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setClientType", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setClientType", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setClientType", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setClientType", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // SET Client Type End

        //Delete A Client Type

        public int deleteClientType(int clientType) {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "deleteClientType", STATE.INITIALIZED, "Method: deleteClientType in Class: DatabaseConnectivity has Initialized.");
                int result = 0;
                SqlConnection myConnection;
                using (myConnection = new SqlConnection(con))
                {
                    string oString = "[dbo].[spDeleteClientType]";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.Parameters.AddWithValue("@ClientTypeID", clientType);
                    oCmd.CommandType = CommandType.StoredProcedure;
                    myConnection.Open();
                    result = oCmd.ExecuteNonQuery();
                    myConnection.Close();
                }
                log.DetailLog("DatabaseConnectivity.cs", "deleteClientType", STATE.COMPLETED, "Method: deleteClientType in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteClientType", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteClientType", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteClientType", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteClientType", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        //Delete A Client Type End

        // GET User Role

        public List<UserRole> getUserRole()
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getUserRole", STATE.INITIALIZED, "Method: getUserRole in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "getUserRole", STATE.COMPLETED, "Method: insertUserRole in Class: DatabaseConnectivity has completed its execution Successfully.");
                return _userRoleList;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getUserRole", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getUserRole", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getUserRole", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getUserRole", STATE.INTERRUPTED, ex.Message);
                return null;
            }
        }

        // GET User Role End

        // ADD User Role

        public int insertUserRole(string Role_Title, string Role_Desc)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "insertUserRole", STATE.INITIALIZED, "Method: insertUserRole in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "insertUserRole", STATE.COMPLETED, "Method: insertUserRole in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "insertUserRole", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertUserRole", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "insertUserRole", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertUserRole", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // ADD User Role End

        // SET User Role

        public int setUserRole(int Role_ID, string Role_Title, string Role_Desc) {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "setUserRole", STATE.INITIALIZED, "Method: setUserRole in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "setUserRole", STATE.COMPLETED, "Method: setUserRole in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setUserRole", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setUserRole", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setUserRole", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setUserRole", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // SET User Role End

        // Delete A User Role

        public int deleteUserRole(int UserRoleID) {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "deleteUserRole", STATE.INITIALIZED, "Method: deleteUserRole in Class: DatabaseConnectivity has Initialized.");
                int result = 0;
                SqlConnection myConnection;
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
                log.DetailLog("DatabaseConnectivity.cs", "deleteUserRole", STATE.COMPLETED, "Method: deleteUserRole in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteUserRole", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteUserRole", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteUserRole", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteUserRole", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // Delete A User Role End

        // Add Environment Type

        public int insertEnvironmentType(string EnvTitle, string EnvDesc) {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "insertEnvironmentType", STATE.INITIALIZED, "Method: insertEnvironmentType in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "insertEnvironmentType", STATE.COMPLETED, "Method: insertEnvironmentType in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "insertEnvironmentType", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertEnvironmentType", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "insertEnvironmentType", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertEnvironmentType", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // Add Environment Type End

        //Update An Environment Type 

        public int setEnvType(int ClientID, string ClientName, string ClientDesc)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "setEnvType", STATE.INITIALIZED, "Method: setEnvType in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "setEnvType", STATE.COMPLETED, "Method: setEnvType in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setEnvType", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setEnvType", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setEnvType", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setEnvType", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        //Update An Environment Type End

        //Getting Environment Type List

        public List<EnvironmentType> getEnvTypeList()
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getEnvTypeList", STATE.INITIALIZED, "Method: getEnvTypeList in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "getEnvTypeList", STATE.COMPLETED, "Method: getEnvTypeList in Class: DatabaseConnectivity has completed its execution Successfully.");
                return _envList;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getEnvTypeList", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getEnvTypeList", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getEnvTypeList", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getEnvTypeList", STATE.INTERRUPTED, ex.Message);
                return null;
            }
        }

        //Getting Environment Type List End

        //Delete Environment Type

        public int deleteEnvironmentType(int EnvTypeID) {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "deleteEnvironmentType", STATE.INITIALIZED, "Method: deleteEnvironmentType in Class: DatabaseConnectivity has Initialized.");
                int result = 0;
                SqlConnection myConnection;
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
                log.DetailLog("DatabaseConnectivity.cs", "deleteEnvironmentType", STATE.COMPLETED, "Method: deleteEnvironmentType in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteEnvironmentType", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteEnvironmentType", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteEnvironmentType", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteEnvironmentType", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        //Delete Environment Type End

        // Add Product

        public int insertProduct(string productName, string productDesc, string productVersion, string productType, string productCategory, string productRating, string productDemoUserID, string productDemoPassword, string productPOC, string productSupportEmail, string productComments) {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "insertProduct", STATE.INITIALIZED, "Method: insertProduct in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "insertProduct", STATE.COMPLETED, "Method: insertProduct in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "insertProduct", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertProduct", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "insertProduct", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertProduct", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // Add Product End

        //Getting Product List

        public List<Product> getProductList()
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getProductList", STATE.INITIALIZED, "Method: getProductList in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "getProductList", STATE.COMPLETED, "Method: getProductList in Class: DatabaseConnectivity has completed its execution Successfully.");
                return _productList;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getProductList", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getProductList", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getProductList", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getProductList", STATE.INTERRUPTED, ex.Message);
                return null;
            }
        }

        //Getting Product List End


        //Delete Product 

        public int deleteProduct(int productID)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "deleteProduct", STATE.INITIALIZED, "Method: deleteProduct in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "deleteProduct", STATE.COMPLETED, "Method: deleteProduct in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteProduct", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteProduct", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteProduct", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteProduct", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        //Delete Product End

        //Delete User

        public int deleteUser(int userID) {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "deleteUser", STATE.INITIALIZED, "Method: deleteUser in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "deleteUser", STATE.COMPLETED, "Method: deleteUser in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteUser", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteUser", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteUser", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteUser", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        //Delete User End

        // Add User

        public int insertUser(string Username, string Userrole, string Passcode) {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "insertUser", STATE.INITIALIZED, "Method: insertUser in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "insertUser", STATE.COMPLETED, "Method: insertUser in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "insertUser", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertUser", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "insertUser", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertUser", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // Add User End

        public List<Patch> getAllUpdatedClientPatches(int ProductID, int EnvType)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getAllUpdatedClientPatches", STATE.INITIALIZED, "Method: getAllUpdatedClientPatches in Class: DatabaseConnectivity has Initialized.");
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
                        }

                        myConnection.Close();
                    }
                }
                log.DetailLog("DatabaseConnectivity.cs", "getAllUpdatedClientPatches", STATE.COMPLETED, "Method: getAllUpdatedClientPatches in Class: DatabaseConnectivity has completed its execution Successfully.");
                return matchingPatch;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getAllUpdatedClientPatches", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getAllUpdatedClientPatches", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getAllUpdatedClientPatches", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getAllUpdatedClientPatches", STATE.INTERRUPTED, ex.Message);
                return null;
            }
        }

        // Updated Patch List

        public List<Patch> getPatchList(int ProductID, int EnvType, int ClientID)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getClientId", STATE.INITIALIZED, "Method: getClientId in Class: DatabaseConnectivity has Initialized.");
                List<Patch> matchingPatch = new List<Patch>();
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string oString = "[dbo].[spGetPatchListThroughCurser]";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.CommandTimeout = 100;
                    oCmd.Parameters.AddWithValue("@ProductID", ProductID);
                    oCmd.Parameters.AddWithValue("@EnvID", EnvType);
                    oCmd.Parameters.AddWithValue("@ClientID", ClientID);
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
                            item.patchWorkingDirectory = oReader["WorkingDirectory"].ToString();
                            item.patchStatus = oReader["PatchStatus"].ToString();
                            matchingPatch.Add(item);
                        }

                        myConnection.Close();
                    }
                }
                log.DetailLog("DatabaseConnectivity.cs", "getPatchList", STATE.COMPLETED, "Method: getPatchList in Class: DatabaseConnectivity has completed its execution Successfully.");
                return matchingPatch;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getPatchList", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getPatchList", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getPatchList", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getPatchList", STATE.INTERRUPTED, ex.Message);
                return null;
            }
        }

        // Updated Patch List End

        ///
        ///<param name="ClientName">String</param>
        ///<summary>Get Client ID Method</summary>
        ///<returns>Int</returns>
        ///
        public int getClientId(String clientName) {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getClientId", STATE.INITIALIZED, "Method: getClientId in Class: DatabaseConnectivity has Initialized.");
                int result = 0;
                using (SqlConnection conn = new SqlConnection(con)) {
                    conn.Open();
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
                log.DetailLog("DatabaseConnectivity.cs", "getClientId", STATE.COMPLETED, "Method: getClientId in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getClientId", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getClientId", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getClientId", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getClientId", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        ///
        ///<param name="ProductName">String</param>
        ///<summary>Get Product ID Method</summary>
        ///<returns>Int</returns>
        ///
        public int getProductId(String productName)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getProductId", STATE.INITIALIZED, "Method: getProductId in Class: DatabaseConnectivity has Initialized.");
            int result = 0;
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
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
            log.DetailLog("DatabaseConnectivity.cs", "getProductId", STATE.COMPLETED, "Method: getProductId in Class: DatabaseConnectivity has completed its execution Successfully.");
            return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getProductId", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getProductId", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getProductId", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getProductId", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // Set Product

        public int setAProduct(int ProductID, string ProductName, string ProductDesc, string ProductVersion, string ProductType, string ProductCategory, string ProductRating, string ProductUserID, string ProductPassword, string ProductPOC, string ProductEmail, string ProductComment)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "setAProduct", STATE.INITIALIZED, "Method: setAProduct in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "setAProduct", STATE.COMPLETED, "Method: setAProduct in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setAProduct", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setAProduct", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setAProduct", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setAProduct", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // Set Product End

        ///
        ///<param name="ClientName">String</param>
        ///<summary>Update Patch Method</summary>
        ///<returns>Bool</returns>
        ///

        public int updateClientPatches(String clientName, String productName)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "updateClientPatches", STATE.INITIALIZED, "Method: updateClientPatches in Class: DatabaseConnectivity has Initialized.");
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
                    result = oCmd.ExecuteNonQuery();
                    oCmd.Dispose();
                    myConnection.Close();
                }
                log.DetailLog("DatabaseConnectivity.cs", "updateClientPatches", STATE.COMPLETED, "Method: updateClientPatches in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "updateClientPatches", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "updateClientPatches", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "updateClientPatches", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "updateClientPatches", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        ///
        ///<param name="ClientName">String</param>
        ///<summary>Update Patch Method</summary>
        ///<returns>Bool</returns>
        ///

        public int updateClientPatches2(int clientID, int productID,int EnvType)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "updateClientPatches2", STATE.INITIALIZED, "Method: updateClientPatches2 in Class: DatabaseConnectivity has Initialized.");
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
                int patchNumber = 0;
                if (latestPatchNumber != "")
                {
                    patchNumber = Convert.ToInt32(latestPatchNumber) + 1;
                }
                else { }
                using (SqlConnection myConnection = new SqlConnection(con))
                {
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
                    result = oCmd.ExecuteNonQuery();
                    oCmd.Dispose();
                    myConnection.Close();
                }
                log.DetailLog("DatabaseConnectivity.cs", "updateClientPatches2", STATE.COMPLETED, "Method: updateClientPatches2 in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "updateClientPatches2", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "updateClientPatches2", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "updateClientPatches2", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "updateClientPatches2", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        //Update A Patch Manual

        public int updatePatcheManually(string title, string desc, string patchNumber1, string deployedBy, string createdDate, string deployedDate, string status, int clientID, int productID, int EnvType)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "updatePatcheManually", STATE.INITIALIZED, "Method: updatePatcheManually in Class: DatabaseConnectivity has Initialized.");
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
                int patchNumber = 0;
                if (latestPatchNumber != "")
                {
                    patchNumber = Convert.ToInt32(latestPatchNumber) + 1;
                }
                else { }
                using (SqlConnection myConnection = new SqlConnection(con))
                {
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
                    result = oCmd.ExecuteNonQuery();
                    oCmd.Dispose();
                    myConnection.Close();
                }
                log.DetailLog("DatabaseConnectivity.cs", "updatePatcheManually", STATE.COMPLETED, "Method: updatePatcheManually in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "updatePatcheManually", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "updatePatcheManually", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "updatePatcheManually", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "updatePatcheManually", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }


        //Update A Patch Manual End

        // Delete A Patch

        public int deleteARelease(string title, string patchNumber1, string createdDate, string deployedDate, string clientID, string environment, string product) {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "deleteARelease", STATE.INITIALIZED, "Method: deleteARelease in Class: DatabaseConnectivity has Initialized.");
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
                using (SqlConnection myConnection = new SqlConnection(con))
                {
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
                    result = oCmd.ExecuteNonQuery();
                    oCmd.Dispose();
                    myConnection.Close();
                }
            log.DetailLog("DatabaseConnectivity.cs", "deleteARelease", STATE.COMPLETED, "Method: deleteARelease in Class: DatabaseConnectivity has completed its execution Successfully.");
            return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteARelease", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteARelease", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "deleteARelease", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "deleteARelease", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // Delete A Patch End

        // User Auth Start
        public List<User> getAuthUsers()
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getAuthUsers", STATE.INITIALIZED, "Method: getAuthUsers in Class: DatabaseConnectivity has Initialized.");
                List<User> matchingUser = new List<User>();
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string oString = "Select * from [USER]";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);
                    //oCmd.Parameters.AddWithValue("@Fname", fName);
                    myConnection.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            User item = new User();
                            item.UserID = oReader["USR_LOGIN_ID"].ToString();
                            item.Password = oReader["USR_CURRENT_PASSCODE"].ToString();
                            matchingUser.Add(item);
                            //matchingPatch.clientName = oReader["ClientName"].ToString();
                            //matchingPatch.patchHotNumber = oReader["PatchHotNumber"].ToString();
                        }

                        myConnection.Close();
                    }
                }
                log.DetailLog("DatabaseConnectivity.cs", "getAuthUsers", STATE.COMPLETED, "Method: getAuthUsers in Class: DatabaseConnectivity has completed its execution Successfully.");
                return matchingUser;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getAuthUsers", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getAuthUsers", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getAuthUsers", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getAuthUsers", STATE.INTERRUPTED, ex.Message);
                return null;
            }
        }
        // User Auth End

        //Getting User List

        public List<User> getUserList()
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getUserList", STATE.INITIALIZED, "Method: getUserList in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "getUserList", STATE.COMPLETED, "Method: getUserList in Class: DatabaseConnectivity has completed its execution Successfully.");
                return _userList;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getUserList", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getUserList", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setAUser", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setAUser", STATE.INTERRUPTED, ex.Message);
                return null;
            }
        }

        //Getting User List End

        //Setting User

        public int setAUser(int userID, string userName, string userRole, string userStatus, string userLoginDate, string wrongAttempts) {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "setAUser", STATE.INITIALIZED, "Method: setAUser in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "setAUser", STATE.COMPLETED, "Method: setAUser in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setAUser", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setAUser", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setAUser", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setAUser", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        //Setting User End

        // Get All Environments

        public List<Environment> getAllEnvironments()
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "getAllEnvironments", STATE.INITIALIZED, "Method: getAllEnvironments in Class: DatabaseConnectivity has Initialized.");
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
                            item.EnvironmentID = Convert.ToInt32(oReader["ENV_ID"]);
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
                            item.EnvironmentAppServerIP = oReader["ENV_AppServerIP"].ToString();
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
                            item.EnvironmentDBMDFFileSize = oReader["ENV_DBMDFFileSize"].ToString();
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
                log.DetailLog("DatabaseConnectivity.cs", "getAllEnvironments", STATE.COMPLETED, "Method: getAllEnvironments in Class: DatabaseConnectivity has completed its execution Successfully.");
                return _envList;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getAllEnvironments", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getAllEnvironments", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getAllEnvironments", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getAllEnvironments", STATE.INTERRUPTED, ex.Message);
                return null;
            }

        }

        // Get All Environments End

        //Set an Environment

        public int setAnEnvironment(int EnvID, int ClientName, int ProductName, int EnvironmentAppServerEnvType, int DBServerEnvType, string AppServerName, string AppServerOS, Int64 AppServerOSBuild, Boolean AppServerIsX86Version, Boolean AppServerIsVirtual, string AppServerProcessor, int AppServerMemory, string AppServerWebBrowser, int AppServerWebBrowserVersion, string AppServerWorkingDirectoryLocation, string AppHyperLink, string AppServerIP, int AppServerPort, string AppServerDependency, string DBServerName, Boolean DBServerIsX86Version, Boolean DBServerIsVirtual, int DBServerMemory, string DBServerProcessor, string DBServerOS, Int64 DBServerOSBuild, string DBServerDirectoryLocation, string DBMDFFileLocation, Int64 DBMDFFileSize, string DBLDFFileLocation, Int64 DBLDFFileSize, string DBServerIP, int DBServerPort, string DBServerDependency)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "setAnEnvironment", STATE.INITIALIZED, "Method: setAnEnvironment in Class: DatabaseConnectivity has Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "setAnEnvironment", STATE.COMPLETED, "Method: setAnEnvironment in Class: DatabaseConnectivity has completed its execution Successfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setAnEnvironment", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setAnEnvironment", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "setAnEnvironment", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "setAnEnvironment", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        //Set an Environment End

        // Environment Settings Start

        public List<Environment> getClientEnvironmentInfo(int ProductID, int EnvType, int ClientID)
        {
            log.DetailLog("DatabaseConnectivity.cs", "getClientEnvironmentInfo", STATE.INITIALIZED, "Method: getClientEnvironmentInfo in Class: DatabaseConnectivity is Initialized.");
            List<Environment> matchingPatch = new List<Environment>();
            try
            {
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
                            item.EnvironmentID = Convert.ToInt32(oReader["ENV_ID"]);
                            item.EnvironmentAppHyperLink = oReader["ENV_AppHyperLink"].ToString();
                            matchingPatch.Add(item);
                        }

                        myConnection.Close();
                    }
                }
                log.DetailLog("DatabaseConnectivity.cs", "getClientEnvironmentInfo", STATE.COMPLETED, "Method: getClientEnvironmentInfo in Class: DatabaseConnectivity has completed its execution Successfully.");
                return matchingPatch;
            }
            catch (SqlException ex) {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getClientEnvironmentInfo", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getClientEnvironmentInfo", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getClientEnvironmentInfo", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getClientEnvironmentInfo", STATE.INTERRUPTED, ex.Message);
                return null;
            }

            
        }

        //Environment Settings End

        // Inserting Data into Client Table

        public int insertClient(string ClientName, string ClientType, string ClientDescription, string POCName, string POCEmail, string POCPhone) {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "insertClient", STATE.INITIALIZED, "Method: insertClient in Class: DatabaseConnectivity is Initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "insertClient", STATE.COMPLETED, "Method: insertClient in Class: DatabaseConnectivity is Completed its Execution Succesfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "insertClient", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertClient", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex) {
                log.ErrorLog("DatabaseConnectivity.cs", "insertClient", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertClient", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // End Inserting Data into Client Table


        // Inserting Data into Patch Table

        public int insertPatch(string PatchTitle, string PatchDesc, string PatchHotNumber, string PatchDeployedBy, DateTime PatchCreatedDate, DateTime PatchDeployedDate, int IsQAPassed, string Dependency, int ClientID, int ProductID, int EnvironmentType)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "insertPatch", STATE.INITIALIZED, "Method: insertPatch in Class: DatabaseConnectivity is initialized.");
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
                log.DetailLog("DatabaseConnectivity.cs", "insertPatch", STATE.COMPLETED, "Method: insertPatch in Class: DatabaseConnectivity is Ended Succesfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "insertPatch", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertPatch", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex) {
                log.ErrorLog("DatabaseConnectivity.cs", "insertPatch", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertPatch", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // End Inserting Data into Patch Table

        // Inserting Data into Environment Table

        public int insertEnvironment(int ClientID, int ProductID, int AppEnvType, int DBEnvType, string AppServerName, string AppServerOS, double AppServerOSBuild, int AppServerIsX86Version, int AppServerIsVirtual, string AppServerProcessor, double AppServerMemory, string AppServerWebBrowser, string AppServerWebBrowserVersion, string AppServerWorkingDirectoryLocation, string AppHyperLink, string AppServerIP, double AppServerPort, string AppServerDependency, string DBServerName, string DBServerOS, double DBerverOSBuild, int DBServerIsX86Version, int DBServerIsVirtual, string DBServerProcessor, double DBServerMemory, string DBServerWorkingDirectoryLocation, string DBMDFFileLocation, double DBMDFFileSize, string DBLDFFileLocation, double DBLDFFileSize, string DBServerIP, double DBServerPort, string DBServerDependency)
        {
            try
            {
                log.DetailLog("DatabaseConnectivity.cs", "insertEnvironment", STATE.INITIALIZED, "Method: insertEnvironment in Class: DatabaseConnectivity is Startet.");
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
                log.DetailLog("DatabaseConnectivity.cs", "insertEnvironment", STATE.COMPLETED, "Method: insertEnvironment in Class: DatabaseConnectivity is Ended Succesfully.");
                return result;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "insertEnvironment", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertEnvironment", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                log.ErrorLog("DatabaseConnectivity.cs", "insertEnvironment", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "insertEnvironment", STATE.INTERRUPTED, ex.Message);
                return 0;
            }

        }


        // End Inserting Data into Environment Table

        // Get Total Data Sources

        public int getAllDataSources(int EnvironmentID) {
            log.DetailLog("DatabaseConnectivity.cs", "getAllDataSources", STATE.INITIALIZED, "Method: getAllDataSources in Class: DatabaseConnectivity is Initialized.");
            int totalDataSources = 0;
            try
            {
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string oString = "[dbo].[spGetDataSourceFromEnvID]";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);

                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.Parameters.AddWithValue("@ENV_ID", EnvironmentID);
                    myConnection.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            totalDataSources = Convert.ToInt32(oReader["TOTAL_DATA_SOURCE"].ToString());
                        }

                        myConnection.Close();
                    }
                }
                log.DetailLog("DatabaseConnectivity.cs", "getAllDataSources", STATE.COMPLETED, "Method: getAllDataSources in Class: DatabaseConnectivity has completed its execution Successfully.");
                return totalDataSources;
            }
            catch (SqlException ex) {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getAllDataSources", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getAllDataSources", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getAllDataSources", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getAllDataSources", STATE.INTERRUPTED, ex.Message);
                return 0;
            }
        }

        // Get Tally Datasource End

        // Get Database Datasource Desc Start

        public List<DataSource_Database> getAllDatabaseDataSourceDesc(int EnvironmentID)
        {
            log.DetailLog("DatabaseConnectivity.cs", "getAllDatabaseDataSourceDesc", STATE.INITIALIZED, "Method: getAllDatabaseDataSourceDesc in Class: DatabaseConnectivity is Initialized.");
            List<DataSource_Database> resdatasourceDatabase = new List<DataSource_Database>();
            try
            {
                using (SqlConnection myConnection = new SqlConnection(con))
                {
                    string oString = "[dbo].[spGetAllDataSourceDesc]";
                    SqlCommand oCmd = new SqlCommand(oString, myConnection);

                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.Parameters.AddWithValue("@ENV_ID", EnvironmentID);
                    myConnection.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            DataSource_Database item = new DataSource_Database();
                            item.DB_SERVER_DEPENDENCY = oReader["TYPE"].ToString();
                            item.DB_ID = Convert.ToInt32(oReader["DB_ID"].ToString());
                            item.DB_ENV_ID = oReader["DB_ENV_ID"].ToString();
                            item.DB_NAME = oReader["DB_NAME"].ToString();
                            item.MDW_VENDER_IMAGE_SRC = oReader["VEN_IMAGE_SRC"].ToString();
                            resdatasourceDatabase.Add(item);
                        }

                        myConnection.Close();
                    }
                }
                log.DetailLog("DatabaseConnectivity.cs", "getAllDatabaseDataSourceDesc", STATE.COMPLETED, "Method: getAllDatabaseDataSourceDesc in Class: DatabaseConnectivity has completed its execution Successfully.");
                return resdatasourceDatabase;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("DataConnectivity SQL. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getAllDatabaseDataSourceDesc", ExceptionType.SQLException, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getAllDatabaseDataSourceDesc", STATE.INTERRUPTED, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DataConnectivity. cs Exception: " + ex.Message);
                log.ErrorLog("DatabaseConnectivity.cs", "getAllDatabaseDataSourceDesc", ExceptionType.Exception, ex);
                log.DetailLog("DatabaseConnectivity.cs", "getAllDatabaseDataSourceDesc", STATE.INTERRUPTED, ex.Message);
                return null;
            }
        }

        // Get Database Datasource Desc End

    }
}