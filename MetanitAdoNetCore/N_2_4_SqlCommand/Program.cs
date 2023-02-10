using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace N_2_4_SqlCommand
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=master;Trusted_Connection=true;TrustServerCertificate=true;";

            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand();
                command.CommandText = "CREATE DATABASE adonetdb";
                command.Connection = connection;

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("База данных создана");
            }

            Console.ReadLine();
        }
    }
}