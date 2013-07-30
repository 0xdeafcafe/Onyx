using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Onyx.Domain.Controllers
{
    public class UserController : ApiController
    {
        // PUT api/user/xerax
        public string[] Put(string username, [FromBody]string value)
        {
			return new string[] { username, value };
        }
    }
}
