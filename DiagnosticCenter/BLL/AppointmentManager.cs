using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Gateway;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.BLL
{
    
    public class AppointmentManager
    {
        AppointmentGateway appointmentGateway = new AppointmentGateway();

        public string Save(AppointmentVm appointment)
        {
            
            Patient patient = appointmentGateway.GetPatientId(appointment);
            int pId = patient.Id;
            appointment.PatientId = pId;
            int rowAffected = appointmentGateway.Save(appointment);
            if (rowAffected > 0)
            {
                return "1";
            }
            return "2";
        }

        public List<AppointmentVm> GetAllAppointment()
        {
            return appointmentGateway.GetAllAppointment();
        }
    }
}