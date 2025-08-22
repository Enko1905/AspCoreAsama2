using Demo.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Entites
{
    public class Product :EntityBase
    {
        public Product()
        {

        }

        public Product(string title, string description, decimal price, decimal discount)
        {
            Title = title;
            Description = description;
            Price = price;
            Discount = discount;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        
    }
}
