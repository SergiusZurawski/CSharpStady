using System;
using System.Data;
using System.Data.SqlClient;

namespace DBInteraction
{
    class Program
    {
        private static string _connectionString = "Data Source = Computer; Initial Catalog = testdemodb_serg1; Integrated Security = True; Connection Timeout = 30";
        static void Main(string[] args)
        {
            PerfromUpdateCall(1, "1");
        }

        private static void PerfromUpdateCall(int authorizationIdHash,string patientMemberId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var comm = new SqlCommand(
                    "UPDATE [auth].[tblAuthorization] SET [PatientMemberId]=@PatientMemberId WHERE AuthorizationIdHash=@ID",
                    conn);
                comm.Parameters.Add("@ID", SqlDbType.BigInt);
                comm.Parameters.Add("@PatientMemberId", SqlDbType.VarChar);
                comm.Parameters["@ID"].Value = authorizationIdHash;
                comm.Parameters["@PatientMemberId"].Value = patientMemberId;
                comm.ExecuteNonQuery();
            }
        }
        
        private static void ReadData(int authorizationIdHash,string patientMemberId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var comm = new SqlCommand(
                    "UPDATE [auth].[tblAuthorization] SET [PatientMemberId]=@PatientMemberId WHERE AuthorizationIdHash=@ID",
                    conn);
                comm.Parameters.Add("@ID", SqlDbType.BigInt);
                comm.Parameters.Add("@PatientMemberId", SqlDbType.VarChar);
                comm.Parameters["@ID"].Value = authorizationIdHash;
                comm.Parameters["@PatientMemberId"].Value = patientMemberId;
                comm.ExecuteNonQuery();
            }
        }
    }
}
