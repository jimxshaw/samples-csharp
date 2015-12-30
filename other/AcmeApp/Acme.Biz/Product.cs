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
