using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Test.Driver.Models
{
    public class StateSettings
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }

        [JsonProperty(PropertyName = "abbreviation")]
        public string abbreviation { get; set; }
    }

    public class NameSettings
	{
		[JsonProperty(PropertyName = "first")]
		public string first { get; set; }

		[JsonProperty(PropertyName = "middle")]
		public string middle { get; set; }

		[JsonProperty(PropertyName = "last")]
		public string last { get; set; }
	}

	public class SchoolSettings
	{
		[JsonProperty(PropertyName = "name")]
		public string name { get; set; }

		[JsonProperty(PropertyName = "city")]
		public string city { get; set; }

		[JsonProperty(PropertyName = "district")]
		public string district { get; set; }
	}

	public class CandidateSettings
	{
		[JsonProperty(PropertyName = "id")]
		public string id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public NameSettings nameSettings { get; set; }

		[JsonProperty(PropertyName = "dob")]
		public string dob { get; set; }

		[JsonProperty(PropertyName = "grade")]
		public string grade { get; set; }

		[JsonProperty(PropertyName = "school")]
		public SchoolSettings schoolSettings { get; set; }

        [JsonProperty(PropertyName = "state")]
        public StateSettings stateSettings { get; set; }
    }
}

/*
	"candidate": {
		"id": "12345678",
		"name": {
			"first": "Jane",
			"middle": "",
			"last": "Doe"
		},
		"dob": "01/01/2000",
		"grade": "3rd Grade",
		"school": {
			"name": "Stone Elementary",
			"city": "Addison",
			"district": "4"
		},
        "state": {
            "name": "Illinois",
            "abbreviation": "IL"
        }
	},
*/
