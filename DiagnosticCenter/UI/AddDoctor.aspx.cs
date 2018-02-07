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
    public partial class AddDoctor : System.Web.UI.Page
    {
        DoctorManager aDoctorManager = new DoctorManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView();
            messageLabel2.InnerText = String.Empty;
            messageLabel.InnerText = String.Empty;
        }
        private void PopulateGridView()
        {
            List<Doctor> doctors = aDoctorManager.GetAllDoctor();
            doctorGridView.DataSource = doctors;
            doctorGridView.DataBind();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            string availableFrom = availableFromTextBox.Value;

            string availableTo = availableToTextBox.Value;

            string fromHr = availableFrom.Substring(0, 2);
            string toHr = availableTo.Substring(0, 2);

            string fromMin = availableFrom.Substring(3,2);
            string toMin = availableTo.Substring(3,2);

            int availFromHr = Convert.ToInt32(fromHr);
            int availToHr = Convert.ToInt32(toHr);

            int availFromMin = Convert.ToInt32(fromMin);
            int availToMin = Convert.ToInt32(toMin);

            string fromAMPM = availableFrom.Substring(6, 2);
            string toAMPM = availableTo.Substring(6, 2);
            if (fromAMPM == "PM")
            {
                availFromHr = availFromHr + 12;
            }
            if (toAMPM == "PM")
            {
                availToHr = availToHr + 12;
            }
            int from = availFromHr * 60 + availFromMin;
            int to = availToHr * 60 + availToMin;

            Doctor aDoctor = new Doctor();
            aDoctor.Name = nameTextBox.Value;
            aDoctor.ContactNo = contactNoText.Value;
            aDoctor.Email = emailTextBox.Value;
            aDoctor.Qualifications = qualificationTextBox.Value;
            aDoctor.Fee = Convert.ToDouble(feeTextBox.Value);
            aDoctor.Address = addressTextBox.Value;
            aDoctor.AvailableFrom = Convert.ToString(from);
            aDoctor.AvailableTo = Convert.ToString(to);

            string msg = aDoctorManager.Save(aDoctor);
            if (msg == "1")
            {
                messageLabel.InnerText = "Saved successfully";
            }
            else if (msg == "2")
            {
                messageLabel2.InnerText = "Doctor already exists";
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
            qualificationTextBox.Value = String.Empty;
            feeTextBox.Value = String.Empty;
            emailTextBox.Value = String.Empty;
            addressTextBox.Value = String.Empty;
            
        }


        protected void doctorGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string contactNo = null;

            if (e.CommandName == "DeleteRow")
            {
               contactNo  = e.CommandArgument.ToString();
                
            }
            aDoctorManager.DeleteDoctor(contactNo);
            PopulateGridView();
        }



        protected void editBtn_Click(object sender, EventArgs e)
        {
            string contactNo = (sender as LinkButton).CommandArgument;
           
            Response.Redirect("EditDoctor.aspx?ContactNo=" + contactNo);

            
        }

    }
}
