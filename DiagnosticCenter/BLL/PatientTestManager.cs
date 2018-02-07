using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Gateway;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.BLL
{
    public class PatientTestManager
    {
        PatientTestGateway aPatientTestGateway = new PatientTestGateway();
        //public List<PatientTestVm> GetPatientTest(Patient aPatient)
        //{
        //    return aPatientTestGateway.GetPatientTest(aPatient);
        //}
        public int SaveInPatientTest(PatientTestVm patientTestVm)
        {
            int rowAffected = aPatientTestGateway.SaveInPatientTest(patientTestVm);
            return rowAffected;
        }

        public int SaveIntoBill(PatientTestVm aPatientVm)
        {
            int rowAffected = aPatientTestGateway.SaveIntoBill(aPatientVm);
            return rowAffected;
        }

        public List<PatientTestVm> GetPatientTest(string code)
        {
            return aPatientTestGateway.GetPatientTest(code);
        }

        public PatientTestVm GetDueInformation(PatientTestVm aPatient)
        {

            return aPatientTestGateway.GetDueInformation(aPatient);
        }

        public string UpdateDueBill(PatientTestVm aPatient)
        {

            int rowAffected = aPatientTestGateway.UpdateDueBill(aPatient);
            if (rowAffected > 0)
            {

                return "Bill Updated";
            }
            else
            {
                return "Bill Updating failed";
            }
        }
    }
}