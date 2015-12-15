using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casting
{
    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Draw()
        {

        }
    }

    public class Text : Shape
    {
        public int FontSize { get; set; }
        public string FontName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Text text = new Text();
            // Upcasting - both text and shape refence the same
            // object in memory. 
            Shape shape = text;
            // To test the reference
            text.Width = 200;
            shape.Width = 100;

            Console.WriteLine(text.Width); // 100




            StreamReader reader = new StreamReader(new MemoryStream());
            var list = new ArrayList();
            list.Add(1);
            list.Add("Joe");
            list.Add(new Text());
            var anotherList = new List<Shape>();

            Shape shape1 = new Text();
            // Downcasting - so text1 will have access to all derived class members
            Text text1 = (Text)shape;

            Console.ReadLine();
        }
    }
}
