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
    public partial class TestSetup : System.Web.UI.Page
    {
        TestManager aTestManager = new TestManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                List<TestType> testTypes = aTestManager.GetAllTypes();
                testTypeDropDownList.DataSource = testTypes;
                testTypeDropDownList.DataValueField = "Id";
                testTypeDropDownList.DataTextField = "TypeName";
                testTypeDropDownList.DataBind();
            }
            messageLabel2.InnerText = String.Empty;
            messageLabel.InnerText = String.Empty;
            PopulateTestGridView();
        }

        private void PopulateTestGridView()
        {
            List<TestVM> Tests = aTestManager.GetAllTest();
            testGridView.DataSource = Tests;
            testGridView.DataBind();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestVM aTest = new TestVM();
            aTest.Name = testNameTextBox.Value;
            aTest.Fee = Convert.ToDouble(feeTextBox.Value);
            aTest.TypeName = testTypeDropDownList.SelectedItem.Text;
            aTest.TypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);

            string msg = aTestManager.Save(aTest);
            if (msg == "1")
            {
                messageLabel.InnerText = "Test saved successfully..";
            }
            else if (msg == "2")
            {
                messageLabel2.InnerText = "Test already exists";
            }
            else if (msg == "3")
            {
                messageLabel2.InnerText = "Saving failed..";
            }
            else
            {
                messageLabel2.InnerText = "";
            }
            ClearTextField();
            PopulateTestGridView();

        }
        public void ClearTextField()
        {
            testNameTextBox.Value = String.Empty;
            feeTextBox.Value = String.Empty;
        }
        protected void testGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string name = null;

            if (e.CommandName == "DeleteRow")
            {
                name = e.CommandArgument.ToString();

            }
            aTestManager.DeleteTest(name);
            PopulateTestGridView();
        }



        protected void editBtn_Click(object sender, EventArgs e)
        {
            string testName = (sender as LinkButton).CommandArgument;

            Response.Redirect("EditTest.aspx?Name=" + testName);


        }
    }
}