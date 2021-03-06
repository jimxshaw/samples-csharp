﻿using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor
    {
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        public enum IncludeAddress { Yes, No }
        public enum SendCopy { Yes, No }

        /// <summary>
        /// Sends a product order to the vendor.
        /// </summary>
        /// <param name="product">Product to order.</param>
        /// <param name="quantity">Quantity of the product to order.</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity)
        {
            //// Guard clauses make sure passed in values are within constraints.
            //if (product == null) throw new ArgumentNullException(nameof(product));
            //if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(product));

            //var success = false;

            //var orderText = "Order from ACME, Inc" + "\n" +
            //                "Product: " + product.ProductCode + "\n" +
            //                "Quantity: " + quantity;

            //var emailService = new EmailService();
            //var confirmation = emailService.SendMessage("New Order", orderText, Email);

            //if (confirmation.StartsWith("Message sent: "))
            //{
            //    success = true;
            //}

            //var operationResult = new OperationResult(success, orderText);
            //return operationResult;

            //// Example of method chaining
            return PlaceOrder(product, quantity, null, null);
        }

        /// <summary>
        /// Sends a product order to the vendor.
        /// </summary>
        /// <param name="product">Product to order.</param>
        /// <param name="quantity">Quantity of the product to order.</param>
        /// <param name="deliverBy">Requested delivery date.</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity,
                                            DateTimeOffset? deliverBy = null)
        {
            //// Guard clauses make sure passed in values are within constraints.
            //if (product == null) throw new ArgumentNullException(nameof(product));
            //if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(product));
            //if (deliverBy <= DateTimeOffset.Now) throw new ArgumentOutOfRangeException(nameof(deliverBy));

            //var success = false;

            //var orderText = "Order from ACME, Inc" + "\n" +
            //                "Product: " + product.ProductCode + "\n" +
            //                "Quantity: " + quantity;

            //if (deliverBy.HasValue)
            //{
            //    orderText += "\n" + "Deliver By: " + deliverBy.Value.ToString("d");
            //}

            //var emailService = new EmailService();
            //var confirmation = emailService.SendMessage("New Order", orderText, Email);

            //if (confirmation.StartsWith("Message sent: "))
            //{
            //    success = true;
            //}

            //var operationResult = new OperationResult(success, orderText);
            //return operationResult;

            return PlaceOrder(product, quantity, deliverBy, null);
        }

        /// <summary>
        /// Sends a product order to the vendor.
        /// </summary>
        /// <param name="product">Product to order.</param>
        /// <param name="quantity">Quantity of the product to order.</param>
        /// <param name="deliverBy">Requested delivery date.</param>
        /// <param name="instructions">Delivery instructions</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity,
                                            DateTimeOffset? deliverBy = null,
                                            string instructions = "standard delivery")
        {
            // Guard clauses make sure passed in values are within constraints.
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(product));
            if (deliverBy <= DateTimeOffset.Now) throw new ArgumentOutOfRangeException(nameof(deliverBy));

            var success = false;

            var orderText = "Order from ACME, Inc" + "\n" +
                            "Product: " + product.ProductCode + "\n" +
                            "Quantity: " + quantity;

            if (deliverBy.HasValue)
            {
                orderText += "\n" + "Deliver By: " + deliverBy.Value.ToString("d");
            }

            if (!String.IsNullOrWhiteSpace(instructions))
            {
                orderText += "\n" + "Instructions: " + instructions;
            }

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, Email);

            if (confirmation.StartsWith("Message sent: "))
            {
                success = true;
            }

            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends a product order to the vendor.
        /// </summary>
        /// <param name="product">Product to order.</param>
        /// <param name="quantity">Quantity of the product to order.</param>
        /// <param name="includeAddress">True to include the shipping address.</param>
        /// <param name="sendCopy">True to send a copy of the email to the current email.</param>
        /// <returns>Success flag and order text.</returns>
        public OperationResult PlaceOrder(Product product, int quantity,
                                          IncludeAddress includeAddress,
                                          SendCopy sendCopy)
        {
            var orderText = "Test";
            if (includeAddress == IncludeAddress.Yes) orderText += " with Address";
            if (sendCopy == SendCopy.Yes) orderText += " with Copy";

            var operationResult = new OperationResult(true, orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message,
                                                        this.Email);
            return confirmation;
        }

        public override string ToString()
        {
            string vendorInfo = "Vendor: " + CompanyName;

            return vendorInfo;
        }
    }
}
