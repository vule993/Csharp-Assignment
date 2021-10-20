using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsV2.Models
{
    public class Database
    {
        public List<Product> Products { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Relation> Relations { get; set; }
    }
}
