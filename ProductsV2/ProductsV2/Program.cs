using ProductsV2.Repository;
using System;
using System.Threading.Tasks;

namespace ProductsV2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var repo = new ApplicationDbRepository();

            foreach(var supplierRecord in await repo.LoadFromJson("../Database.json"))
            {
                Console.WriteLine(supplierRecord.Value);
            }


            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
    }
}
