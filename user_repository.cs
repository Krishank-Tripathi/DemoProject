using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WcfServiceuser_login
{

    public class user_repository
    {
        public SqlConnection getconnection()
        {
            SqlConnection sqlconn = new SqlConnection();
            string connstring = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            sqlconn.ConnectionString = connstring;
            return sqlconn;
        }

        public bool chkuser(string uId, string pass)
        {
            int flag = 0;
            SqlConnection sqlconnection = getconnection();
            sqlconnection.Open();
            SqlCommand sqlcmd = new SqlCommand("select * from User_tab", sqlconnection);
            SqlDataReader rd = sqlcmd.ExecuteReader();
            List<User> lst = new List<User>();
            while (rd.Read())
            {
                User l = new User();
                l.UserId = (rd["UserId"]).ToString();
                l.Password = rd["Password"].ToString();
                if (l.UserId == uId && l.Password == pass)
                {
                    flag = 1;
                    break;
                }
               // lst.Add(l);
            }
            if (flag == 1)
                return true;
            else
                return false;
        }
    }
}