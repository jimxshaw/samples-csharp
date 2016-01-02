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
        // Constants are by definition static and must be
        // initialized when they're declared. They are "compile-time"
        // constants. Only numbers, boolean or string can be constants.
        public const double InchesPerMeter = 39.37;

        // Readonly fields are like "run-time" constants.
        // They can be optionally static. If so then they can only be
        // initialized at declaration or in a static constructor.
        // Readonly fields can be of any type. 
        public readonly decimal MinimumPrice;

        private int productId;
        private string productName;
        private string description;
        private Vendor productVendor;
        private DateTime? availabilityDate;

        public int ProductId { get; set; }

        public string ProductName
        {
            get
            {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";
                }
                else
                {
                    productName = value;
                }

            }
        }

        internal string Category { get; set; }
        public int SequenceNumber { get; set; } = 1;
        public string ProductCode => Category + "-" + SequenceNumber;
        public string ValidationMessage { get; set; }
        public string Description { get; set; }
        public DateTime? AvailabilityDate { get; set; }
        public Vendor ProductVendor
        {
            get
            {
                if (productVendor == null)
                {
                    // Objects can be initialized in the property
                    // getter. This is called lazy loading, where
                    // related objects are instantiated when they
                    // are needed but not before.
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public Product()
        {
            Console.WriteLine("Product instance created!");
            //ProductVendor = new Vendor();
            MinimumPrice = .95m;
            Category = "Tools";
        }

        public Product(int productId,
            string productName,
            string description) : this()
        {
            ProductId = productId;
            ProductName = productName;
            Description = description;

            if (ProductName.StartsWith("Bulk"))
            {
                MinimumPrice = 7.75m;
            }
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
