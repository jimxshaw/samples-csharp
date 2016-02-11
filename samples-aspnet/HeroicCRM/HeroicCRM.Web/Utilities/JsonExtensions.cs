using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace HeroicCRM.Web.Utilities
{
    public static class JsonExtensions
    {
        // Method to convert any object to json. This ToJson method extends any object and it uses 
        // json.NET to convert the target object into a json string. It gives every object a .ToJson 
        // method similar to how every object already has a .ToString method. 
        public static string ToJson<T>(this T obj, bool includeNull = true)
        {
            var settings = new JsonSerializerSettings
            {
                // We're configuring the conversion to translate from PascalCase property names to 
                // camelCase property names. We're converting enums to strings rather than to 
                // numbers. Null values are included or excluded depending on the includeNull 
                // parameter, which is optional.   
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[] { new StringEnumConverter() },
                NullValueHandling = includeNull ? NullValueHandling.Include : NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}