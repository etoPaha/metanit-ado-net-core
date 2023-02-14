using System.Threading.Tasks;

namespace N_2_4_SqlCommand
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // await Examples.N_1_Example_CreateDatabaseAsync();
            // await Examples.N_2_Example_CreateTableAsync();
            await Examples.N_3_Example_InsertDataAsync();
        }
    }
}