using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.DAL.Gateway
{
    public class PatientGateway : Gateway
    {
        public bool IsPatientExists(Patient aPatient)
        {
            Query = "SELECT * FROM Patient WHERE Name = @name and ContactNo = @contactNo";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aPatient.Name;
            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = aPatient.ContactNo;
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }

        public int Save(Patient aPatient)
        {
            Query = "INSERT INTO Patient(Name,ContactNo,Address,Age) VALUES(@name, @contactNo, @address,@age)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aPatient.Name;

            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = aPatient.ContactNo;

            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = aPatient.Address;
            Command.Parameters.Add("age", SqlDbType.Int);
            Command.Parameters["age"].Value = aPatient.Age;
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Patient> GetAllPatient()
        {
            Query = "SELECT Name, PatientCode, ContactNo FROM Patient";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Patient> patients = new List<Patient>();

            while (Reader.Read())
            {
                Patient aPatient= new Patient();
                aPatient.Name = Reader["Name"].ToString();
                aPatient.ContactNo = Reader["ContactNo"].ToString();
                aPatient.Code = Reader["PatientCode"].ToString();

                patients.Add(aPatient);
            }
            Reader.Close();
            Connection.Close();
            return patients;
        }

        public Patient GetPatientInfo(Patient aPatient)
        {
            Query = "SELECT Id,Name, ContactNo,Address,Age,PatientCode FROM Patient WHERE PatientCode = @code";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = aPatient.Code;
            Connection.Open();

            Reader = Command.ExecuteReader();

            Patient patient = null;
            
            while (Reader.Read())
            {
                patient = new Patient();
                patient.Id = (int) Reader["Id"];
                patient.Name = Reader["Name"].ToString();
                //patient.DateOfBirth = Reader["DateOfBirth"].ToString();
                patient.ContactNo = Reader["ContactNo"].ToString();
                patient.Age = (int)Reader["Age"];
                patient.Address = Reader["Address"].ToString();
                patient.Code = Reader["PatientCode"].ToString();

                
            }
            Reader.Close();
            Connection.Close();
            return patient;
        }

        public Patient GetPatientCode(Patient aPatient)
        {
            Query = "Select Id,Age From Patient WHERE ContactNo = @contactNo";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = aPatient.ContactNo;
            Connection.Open();

            Reader = Command.ExecuteReader();

            Patient patient = null;

            if (Reader.Read())
            {
                patient = new Patient();
                patient.Id = (int)Reader["Id"];
                patient.Age = (int)Reader["Age"];


            }
            Reader.Close();
            Connection.Close();
            return patient;

        }

        public int Update(Patient aPatient)
        {
            Query = "UPDATE Patient SET PatientCode = @code WHERE ContactNo = @contactNo";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            
            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = aPatient.ContactNo;

            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = aPatient.Code;
           
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public void DeletePatient(string contactNo)
        {
            Query = "Delete From Patient WHERE ContactNo = @contactNo";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = contactNo;
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public int UpdatePatient(Patient aPatient)
        {
            Query = "Update Patient SET Name = @name,ContactNo = @contactNo,Address = @address, Age = @age WHERE Id=@id";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aPatient.Name;

            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = aPatient.ContactNo;

            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = aPatient.Address;
            Command.Parameters.Add("age", SqlDbType.Int);
            Command.Parameters["age"].Value = aPatient.Age;
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = aPatient.Id;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }


        public Patient GetPatient(string contactNo)
        {
            Query = "SELECT Id,Name, ContactNo,Address,Age,PatientCode FROM Patient WHERE ContactNo = @contactNo";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = contactNo;
            Connection.Open();

            Reader = Command.ExecuteReader();

            Patient patient = null;

            while (Reader.Read())
            {
                patient = new Patient();
                patient.Id = (int)Reader["Id"];
                patient.Name = Reader["Name"].ToString();
                //patient.DateOfBirth = Reader["DateOfBirth"].ToString();
                patient.ContactNo = Reader["ContactNo"].ToString();
                patient.Age = (int)Reader["Age"];
                patient.Address = Reader["Address"].ToString();
                patient.Code = Reader["PatientCode"].ToString();


            }
            Reader.Close();
            Connection.Close();
            return patient;
        }

        public int GetPatientId(PatientTestVm aPatientVm)
        {
            Query = "SELECT * FROM Patient WHERE PatientCode = @code";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = aPatientVm.Code;
            Connection.Open();

            Reader = Command.ExecuteReader();

            Patient patient = null;
            int id=0;
            if (Reader.Read())
            {
                patient = new Patient();
                patient.Id = Convert.ToInt32(Reader["Id"]);
                id = patient.Id;


            }
            Reader.Close();
            Connection.Close();
            return id;
        }

        public Patient GetPatientForPdf(int patientId)
        {
            Query = "SELECT Id,Name, ContactNo,Address,Age,PatientCode FROM Patient WHERE Id = @id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = patientId;
            Connection.Open();

            Reader = Command.ExecuteReader();

            Patient patient = null;

            while (Reader.Read())
            {
                patient = new Patient();
                patient.Id = Convert.ToInt32(Reader["Id"]);
                patient.Name = Reader["Name"].ToString();
                //patient.DateOfBirth = Reader["DateOfBirth"].ToString();
                patient.ContactNo = Reader["ContactNo"].ToString();
                patient.Age = (int)Reader["Age"];
                patient.Address = Reader["Address"].ToString();
                patient.Code = Reader["PatientCode"].ToString();


            }
            Reader.Close();
            Connection.Close();
            return patient;
        }

        public void DeleteFromBill(int pId)
        {
            Query = "Delete From Bill WHERE PatientId = @pId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Add("pId", SqlDbType.Int);
            Command.Parameters["pId"].Value = pId;
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        

        public void DeleteFromPatientTest(int pId)
        {
            Query = "Delete From PatientTest WHERE PatientId = @pId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Add("pId", SqlDbType.Int);
            Command.Parameters["pId"].Value = pId;
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public void DeleteTest(int tId)
        {
            Query = "Delete From Test WHERE Id = @id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = tId;
            Command.ExecuteNonQuery();
            Connection.Close();
        }
    }
}