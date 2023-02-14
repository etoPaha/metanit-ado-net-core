using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace N_2_4_SqlCommand
{
    public class Examples
    {
        /// <summary>
        /// Создание БД
        /// </summary>
        public static async Task N_1_Example_CreateDatabaseAsync()
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
        
        /// <summary>
        /// Создание таблицы 
        /// </summary>
        public static async Task N_2_Example_CreateTableAsync()
        {

            string connectionString = "Server=localhost;Database=adonetdb;Trusted_Connection=true;TrustServerCertificate=true;";

            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand();
                command.CommandText = @"
                CREATE TABLE Users (
                    Id INT PRIMARY KEY IDENTITY,
                    Age INT NOT NULL,
                    Name NVARCHAR(100) NOT NULL)";
                command.Connection = connection;

                await command.ExecuteNonQueryAsync();

                Console.WriteLine("Таблица Users создана");
            }

            Console.Read();
        }

        /// <summary>
        /// Вставка данных
        /// </summary>
        public static async Task N_3_Example_InsertDataAsync()
        {
            string connectionString = "Server=localhost;Database=adonetdb;Trusted_Connection=true;TrustServerCertificate=true;";
            string sqlExpression = "INSERT INTO Users (Name, Age) VALUES ('Tom', 36)";
            
            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();

                Console.WriteLine($"Добавлено объектов: {number}");
            }

            Console.Read();
        }

        /// <summary>
        /// Добавить несколько строк
        /// </summary>
        public static async Task N_4_Example_InsertFewLinesAsync()
        {
            var connectionString = "Server=localhost;Database=adonetdb;Trusted_Connection=true;TrustServerCertificate=true;";
            var sqlExpression = "INSERT INTO Users (Name, Age) VALUES ('Alice', 32), ('Bob', 28)";

            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = await command.ExecuteNonQueryAsync();
                
                Console.WriteLine($"Добавлено объектов: {number}");
            }

            Console.Read();
        }
    }
}