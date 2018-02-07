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
    public partial class Payment : System.Web.UI.Page
    {
        PatientTestManager patientTestManager = new PatientTestManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            PatientTestVm aPatient = new PatientTestVm();

            aPatient.PatientCode = patientCodeTextBox.Value;
            //aPatient.BillNo = billNoTextBox.Value;
            
                PatientTestVm bPatient = patientTestManager.GetDueInformation(aPatient);
            double due = bPatient.UnpaidBill;
                if (due == 0)
                {
                    messageLabel2.InnerText = "no dues";
                    payButton.Enabled = false;
                    amountTextBox.Value = String.Empty;
                    dueDateTextBox.Value = String.Empty;
                }
                else
                {
                    
                    payButton.Enabled = true;
                    amountTextBox.Value = bPatient.UnpaidBill.ToString();
                    string date = bPatient.BillDate;
                    dueDateTextBox.Value = date.Substring(0, 10);
                    idHiddenField.Value = bPatient.Id.ToString();
                }
            


        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            PatientTestVm aPatient = new PatientTestVm();
            aPatient.PatientId = Convert.ToInt32(idHiddenField.Value);
            aPatient.UnpaidBill = Convert.ToDouble(amountTextBox.Value);
            //billNoTextBox.Value = String.Empty;
            patientCodeTextBox.Value = String.Empty;
            messageLabel.InnerText = patientTestManager.UpdateDueBill(aPatient);
        }

    }
}