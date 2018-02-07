using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenter.BLL;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.UI
{
    public partial class Login : System.Web.UI.Page
    {
        LoginManager aLoginManager = new LoginManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    messageLabel.InnerText = "Invalid"
            //}
        }

        protected void signInButton_Click(object sender, EventArgs e)
        {
            Admin anAdmin = new Admin();
            anAdmin.Email = emailTextBox.Value;
            anAdmin.Password = passwordTextBox.Value;

            string msg = aLoginManager.Login(anAdmin);
            if (msg == "1")
            {
                Response.Redirect("Index.aspx", true);
            }
            messageLabel.InnerText = msg;


        }
    }
}