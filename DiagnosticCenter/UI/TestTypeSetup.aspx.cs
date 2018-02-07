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
    public partial class TestTypeSetup : System.Web.UI.Page
    {
        TestTypeManager aTestTypeManager = new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            messageLabel2.InnerText = String.Empty;
            messageLabel.InnerText = String.Empty;
            PopulateTypeGridView();
        }
        private void PopulateTypeGridView()
        {
            List<TestType> testTypes = aTestTypeManager.GetAllTestType();
            typeNameGridView.DataSource = testTypes;
            typeNameGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestType aTestType = new TestType();
            aTestType.TypeName = typeNameTextBox.Value;

            string msg = aTestTypeManager.Save(aTestType);
            if (msg == "1")
            {
                messageLabel.InnerText = "Saved successfully";
            }
            else if (msg == "2")
            {
                messageLabel2.InnerText = "Test Type already exists";
            }
            else if (msg == "3")
            {
                messageLabel2.InnerText = "Saving failed..";
            }
            PopulateTypeGridView();

            typeNameTextBox.Value = null;
        }

        

        protected void typeNameGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string name = null;

            if (e.CommandName == "DeleteRow")
            {
                name = e.CommandArgument.ToString();

            }
            aTestTypeManager.DeleteTestType(name);
            PopulateTypeGridView();
        }



        protected void editBtn_Click(object sender, EventArgs e)
        {
            string typeName = (sender as LinkButton).CommandArgument;

            Response.Redirect("EditTestType.aspx?TypeName=" + typeName);


        }
    }
}