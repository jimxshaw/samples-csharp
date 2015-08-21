using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Rectangle
    {
        private int length;
        private int width;

        public Rectangle()
        {
            Console.WriteLine("We are in the rectangle's constructor");
            length = 0;
            width = 0;
        }

        public Rectangle(int sideA, int sideB)
        {
            Console.WriteLine("This is the constructor that takes two values");
            length = sideA;
            width = sideB;
        }

        public int GetArea()
        {
            return length * width;
        }
    }
}
