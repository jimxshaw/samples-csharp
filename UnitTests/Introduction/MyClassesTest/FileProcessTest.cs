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

    public TestContext TestContext { get; set; }

    #region Class Initialization and Cleanup
    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
      context.WriteLine("In the ClassInitialize method.");
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {

    }
    #endregion

    #region Test Initialization and Cleanup
    [TestInitialize]
    public void TestInitialize()
    {
      if (TestContext.TestName == "FileNameDoesExist")
      {
        SetGoodFileName();

        if (!string.IsNullOrEmpty(_goodFileName))
        {
          TestContext.WriteLine($"Creating File: {_goodFileName}");

          File.AppendAllText(_goodFileName, "This is some sample text.");
        }
      }
    }

    [TestCleanup]
    public void TestCleanup()
    {
      if (TestContext.TestName == "FileNameDoesExist")
      {
        if (!string.IsNullOrEmpty(_goodFileName))
        {
          TestContext.WriteLine($"Deleting File: {_goodFileName}");

          File.Delete(_goodFileName);
        }
      }
    }
    #endregion

    [TestMethod]
    [Description("Check to see if a file does exist")]
    [Owner("Washington")]
    public void FileNameDoesExist()
    {
      var fileProcess = new FileProcess();

      //SetGoodFileName();

      //TestContext.WriteLine($"Creating the File: {_goodFileName}");

      //File.AppendAllText(_goodFileName, "This is some sample text.");

      TestContext.WriteLine($"Testing the file: {_goodFileName}");

      bool fromCall = fileProcess.FileExists(_goodFileName);

      //TestContext.WriteLine($"Deleting the file: {_goodFileName}");

      //File.Delete(_goodFileName);

      Assert.IsTrue(fromCall);

    }

    [TestMethod]
    [Description("Check to see if a file does NOT exist")]
    [Owner("Washington")]
    public void FileNameDoesNotExist()
    {
      var fileProcess = new FileProcess();

      bool fromCall = fileProcess.FileExists(BAD_FILE_NAME);

      Assert.IsFalse(fromCall);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    [Owner("Madison")]
    public void FileNameNullOrEmpty_ThrowsArgumentNullException()
    {
      var fileProcess = new FileProcess();

      fileProcess.FileExists("");
    }

    [TestMethod]
    [Owner("Jefferson")]
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
