using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        public Product()
        {
            Console.WriteLine("Product instance created!");
        }

        public Product(int productId, 
            string productName, 
            string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;

            Console.WriteLine("Product instance has a name: " + ProductName);
        }

        private int productId;
        private string productName;
        private string description;

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public string SayHello()
        {
            return "Hello " + 
                ProductName + 
                " (" + ProductId + "): " + 
                Description;
        }

    }
}
