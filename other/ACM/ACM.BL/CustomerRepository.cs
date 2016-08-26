using System.Collections.Generic;

namespace ACM.BL
{
    public class CustomerRepository
    {
        public List<Customer> Retrieve()
        {
            return new List<Customer>();
        }

        public Customer Retrieve(int customerId)
        {
            var customer = new Customer(customerId);

            if (customerId == 1)
            {
                customer.EmailAddress = "samwisegamgee@hobbiton.me";
                customer.FirstName = "Samwise";
                customer.LastName = "Gamgee";
            }

            return customer;
        }

        public bool Save(Customer customer)
        {
            // Code that saves the defined customer.
            return true;
        }

    }
}
