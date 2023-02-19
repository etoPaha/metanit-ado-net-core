using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace N_2_5_SqlDataReader
{
    public static class Examples
    {
        /// <summary>
        /// Использование SqlDataReader для чтения данных из таблицы
        /// </summary>
        public static async Task N_1_Example_UseReaderForSelect()
        {
            string connectionString = "Server=localhost;Database=adonetdb;Trusted_Connection=true;TrustServerCertificate=true;";
            string sqlExpression = "SELECT * FROM Users";
        
            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows) // есть данные
                {
                    string columnName1 = reader.GetName(0);
                    string columnName2 = reader.GetName(1);
                    string columnName3 = reader.GetName(2);
                    
                    Console.WriteLine($"{columnName1}\t{columnName3}\t{columnName2}");

                    while (await reader.ReadAsync()) // строчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(2);
                        object age = reader.GetValue(1);
                        
                        Console.WriteLine($"{id}\t{name}\t{age}");
                    }

                    await reader.CloseAsync();
                }

                Console.Read();
            }
        }

        /// <summary>
        /// Использование using для SqlDataReader
        /// </summary>
        public static async Task N_2_Example_UsingForReader()
        {
            string connectionString = "Server=localhost;Database=adonetdb;Trusted_Connection=true;TrustServerCertificate=true;";
            string sqlExpression = "SELECT * FROM Users";

            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    string columnName1 = reader.GetName(0); // id
                    string columnName2 = reader.GetName(1); // age
                    string columnName3 = reader.GetName(2); // name
                    
                    Console.WriteLine($"{columnName1}\t{columnName3}\t{columnName2}");

                    while (await reader.ReadAsync()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object age = reader.GetValue(2);
                        
                        Console.WriteLine($"{id}\t{name}\t{age}");
                    }
                }
            }
        }

        /// <summary>
        /// Использование индексатора
        /// </summary>
        public static async Task N_3_Example_ReaderIndexer()
        {
            string connectionString = "Server=localhost;Database=adonetdb;Trusted_Connection=true;TrustServerCertificate=true;";
            string sqlExpression = "SELECT * FROM Users";

            await using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                await using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    string columnName1 = reader.GetName(0); // id
                    string columnName2 = reader.GetName(1); // age
                    string columnName3 = reader.GetName(2); // name
                    
                    Console.WriteLine($"{columnName1}\t{columnName3}\t{columnName2}");

                    while (await reader.ReadAsync())
                    {
                        object id = reader["id"];
                        object age = reader["age"];
                        object name = reader["name"];
                        
                        Console.WriteLine($"{id}\t{name}\t{age}");
                    }
                }
            }

            Console.Read();
        }
    }
}