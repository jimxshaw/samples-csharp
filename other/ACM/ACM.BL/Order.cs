using Acme.Common;
using System;
using System.Collections.Generic;

namespace ACM.BL
{
    public class Order : EntityBase, ILoggable
    {
        public Order()
        {

        }

        public Order(int orderId)
        {
            this.OrderId = orderId;
        }

        public int CustomerId { get; set; }
        public int ShippingAddressId { get; set; }

        public DateTimeOffset? OrderDate { get; set; }
        public int OrderId { get; private set; }
        public List<OrderItem> orderItems { get; set; }

        /// <summary>
        /// Validates the order data.
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            bool isValid = !(OrderDate == null);

            return isValid;
        }

        public override string ToString()
        {
            return OrderDate.Value.Date + " (" + OrderId + ")";
        }

        public string Log()
        {
            var logString = this.OrderId + ": " +
                            this.OrderDate + " " +
                            "CustomerId: " + this.CustomerId + " " +
                            "ShippingAddressId: " + this.ShippingAddressId.ToString();

            return logString;
        }
    }
}
