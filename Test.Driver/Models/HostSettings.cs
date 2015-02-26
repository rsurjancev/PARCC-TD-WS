using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Test.Driver.Models
{
	public class GetSettings
	{
        private string _value;
		[JsonProperty(PropertyName = "base")]
		public string baseUrl
        {
            get
            {
                return _value;
            }
            set
            {
                _value = String.Copy(value);
            }
        }
	}

	public class PostSettings
	{
        private string _state;
        private string _upload;
        private string _pause;
        private string _complete;

        [JsonProperty(PropertyName = "state")]
		public string state
        {
            get
            {
                return _state;
            }
            set
            {
                _state = String.Copy(value);
            }
        }

        [JsonProperty(PropertyName = "upload")]
		public string upload
        {
            get
            {
                return _upload;
            }
            set
            {
                _upload = String.Copy(value);
            }
        }

        [JsonProperty(PropertyName = "pause")]
		public string pause
        {
            get
            {
                return _pause;
            }
            set
            {
                _pause = String.Copy(value);
            }
        }

        [JsonProperty(PropertyName = "complete")]
		public string complete
        {
            get
            {
                return _complete;
            }
            set
            {
                _complete = String.Copy(value);
            }
        }
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