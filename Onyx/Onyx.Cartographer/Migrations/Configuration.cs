using System.Linq;
using Onyx.Cartographer.Models;

namespace Onyx.Cartographer.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatabaseContext context)
        {
            // Add test account
            if (context.Users.SingleOrDefault(u => u.Username == "OnyxTest") == null)
                context.Users.Add(new User { Username = "OnyxTest", Password = "fddeca1244a9e26cc1724cb98fdab6556a5d168c", Email = "xerax@xboxchaos.com" });
        }
    }
}
