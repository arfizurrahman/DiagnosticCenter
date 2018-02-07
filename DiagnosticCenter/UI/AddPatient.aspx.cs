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
    public partial class AddPatient : System.Web.UI.Page
    {
        PatientManager aPatientManager = new PatientManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            messageLabel.InnerText = String.Empty; 
            messageLabel2.InnerText = String.Empty;
            PopulateGridView();
        }
        private void PopulateGridView()
        {
            List<Patient> patients = aPatientManager.GetAllPatient();
            patientGridView.DataSource = patients;
            patientGridView.DataBind();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            //String dob = dateOfBirthTextBox.Value;
            //DateTime myDateTime = new DateTime();
            //myDateTime = DateTime.ParseExact(dob, "dd-MM-yyyy", null);
            //String dobNew = myDateTime.ToString("yyyy-MM-dd");
            
            Patient aPatient = new Patient();
            aPatient.Name = nameTextBox.Value;
            aPatient.ContactNo = contactNoText.Value;
            //aPatient.DateOfBirth = dobNew;
            aPatient.Address = addressTextBox.Value;
            aPatient.Age = Convert.ToInt32(ageTextBox.Value);

            string msg = aPatientManager.Save(aPatient);
            if (msg == "1")
            {
                messageLabel.InnerText = "Patient saved successfully";
            }
            else if (msg == "2")
            {
                messageLabel2.InnerText = "Patient already exists";
            }
            else if (msg == "3")
            {
                messageLabel2.InnerText = "Saving failed..";
            }
            PopulateGridView();
            ClearTextField();

        }

        public void ClearTextField()
        {
            nameTextBox.Value = String.Empty;
            contactNoText.Value = String.Empty;
            //dateOfBirthTextBox.Value = String.Empty;
            addressTextBox.Value = String.Empty;
            ageTextBox.Value = String.Empty;
            

        }
        protected void patientGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string contactNo = null;

            if (e.CommandName == "DeleteRow")
            {
                contactNo = e.CommandArgument.ToString();

            }
            aPatientManager.DeletePatient(contactNo);
            PopulateGridView();
        }



        protected void editBtn_Click(object sender, EventArgs e)
        {
            string contactNo = (sender as LinkButton).CommandArgument;

            Response.Redirect("EditPatient.aspx?ContactNo=" + contactNo);


        }

        protected void codeBtn_Click(object sender, EventArgs e)
        {
            string patientCode = (sender as LinkButton).CommandArgument;

            Response.Redirect("TestRquestByPatient.aspx?PatientCode=" + patientCode);


        }
    }
}