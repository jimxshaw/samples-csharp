using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory.Containers
{
    class Sack : Satchel
    {
        public Sack(int capacity)
            : base(capacity)
        {

        }
        public override void AddItem(Items.Item itemToAdd)
        {
            if (itemToAdd.Weight > 1)
            {
                Console.WriteLine("That item is too large for the sack.");
            }
            else
            {
                base.AddItem(itemToAdd);
            }
        }
    }
}
