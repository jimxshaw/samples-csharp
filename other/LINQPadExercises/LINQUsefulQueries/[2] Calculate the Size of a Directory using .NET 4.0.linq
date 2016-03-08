<Query Kind="Program" />

// Title: Calculate the Size of a Folder/Directory using .NET 4.0
// Link: http://www.devcurry.com/2010/07/calculate-size-of-folderdirectory-using.html
static void Main()
{
  DirectoryInfo dInfo = new DirectoryInfo(Path.GetTempPath());
  
  // set bool parameter to false if you
  // do not want to include subdirectories.
  var sizeOfDir = DirectorySize(dInfo, true);

  Console.WriteLine("Directory size in Bytes : {0:N0} Bytes", sizeOfDir);
  Console.WriteLine("Directory size in KB : {0:N2} KB", ((double)sizeOfDir) / 1024);
  Console.WriteLine("Directory size in MB : {0:N2} MB", ((double)sizeOfDir) / (1024 * 1024));
}

static long DirectorySize(DirectoryInfo dInfo, bool includeSubDir)
{
   // Enumerate all the files
   var totalSize = dInfo.EnumerateFiles().Sum(file => file.Length);

   // If Subdirectories are to be included
   if (includeSubDir)  totalSize += dInfo.EnumerateDirectories().Sum(dir => DirectorySize(dir, true));
   
   return totalSize;
}