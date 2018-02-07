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
    public partial class EditTest : System.Web.UI.Page
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
                string testName = Request.QueryString["Name"];

                TestVM test = aTestManager.GetTest(testName);
                testNameTextBox.Value = test.Name;
                feeTextBox.Value = Convert.ToString(test.Fee);



                testTypeDropDownList.DataValueField = Convert.ToString(test.TypeId);
                testTypeDropDownList.DataTextField = Convert.ToString(test.TypeName);
                //testTypeDropDownList.SelectedItem.Value = Convert.ToString(test.TypeId);
                testTypeDropDownList.SelectedValue = Convert.ToString(test.TypeId);
                idHiddenField.Value = Convert.ToString(test.Id);
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            TestVM aTestVm = new TestVM();
            aTestVm.Name = testNameTextBox.Value;
            aTestVm.Fee = Convert.ToInt32(feeTextBox.Value);
            aTestVm.TypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);
            
            aTestVm.Id = Convert.ToInt32(idHiddenField.Value);
            string msg = aTestManager.Update(aTestVm);
            if (msg == "1")
            {
                messageLabel.InnerText = "Updated successfully";
            }

            else if (msg == "3")
            {
                messageLabel2.InnerText = "Saving failed..";
            }
        }
    }
}