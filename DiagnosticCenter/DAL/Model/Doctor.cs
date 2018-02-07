using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenter.DAL.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public double Fee { get; set; }
        public string Address { get; set; }
        public string Qualifications { get; set; }
        public string AvailableFrom { get; set; }
        public string AvailableTo { get; set; }
        public string Available { get; set; }
    }
}