using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductsV2.Common;
using ProductsV2.Models;
using ProductsV2.Repository;
using ProductsV2.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsV2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            var productService = host.Services.GetRequiredService<IProductService>();

            var suppliers = await productService.GetProductsPerSupplier ();
            foreach(var supplier in suppliers)
            {
                productService.PrintProductsPerSupplier(supplier.Value);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            return;
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<IProductService, ProductsService>()
                            .AddTransient<IRepository, ApplicationDbRepository>()
        );
    }
}
