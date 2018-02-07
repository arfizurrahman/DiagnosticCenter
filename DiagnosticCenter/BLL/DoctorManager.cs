using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Gateway;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.BLL
{

    public class DoctorManager
    {
        DoctorGateway aDoctorGateway = new DoctorGateway();

        public string Save(Doctor aDoctor)
        {
            if (aDoctorGateway.IsDoctorExists(aDoctor))
            {
                return "2";
            }
            else
            {
                int rowAffected = aDoctorGateway.Save(aDoctor);
                if (rowAffected > 0)
                {
                    return "1";
                }
                return "3";
            }
        }

        public List<Doctor> GetAllDoctor()
        {
            return aDoctorGateway.GetAllDoctor();
        }

        public Doctor GetDoctorInfo(Doctor aDoctor)
        {
            return aDoctorGateway.GetDoctorInfo(aDoctor);
        }

        public Doctor GetDoctor(string contactNo)
        {
            return aDoctorGateway.GetDoctor(contactNo);
        }

        public void DeleteDoctor(string contactNo)
        {
            aDoctorGateway.DeleteDoctor(contactNo);
        }

        public string Update(Doctor aDoctor)
        {
            
                int rowAffected = aDoctorGateway.Update(aDoctor);
                if (rowAffected > 0)
                {
                    return "1";
                }
                return "3";
            
        }
    }
}