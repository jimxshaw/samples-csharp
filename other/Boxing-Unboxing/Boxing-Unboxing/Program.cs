using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Boxing and Unboxing refers to the storing of value
            // types (int, char, double, float etc) on the heap
            // rather than on the stack.
            // Boxing is the implicit conversion of a value type
            // in to a reference type.
            // Unboxing is the explicit conversion of the same reference
            // type (created by boxing) back to a value type.

            var list = new ArrayList();
            // Since list.Add() takes in a refence type, boxing occurs
            // with the int of 1 and strut of DateTime.
            // There is no type safety in this case.
            list.Add(1);
            list.Add("Hello");
            list.Add(DateTime.Now);

            // Using type collections, no boxing will occur.
            // because the user already specified the exact type.
            var anotherList = new List<int>();
            anotherList.Add(5);
            var names = new List<string>();
            names.Add("James");

            // Summary - if you're using a method that takes a parameter of
            // type object and you pass in a value type, boxing will occur.
            // This will result in a performance penalty.
        }
    }
}
