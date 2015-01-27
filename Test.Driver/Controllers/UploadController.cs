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
    public class UploadController : ApiController
    {
        // GET: api/Upload
        public async Task<HttpResponseMessage> Get()
        {
			return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "GET /upload is not implemented.", new HttpResponseException(HttpStatusCode.NotImplemented));
		}

		// GET: api/Upload/5
		public async Task<HttpResponseMessage> Get(int id)
        {
			return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "GET /upload/{id} is not implemented.", new HttpResponseException(HttpStatusCode.NotImplemented));
		}

		// POST: api/Upload
		[AccessControlAllowOrigin]
		public async Task<HttpResponseMessage> Post([FromBody]string state)
		{
			JObject job = JObject.Parse(state);
			int id = Convert.ToInt32(job["dynamic"]["id"]);
			UTF8Encoding encoding = new UTF8Encoding();
			string filename = HostingEnvironment.MapPath("~/TestPackages/" + id.ToString() + "/state/state.json");
			byte[] content = encoding.GetBytes(state);

			try
			{
				CheckCreateFolder(id);
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
			return Request.CreateResponse<string>(HttpStatusCode.OK, "INPROGRESS", new JsonMediaTypeFormatter());
			// return Request.CreateErrorResponse(HttpStatusCode.NotImplemented, "POST /upload is not implemented.", new HttpResponseException(HttpStatusCode.NotImplemented));
		}

		// PUT: api/Upload/5
		[AccessControlAllowOrigin]
		public async Task<HttpResponseMessage> Put(int id, [FromBody]string state)
        {
			/*
			UTF8Encoding encoding = new UTF8Encoding();
			string filename = HostingEnvironment.MapPath("~/TestPackages/" + id.ToString() + "/state/state.json");
			byte[] content = encoding.GetBytes(state);

			try
			{
				CheckCreateFolder(id);
				using (FileStream stream = File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.None))
				{
					await stream.WriteAsync(content, 0, (int)content.Length);
				}
			}
			catch (Exception e)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "File.Open() probably failed, if not will not see this: " + e.ToString(), new HttpResponseException(HttpStatusCode.InternalServerError));
			}
			*/

			// Piggy-Back some crap here
			return Request.CreateResponse<string>(HttpStatusCode.OK, "INPROGRESS", new JsonMediaTypeFormatter());
		}

		// DELETE: api/Upload/5
		public void Delete(int id)
        {
        }

		private void CheckCreateFolder(int id)
		{
			try
			{
				string stateFolder = HostingEnvironment.MapPath("~/TestPackages/" + id.ToString() + "/state");
				if (!Directory.Exists(stateFolder))
				{
					DirectoryInfo di = Directory.CreateDirectory(stateFolder);
				}
			}
			catch (Exception e)
			{
				throw e;
			}
        }
    }
}
