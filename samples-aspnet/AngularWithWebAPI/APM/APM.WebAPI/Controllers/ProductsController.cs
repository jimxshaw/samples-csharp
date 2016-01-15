using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using APM.WebAPI.Models;

namespace APM.WebAPI.Controllers
{
    // First, add the valid origin designated by the angular 
    // port number. Second, add valid headers. In this case, 
    // we're allowing all headers by adding *. Third, add valid 
    // methods. In this case, we're allowing all methods such as 
    // GET, POST, PUT, DELETE etc.
    [EnableCors("http://localhost:56077", "*", "*")]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        // To use OData, first add the EnableQuery() attribute allows the use of OData syntax.
        // Second, change the return type from IEnumerable to IQueryable to enable the 
        // functionality to evaluate queries. Third, incorporate the .AsQueryable() method to 
        // ensure we're returning the IQueryable type.
        // OData works like this. EnableQuery attribute is an action filter that parses, validates 
        // and applies the query. The filter converts the query options from the OData query into a 
        // LINQ expression. When the IQueryable type returns, it processes the LINQ expression 
        // returned using an appropriate LINQ provider. Performance depends on which LINQ provider 
        // is used and on the characteristics of the data model or schema. This web api isn't using 
        // ADO.NET or Entity Framework. Instead, the productRepository is returning a set of 
        // product objects. So the LINQ provider is LINQ-to-Objects. For Entity Framework, it'll be 
        // LINQ-to-Entities.    
        [EnableQuery()]
        public IQueryable<Product> Get()
        {
            var productRepository = new ProductRepository();
            return productRepository.Retrieve().AsQueryable();
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // GET that takes in a query string or URL path from the 
        // client as a paramater. The below action mether parameter name 
        // must match the path parameter name in WebApiConfig.cs. For 
        // example, Get method's search matches {search} in the route path.  
        public IEnumerable<Product> Get(string search)
        {
            var productsRepository = new ProductRepository();
            var products = productsRepository.Retrieve();

            return products.Where(p => p.ProductCode.Contains(search));
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
