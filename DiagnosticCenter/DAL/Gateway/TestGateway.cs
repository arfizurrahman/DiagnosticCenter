using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.DAL.Gateway
{
    public class TestGateway : Gateway
    {
        public bool IsTestExists(TestVM aTest)
        {
            Query = "SELECT Name FROM Test WHERE Name = @name";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aTest.Name;
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }

        public int Save(TestVM test)
        {
            Query = "INSERT INTO Test VALUES(@name, @fee, @typeId)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = test.Name;

            Command.Parameters.Add("fee", SqlDbType.Decimal);
            Command.Parameters["fee"].Value = test.Fee;

            Command.Parameters.Add("typeId", SqlDbType.Int);
            Command.Parameters["typeId"].Value = test.TypeId;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<TestType> GetAllTypes()
        {
            Query = "SELECT * FROM TestType";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();

            List<TestType> Types = new List<TestType>();
            while (Reader.Read())
            {
                TestType aType = new TestType();
                aType.Id = (int)Reader["Id"];
                aType.TypeName = Reader["TypeName"].ToString();

                Types.Add(aType);
            }
            Reader.Close();
            Connection.Close();
            return Types;
        }

        public List<TestVM> GetAllTest()
        {
            Query = "SELECT t.Id,t.Name,Fee,TypeName FROM Test t INNER JOIN TestType tt ON t.TypeId = tt.Id ORDER BY t.Name";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            List<TestVM> tests = new List<TestVM>();

            while (Reader.Read())
            {
                TestVM aTest = new TestVM();
                aTest.Id = (int) Reader["Id"];
                aTest.Name = Reader["Name"].ToString();
                aTest.Fee = Convert.ToDouble(Reader["Fee"]);
                aTest.TypeName = Reader["TypeName"].ToString();

                tests.Add(aTest);
            }
            Reader.Close();
            Connection.Close();
            return tests;
        }


        public double GetSelectedTestFee(TestVM test)
        {
            Query = "SELECT Fee FROM Test WHERE Name = @name";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = test.Name;

            Reader = Command.ExecuteReader();
            TestVM aTest = null;

            while (Reader.Read())
            {
                aTest = new TestVM();

                aTest.Fee = Convert.ToDouble(Reader["Fee"]);


            }

            Reader.Close();
            Connection.Close();
            return aTest.Fee;

        }

        public TestVM GetTest(string testName)
        {
            Query = "SELECT t.Id,t.TypeId,t.Name,Fee,TypeName FROM Test t INNER JOIN TestType tt ON t.TypeId = tt.Id Where t.Name = @name";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = testName;
            Reader = Command.ExecuteReader();
            TestVM aTest = null;

            if (Reader.Read())
            {
                aTest = new TestVM();
                aTest.Id = (int)Reader["Id"];
                aTest.TypeId = (int) Reader["TypeId"];
                aTest.Name = Reader["Name"].ToString();
                aTest.Fee = Convert.ToDouble(Reader["Fee"]);
                aTest.TypeName = Reader["TypeName"].ToString();

                
            }
            Reader.Close();
            Connection.Close();
            return aTest;
        }

        public int UpdateTest(TestVM aTestVm)
        {
            Query = "Update Test SET Name = @name,Fee = @fee, TypeId = @typeId WHERE Id=@testId";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aTestVm.Name;

            Command.Parameters.Add("fee", SqlDbType.Decimal);
            Command.Parameters["fee"].Value = aTestVm.Fee;

            Command.Parameters.Add("typeId", SqlDbType.Int);
            Command.Parameters["typeId"].Value = aTestVm.TypeId;

            Command.Parameters.Add("testId", SqlDbType.Int);
            Command.Parameters["testId"].Value = aTestVm.Id;
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        
    }
}