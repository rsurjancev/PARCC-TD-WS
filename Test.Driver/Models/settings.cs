using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Test.Driver.Models
{
	public class Settings
	{
		public Settings() { }
		public Settings(Settings rval)
		{
			hostSettings = rval.hostSettings;
			testSettings = rval.testSettings;
			candidateSettings = rval.candidateSettings;
			debugSettings = rval.debugSettings;
			configurationSettings = rval.configurationSettings;
		}

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