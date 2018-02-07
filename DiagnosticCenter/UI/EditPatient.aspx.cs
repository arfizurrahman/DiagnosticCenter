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
    public partial class EditPatient : System.Web.UI.Page
    {
        PatientManager aPatientManager = new PatientManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string contactNo = Request.QueryString["ContactNo"];

                Patient aPatient = aPatientManager.GetPatient(contactNo);
                nameTextBox.Value = aPatient.Name;

                contactNoText.Value = aPatient.ContactNo;
                addressTextBox.Value = aPatient.Address;
                ageTextBox.Value = Convert.ToString(aPatient.Age);
                idHiddenField.Value = Convert.ToString(aPatient.Id);
            }

        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            Patient aPatient = new Patient();
            aPatient.Name = nameTextBox.Value;
            aPatient.ContactNo = contactNoText.Value;
            aPatient.Address = addressTextBox.Value;
            aPatient.Age = Convert.ToInt32(ageTextBox.Value);
            aPatient.Id = Convert.ToInt32(idHiddenField.Value);
            string msg = aPatientManager.Update(aPatient);
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