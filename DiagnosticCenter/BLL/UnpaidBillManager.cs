using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Gateway;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.BLL
{
    public class UnpaidBillManager
    {
        UnpaidBillGateway aUnpaidBillGateway = new UnpaidBillGateway();

        public List<PatientTestVm> GetPatientWithUnpaidBill(string fromDate, string toDate)
        {
            return aUnpaidBillGateway.GetPatientWithUnpaidBill(fromDate, toDate);
        } 
    }
}