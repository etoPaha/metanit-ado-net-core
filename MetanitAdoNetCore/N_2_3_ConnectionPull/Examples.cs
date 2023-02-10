using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace N_2_3_ConnectionPull
{
    public static class Examples
    {
        /// <summary>
        /// Одинаковые подключения в пулле
        /// </summary>
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

        /// <summary>
        /// Пример использования одинаковых и разных подключений у пулле
        /// </summary>
        public static async Task N_2_DifferentConnectionStrings()
        {
            string connectionString = "Server=localhost;Database=master;Trusted_Connection=true;TrustServerCertificate=true;";
            string connectionString2 = "Server=localhost;Database=metanit_View;User=test;Password=123;TrustServerCertificate=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                Console.WriteLine(connection.ClientConnectionId);
            }

            using (SqlConnection connection = new SqlConnection(connectionString2))
            {
                await connection.OpenAsync();

                Console.WriteLine(connection.ClientConnectionId);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                Console.WriteLine(connection.ClientConnectionId);
            }
            
            Console.WriteLine("Программа завершила работу");
            Console.Read();
        }
    }
}