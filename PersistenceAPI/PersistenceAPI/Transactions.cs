using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceAPI
{
    /*
        Maybe you are executing multiple queries that should be grouped together. 
        If the last one fails, the previous ones are already executed, and suddenly your data can go corrupt. 
        Because of this, .NET Framework helps you with transactions.
        A transaction has four key properties that are referred to as ACID: 
        - Atomicity All operations are grouped together. If one fails, they all fail. 
        - Consistency Transactions bring the database from one valid state to another. 
        - Isolation Transactions can operate independently of each other. Multiple concurrent transactions won’t influence each other. It will be as if they were executed serially. 
        - Durability The result of a committed transaction is always stored permanently, even if the database crashes immediately thereafter. 
     */
    class Transactions
    {
        
        public static void Example()
        {
            string connectionString = "";// ConfigurationManager.ConnectionStrings["ProgrammingInCSharpConnection"].ConnectionString;
            using (TransactionScope transactionScope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command1 = new SqlCommand(
                    "INSERT INTO People ([FirstName], [LastName], [MiddleInitial]) VALUES('John', 'Doe', null)",
                    connection);
                    SqlCommand command2 = new SqlCommand(
                    "INSERT INTO People ([FirstName], [LastName], [MiddleInitial]) VALUES('Jane', 'Doe', null)",
                    connection);

                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                }
                transactionScope.Complete();
            }
        }

        // When you need to build a connection string dynamically - DbConnectionStringBuilder 
        public static void ExampleBuildConnectionString()
        {
            

        }

        

    }
}
