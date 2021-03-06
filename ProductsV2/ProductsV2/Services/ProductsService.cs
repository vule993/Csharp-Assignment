using ProductsV2.Common;
using ProductsV2.Models;
using ProductsV2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsV2.Services
{
    public class ProductsService : IProductService
    {
        private readonly IRepository _repository;

        public ProductsService(IRepository _repository)
        {
            this._repository = _repository;
        }

        /// <summary>
        /// Retrieves all products per supplier based on relations
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<int, Supplier>> GetProductsPerSupplier()
        {
            var data = await _repository.LoadFromJson();
            Dictionary<int, Supplier> Suppliers = new Dictionary<int, Supplier>();
            Product product;

            foreach (var relation in data.Relations)
            {
                if (!Suppliers.ContainsKey(relation.SupplierId))
                {
                    Suppliers[relation.SupplierId] = data.Suppliers.FirstOrDefault(s => s.Id == relation.SupplierId);
                }
                product = data.Products.FirstOrDefault(p => p.Id == relation.ProductId);
                Suppliers[relation.SupplierId].Products.Add(product);
            }

            return Suppliers;
        }

        /// <summary>
        /// Prints all products per supplier
        /// </summary>
        /// <param name="supplier"></param>
        public void PrintProductsPerSupplier(Supplier supplier)
        {
            foreach (var product in supplier.Products)
            {
                product.SellingPrice = product.InitialPrice + (product.InitialPrice * supplier.Markup / 100);
            }
            Console.WriteLine(supplier);
        }

    }
}
