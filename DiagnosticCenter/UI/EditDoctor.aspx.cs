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
    public partial class EditDoctor : System.Web.UI.Page
    {
        DoctorManager aDoctorManager = new DoctorManager();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                string contactNo = Request.QueryString["ContactNo"];


                Doctor aDoctor = aDoctorManager.GetDoctor(contactNo);
                nameTextBox.Value = aDoctor.Name;
                emailTextBox.Value = aDoctor.Email;
                contactNoText.Value = aDoctor.ContactNo;
                qualificationTextBox.Value = aDoctor.Qualifications;
                feeTextBox.Value = aDoctor.Fee.ToString();
                addressTextBox.Value = aDoctor.Address;
                availableFromTextBox.Value = aDoctor.AvailableFrom;
                availableToTextBox.Value = aDoctor.AvailableTo;
                idHiddenField.Value = Convert.ToString(aDoctor.Id);

            }


        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            string availableFrom = availableFromTextBox.Value;
            string f = Convert.ToString(availableFrom[1]);
            if (f == ":")
            {
                availableFrom = "0" + availableFrom;
            }
            string availableTo = availableToTextBox.Value;
            string t = Convert.ToString(availableTo[1]);
            if (t == ":")
            {
                availableTo = "0" + availableTo;
            }
            string fromHr = availableFrom.Substring(0, 2);
            string toHr = availableTo.Substring(0, 2);

            string fromMin = availableFrom.Substring(3, 2);
            string toMin = availableTo.Substring(3, 2);

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
            aDoctor.Id = Convert.ToInt32(idHiddenField.Value);
            aDoctor.Name = nameTextBox.Value;
            aDoctor.ContactNo = contactNoText.Value;
            aDoctor.Email = emailTextBox.Value;
            aDoctor.Qualifications = qualificationTextBox.Value;
            aDoctor.Fee = Convert.ToDouble(feeTextBox.Value);
            aDoctor.Address = addressTextBox.Value;
            aDoctor.AvailableFrom = Convert.ToString(from);
            aDoctor.AvailableTo = Convert.ToString(to);

            string msg = aDoctorManager.Update(aDoctor);
            if (msg == "1")
            {
                messageLabel.InnerText = "Updated successfully";
            }
            else if (msg == "2")
            {
                messageLabel2.InnerText = "Doctor already exists";
            }
            else if (msg == "3")
            {
                messageLabel2.InnerText = "Saving failed..";
            }
        }
    }
}