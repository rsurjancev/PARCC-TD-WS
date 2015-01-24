using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Test.Driver.Models
{
	public class LoginSettings
	{
		[JsonProperty(PropertyName = "maskkey")]
		public bool maskKey { get; set; }

		[JsonProperty(PropertyName = "usedob")]
		public bool useDob { get; set; }
	}

	public class ReviewSettings
	{
		[JsonProperty(PropertyName = "enabled")]
		public bool enabled { get; set; }

		[JsonProperty(PropertyName = "all")]
		public bool all { get; set; }

		[JsonProperty(PropertyName = "thumbnails")]
		public bool thumbNails { get; set; }

		[JsonProperty(PropertyName = "thumbsize")]
		public string thumbSize { get; set; }
	}

	public class PingSettings
	{
		[JsonProperty(PropertyName = "interval")]
		public int interval { get; set; }
	}

	public class UpdateSettings
	{
		[JsonProperty(PropertyName = "ping")]
		public bool ping { get; set; }

		[JsonProperty(PropertyName = "navto")]
		public bool navTo { get; set; }

		[JsonProperty(PropertyName = "navfrom")]
		public bool navFrom { get; set; }

		[JsonProperty(PropertyName = "state")]
		public bool state { get; set; }

		[JsonProperty(PropertyName = "response")]
		public bool response { get; set; }

		[JsonProperty(PropertyName = "error")]
		public bool error { get; set; }
	}

	public class ConfigurationSettings
	{
		[JsonProperty(PropertyName = "login")]
		public LoginSettings loginSettings { get; set; }

		[JsonProperty(PropertyName = "review")]
		public ReviewSettings reviewSettings { get; set; }

		[JsonProperty(PropertyName = "ping")]
		public PingSettings pingSettings { get; set; }

		[JsonProperty(PropertyName = "updateon")]
		public UpdateSettings updateSettings { get; set; }
	}
}

/*
	"config": {
		"login": {
			"maskKey": false,
			"usedob":  true
		},
		"review": {
			"enabled": false,
			"all": false,
			"thumbnails": false,
			"thumbsize": "small"
		},
		"ping": {
			"interval": "60000"
		},
		"updateon": {
			"ping": true,
			"navto": false,
			"navfrom": false,
			"state": false,
			"response": false,
			"error": false
		}
	}
*/
