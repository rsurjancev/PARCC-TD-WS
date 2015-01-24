using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Test.Driver.Models
{
	public class Credentials
	{
		[JsonProperty(PropertyName = "testkey")]
		public string testKey { get; set; }

		[JsonProperty(PropertyName = "dob")]
		public string dob { get; set; }
	}
}