using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.DAL.Gateway
{
    public class PatientTestGateway : Gateway
    {
        //public List<PatientTestVm> GetPatientTest(Patient aPatient)
        //{
            
        //}
        public int SaveInPatientTest(PatientTestVm patientTestVm)
        {
            Query = "Insert into PatientTest Values(@patientId, @testId, @date)";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("testId", SqlDbType.Int);
            Command.Parameters["testId"].Value = patientTestVm.TestId;


            Command.Parameters.Add("patientId", SqlDbType.Int);
            Command.Parameters["patientId"].Value = patientTestVm.PatientId;

            Command.Parameters.Add("date", SqlDbType.Date);
            Command.Parameters["date"].Value = patientTestVm.EntryDate;

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int SaveIntoBill(PatientTestVm aPatientVm)
        {
            Query = "Insert into Bill(PatientId,BillNo,Date,TotalBill,Unpaid) Values(@patientId, @billNo, @date, @total,@unpaid)";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("patientId", SqlDbType.Int);
            Command.Parameters["patientId"].Value = aPatientVm.PatientId;


            Command.Parameters.Add("billNo", SqlDbType.VarChar);
            Command.Parameters["billNo"].Value = aPatientVm.BillNo;

            Command.Parameters.Add("date", SqlDbType.Date);
            Command.Parameters["date"].Value = aPatientVm.EntryDate;

            Command.Parameters.Add("total", SqlDbType.Decimal);
            Command.Parameters["total"].Value = aPatientVm.TotalBill;
            Command.Parameters.Add("unpaid", SqlDbType.Decimal);
            Command.Parameters["unpaid"].Value = aPatientVm.TotalBill;
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<PatientTestVm> GetPatientTest(string code)
        {
            Query = "Select t.Name Test FROm PatientTest pt Join Patient p On p.Id = pt.PatientId JOIN Test t ON t.Id = pt.TestId WHERE PatientCode = @code";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Command.Parameters.Clear();
           


            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = code;

            Reader = Command.ExecuteReader();

            List<PatientTestVm> patientTestVms = new List<PatientTestVm>();

            if (Reader.Read())
            {
                PatientTestVm patientTest = new PatientTestVm();
                patientTest = new PatientTestVm();
                patientTest.TestName = Reader["Test"].ToString();

                patientTestVms.Add(patientTest);

            }
           
            Reader.Close();
            Connection.Close();
            return patientTestVms;
        }

        public void DeleteFromPatientTest(int tId)
        {
           
            Query = "Delete From PatientTest WHERE TestId = @tId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Add("tId", SqlDbType.Int);
            Command.Parameters["tId"].Value = tId;
            Command.ExecuteNonQuery();
            Connection.Close();
        
        }

        public PatientTestVm GetDueInformation(PatientTestVm aPatient)
        {
            Query = "SELECT b.Unpaid,p.Id,b.Date FROM Patient p JOIN Bill b On p.Id= b.PatientId WHERE p.PatientCode = @patientCode";

            Command = new SqlCommand(Query, Connection);
            PatientTestVm aPatients = null;


            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("patientCode", SqlDbType.VarChar);
            Command.Parameters["patientCode"].Value = aPatient.PatientCode;
            

            Reader = Command.ExecuteReader();
            bool a = Reader.HasRows;
            while (Reader.Read())
            {
                aPatients = new PatientTestVm();
                aPatients.BillDate = Reader["Date"].ToString();
                aPatients.UnpaidBill = Convert.ToDouble(Reader["Unpaid"]);
                aPatients.Id = (int)Reader["Id"];
            }

            Reader.Close();
            Connection.Close();
            return aPatients;
        }

        public int UpdateDueBill(PatientTestVm aPatient)
        {

            Query = "UPDATE Bill SET Unpaid = '0.00', Paid = @paid WHERE PatientId = @id ";

            Command = new SqlCommand(Query, Connection);


            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = aPatient.PatientId;
            Command.Parameters.Add("paid", SqlDbType.Int);
            Command.Parameters["paid"].Value = aPatient.UnpaidBill;

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}