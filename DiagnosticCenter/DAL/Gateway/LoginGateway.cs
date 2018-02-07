using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.DAL.Gateway
{
    public class LoginGateway : Gateway
    {
        public bool IsEmailExists(Admin admin)
        {
            Query = "SELECT Email FROM Admin WHERE Email = @email";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = admin.Email;
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }
        public bool IsPasswordExists(Admin admin)
        {
            Query = "SELECT Password FROM Admin WHERE Password = @password";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("password", SqlDbType.VarChar);
            Command.Parameters["password"].Value = admin.Password;
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }
    }
}