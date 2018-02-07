using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.DAL.Gateway
{
    public class DoctorGateway : Gateway
    {
        public bool IsDoctorExists(Doctor aDoctor)
        {
            Query = "SELECT * FROM Doctor WHERE ContactNo = @contactNo";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
           
            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = aDoctor.ContactNo;
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

        public int Save(Doctor aDoctor)
        {
            Query = "INSERT INTO Doctor VALUES(@name, @contactNo, @email, @qualifications, @fee, @address,@availFrom, @availTo)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aDoctor.Name;

            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = aDoctor.ContactNo;

            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = aDoctor.Email;
            Command.Parameters.Add("qualifications", SqlDbType.VarChar);
            Command.Parameters["qualifications"].Value = aDoctor.Qualifications;
            Command.Parameters.Add("fee", SqlDbType.Decimal);
            Command.Parameters["fee"].Value = aDoctor.Fee;
            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = aDoctor.Address;
            Command.Parameters.Add("availFrom", SqlDbType.VarChar);
            Command.Parameters["availFrom"].Value = aDoctor.AvailableFrom;
            Command.Parameters.Add("availTo", SqlDbType.VarChar);
            Command.Parameters["availTo"].Value = aDoctor.AvailableTo;
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Doctor> GetAllDoctor()
        {
            Query = "SELECT Id,Name, ContactNo,Email,AvailableFrom,AvailableTo FROM Doctor";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Doctor> doctors = new List<Doctor>();

            while (Reader.Read())
            {
                Doctor aDoctor = new Doctor();
                aDoctor.Id = (int)Reader["Id"];
                aDoctor.Name = Reader["Name"].ToString();
                aDoctor.ContactNo = Reader["ContactNo"].ToString();
                aDoctor.Email = Reader["Email"].ToString();
                int availFrom = Convert.ToInt32(Reader["AvailableFrom"]);
                int availTo = Convert.ToInt32(Reader["AvailableTo"]);
                
                string aFromAMPM = null;
                string aToAMPM = null;
                int fHr;
                int tHr;
                
                if (availFrom > 719)
                {
                    aFromAMPM = "PM";
                }
                else
                {
                    aFromAMPM = "AM";
                }
                
                if (availTo > 719)
                {
                    aToAMPM = "PM";
                }
                else
                {
                    aToAMPM = "AM";
                }
                string FromMin = Convert.ToString(availFrom % 60);
                if (FromMin.Length == 1)
                {
                    FromMin = FromMin + "0";
                }
                int FromHr = availFrom / 60;
                if (FromHr > 12)
                {
                    fHr = FromHr - 12;
                }
                else
                {
                    fHr = FromHr;
                }
                string ToMin = Convert.ToString(availTo % 60);
                if (ToMin.Length == 1)
                {
                    ToMin = ToMin + "0";
                }

                int ToHr = availTo / 60;
                if (ToHr > 12)
                {
                    tHr = ToHr - 12;
                }
                else
                {
                    tHr = ToHr;
                }
                aDoctor.Available = fHr + ":" + FromMin + "" + aFromAMPM+"-"+ tHr+":"+ToMin+""+aToAMPM;
                
                doctors.Add(aDoctor);
            }
            Reader.Close();
            Connection.Close();
            return doctors;
        }

        public Doctor GetDoctorInfo(Doctor aDoctor)
        {
            Query = "SELECT Name, ContactNo,Email,AvailableFrom,AvailableTo,Fee,Address,Qualifications FROM Doctor Where ContactNo = @contactNo";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = aDoctor.ContactNo;
            Reader = Command.ExecuteReader();
            Doctor doctor = null;

            while (Reader.Read())
            {
                doctor = new Doctor();
                doctor.Name = Reader["Name"].ToString();
                doctor.ContactNo = Reader["ContactNo"].ToString();
                doctor.Email = Reader["Email"].ToString();
                doctor.Address = Reader["Address"].ToString();
                doctor.Qualifications = Reader["Qualifications"].ToString();
                doctor.Fee = Convert.ToDouble(Reader["Fee"]);
                int availFrom = Convert.ToInt32(Reader["AvailableFrom"]);
                int availTo = Convert.ToInt32(Reader["AvailableTo"]);

                string aFromAMPM = null;
                string aToAMPM = null;
                int fHr;
                int tHr;

                if (availFrom > 719)
                {
                    aFromAMPM = "PM";
                }
                else
                {
                    aFromAMPM = "AM";
                }

                if (availTo > 719)
                {
                    aToAMPM = "PM";
                }
                else
                {
                    aToAMPM = "AM";
                }
                string FromMin = Convert.ToString(availFrom % 60);
                if (FromMin.Length == 1)
                {
                    FromMin = FromMin + "0";
                }
                int FromHr = availFrom / 60;
                if (FromHr > 12)
                {
                    fHr = FromHr - 12;
                }
                else
                {
                    fHr = FromHr;
                }
                string ToMin = Convert.ToString(availTo % 60);
                if (ToMin.Length == 1)
                {
                    ToMin = ToMin + "0";
                }

                int ToHr = availTo / 60;
                if (ToHr > 12)
                {
                    tHr = ToHr - 12;
                }
                else
                {
                    tHr = ToHr;
                }
                doctor.Available = fHr + ":" + FromMin + "" + aFromAMPM + "-" + tHr + ":" + ToMin + "" + aToAMPM;

                
            }
            Reader.Close();
            Connection.Close();
            return doctor;
        }

        public Doctor GetDoctor(string contactNo)
        {
            Query = "SELECT Id,Name, ContactNo,Email,AvailableFrom,AvailableTo,Fee,Address,Qualifications FROM Doctor Where ContactNo = @contactNo";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = contactNo;
            Reader = Command.ExecuteReader();
            Doctor doctor = null;

            while (Reader.Read())
            {

                doctor = new Doctor();
                doctor.Id = (int)Reader["Id"];
                doctor.Name = Reader["Name"].ToString();
                doctor.ContactNo = Reader["ContactNo"].ToString();
                doctor.Email = Reader["Email"].ToString();
                doctor.Address = Reader["Address"].ToString();
                doctor.Qualifications = Reader["Qualifications"].ToString();
                doctor.Fee = Convert.ToDouble(Reader["Fee"]);
                int availFrom = Convert.ToInt32(Reader["AvailableFrom"]);
                int availTo = Convert.ToInt32(Reader["AvailableTo"]);

                string aFromAMPM = null;
                string aToAMPM = null;
                int fHr;
                int tHr;

                if (availFrom > 719)
                {
                    aFromAMPM = "PM";
                }
                else
                {
                    aFromAMPM = "AM";
                }

                if (availTo > 719)
                {
                    aToAMPM = "PM";
                }
                else
                {
                    aToAMPM = "AM";
                }
                string FromMin = Convert.ToString(availFrom % 60);
                if (FromMin.Length == 1)
                {
                    FromMin = FromMin + "0";
                }
                
                string FromH = Convert.ToString(availFrom / 60);
                if (FromH.Length == 1)
                {
                    FromH = "0" + FromH;
                }
                int FromHr = Convert.ToInt32(FromH);
                if (FromHr > 12)
                {
                    fHr = FromHr - 12;
                }
                else
                {
                    fHr = FromHr;
                }
                string ToMin = Convert.ToString(availTo % 60);
                if (ToMin.Length == 1)
                {
                    ToMin = ToMin + "0";
                }

                string ToH = Convert.ToString(availTo / 60);
                if (ToH.Length == 1)
                {
                    ToH = "0" + ToH;
                }
                int ToHr = Convert.ToInt32(ToH);
                if (ToHr > 12)
                {
                    tHr = ToHr - 12;
                }
                else
                {
                    tHr = ToHr;
                }
               
                doctor.AvailableFrom = fHr + ":" + FromMin+" "+ aFromAMPM;
                doctor.AvailableTo = tHr + ":" + ToMin+" "+aToAMPM;


            }
            Reader.Close();
            Connection.Close();
            return doctor;
        }

        public void DeleteDoctor(string contactNo)
        {
            Query = "Delete From Doctor WHERE ContactNo = @contactNo";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = contactNo;
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public int Update(Doctor aDoctor)
        {
            Query = "Update Doctor SET Name = @name,ContactNo = @contactNo,Email = @email,Qualifications = @qualifications,Fee = @fee,Address = @address, AvailableFrom = @availFrom,AvailableTo = @availTo WHERE Id=@id";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aDoctor.Name;
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = aDoctor.Id;
            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = aDoctor.ContactNo;

            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = aDoctor.Email;
            Command.Parameters.Add("qualifications", SqlDbType.VarChar);
            Command.Parameters["qualifications"].Value = aDoctor.Qualifications;
            Command.Parameters.Add("fee", SqlDbType.Decimal);
            Command.Parameters["fee"].Value = aDoctor.Fee;
            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = aDoctor.Address;
            Command.Parameters.Add("availFrom", SqlDbType.VarChar);
            Command.Parameters["availFrom"].Value = aDoctor.AvailableFrom;
            Command.Parameters.Add("availTo", SqlDbType.VarChar);
            Command.Parameters["availTo"].Value = aDoctor.AvailableTo;
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}