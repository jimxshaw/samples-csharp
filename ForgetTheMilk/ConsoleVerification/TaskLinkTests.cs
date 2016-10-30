using ForgetTheMilk.Controllers;
using ForgetTheMilk.Models;
using NUnit.Framework;
using System;

namespace ConsoleVerification
{
    class TaskLinkTests : AssertionHelper
    {
        class IgnoreLinkValidtor : ILinkValidator
        {
            public void Validate(string link)
            {

            }
        }

        [Test]
        public void CreateTask_DescriptionWithLink_SetLink()
        {
            var input = "test http://www.google.com";

            var task = new Task(input, default(DateTime), new IgnoreLinkValidtor());

            Expect(task.Link, Is.EqualTo("http://www.google.com"));
        }

        [Test]
        public void Validate_InvalidUrl_ThrowsException()
        {
            var input = "http://www.thisfakelinkdoesnotexist.org";

            Expect(() => new Task(input, default(DateTime), new LinkValidator()), Throws.Exception.With.Message.EqualTo($"Invalid link {input}"));
        }
    }
}
