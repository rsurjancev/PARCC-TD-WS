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
		private static Settings settingsTemplate = new Settings
		{
			hostSettings = new HostSettings
			{
				getSettings = new GetSettings
				{
					baseUrl = "http://tdws.parcc.com/api/"
				},
				postSettings = new PostSettings
				{
					state = "http://tdws.parcc.com/api/state/",
					upload = "http://tdws.parcc.com/api/upload/",
					pause = "http://tdws.parcc.com/api/pause/",
					complete = "http://tdws.parcc.com/api/complete/"
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
			return Request.CreateResponse<Settings>(HttpStatusCode.OK, LoginController.settingsTemplate, new JsonMediaTypeFormatter());
        }

        // GET: api/Login/5
        public async Task<HttpResponseMessage> Get(int id)
        {
			return Request.CreateResponse<Settings>(LoginController.settingsTemplate);
		}

		// POST: api/Login
		[AccessControlAllowOrigin]
		public async Task<HttpResponseMessage> Post([FromBody]Credentials credentials)
        {
			// Rules: 
			//    testkey{n} where n = 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 - real test keys, the date for those must be 01/01/2000
			//    practice - date is not important
			//    surekey{n} where n = 11, 121 - dob must be 01/11/1961 - goes against surjancev.net server
			string testKey = credentials.testKey.ToLower();
			if (testKey.StartsWith("testkey"))
			{
				int registrationId = Convert.ToInt32(testKey.Substring("testkey".Length));
				if (registrationId >= 1 && registrationId <= 10)
                {
					Settings response = new Settings(LoginController.settingsTemplate);
					response.testSettings.id = registrationId.ToString();
					response.testSettings.key = credentials.testKey;
					return Request.CreateResponse<Settings>(HttpStatusCode.OK, response, new JsonMediaTypeFormatter());
				}
			}
			else if (testKey.StartsWith("practice"))
			{
				Settings response = new Settings(LoginController.settingsTemplate);
				response.configurationSettings.updateSettings.ping = false;
				return Request.CreateResponse<Settings>(HttpStatusCode.OK, response, new JsonMediaTypeFormatter());
			}
			else if (testKey.StartsWith("surekey"))
			{
				int registrationId = Convert.ToInt32(testKey.Substring("surekey".Length));
				if (registrationId == 11 || registrationId == 121)
				{
					Settings response = new Settings(LoginController.settingsTemplate);
					response.testSettings.id = registrationId.ToString();
					response.testSettings.key = credentials.testKey;
					response.hostSettings.getSettings.baseUrl = "http://tdws.surjancev.net/hosting/tdws/api/";
					response.hostSettings.postSettings.state = "http://tdws.surjancev.net/hosting/tdws/api/state/";
					response.hostSettings.postSettings.upload = "http://tdws.surjancev.net/hosting/tdws/api/upload/";
					response.hostSettings.postSettings.pause = "http://tdws.surjancev.net/hosting/tdws/api/pause/";
					response.hostSettings.postSettings.complete = "http://tdws.surjancev.net/hosting/tdws/api/complete/";
					return Request.CreateResponse<Settings>(HttpStatusCode.OK, response, new JsonMediaTypeFormatter());
				}
			}
			return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid credentials, go ask Radovan to give you access!", new HttpResponseException(HttpStatusCode.Unauthorized));
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
