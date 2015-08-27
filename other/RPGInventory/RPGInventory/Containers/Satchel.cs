using RPGInventory.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory.Containers
{
    class Satchel : Item
    {
        protected int _capacity;
        protected int _currentIndex;
        protected Item[] _itemsInSatchel;

        public Satchel(int capacity)
        {
            Name = "a small brown satchel";
            Weight = 2;
            _itemsInSatchel = new Item[capacity];
            _capacity = capacity;
        }

        public virtual void AddItem(Item itemToAdd)
        {
            if (_currentIndex >= _capacity)
            {
                Console.WriteLine("The satchel is full");
            }
            else
            {
                _itemsInSatchel[_currentIndex] = itemToAdd;
                _currentIndex++;
            }
        }
        public virtual Item RemoveItem()
        {
            if (_currentIndex == 0)
            {
                Console.WriteLine("Your inventory is empty");

                return null;
            }
            else
            {
                Item itemToReturn = _itemsInSatchel[_currentIndex - 1];

                _itemsInSatchel[_currentIndex - 1] = null;
                _currentIndex--;

                return itemToReturn;
            }
        }

        public virtual void DisplayContents()
        {
            Console.WriteLine("Items in inventory: ");

            foreach (var item in _itemsInSatchel)
            {
                if (item != null)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
