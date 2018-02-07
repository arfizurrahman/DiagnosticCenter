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
    public partial class PatientProfile : System.Web.UI.Page
    {
        PatientManager aPatientManager = new PatientManager();
        PatientTestManager aPatientTestManager = new PatientTestManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            messageLabel2.InnerText = String.Empty;
        }

        private void PopulateGridView(string code)
        {
            
            List<PatientTestVm> patientTests = aPatientTestManager.GetPatientTest(code);
            patientTestGridView.DataSource = patientTests;
            patientTestGridView.DataBind();
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            Patient aPatient = new Patient();
            aPatient.Code = patientCodeText.Value;
            Patient patient = aPatientManager.GetPatientInfo(aPatient);
            if (patient == null)
            {

                messageLabel2.InnerText = "No Patient found";
            }
            else
            {
                nameLabel.InnerText = patient.Name;


                
                contactLabel.InnerText = patient.ContactNo;
                ageLabel.InnerText = Convert.ToString(patient.Age);
                addressLabel.InnerText = patient.Address; 
            }
            string code = aPatient.Code;
            PopulateGridView(code);
            
            //List<PatientTestVm> tests = aPatientTestManager.GetPatientTest(aPatient);
            //patientTestGridView.DataSource = tests;
            //patientTestGridView.DataBind();
        }
    }
}