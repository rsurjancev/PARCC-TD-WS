using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Test.Driver.Models;
using Test.Driver.Filters;

namespace Test.Driver.Controllers
{
    public class StateController : ApiController
    {
        // GET: api/State
        public async Task<HttpResponseMessage> Get()
        {
			return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "GET /state is not implemented.", new HttpResponseException(HttpStatusCode.NotImplemented));
		}

		// GET: api/State/5
		[AccessControlAllowOrigin]
		public async Task<HttpResponseMessage> Get(int id)
        {
            return Request.CreateResponse<string>(HttpStatusCode.NotFound, "", new JsonMediaTypeFormatter());
        }

		// POST: api/State
		public async Task<HttpResponseMessage> Post([FromBody]JObject state)
        {
			return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "POST /state is not implemented.", new HttpResponseException(HttpStatusCode.NotImplemented));
		}

		// PUT: api/State/5
		public async Task<HttpResponseMessage> Put(int id, [FromBody]string value)
        {
			return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "PUT /state/{id} is not implemented.", new HttpResponseException(HttpStatusCode.NotImplemented));
		}

		// DELETE: api/State/5
		public void Delete(int id)
        {
        }
    }
}
