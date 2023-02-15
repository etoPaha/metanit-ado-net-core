using System.Threading.Tasks;

namespace N_2_4_SqlCommand
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // await Examples.N_1_Example_CreateDatabaseAsync();
            // await Examples.N_2_Example_CreateTableAsync();
            // await Examples.N_3_Example_InsertDataAsync();
            // await Examples.N_4_Example_InsertFewLinesAsync();
            // await Examples.N_5_Example_UpdateAge();
            await Examples.N_6_Example_DeleteAsync();
        }
    }
}