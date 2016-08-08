using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";

            // Find the first 5 largest files within a given path. 
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("***************");
            ShowLargeFilesWithLinq(path);

        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();

            Array.Sort(files, new FileInfoComparer());

            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = new DirectoryInfo(path).GetFiles()
                        .OrderByDescending(f => f.Length).Take(5);

            foreach (FileInfo file in query)
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            // Return -1 if the first file is less than the second file.
            // Return 0 if the two files are equal.
            // Return 1 if the first file is greater than the second file.
            return y.Length.CompareTo(x.Length);
        }
    }
}
