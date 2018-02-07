using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenter.DAL.Model
{
    [Serializable]
        public class PatientTestVm
        {
            public int Id { get; set; }
            public string PatientName { get; set; }
            public string ContactNo { get; set; }
            public string PatientCode { get; set; }
            public int TestId { get; set; }
            public string TestName { get; set; }
        public string Code { get; set; }

            public int PatientId { get; set; }
            public double Fee { get; set; }
            public string EntryDate { get; set; }
     
        public string Date { get; set; }

        public string BillNo { get; set; }
            public double TotalBill { get; set; }
            public double UnpaidBill { get; set; }
            public string BillDate { get; set; }
    
        }

    
}