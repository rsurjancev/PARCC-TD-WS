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
			UTF8Encoding encoding = new UTF8Encoding();
			string filename = HostingEnvironment.MapPath("~/TestPackages/" + id.ToString() + "/state/state.json");
			byte[] content;

			try
			{
				using (FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					content = new byte[stream.Length];
					await stream.ReadAsync(content, 0, (int)stream.Length);
				}
			}
			catch (Exception e)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "File.Open() probably failed, if not will not see this: " + e.ToString(), new HttpResponseException(HttpStatusCode.InternalServerError));
			}
			string jsonResult = encoding.GetString(content);
			var jsonObject = JObject.Parse(jsonResult);
			return Request.CreateResponse<JObject>(HttpStatusCode.OK, jsonObject, new JsonMediaTypeFormatter());
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
