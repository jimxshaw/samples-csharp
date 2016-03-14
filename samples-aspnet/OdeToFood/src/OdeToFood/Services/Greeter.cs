using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
{
    // Generally interfaces and the classes that implement the interfaces are put 
    // in separate files. 
    // The reason why we're using interfaces with services is because we want all 
    // our application components to program to interfaces. For example, developers 
    // should know if they're using a Greeter that talks to a configurable file or 
    // a database or something else. There might be multiple implementations of an 
    // interface available to the application and that interface provides a nice 
    // level of abstraction, a bit of indirection between what an application needs 
    // and the actual component that provides those features.  
    public interface IGreeter
    {
        string GetGreeting();
    }

    public class Greeter : IGreeter
    {
        private string _greeting;

        public Greeter(IConfiguration configuration)
        {
            _greeting = configuration["greeting"];
        }

        public string GetGreeting()
        {
            return _greeting;
        }
    }
}
