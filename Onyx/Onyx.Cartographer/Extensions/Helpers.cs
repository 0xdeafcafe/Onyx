using System;
using System.Web;
using Onyx.Cartographer.Models;

namespace Onyx.Cartographer.Extensions
{
    public static class Helpers
    {
        public static User GetAuthenticatedUser()
        {
            var dbContext = new DatabaseContext();

            // Get Session GUID
            var sessionGuid = HttpContext.Current.Request.Cookies["SessionGuid"];
            if (sessionGuid == null)
                return null;

            // Validate Session
            var session = dbContext.Sessions.Find(Guid.Parse(sessionGuid.Value));
            if (session != null && session.Expires < DateTime.UtcNow)
                return null;

            return session == null ? null : session.User;
        }
    }
}