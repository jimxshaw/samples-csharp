using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
  [TestClass]
  public class FileProcessTest
  {
    private const string BAD_FILE_NAME = @"C:\BadFile.txt";

    private string _goodFileName;

    [TestMethod]
    public void FileNameDoesExist()
    {
      var fileProcess = new FileProcess();

      SetGoodFileName();

      File.AppendAllText(_goodFileName, "This is some sample text.");

      bool fromCall = fileProcess.FileExists(_goodFileName);

      File.Delete(_goodFileName);

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

    public void SetGoodFileName()
    {
      _goodFileName = ConfigurationManager.AppSettings["GoodFileName"];

      if (_goodFileName.Contains("[AppPath]"))
      {
        _goodFileName = _goodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
      }
    }
  }
}
