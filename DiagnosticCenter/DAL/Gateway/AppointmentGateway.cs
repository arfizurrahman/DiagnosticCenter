using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.DAL.Gateway
{
    public class AppointmentGateway : Gateway
    {
        public int Save(AppointmentVm appointment)
        {
            Query = "INSERT INTO Appointment VALUES(@patientid, @doctorId, @time)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("patientid", SqlDbType.Int);
            Command.Parameters["patientid"].Value = appointment.PatientId;

            Command.Parameters.Add("doctorId", SqlDbType.Int);
            Command.Parameters["doctorId"].Value = appointment.DoctorId;

            Command.Parameters.Add("time", SqlDbType.VarChar);
            Command.Parameters["time"].Value = appointment.Time;
           
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public Patient GetPatientId(AppointmentVm appointment)
        {
           
            Query = "SELECT Id FROM Patient WHERE PatientCode = @patientCode";

            Command = new SqlCommand(Query, Connection);
            Patient aPatient = null;


            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("patientCode", SqlDbType.VarChar);
            Command.Parameters["patientCode"].Value = appointment.PatientCode;
            

            Reader = Command.ExecuteReader();
            bool a = Reader.HasRows;
            while (Reader.Read())
            {
                aPatient = new Patient();
                
                aPatient.Id = (int)Reader["Id"];
            }

            Reader.Close();
            Connection.Close();
            return aPatient;
        }

        public List<AppointmentVm> GetAllAppointment()
        {
            Query = "SELECT p.PatientCode,p.ContactNo,d.Name,a.time FROM Appointment a JOIN Doctor d ON a.DoctorId = d.Id JOIN Patient p ON p.Id = a.PatientId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            List<AppointmentVm> appointmentVms = new List<AppointmentVm>();

            while (Reader.Read())
            {
                AppointmentVm appointmentVm = new AppointmentVm();
                appointmentVm.PatientCode = Reader["PatientCode"].ToString();
                appointmentVm.DoctorName = Reader["Name"].ToString();
                appointmentVm.PatientContactNo = Reader["ContactNo"].ToString();
                
                int Time = Convert.ToInt32(Reader["Time"].ToString());
                string ampm = null;
                
                int Hr;
                

                if (Time > 719)
                {
                    ampm = "PM";
                }
                else
                {
                    ampm = "AM";
                }

                
                string Min = Convert.ToString(Time % 60);
                if (Min.Length == 1)
                {
                    Min = Min + "0";
                }
                int Hr2 = Time / 60;
                if (Hr2 > 12)
                {
                    Hr = Hr2 - 12;
                }
                else
                {
                    Hr = Hr2;
                }
                
                appointmentVm.Time = Hr + ":" + Min + "" + ampm ;
                appointmentVms.Add(appointmentVm);
            }
            Reader.Close();
            Connection.Close();
            return appointmentVms;
        }
    }
}