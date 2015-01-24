using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Test.Driver.Models
{
	public class DebugSettings
	{
		[JsonProperty(PropertyName = "visible")]
		public bool visible { get; set; }

		[JsonProperty(PropertyName = "style")]
		public string style { get; set; }
	}
}

/*
	"debug": {
		"visible": true,
		"style": "to-be-determined"
	},
*/
