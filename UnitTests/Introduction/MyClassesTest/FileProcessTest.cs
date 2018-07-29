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

    private const string FILE_NAME = @"FileToDeploy.txt";

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
      if (TestContext.TestName.StartsWith("FileNameDoesExist"))
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
      if (TestContext.TestName.StartsWith("FileNameDoesExist"))
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
    [Timeout(3000)]
    [TestCategory("Other")]
    public void SimulateTimeout()
    {
      System.Threading.Thread.Sleep(2000);
    }

    [TestMethod]
    [Owner("Lincoln")]
    [DeploymentItem(FILE_NAME)]
    public void FileNameDoesExistUsingDeploymentItem()
    {
      var fileProcess = new FileProcess();

      string fileName;

      bool fromCall;

      fileName = TestContext.DeploymentDirectory + @"\" + FILE_NAME;

      TestContext.WriteLine("Checking file: " + fileName);

      fromCall = fileProcess.FileExists(fileName);

      Assert.IsTrue(fromCall);
    }

    [TestMethod]
    [Description("Check to see if a file does exist")]
    [Owner("Washington")]
    [Priority(0)]
    [TestCategory("NoException")]
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
    [Priority(0)]
    [TestCategory("NoException")]
    public void FileNameDoesNotExist()
    {
      var fileProcess = new FileProcess();

      bool fromCall = fileProcess.FileExists(BAD_FILE_NAME);

      Assert.IsFalse(fromCall);
    }

    [TestMethod]
    public void FileNameDoesExistSimpleMessage()
    {
      var fileProcess = new FileProcess();
      bool fromCall = fileProcess.FileExists(_goodFileName);

      Assert.IsTrue(fromCall, "File does exist.");
    }

    [TestMethod]
    public void FileNameDoesExistMessageWithFormatting()
    {
      var fileProcess = new FileProcess();
      bool fromCall = fileProcess.FileExists(_goodFileName);

      Assert.IsTrue(fromCall, "File '{0}' does exist.", _goodFileName);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    [Owner("Madison")]
    [Priority(1)]
    [TestCategory("Exception")]
    public void FileNameNullOrEmpty_ThrowsArgumentNullException()
    {
      var fileProcess = new FileProcess();

      fileProcess.FileExists("");
    }

    [TestMethod]
    [Owner("Jefferson")]
    [Priority(1)]
    [TestCategory("Exception")]
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
