using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Test.Driver.Filters
{
	public class AccessControlAllowOriginAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			actionExecutedContext.Response.Content.Headers.Add("Access-Control-Allow-Origin", "http://dev.parcc.com");
		}
	}
}