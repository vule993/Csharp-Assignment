using Products.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Products.Common
{
    class Megastore
    {
        private readonly string _database;  //path to database

        public Megastore(string database)
        {
            _database = database;
        }

        public async Task<List<Supplier>> LoadAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            try
            {
                using FileStream openStream = File.OpenRead(_database);
                suppliers = await JsonSerializer.DeserializeAsync<List<Supplier>>(openStream);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error occured during deserializing data... Error: {ex.Message}");
            }

            return suppliers;
        } 
    }
}
