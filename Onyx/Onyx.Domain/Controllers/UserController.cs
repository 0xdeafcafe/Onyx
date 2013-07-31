using System.Web.Http;
using System.Web.Mvc;

namespace Onyx.Domain.Controllers
{
    public class UserController : ApiController
    {
        // PUT api/user/xerax
        public ActionResult Put(string username, [FromBody]string password)
        {
            if (username == "onyx" && password == "fuckyotits")
            {
                return new JsonResult();
            }
            else
            {
                return new JsonResult();
            }
        }
    }
}
