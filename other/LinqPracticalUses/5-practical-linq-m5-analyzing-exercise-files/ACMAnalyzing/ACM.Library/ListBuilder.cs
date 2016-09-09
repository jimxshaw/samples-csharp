using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACM.Library
{
    public class ListBuilder
    {

        public List<int> BuildIntegerList()
        {
            List<int> integerList;

            //integerList = Enumerable.Range(0, 10).ToList();

            //integerList = Enumerable.Range(0, 10).Select(
            //                    i => 10 + (10 * i)).ToList();

            integerList = Enumerable.Repeat(-1, 10).ToList();

            return integerList;
        }

        public List<string> BuildStringList()
        {
            List<string> stringList=null;

            //stringList = Enumerable.Range(0, 10).Select(
            //                i => ((char)('A' + i)).ToString()).ToList();

            //Random rand = new Random();
            //stringList = Enumerable.Range(0, 20).Select
            //                    (i => ((char)('A' + rand.Next(0, 26))).ToString()).ToList();

            stringList = Enumerable.Repeat("A", 10).ToList();

            return stringList;
        }

        public List<int> CompareLists()
        {
            List<int> integerList = null;

            var list1 = new List<int>() { 1, 6, 8, 12, 42 };
            var list2 = new List<int>() { 2, 6, 42 };

            //integerList = list1.Intersect(list2).ToList();

            //integerList = list1.Except(list2).ToList();

            integerList = list1.Concat(list2).Distinct().OrderBy(i=>i).ToList();

            return integerList;
        }

    }
}
