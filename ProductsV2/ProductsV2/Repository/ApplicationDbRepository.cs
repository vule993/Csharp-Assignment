using ProductsV2.Common;
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
    public class ApplicationDbRepository: IRepository
    {
        private Database _database = null;
        private string databaseFile = "../Database.json"; //config

        public ApplicationDbRepository()
        {

        }

        /// <summary>
        /// Loads database from JSON file
        /// </summary>
        /// <returns>Returns database populated with data</returns>
        public async Task<Database> LoadFromJson()
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

            return _database;
        }

        
    }
}
