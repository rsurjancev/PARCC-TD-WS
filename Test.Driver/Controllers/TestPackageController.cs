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
    public class TestPackageController : ApiController
    {
        // GET: api/TestPackage
        public async Task<HttpResponseMessage> Get()
        {
			UTF8Encoding encoding = new UTF8Encoding();
			string filename = HostingEnvironment.MapPath("~/TestPackages/mysecondtp.json");
			byte[] result;

			using (FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				result = new byte[stream.Length];
				await stream.ReadAsync(result, 0, (int)stream.Length);
			}

			string jsonResult = encoding.GetString(result);
			var jsonObject = JObject.Parse(jsonResult);
			return Request.CreateResponse<JObject>(HttpStatusCode.OK, jsonObject, new JsonMediaTypeFormatter());
		}

		// GET: api/TestPackage/5
		[AccessControlAllowOrigin]
		public async Task<HttpResponseMessage> Get(int id)
        {
			UTF8Encoding encoding = new UTF8Encoding();
			string filename = HostingEnvironment.MapPath("~/TestPackages/mysecondtp.json");
			byte[] result;

			try
			{
				using (FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					result = new byte[stream.Length];
					await stream.ReadAsync(result, 0, (int)stream.Length);
				}
			}
			catch (Exception e)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "File.Open() probably failed, if not will not see this: " + e.ToString(), new HttpResponseException(HttpStatusCode.InternalServerError));
			}

			string jsonResult = encoding.GetString(result);
			var jsonObject = JObject.Parse(jsonResult);
			return Request.CreateResponse<JObject>(HttpStatusCode.OK, jsonObject, new JsonMediaTypeFormatter());
		}

		// POST: api/TestPackage
		public void Post([FromBody]string value)
        {
        }

        // PUT: api/TestPackage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TestPackage/5
        public void Delete(int id)
        {
        }
    }
}
