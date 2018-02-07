using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenter.DAL.Model
{
    public class AppointmentVm
    {
        public int Id { get; set; }
        public string PatientCode { get; set; }
        public string DoctorName { get; set; }
        public string PatientContactNo { get; set; }
        public string Time { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}