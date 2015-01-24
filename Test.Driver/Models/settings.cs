using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Test.Driver.Models
{
	public class Settings
	{
		[JsonProperty(PropertyName = "host")]
		public HostSettings hostSettings { get; set; }

		[JsonProperty(PropertyName = "test")]
		public TestSettings testSettings { get; set; }

		[JsonProperty(PropertyName = "candidate")]
		public CandidateSettings candidateSettings { get; set; }

		[JsonProperty(PropertyName = "debug")]
		public DebugSettings debugSettings { get; set; }

		[JsonProperty(PropertyName = "config")]
		public ConfigurationSettings configurationSettings { get; set; }
	}
}