using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
  [TestClass]
  public class FileProcessTest
  {
    [TestMethod]
    public void FileNameDoesExist()
    {
      var fileProcess = new FileProcess();

      bool fromCall = fileProcess.FileExists(@"C:\Windows\Regedit.exe");

      Assert.IsTrue(fromCall);

    }

    [TestMethod]
    public void FileNameDoesNotExist()
    {
      Assert.Inconclusive();
    }

    [TestMethod]
    public void FileNameNullOrEmpty_ThrowsArgumentNullException()
    {
      Assert.Inconclusive();
    }
  }
}
