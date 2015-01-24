using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Test.Driver.Models
{
	public class GetSettings
	{
		[JsonProperty(PropertyName = "base")]
		public string baseUrl { get; set; }
	}

	public class PostSettings
	{
		[JsonProperty(PropertyName = "state")]
		public string state { get; set; }

		[JsonProperty(PropertyName = "upload")]
		public string upload { get; set; }

		[JsonProperty(PropertyName = "pause")]
		public string pause { get; set; }

		[JsonProperty(PropertyName = "complete")]
		public string complete { get; set; }
	}

	public class HostSettings
	{
		[JsonProperty(PropertyName = "get")]
		public GetSettings getSettings { get; set; }

		[JsonProperty(PropertyName = "post")]
		public PostSettings postSettings { get; set; }
	}
}

/*
{
	"host": {
		"get": {
			"base": "/samples/tests/"
		},
		"post": {
			"state": "/state/",
			"upload": "/upload/",
			"pause": "/pause/",
			"complete": "/complete/"
		}
	},
*/