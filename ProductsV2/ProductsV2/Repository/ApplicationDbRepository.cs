using ProductsV2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductsV2.Repository
{
    class ApplicationDbRepository
    {
        private Database _database = null;
        Dictionary<int, Supplier> Suppliers = new Dictionary<int, Supplier>();

        public ApplicationDbRepository()
        {

        }

        public async Task<Dictionary<int,Supplier>> LoadFromJson(string databaseFile)
        {
            try
            {
                using FileStream openStream = File.OpenRead(databaseFile);
                _database = await JsonSerializer.DeserializeAsync<Database>(openStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured during deserializing data... Error: {ex.Message}");
            }

            return RelationsMapping();
        }

        private Dictionary<int, Supplier> RelationsMapping()
        {
            foreach(var relation in _database.Relations)
            {
                if (!Suppliers.ContainsKey(relation.SupplierId))
                {
                    Suppliers[relation.SupplierId] = _database.Suppliers.FirstOrDefault(s => s.Id == relation.SupplierId);
                }
                Suppliers[relation.SupplierId].Products.AddRange(_database.Products.FindAll(p => p.Id == relation.ProductId));
            }

            
            return Suppliers;
        }
    }
}
