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
        private Settings CreateQATestSettings()
        {
            return new Settings
            {
                hostSettings = new HostSettings
                {
                    getSettings = new GetSettings
                    {
                        baseUrl = "http://tdws.surjancev.net/hosting/tdwsqa/api/"
                    },
                    postSettings = new PostSettings
                    {
                        state = "http://tdws.surjancev.net/hosting/tdwsqa/api/state/",
                        upload = "http://tdws.surjancev.net/hosting/tdwsqa/api/upload/",
                        pause = "http://tdws.surjancev.net/hosting/tdwsqa/api/pause/",
                        complete = "http://tdws.surjancev.net/hosting/tdwsqa/api/complete/"
                    }
                },
                testSettings = new TestSettings
                {
                    id = "1",
                    key = "TestKey1",
                    name = "Sample QA Exam",
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
                    },
                    stateSettings = new StateSettings
                    {
                        name = "Illinois",
                        abbreviation = "IL"
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
        }

        private Settings CreateDevTestSettings()
        {
            return new Settings
            {
                hostSettings = new HostSettings
                {
                    getSettings = new GetSettings
                    {
                        baseUrl = "http://tdws.surjancev.net/hosting/tdws/api/"
                    },
                    postSettings = new PostSettings
                    {
                        state = "http://tdws.surjancev.net/hosting/tdws/api/state/",
                        upload = "http://tdws.surjancev.net/hosting/tdws/api/upload/",
                        pause = "http://tdws.surjancev.net/hosting/tdws/api/pause/",
                        complete = "http://tdws.surjancev.net/hosting/tdws/api/complete/"
                    }
                },
                testSettings = new TestSettings
                {
                    id = "1",
                    key = "TestKey1",
                    name = "Sample DEV Exam",
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
                    },
                    stateSettings = new StateSettings
                    {
                        name = "Illinois",
                        abbreviation = "IL"
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
        }
        private Settings CreateGeneralTestSettings()
        {
            return new Settings
            {
                hostSettings = new HostSettings
                {
                    getSettings = new GetSettings
                    {
                        baseUrl = "http://tdws.surjancev.net/hosting/tdws/api/"
                    },
                    postSettings = new PostSettings
                    {
                        state = "http://tdws.surjancev.net/hosting/tdws/api/state/",
                        upload = "http://tdws.surjancev.net/hosting/tdws/api/upload/",
                        pause = "http://tdws.surjancev.net/hosting/tdws/api/pause/",
                        complete = "http://tdws.surjancev.net/hosting/tdws/api/complete/"
                    }
                },
                testSettings = new TestSettings
                {
                    id = "1",
                    key = "TestKey1",
                    name = "Sample General Exam",
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
                    },
                    stateSettings = new StateSettings
                    {
                        name = "Illinois",
                        abbreviation = "IL"
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
        }
        private Settings CreatePracticeTestSettings()
        {
            return new Settings
            {
                hostSettings = new HostSettings
                {
                    getSettings = new GetSettings
                    {
                        baseUrl = "http://tdws.surjancev.net/hosting/tdws/api/"
                    },
                    postSettings = new PostSettings
                    {
                        state = "http://tdws.surjancev.net/hosting/tdws/api/state/",
                        upload = "http://tdws.surjancev.net/hosting/tdws/api/upload/",
                        pause = "http://tdws.surjancev.net/hosting/tdws/api/pause/",
                        complete = "http://tdws.surjancev.net/hosting/tdws/api/complete/"
                    }
                },
                testSettings = new TestSettings
                {
                    id = "1",
                    key = "TestKey1",
                    name = "Sample Practice Exam",
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
                    },
                    stateSettings = new StateSettings
                    {
                        name = "Illinois",
                        abbreviation = "IL"
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
        }
        private Settings CreatePrivateTestSettings()
        {
            return new Settings
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
                    name = "Sample Private Exam",
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
                    },
                    stateSettings = new StateSettings
                    {
                        name = "Illinois",
                        abbreviation = "IL"
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
        }

        private static Settings settingsTemplate = new Settings
		{
			hostSettings = new HostSettings
			{
				getSettings = new GetSettings
				{
					baseUrl = "http://tdws.surjancev.net/hosting/tdws/api/"             // "http://tdws.parcc.com/api/"
				},
				postSettings = new PostSettings
				{
					state = "http://tdws.surjancev.net/hosting/tdws/api/state/",        // "http://tdws.parcc.com/api/state/",
					upload = "http://tdws.surjancev.net/hosting/tdws/api/upload/",      // "http://tdws.parcc.com/api/upload/",
					pause = "http://tdws.surjancev.net/hosting/tdws/api/pause/",        // "http://tdws.parcc.com/api/pause/",
					complete = "http://tdws.surjancev.net/hosting/tdws/api/complete/"   // "http://tdws.parcc.com/api/complete/"
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
				},
                stateSettings = new StateSettings
                {
                    name = "Illinois",
                    abbreviation = "IL"
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

        private static List<string> allowedKeys = new List<string>
        {
            "qaaaaaaaaa", "qabbbbbbbb", "qacccccccc", "qadddddddd", "qaeeeeeeee", "qaffffffff", "qagggggggg", "qahhhhhhhh", "qaiiiiiiii", "qajjjjjjjj", "qakkkkkkkk", "qallllllll",
            "qasaaaaaaa", "qasbbbbbbb", "qasccccccc", "qasddddddd", "qaseeeeeee", "qasfffffff", "qasggggggg", "qashhhhhhh", "qasiiiiiii", "qasjjjjjjj", 
            "qamaaaaaaa", "qambbbbbbb", "qamccccccc", "qamddddddd", "qameeeeeee", "qamfffffff", "qamggggggg", "qamhhhhhhh", "qamiiiiiii", "qamjjjjjjj", 
            "qalaaaaaaa", "qalbbbbbbb", "qalccccccc", "qalddddddd", "qaleeeeeee", "qalfffffff", "qalggggggg", "qalhhhhhhh", "qaliiiiiii", "qaljjjjjjj", 
            "devaaaaaaa", "devbbbbbbb", "devccccccc", "devddddddd", "deveeeeeee", "devfffffff", "devggggggg", "devhhhhhhh", "deviiiiiii", "devjjjjjjj", "devkkkkkkk", "devlllllll",
            "genaaaaaaa", "genbbbbbbb", "genccccccc", "genddddddd", "geneeeeeee", "genfffffff", "genggggggg", "genhhhhhhh", "geniiiiiii", "genjjjjjjj", "genkkkkkkk", "genlllllll",
            "practaaaaa", "practbbbbb", "practccccc", "practddddd", "practeeeee", "practfffff", "practggggg", "practhhhhh", "practiiiii", "practjjjjj", "practkkkkk", "practlllll",
            "shurecorpa", "shurecorpb"
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
            if (credentials == null || String.IsNullOrEmpty(credentials.testKey))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad request format!", new HttpResponseException(HttpStatusCode.BadRequest));
            }

            string testKey = credentials.testKey.ToLower();
            if (!LoginController.allowedKeys.Contains(testKey))
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid credentials, go ask Radovan to give you access!", new HttpResponseException(HttpStatusCode.Unauthorized));
            }

            int offset = testKey[9] - 'a';
            int registrationId = 0;
            Settings response = null;

            if (testKey.StartsWith("qa"))
            {
                response = CreateQATestSettings();
                if (testKey[2] == 's')
                {
                    registrationId = offset + 20;
                }
                else if (testKey[2] == 'm')
                {
                    registrationId = offset + 30;
                }
                else if (testKey[2] == 'l' && offset != 11)
                {
                    registrationId = offset + 40;
                }
                else
                {
                    registrationId = offset + 1;
                }
            }
            else if (testKey.StartsWith("dev"))
            {
                response = CreateDevTestSettings();
                registrationId = offset + 100 + 1;
            }
            else if (testKey.StartsWith("gen"))
            {
                response = CreateGeneralTestSettings();
                registrationId += 200 + 1;
            }
            else if (testKey.StartsWith("pract"))
            {
                response = CreatePracticeTestSettings();
                response.configurationSettings.updateSettings.ping = false;
                registrationId += 300 + 1;
            }
            else if (testKey.StartsWith("shurecorp"))
            {
                response = CreatePrivateTestSettings();
                registrationId = offset == 0 ? 11 : 121;
            }

            response.testSettings.key = credentials.testKey;
            response.testSettings.id = registrationId.ToString();
            return Request.CreateResponse<Settings>(HttpStatusCode.OK, response, new JsonMediaTypeFormatter());
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
