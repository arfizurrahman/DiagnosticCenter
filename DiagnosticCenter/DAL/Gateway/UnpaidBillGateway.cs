using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.DAL.Gateway
{
    public class UnpaidBillGateway:Gateway
    {
        public List<PatientTestVm> GetPatientWithUnpaidBill(string fromDate, string toDate)
        {
            Query = "Select * from Bill b Join Patient p On p.Id = b.PatientId WHERE b.Date BETWEEN '" + fromDate + "' AND '" +
                    toDate + "' AND Unpaid > 0 ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            List<PatientTestVm> patientTest = new List<PatientTestVm>();
            while (Reader.Read())
            {
                PatientTestVm aPatient = new PatientTestVm();
                aPatient.PatientName = Reader["Name"].ToString();
                aPatient.ContactNo = Reader["ContactNo"].ToString();
                aPatient.BillNo = Reader["BillNo"].ToString();
                aPatient.UnpaidBill = Convert.ToDouble(Reader["Unpaid"]);

                patientTest.Add(aPatient);
            }
            Reader.Close();
            Connection.Close();
            return patientTest;
        }
    }
}