using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Test.Driver.Models
{
	public class TestSettings
	{
		[JsonProperty(PropertyName = "id")]
		public string id { get; set; }

		[JsonProperty(PropertyName = "key")]
		public string key { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string name { get; set; }

		[JsonProperty(PropertyName = "secure")]
		public bool secure { get; set; }

		[JsonProperty(PropertyName = "package")]
		public string package { get; set; }

		[JsonProperty(PropertyName = "state")]
		public string state { get; set; }

		[JsonProperty(PropertyName = "instructions")]
		public string instructions { get; set; }
	}
}
/*
	"test": {
		"id": "test",
		"key": "TestKey1",
		"name": "Sample Exam",
		"secure": "false",
		"package": "mysecondtp.json",
		"state": "state.json",
		"instructions": "<p style='font-weight:bold; font-size:1.1em; text-align:center;'>These are the Test Instructions</p><p style='font-style:italic;'>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean euismod bibendum laoreet. Proin gravida dolor sit amet lacus accumsan et viverra justo commodo. Proin sodales pulvinar tempor. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam fermentum, nulla luctus pharetra vulputate, felis tellus mollis orci, sed rhoncus sapien nunc eget odio. Phasellus justo nunc in, bibendum mauris amet vulputate aptent sapien, sit risus vel rutrum. Vitae magna ipsum laoreet eu eu et, senectus pede tellus enim magna platea.</p>"
	},
*/