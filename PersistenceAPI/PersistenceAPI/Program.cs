using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceAPI
{
    /*
     ADO.NET -  parts: connected and disconnected data
        connected - you explicitly connect to a database and use that as the underlying data store. 
                    You execute queries by using Structured Query Language (SQL) to create, 
                    read, update, and delete data (commonly known as CRUD operations). 
                    Connection objects, Command objects and DataReader objects. 
        disconnected -  DataSets and DataTables that mimic the structure of a relational database in memory. 
                        Changes can be sent back to the data store by using a DataAdapter.

        A .NET Framework data provider is used for connecting to a database, executing commands, and working the resulting data. 
        When working with DB firts step is Connection with help of (connection string).

        DbConnection class uses a real, unmanaged database connection, it’s important to close the connection when you’re finished with it


         */
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        //A SqlConnection with a using statement to automatically close it

        public static void Example()
        {
            string connectionString = "Persist Security Info=False;Integrated Security=true;Initial Catalog=Northwind;server=( local)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();     // Execute operations against the database 
            } // Connection is automatically closed
        }

        // When you need to build a connection string dynamically - DbConnectionStringBuilder 
        public static void ExampleBuildConnectionString()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

            sqlConnectionStringBuilder.DataSource = @"(localdb)\v11.0";
            sqlConnectionStringBuilder.InitialCatalog = "ProgrammingInCSharp";

            string connectionString = sqlConnectionStringBuilder.ToString();

        }

        //YOu can store connection string in configuration: app.config or web.config file
        public static void ExampleAccessConnectionStringFromConfiguration()
        {
            string connectionString = ""; //ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
            }
        }

        //Connecting to a database is a time-consuming operation
        //  to avoid repeatedly opening and closing connections, 
        //  ADO.NET applies an optimization that’s called connection pooling. 

        /// Steps to perform query
        ///  1. Connection
        ///  2. SQL statement
        ///  3. SqlCommand object
        ///  4. SqlCommand returns SqlDataReader 
        ///  5.  result set
        public static void ExampleAccessToDB()
        {

        }

        public async Task SelectDataFromTable()
        {
            string connectionString = ""; // ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM People", connection);
                await connection.OpenAsync();

                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                while (await dataReader.ReadAsync())
                {
                    string formatStringWithMiddleName = "Person ({0}) is named {1} {2} {3}";
                    string formatStringWithoutMiddleName = "Person ({0}) is named {1} {3}";

                    if ((dataReader["middlename"] == null))
                    {
                        Console.WriteLine(formatStringWithoutMiddleName,
                        dataReader["id"],
                        dataReader["firstname"],
                        dataReader["lastname"]);
                    }
                    else
                    {
                        Console.WriteLine(formatStringWithMiddleName,
                        dataReader["id"],
                        dataReader["firstname"],
                        dataReader["middlename"],
                        dataReader["lastname"]);
                    }
                }
                dataReader.Close();
            }
        }

    }
}
