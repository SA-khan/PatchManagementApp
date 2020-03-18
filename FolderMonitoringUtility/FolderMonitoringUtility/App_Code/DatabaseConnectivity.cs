using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FolderMonitoringUtility.App_Code
{
    class DatabaseConnectivity
    {
        String con = System.Configuration.ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

        //Getting Client in String List

        //public User[] getClientListString()
        //{
        //    List<User> _userList = new List<User>();
        //    using (SqlConnection myConnection = new SqlConnection(con))
        //    {
        //        string oString = "[dbo].[spGetAllUsers]";
        //        SqlCommand oCmd = new SqlCommand(oString, myConnection);

        //        oCmd.CommandType = CommandType.StoredProcedure;
        //        myConnection.Open();
        //        using (SqlDataReader oReader = oCmd.ExecuteReader())
        //        {
        //            while (oReader.Read())
        //            {
        //                User item = new User();
        //                item.USER_ID = Convert.ToInt32(oReader["USR_ID"].ToString());
        //                item.USER_NAME = oReader["USR_LOGIN_ID"].ToString();
        //                item.USER_PASSCODE = oReader["USR_CURRENT_PASSCODE"].ToString();
        //                _userList.Add(item);
        //            }

        //            myConnection.Close();
        //        }
        //    }
        //    User[] res = new User[_userList.Count];
        //    for (int i = 0; i < _userList.Count; i++)
        //    {
        //        res[i] = _userList[i];
        //    }
        //    return res;
        //}

        //Getting Client List in String End

    }
}
