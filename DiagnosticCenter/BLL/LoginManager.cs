using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Gateway;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.BLL
{
    public class LoginManager
    {
        LoginGateway aLoginGateway = new LoginGateway();

        public string Login(Admin admin)
        {
            if (aLoginGateway.IsEmailExists(admin))
            {
                if (aLoginGateway.IsPasswordExists(admin))
                {
                    return "1";
                }
                else
                {
                    return "Incorrect Email or Password!";
                }
            }
            else
            {
                return "Incorrect Email!";
            }
            
        }

        
    }
}