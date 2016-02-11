using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeroicCRM.Web.Utilities;

namespace HeroicCRM.Web.ActionResults
{
    // Our class derives from the standard JsonResult class.
    public class BetterJsonResult : JsonResult
    {
        // A list is created to show error messages to the client in a consistent way.  
        public IList<string> ErrorMessages { get; private set; }

        public BetterJsonResult()
        {
            ErrorMessages = new List<string>();
        }

        // A method to add error messages to the above list. 
        public void AddError(string errorMessage)
        {
            ErrorMessages.Add(errorMessage);
        }

        // Overriding the base ExecuteResult method because in addition to doing the usual 
        // uninterested stuff, it calls our SerializeData method below. 
        public override void ExecuteResult(ControllerContext context)
        {
            DoUninterestingBaseClassStuff(context);

            SerializeData(context.HttpContext.Response);
        }

        private void DoUninterestingBaseClassStuff(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                "GET".Equals(context.HttpContext.Request.HttpMethod, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    "GET access is not allowed.  Change the JsonRequestBehavior if you need GET access.");
            }

            var response = context.HttpContext.Response;
            response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/json" : ContentType;

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
        }

        // First, check if there are any error messages. If yes, we create a new anonymous object to hold 
        // two things. First thing is a concatenated list of all error messages. We do this strictly for 
        // convenience in our client-side code so if the client side wanted to do something more interest 
        // with the messages then it would be able to it. For example, format it into an unordered list etc. 
        // We set the status code to 400 to ensure our client-side code will see the response as an actual 
        // error and our client-side error handling code will fire. Finally, we serialize our data to json 
        // using our .ToJson method we wrote in JsonExtensions.cs and pass it down to the client.   
        protected virtual void SerializeData(HttpResponseBase response)
        {
            if (ErrorMessages.Any())
            {
                Data = new
                {
                    ErrorMessage = string.Join("\n", ErrorMessages),
                    ErrorMessages = ErrorMessages.ToArray()
                };

                response.StatusCode = 400;
            }

            if (Data == null) return;

            response.Write(Data.ToJson());
        }
    }

    public class BetterJsonResult<T> : BetterJsonResult
    {
        public new T Data
        {
            get { return (T)base.Data; }
            set { base.Data = value; }
        }
    }
}