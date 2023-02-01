using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace N_2_3_ConnectionPull
{
    public static class Examples
    {
        public static async Task N_1_FirstExample()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=true;";
        
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                Console.WriteLine(connection.ClientConnectionId);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                Console.WriteLine(connection.ClientConnectionId);
            }

            Console.WriteLine("Программа завершила работу.");
            Console.Read();
        }
        
        
    }
}