using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;
using Test.Driver.Models;
using Test.Driver.Filters;

namespace Test.Driver.Controllers
{
	// [RequireHttps]
	public class LoginController : ApiController
    {
		private static Settings settings = new Settings
		{
			hostSettings = new HostSettings
			{
				getSettings = new GetSettings
				{
					baseUrl = "http://tdws.parcc.com/api/"				// "http://tdws.surjancev.net/hosting/tdws/api/"
				},
				postSettings = new PostSettings
				{
					state = "http://tdws.parcc.com/api/state/",		// "http://tdws.surjancev.net/hosting/tdws/api/state/"
					upload = "http://tdws.parcc.com/api/upload/",		// "http://tdws.surjancev.net/hosting/tdws/api/upload/"
					pause = "http://tdws.parcc.com/api/pause/",		// "http://tdws.surjancev.net/hosting/tdws/api/pause/"
					complete = "http://tdws.parcc.com/api/complete/"	// "http://tdws.surjancev.net/hosting/tdws/api/complete/"
				}
			},
			testSettings = new TestSettings
			{
				id = "1",
				key = "TestKey1",
				name = "Sample Exam",
				secure = false,
				package = "testpackage/",
				state = "state/",
				instructions = "<p style='font-weight:bold; font-size:1.1em; text-align:center;'>These are the Test Instructions</p><p style='font-style:italic;'>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean euismod bibendum laoreet. Proin gravida dolor sit amet lacus accumsan et viverra justo commodo. Proin sodales pulvinar tempor. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam fermentum, nulla luctus pharetra vulputate, felis tellus mollis orci, sed rhoncus sapien nunc eget odio. Phasellus justo nunc in, bibendum mauris amet vulputate aptent sapien, sit risus vel rutrum. Vitae magna ipsum laoreet eu eu et, senectus pede tellus enim magna platea.</p>"
			},
			candidateSettings = new CandidateSettings
			{
				id = "12345678",
				nameSettings = new NameSettings
				{
					first = "Jane",
					middle = "",
					last = "Doe"
				},
				dob = "01/01/2000",
				grade = "3rd Grade",
				schoolSettings = new SchoolSettings
				{
					name = "Stone Elementary",
					city = "Addison",
					district = "4"
				}
			},
			debugSettings = new DebugSettings
			{
				visible = true,
				style = "to-be-determined"
			},
			configurationSettings = new ConfigurationSettings
			{
				loginSettings = new LoginSettings
				{
					maskKey = true,
					useDob = true
				},
				reviewSettings = new ReviewSettings
				{
					enabled = false,
					all = false,
					thumbNails = false,
					thumbSize = "small"
				},
				pingSettings = new PingSettings
				{
					interval = 60000
				},
				updateSettings = new UpdateSettings
				{
					ping = true,
					navTo = false,
					navFrom = false,
					state = false,
					response = false,
					error = false
				}
			}
		};

        // GET: api/Login
        public async Task<HttpResponseMessage> Get()
        {
			return Request.CreateResponse<Settings>(HttpStatusCode.OK, LoginController.settings, new JsonMediaTypeFormatter());
        }

        // GET: api/Login/5
        public async Task<HttpResponseMessage> Get(int id)
        {
			return Request.CreateResponse<Settings>(LoginController.settings);
		}

		// POST: api/Login
		[AccessControlAllowOrigin]
		public async Task<HttpResponseMessage> Post([FromBody]Credentials credentials)
        {
			if (String.Compare(credentials.testKey, LoginController.settings.testSettings.key, true) == 0 && credentials.dob == LoginController.settings.candidateSettings.dob)
			{
				return Request.CreateResponse<Settings>(HttpStatusCode.OK, LoginController.settings, new JsonMediaTypeFormatter());
			}
			return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid credentials, go and ask Radovan to give you access!", new HttpResponseException(HttpStatusCode.Unauthorized));
		}

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
