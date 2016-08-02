using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MeetHub.ViewModels
{
    // This class is used as a custom field validation annotation in our form view model.
    public class FutureDate : ValidationAttribute
    {
        // We first have to override the default IsValid method.
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "MMM d yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            // This validation rule states return true if the user input datetime object 
            // is valid and that it's in the future.
            return (isValid && dateTime > DateTime.Now);
        }
    }
}