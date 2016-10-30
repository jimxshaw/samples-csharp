using ForgetTheMilk.Controllers;
using NUnit.Framework;

namespace ConsoleVerification
{
    public class LinkValidationTests : AssertionHelper
    {
        [Test]
        public void Validate_InvalidUrl_ThrowsException()
        {
            var invalidLink = "http://www.thisfakelinkdoesnotexist.org";

            Expect(() => new LinkValidator().Validate(invalidLink), Throws.Exception.With.Message.EqualTo($"Invalid link {invalidLink}"));
        }

        [Test]
        public void Validate_ValidUrl_DoesNotThrowException()
        {
            var validLink = "http://www.google.com";

            Expect(() => new LinkValidator().Validate(validLink), Throws.Nothing);
        }
    }
}
