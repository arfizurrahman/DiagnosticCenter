using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenter.DAL.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Code { get; set; }
        
    }
}