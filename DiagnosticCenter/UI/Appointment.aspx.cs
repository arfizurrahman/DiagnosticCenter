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
    public partial class Appointment : System.Web.UI.Page
    {
        DoctorManager aDoctorManager = new DoctorManager();
        AppointmentManager appointmentManager = new AppointmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            List<Doctor> doctors = aDoctorManager.GetAllDoctor();
            selectDoctorDropDownList.DataSource = doctors;
            selectDoctorDropDownList.DataValueField = "Id";
            selectDoctorDropDownList.DataTextField = "Name";
            selectDoctorDropDownList.DataBind();


            PopulateGridView();

        }
        private void PopulateGridView()
        {
            List<AppointmentVm> appointments = appointmentManager.GetAllAppointment();
            appointmentGridView.DataSource = appointments;
            appointmentGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string time = timeTextBox.Value;

            

            string timeHr = time.Substring(0, 2);
            

            string timeMin = time.Substring(3, 2);
            

            int timeHr2 = Convert.ToInt32(timeHr);

            int timeMin2 = Convert.ToInt32(timeMin);
            

            string timeAMPM = time.Substring(6, 2);
            
            if (timeAMPM == "PM")
            {
                timeHr2 = timeHr2 + 12;
            }
            
            int time2 = timeHr2 * 60 + timeMin2;
           
            AppointmentVm appointment = new AppointmentVm();
            
            appointment.PatientCode = patientCodeTextBox.Value;
            
            appointment.DoctorId = Convert.ToInt32(selectDoctorDropDownList.SelectedValue);
            
            appointment.Time = Convert.ToString(time2);

            string msg = appointmentManager.Save(appointment);
            if (msg == "1")
            {
                messageLabel.InnerText = "Appointment saved";
            }
            else if (msg == "2")
            {
                messageLabel2.InnerText = "Saving failed";
            }
            
            PopulateGridView();
           patientCodeTextBox.Value = String.Empty;
           timeTextBox.Value = String.Empty;

        }

    }
}