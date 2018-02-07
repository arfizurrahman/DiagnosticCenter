using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Gateway;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.BLL
{
    public class PatientManager
    {
        PatientGateway aPatientGateway = new PatientGateway();
        public string Save(Patient aPatient)
        {
               
                int rowAffected = aPatientGateway.Save(aPatient);
                Patient patient = aPatientGateway.GetPatientCode(aPatient);
                string pCode = "P" + patient.Age + patient.Id;
            aPatient.Code = pCode;
                if (rowAffected > 0)
                {
                    int rowAffected2 = aPatientGateway.Update(aPatient);
                    if (rowAffected2 > 0)
                    {
                        return "1";
                    }
                    return "3";
                }
                return "3";
            
        }

        public List<Patient> GetAllPatient()
        {
            return aPatientGateway.GetAllPatient();
        }

        public Patient GetPatientInfo(Patient aPatient)
        {
            return aPatientGateway.GetPatientInfo(aPatient);
        }

        public void DeletePatient(string contactNo)
        {
            int pId;
            Patient aPatient = aPatientGateway.GetPatient(contactNo);

            pId = aPatient.Id;
            aPatientGateway.DeleteFromBill(pId);
            aPatientGateway.DeleteFromPatientTest(pId);
            aPatientGateway.DeletePatient(contactNo);
        }

        public Patient GetPatient(string contactNo)
        {
            return aPatientGateway.GetPatient(contactNo);
        }

        public string Update(Patient aPatient)
        {

            int rowAffected = aPatientGateway.UpdatePatient(aPatient);
            if (rowAffected > 0)
            {
                return "1";
            }
            return "3";

        }

        public int GetPatientId(PatientTestVm aPatientVm)
        {
            return aPatientGateway.GetPatientId(aPatientVm);
        }

        public Patient GetPatientForPdf(int patientId)
        {
            return aPatientGateway.GetPatientForPdf(patientId);
        }
    }
}