using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace N_2_2_ConnectToMSSQL
{
    public class Examples
    {
        public static async Task N_1_SimpleConnection()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=true;";

            // Создаем подключение
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключиние
                await connection.OpenAsync();
                
                Console.WriteLine("Подключение открыто");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // если подключение открыто
                if (connection.State == ConnectionState.Open)
                {
                    // закрываем подключение
                    await connection.CloseAsync();

                    Console.WriteLine("Подключение закрыто...");
                }
            }

            Console.WriteLine("Программа завершила работу");
            Console.Read();
        }

        public static async Task N_2_UsingConstructionForConnection()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                Console.WriteLine("Подключение открыто");
            }
            
            Console.WriteLine("Подключение закрыто...");
            
            Console.WriteLine("Программа завершила работу.");
            Console.Read();
        }

        /// <summary>
        /// Получение информации о подключении
        /// </summary>
        public static async Task N_3_SlqConnectionInformation()
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_COnnection=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                Console.WriteLine("Подключение открыто");
                
                // Информация о подключении
                Console.WriteLine("Свойства подключения:");

                Console.WriteLine($"\tСтрока подключения: {connection.ConnectionString}");
                Console.WriteLine($"\tБаза данных: {connection.Database}");
                Console.WriteLine($"\tСервер: {connection.DataSource}");
                Console.WriteLine($"\tВерсия сервера: {connection.ServerVersion}");
                Console.WriteLine($"\tСостояние: {connection.State}");
                Console.WriteLine($"\tWorkstationId: {connection.WorkstationId}");
            }

            Console.WriteLine("Подключение закрыто...");
            Console.WriteLine("Программа завершила работу.");
            
            Console.Read();
        }
    }
}