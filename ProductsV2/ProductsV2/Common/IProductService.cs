using ProductsV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsV2.Common
{
    public interface IProductService
    {
        Task<Dictionary<int, Supplier>> GetProductsPerSupplier();
        void PrintProductsPerSupplier(Supplier supplier);
    }
}
