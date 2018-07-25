using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;

namespace MyClassesTest
{
  [TestClass]
  public class FileProcessTest
  {
    private const string BAD_FILE_NAME = @"C:\BadFile.txt";

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
      var fileProcess = new FileProcess();

      bool fromCall = fileProcess.FileExists(BAD_FILE_NAME);

      Assert.IsFalse(fromCall);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FileNameNullOrEmpty_ThrowsArgumentNullException()
    {
      var fileProcess = new FileProcess();

      fileProcess.FileExists("");
    }

    [TestMethod]
    public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
    {
      var fileProcess = new FileProcess();

      try
      {
        fileProcess.FileExists("");
      }
      catch (ArgumentNullException)
      {
        // The test was successful.
        return;
      }

      Assert.Fail("Call to FileExists did not throw an argument null exception.");
    }
  }
}
