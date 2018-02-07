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
    public partial class DoctorsProfile : System.Web.UI.Page
    {
        DoctorManager aDoctorManager = new DoctorManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            messageLabel2.InnerText = String.Empty;
            ClearAllLabel();
        }

        public void ClearAllLabel()
        {
            nameLabel.InnerText = String.Empty;
            contactLabel.InnerText = String.Empty;
            emailLabel.InnerText = String.Empty;
            qualificationLabel.InnerText = String.Empty;
            feeLabel.InnerText = String.Empty;
            addressLabel.InnerText = String.Empty;
            avalLabel.InnerText = String.Empty;
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            Doctor aDoctor = new Doctor();
            aDoctor.ContactNo = contactNoText.Value;
            Doctor doctor = aDoctorManager.GetDoctorInfo(aDoctor);
            if (doctor == null)
            {

                messageLabel2.InnerText = "No Doctor found";
            }
            else
            {
                nameLabel.InnerText = doctor.Name;
                contactLabel.InnerText = doctor.ContactNo;
                emailLabel.InnerText = doctor.Email;
                qualificationLabel.InnerText = doctor.Qualifications;
                feeLabel.InnerText = Convert.ToString(doctor.Fee);
                addressLabel.InnerText = doctor.Address;
                avalLabel.InnerText = doctor.Available;
            }



            //List<PatientTestVm> tests = aPatientTestManager.GetPatientTest(aPatient);
            //patientTestGridView.DataSource = tests;
            //patientTestGridView.DataBind();
        }
    }
}