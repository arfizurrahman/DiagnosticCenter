using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Gateway;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.BLL
{
    public class TestManager
    {
        TestGateway aTestGateway = new TestGateway();
        PatientTestGateway aPatientTestGateway = new PatientTestGateway();
        PatientGateway aPatientGateway = new PatientGateway();

        public string Save(TestVM aTest)
        {
            if (aTestGateway.IsTestExists(aTest))
            {
                return "2";
            }
            else
            {
                int rowAffected = aTestGateway.Save(aTest);
                if (rowAffected > 0)
                {
                    return "1";
                }
                else
                {
                    return "3";
                }
            }
        }

        public List<TestType> GetAllTypes()
        {
            return aTestGateway.GetAllTypes();
        }

        public List<TestVM> GetAllTest()
        {
            return aTestGateway.GetAllTest();
        }

        public double GetSelectedTestFee(TestVM test)
        {
            return aTestGateway.GetSelectedTestFee(test);
        }


        public TestVM GetTest(string testName)
        {
            return aTestGateway.GetTest(testName);
        }

        public string Update(TestVM aTestVm)
        {
            int rowAffected = aTestGateway.UpdateTest(aTestVm);
            if (rowAffected > 0)
            {
                return "1";
            }
            return "3";
        }

        public void DeleteTest(string name)
        {
            int tId;
            TestVM test = aTestGateway.GetTest(name);

            tId = test.Id;
            aPatientTestGateway.DeleteFromPatientTest(tId);
            
            aPatientGateway.DeleteTest(tId);
        }
    }
}