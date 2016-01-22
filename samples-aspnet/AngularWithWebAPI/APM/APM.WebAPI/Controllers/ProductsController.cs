using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.OData;
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
        //[EnableQuery()]
        //public IQueryable<Product> Get()
        //{
        //    var productRepository = new ProductRepository();
        //    return productRepository.Retrieve().AsQueryable();
        //}

        // In order to capture valid or invalid HTTP requests, we have to refactor our methods to 
        // return a specific HTTP response action result. Helper methods such as Ok() or NotFound() 
        // are used as well. Also, changing the return from IQueryable<Product> to IHttpActionResult 
        // has no effect on OData querying, which will still work fine. 
        [EnableQuery()]
        [ResponseType(typeof(Product))] // Provides asp.net web api documentation when the app is run.
        public IHttpActionResult Get()
        {
            try
            {
                var productRepository = new ProductRepository();
                return Ok(productRepository.Retrieve().AsQueryable());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Products/5
        // Once the Authorize attribute is set, our angular application won't be able to access this 
        // method unless the user has been authenticated. 
        [Authorize()]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Product product;
                var productRepository = new ProductRepository();

                if (id > 0)
                {
                    var products = productRepository.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);

                    // The NotFound() helper method is used when no product is found.
                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    product = productRepository.Create();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }


        }

        // GET that takes in a query string or URL path from the 
        // client as a paramater. The below action mether parameter name 
        // must match the path parameter name in WebApiConfig.cs. For 
        // example, Get method's search matches {search} in the route path.
        // The below overloaded Get method isn't needed because OData querying 
        // is enabled for the parameterless Get method above.  
        //public IEnumerable<Product> Get(string search)
        //{
        //    var productsRepository = new ProductRepository();
        //    var products = productsRepository.Retrieve();

        //    return products.Where(p => p.ProductCode.Contains(search));
        //}

        // POST: api/Products
        // The FromBody attribute defines to the web api that the parameter 
        // value should come from the body of the request. Otherwise, the 
        // parameter is assumed to be defined on the URL, as we saw with 
        // the GET methods. The return type is changed from void to IHttpActionResult, 
        // like the above methods, for validation purposes.
        [ResponseType(typeof(Product))]
        public IHttpActionResult Post([FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    // The BadRequest() helper method is used to setup the action result.
                    return BadRequest("Product cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    // This is to test server-side model validation.
                    return BadRequest(ModelState);
                }

                var productRepository = new ProductRepository();
                var newProduct = productRepository.Save(product);
                if (newProduct == null)
                {
                    // The product repository could return a null product if the save wasn't 
                    // successful. 
                    return Conflict();
                }

                // If the new product was saved successfully, we send a created response. 
                // The created response is generic. In this case, we're creating a product. 
                // The first argument defines the location of the created resource. It's the
                // URL that defines the link back to the new resource. The second argument is 
                // the content of the response body and includes the new product. This is 
                // required because the new product can have new values defined by the service. 
                // In this case, the services assigned a new product id. So we're sending the data 
                // for the newly created product back in the response.  
                return Created<Product>(Request.RequestUri + newProduct.ProductId.ToString(),
                    newProduct);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var productRepository = new ProductRepository();
                var updatedProduct = productRepository.Save(id, product);
                if (updatedProduct == null)
                {
                    // The product repository could return null here too but we use the NotFound() 
                    // helper method instead because we assume the save wasn't successful because 
                    // the particular product was not found.
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
