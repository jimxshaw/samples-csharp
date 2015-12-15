using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverriding
{
    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Position Position { get; set; }
        //public ShapeType Type { get; set; }

        public virtual void Draw()
        {

        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            // Any code specific to the circle class itself
            Console.WriteLine("Draw a circle");
        }
    }

    public class Square : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a square");
        }
    }

    public class Hexagon : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a hexagon");
        }
    }
}
