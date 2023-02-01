using System.Threading.Tasks;

namespace N_2_2_ConnectToMSSQL
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // await Examples.N_1_SimpleConnection();
            await Examples.N_2_UsingConstructionForConnection();
        }
    }
}