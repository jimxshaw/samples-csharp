using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
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
        public IEnumerable<Product> Get()
        {
            var productRepository = new ProductRepository();
            return productRepository.Retrieve();
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // GET that takes in a query string from the client as a paramater:
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
