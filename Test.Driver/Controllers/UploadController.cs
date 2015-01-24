﻿using System;
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
    public class UploadController : ApiController
    {
        // GET: api/Upload
        public async Task<HttpResponseMessage> Get()
        {
			return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "GET /state is not implemented.", new HttpResponseException(HttpStatusCode.NotImplemented));
		}

		// GET: api/Upload/5
		public async Task<HttpResponseMessage> Get(int id)
        {
			return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "GET /state is not implemented.", new HttpResponseException(HttpStatusCode.NotImplemented));
		}

		// POST: api/Upload
		[AccessControlAllowOrigin]
		public async Task<HttpResponseMessage> Post([FromBody]string state)
		{
			UTF8Encoding encoding = new UTF8Encoding();
			string filename = HostingEnvironment.MapPath("~/StateRepository/state.json");
			byte[] content = encoding.GetBytes(state);

			try
			{
				using (FileStream stream = File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.None))
				{
					await stream.WriteAsync(content, 0, (int)content.Length);
				}
			}
			catch (Exception e)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "File.Open() probably failed, if not will not see this: " + e.ToString(), new HttpResponseException(HttpStatusCode.InternalServerError));
			}

			// Piggy-Back some crap here
			return Request.CreateResponse<string>(HttpStatusCode.OK, "Da ti ne bi jebo mamu u salamu!", new JsonMediaTypeFormatter());
		}

		// PUT: api/Upload/5
		public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Upload/5
        public void Delete(int id)
        {
        }
    }
}
