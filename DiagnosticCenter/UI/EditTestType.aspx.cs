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
    public partial class EditTestType : System.Web.UI.Page
    {
        TestTypeManager aTestTypeManager = new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string typeName = Request.QueryString["TypeName"];

                 TestType testType  = aTestTypeManager.GetType(typeName);
                typeNameTextBox.Value = testType.TypeName;

                
                idHiddenField.Value = Convert.ToString(testType.Id);
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            TestType testType = new TestType();
            testType.TypeName = typeNameTextBox.Value;
            
           testType.Id = Convert.ToInt32(idHiddenField.Value);
            string msg = aTestTypeManager.Update(testType);
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