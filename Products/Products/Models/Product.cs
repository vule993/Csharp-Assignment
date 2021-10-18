using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Models
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool Available => Quantity > 0;
        public double InitialPrice { get; set; }
        public double SellingPrice { get; set; }

        public Product()
        {

        }

        public override string ToString()
        {
            string productString =
                  $"\t Product name: {Name} \n"
                + $"\t Quantity: {Quantity} \n"
                + $"\t Initial price: {InitialPrice} \n"
                + $"\t Selling price: {SellingPrice} \n"
                + $"\t --------------------------------------\n";

            return productString;
        }
    }
}
