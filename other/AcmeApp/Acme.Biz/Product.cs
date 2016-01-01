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
        private int _productId;
        private string _productName;
        private string _description;
        private Vendor _productVendor;
        private DateTime? _availabilityDate;

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime? AvailabilityDate { get; set; }
        public Vendor ProductVendor
        {
            get
            {
                if (_productVendor == null)
                {
                    // Objects can be initialized in the property
                    // getter. This is called lazy loading, where
                    // related objects are instantiated when they
                    // are needed but not before.
                    _productVendor = new Vendor();
                }
                return _productVendor;
            }
            set { _productVendor = value; }
        }

        public Product()
        {
            Console.WriteLine("Product instance created!");
            //ProductVendor = new Vendor();
        }

        public Product(int productId,
            string productName,
            string description) : this()
        {
            ProductId = productId;
            ProductName = productName;
            Description = description;

            Console.WriteLine("Product instance has a name: " + ProductName);
        }

        

        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from the vendor!");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product", this.ProductName, "client@xyz.org");
            var result = LogAction("Saying Hello"); // using static Acme.Common.LoggingService; 

            return "Hello " +
                   ProductName +
                   " (" + ProductId + "): " +
                   Description +
                   " Available on: " +
                   AvailabilityDate?.ToShortDateString();
        }

    }
}
