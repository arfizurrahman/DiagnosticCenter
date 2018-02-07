using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DiagnosticCenter.DAL.Model;

namespace DiagnosticCenter.DAL.Gateway
{
    public class TestTypeGateway : Gateway
    {
        public bool IsTestTypeExists(TestType aTestType)
        {
            Query = "SELECT * FROM TestType WHERE TypeName = @typeName";

            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("typeName", SqlDbType.VarChar);
            Command.Parameters["typeName"].Value = aTestType.TypeName;
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

        public int Save(TestType aTestType)
        {
            Query =
               "INSERT INTO TestType(TypeName) VALUES(@name)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = aTestType.TypeName;
          
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<TestType> GetAllTestType()
        {
            Query = "SELECT * FROM TestType ORDER BY TypeName";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();

            List<TestType> testTypes = new List<TestType>();

            while (Reader.Read())
            {
                TestType aTestType = new TestType();
                aTestType.TypeName = Reader["TypeName"].ToString();

                testTypes.Add(aTestType);
            }
            Reader.Close();
            Connection.Close();
            return testTypes;
        }

        public TestType GetType(string typeName)
        {
            Query = "SELECT * FROM TestType WHERE TypeName = @typeName";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("typeName", SqlDbType.VarChar);
            Command.Parameters["typeName"].Value = typeName;
            Reader = Command.ExecuteReader();

            TestType aTestType = null;
            if (Reader.Read())
            {
                 aTestType = new TestType();
                aTestType.Id = (int) Reader["Id"];
                aTestType.TypeName = Reader["TypeName"].ToString();

            }
            Reader.Close();
            Connection.Close();
            return aTestType;
        }

        public void DeleteFromTest(int typeId)
        {
            Query = "Delete From Test WHERE TypeId = @typeId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Add("typeId", SqlDbType.Int);
            Command.Parameters["typeId"].Value = typeId;
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public void DeleteType(string name)
        {
            Query = "Delete From TestType WHERE TypeName = @name";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = name;
            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public int UpdateTestType(TestType testType)
        {
            Query = "Update TestType SET TypeName = @name WHERE Id=@id";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = testType.TypeName;

            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = testType.Id;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}