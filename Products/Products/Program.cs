using Products.Common;
using System;
using System.Threading.Tasks;

namespace Products
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Megastore megastore = new Megastore("../CentralStorage.json");

            foreach(var supplier in await megastore.LoadAllSuppliers())
            {
                Console.WriteLine(supplier);
            }

            Console.WriteLine("Press any key to close the applicaion.");
            Console.ReadKey();
        }
    }
}
