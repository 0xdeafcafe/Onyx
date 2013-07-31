using Onyx.Cartographer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Onyx.Cartographer.Controllers
{
	public class ErrorController : Controller
	{
		// GET: /Error/
		public ActionResult Index(int statusCode, Exception exception)
		{
			var error = ErrorDefinitions.ElementAtOrDefault(statusCode).Value ?? new ErrorStatusFormat();

			var model = new ErrorModel
			{
				HttpStatusCode = statusCode, 
				Exception = exception,
				HttpStatusMessagePpl = error.PeopleComment ?? "Something bad happened. I don't know what to say.",
				HttpStatusMessage = string.Format("HTTP/1.1 {0} {1}.", statusCode, error.DevComment ?? ""),
				HttpStatusMessageHeh = error.NorComment ?? ""
			};

			Response.StatusCode = statusCode;
			Response.ContentType = "text/html";
			return View(model);
		}

		#region error_codes

		public readonly static IDictionary<uint, ErrorStatusFormat> ErrorDefinitions = new Dictionary<uint, ErrorStatusFormat>
        {
            { 400, new ErrorStatusFormat { DevComment = "Bad Request", NorComment = "It's not what you said, it's how you said it" } },
			{ 401, new ErrorStatusFormat { DevComment = "Unauthorized", NorComment = "I didn't say you could put it there!" } },
			{ 403, new ErrorStatusFormat { DevComment = "Forbidden", NorComment = "Not tonight, I have a headache!" } },
			{ 404, new ErrorStatusFormat { PeopleComment = "This content sadly can't be found.", DevComment = "Not Found", NorComment = "She's left you man." } },
			{ 407, new ErrorStatusFormat { DevComment = "Proxy Authentication Required", NorComment = "Not without protection!" } },
			{ 408, new ErrorStatusFormat { DevComment = "Request Timeout", NorComment = "I want you to meet my mum." } },
			{ 409, new ErrorStatusFormat { DevComment = "Conflict", NorComment = "I CAN'T BELIEVE YOU JUST SAID THAT!" } },
			{ 429, new ErrorStatusFormat { DevComment = "Too Many Requests", NorComment = "Stop asking me out!" } },
			{ 444, new ErrorStatusFormat { DevComment = "No Response", NorComment = "Does this make me look fat?" } },
			{ 451, new ErrorStatusFormat { DevComment = "Unavailable For Legal Reasons", NorComment = "She said she was 18! I  r!" } },
			{ 500, new ErrorStatusFormat { DevComment = "Internal Server Error", NorComment = "Nope, I'm on my period." } },
			{ 501, new ErrorStatusFormat { DevComment = "Not Implemented", NorComment = "Im not on birth control" } },
			{ 502, new ErrorStatusFormat { DevComment = "Bad Gateway", NorComment = "NO NO, WRONG HOLE!" } },
			{ 503, new ErrorStatusFormat { DevComment = "Service Unavailable", NorComment = "Lets be friends" } },
			{ 504, new ErrorStatusFormat { DevComment = "Gateway Timeout", NorComment = "I'm too sex for drunk tonight" } },
			{ 505, new ErrorStatusFormat { DevComment = "HTTP Version Not Supported", NorComment = "I think i'm a lesbian" } },
			{ 506, new ErrorStatusFormat { DevComment = "HTTP Variant Also Negotiates", NorComment = "I'm bi-sexual, do you any cute female friends?" } },
			{ 507, new ErrorStatusFormat { DevComment = "Insufficient Storage", NorComment = "What do you mean my tits are too l?" } },
			{ 508, new ErrorStatusFormat { DevComment = "Loop Detected", NorComment = "It’s up to you. Swings and roundabouts." } },
			{ 509, new ErrorStatusFormat { DevComment = "HTTP Bandwidth Limit Exceeded", NorComment = "What? You want to do it N?" } },
			{ 510, new ErrorStatusFormat { DevComment = "Not Extended", NorComment = "Why is it not hard yet?" } },
			{ 511, new ErrorStatusFormat { DevComment = "HTTP Network Authentication Required", NorComment = "So, let me get right, you want to go out with the lads?" } }
        };

		#endregion
	}
}
