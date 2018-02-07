using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web;
using DiagnosticCenter.DAL.Gateway;
using DiagnosticCenter.DAL.Model;
using DiagnosticCenter.UI;

namespace DiagnosticCenter.BLL
{
    public class TestTypeManager
    {
        TestTypeGateway aTestTypeGateway = new TestTypeGateway();


        public string Save(TestType aTestType)
        {
            if (aTestTypeGateway.IsTestTypeExists(aTestType))
            {
                return "2";
            }
            else
            {
                int rowAffected = aTestTypeGateway.Save(aTestType);
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
        public List<TestType> GetAllTestType()
        {
            return aTestTypeGateway.GetAllTestType();
        }


        public TestType GetType(string typeName)
        {
            return aTestTypeGateway.GetType(typeName);
        }

        public void DeleteTestType(string name)
        {
            int typeId;
            TestType testType = aTestTypeGateway.GetType(name);

            typeId = testType.Id;
            aTestTypeGateway.DeleteFromTest(typeId);
            
            aTestTypeGateway.DeleteType(name);
        }

        public string Update(TestType testType)
        {
            int rowAffected = aTestTypeGateway.UpdateTestType(testType);
            if (rowAffected > 0)
            {
                return "1";
            }
            return "3";
        }
    }
}