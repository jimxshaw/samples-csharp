using System;

namespace InheritanceExample
{
    // True inheritance example
    public class Text : PresentationObject
    {
        public int Fontsize { get; set; }
        public string FontName { get; set; }

        public void AddHyperlink(string url)
        {
            Console.WriteLine("We added a link to " + url);
        }    
    }
}