using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Inv.IRepo;
using Models;

namespace WebAPI.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private IProductRepo iProducDetails;

        public ProductController(IProductRepo _iProducDetails)
        {
            this.iProducDetails = _iProducDetails;
        }

        [Authorize]
        [Route("showProduct")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            List<Product> products = iProducDetails.GetAllProducts();
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        [Authorize]
        [Route("showByID/{id:int}")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetByID(int id)
        {
            Product product = iProducDetails.GetProductById(id);
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        [Authorize]
        [Route("post")]
        [HttpPost]
        public async Task<HttpResponseMessage> Post(Product product)
        {
            iProducDetails.SaveProduct(product);
            return Request.CreateResponse(HttpStatusCode.Accepted, "Product added Successfully");
        }

        [Authorize]
        [Route("delete/{id:int}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            if (id == null || id <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Id");
            }
            iProducDetails.DeleteProduct(id);
            return Request.CreateResponse(HttpStatusCode.Accepted, "Product Deleted Successfully");
        }

        [Authorize]
        [Route("update")]
        [HttpPut]
        public async Task<HttpResponseMessage> Put(Product prod)
        {
            if (prod == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Product cannot be Empty");
            }
            iProducDetails.UpdateProduct(prod);
            return Request.CreateResponse(HttpStatusCode.Accepted, "Product Updated Successfully");
        }
    }
}
