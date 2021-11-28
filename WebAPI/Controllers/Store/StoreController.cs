using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Inv.IRepo;

namespace WebAPI.Controllers.Store
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/Store")]
    public class StoreController : ApiController
    {
        private IStoreRepo _iStoreRepoDetails;

        public StoreController(IStoreRepo iStoreRepo)
        {
            this._iStoreRepoDetails = iStoreRepo;
        }

        [Route("getStore")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "working");
        }
    }
}
