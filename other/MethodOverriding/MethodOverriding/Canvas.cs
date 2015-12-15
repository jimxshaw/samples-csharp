using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverriding
{
    public class Canvas
    {
        public void DrawShapes(List<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                switch (shape.Type)
                {
                    case ShapeType.Circle:
                        Console.WriteLine("Draw a circle");
                        break;
                    case ShapeType.Square:
                        Console.WriteLine("Draw a square");
                        break;
                    case ShapeType.Hexagon:
                        Console.WriteLine("Draw a hexagon");
                        break;
                }
            }
        }
    }
}
