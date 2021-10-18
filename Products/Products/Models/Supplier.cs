﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Models
{
    class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public double Markup { get; set; }

        public Supplier()
        {
            
        }

        public override string ToString()
        {
            string supplierString = $"\n Supplier name: {Name}\n";

            foreach(var product in Products)
            {
                if (product.Available)
                {
                    product.SellingPrice = product.InitialPrice + (product.InitialPrice * Markup) / 100;
                    supplierString += product;
                }
            }

            return supplierString;
        }

    }
}
