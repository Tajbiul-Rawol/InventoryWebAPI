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

namespace WebAPI.Controllers.Category
{
    //[EnableCors(origins:"http://localhost:4200",headers:"*",methods:"*")]
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        private ICategoryRepo _iCategoryRepo;
        public CategoryController(ICategoryRepo iCategoryRepo)
        {
            this._iCategoryRepo = iCategoryRepo;
        }

        [Authorize]
        [Route("showCategories")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            List<Models.Category> categories = _iCategoryRepo.GetAllCategories();
            return Request.CreateResponse(HttpStatusCode.OK, categories);
        }

        [Authorize]
        [Route("post")]
        [HttpPost]
        public async Task<HttpResponseMessage> Post(Models.Category category)
        {
            _iCategoryRepo.SaveCategory(category);
            return Request.CreateResponse(HttpStatusCode.OK, "Category Created");
        }

        [Authorize]
        [Route("put")]
        [HttpPut]
        public async Task<HttpResponseMessage> Put(Models.Category category)
        {
            if (category == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Category cannot be Empty!");
            }
            _iCategoryRepo.UpdateCategory(category);
            return Request.CreateResponse(HttpStatusCode.Accepted, "Category updated Successfully");
        }
    }
}
