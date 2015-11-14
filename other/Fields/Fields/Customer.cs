using System.Collections.Generic;

namespace Fields
{
    public class Customer
    {
        public int Id;
        public string Name;
        public readonly List<Order> Orders = new List<Order>();

        public Customer(int id)
        {
            this.Id = id;
        }

        public Customer(int id, string name) : this(id)
        {
            this.Name = name;
        }

        public void Promote()
        {
            // What happens if I re-initialize Orders here and the use Promote()?
            // Our list of orders will become 0.
            // To prevent this, readonly can be placed on the field above to
            // render the below line unusable as it'll cause a compile error.
            Orders = new List<Order>(); 
        }
    }
}