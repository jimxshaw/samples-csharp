﻿using Acme.Common;
using static Acme.Common.LoggingService;
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
        #region Constructors
        public Product()
        {
            #region Generic List
            //var colorOptions = new List<string>();
            //colorOptions.Add("Red");
            //colorOptions.Add("Espresso");
            //colorOptions.Add("White");
            //colorOptions.Add("Navy");
            //colorOptions.Insert(3, "Purple");
            //colorOptions.Remove("Espresso");

            var colorOptions = new List<string>
            {
                "Red",
                "Espresso",
                "Navy",
                "White"
            };

            Console.WriteLine(colorOptions);
            #endregion

            //var states = new Dictionary<string, string>();
            //states.Add("TX", "Texas");
            //states.Add("CA", "California");
            //states.Add("UT", "Utah");
            //states.Add("FL", "Florida");

            var states = new Dictionary<string, string>
            {
                { "WA", "Washington" },
                { "OR", "Oregon" },
                { "NY", "New York" }
            };

        }
        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
        }
        #endregion

        #region Properties
        public DateTime? AvailabilityDate { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        private string productName;
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

        private Vendor productVendor;
        public Vendor ProductVendor
        {
            get
            {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        #endregion

        /// <summary>
        /// Calculates the suggested retail price
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        public OperationResult<decimal> CalculateSuggestedPrice(decimal markupPercent)
        {
            var message = "";

            if (markupPercent <= 0m)
            {
                message = "Invalid markup percentage";
            }
            else if (markupPercent < 10)
            {
                message = "Below recommended markup percentage";
            }

            var result = this.Cost + (this.Cost * markupPercent / 100);

            var operationResult = new OperationResult<decimal>(result, message);

            return operationResult;

        }

        public override string ToString()
        {
            return this.ProductName + " (" + this.ProductId + ")";
        }
    }
}
