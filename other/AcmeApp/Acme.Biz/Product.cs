using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;
using static Acme.Common.LoggingService;

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
            var vendor = new Vendor();
            vendor.SendWelcomeEmail("Message from the vendor!");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product", this.ProductName, "client@xyz.org");
            var result = LogAction("Saying Hello"); // using static Acme.Common.LoggingService; 

            return "Hello " + 
                ProductName + 
                " (" + ProductId + "): " + 
                Description;
        }

    }
}
