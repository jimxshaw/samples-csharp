using RPGInventory.Containers;
using RPGInventory.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            //SachelTest();
            //SackTest();
            RemoveTest();

            Console.ReadLine();
        }

        private static void RemoveTest()
        {
            Satchel mySatchel = new Satchel(10);

            var item1 = new Mace();
            var item2 = new Potion();
            var item3 = new Mace();

            mySatchel.AddItem(item1);
            mySatchel.AddItem(item2);
            mySatchel.AddItem(item3);

            mySatchel.DisplayContents();

            var removed = mySatchel.RemoveItem();
            Console.WriteLine("Removed {0}", removed.Name);

            mySatchel.DisplayContents();
        }

        private static void SachelTest()
        {
            Satchel mySatchel = new Satchel(10);

            var item1 = new Mace();
            var item2 = new Potion();

            mySatchel.AddItem(item1);
            mySatchel.AddItem(item2);

            mySatchel.DisplayContents();
        }

        private static void SackTest()
        {
            Sack sack = new Sack(4);

            var item1 = new Mace();
            var item2 = new Potion();

            sack.AddItem(item1);
            sack.AddItem(item2);

            sack.DisplayContents();
        }
    }
}
