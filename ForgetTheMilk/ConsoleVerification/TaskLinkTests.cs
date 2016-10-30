using ForgetTheMilk.Models;
using NUnit.Framework;
using System;

namespace ConsoleVerification
{
    class TaskLinkTests : AssertionHelper
    {
        [Test]
        public void CreateTask_DescriptionWithLink_SetLink()
        {
            var input = "test http://www.google.com";

            var task = new Task(input, default(DateTime));

            Expect(task.Link, Is.EqualTo("http://www.google.com"));
        }
    }
}
