using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClasses
{
    // The purpose of abstract classes is so that derived classes can
    // inherit from them. Abstract classes can have abstract or non-abstract
    // fields, properties and methods. If any field, property or method is
    // abstract then its class must also be abstract. Abstract methods do not
    // provide implementation. Methods in a class that inherit from an abstract
    // class use the override keyword and provide implementation.
    public abstract class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public abstract void Draw();

        public void Copy()
        {
            Console.WriteLine("Copy shape onto clipboard");
        }

        public void Select()
        {
            Console.WriteLine("Select the shape");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a circle");
        }
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a rectangle");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle();
            circle.Draw();

            var rectangle = new Rectangle();
            rectangle.Draw();
        }
    }
}
