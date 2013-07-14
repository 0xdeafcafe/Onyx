using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Onyx.Cartographer.Models
{
	public class ErrorModel
	{
		public int HttpStatusCode { get; set; }
		public Exception Exception { get; set; }
		public string HttpStatusMessage { get; set; }
	}

	public class ErrorStatusFormat
	{
		public int ErrorCode { get; set; }

		public string DevComment { get; set; }
		public string NorComment { get; set; }
	}
}