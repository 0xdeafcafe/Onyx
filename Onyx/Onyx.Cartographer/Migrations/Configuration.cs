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
            // Add Default Roles
            if (!context.Roles.Any())
            {
                context.Roles.Add(new Role { Name = "Administrator", Description = "An Onyx Administrator", Identifier = Roles.Administrator, VisualColour = "FF0000" });
                context.Roles.Add(new Role { Name = "Moderator", Description = "An Onyx Moderator", Identifier = Roles.Moderator, VisualColour = "0033CC" });
                context.Roles.Add(new Role { Name = "User", Description = "A Regular User", Identifier = Roles.PrimaryUser, VisualColour = "C0C0C0" });
            }

            // Add Test Account
            if (!context.Users.Any())
                context.Users.Add(new User { Username = "OnyxTest", Password = "1000:c1JY6wtgSaAoIL2b8TDp7MCJeMyDO4A/:fkGpJleo1noIkvhC6gzHM4vNZjPMr0mz", Email = "xerax@xboxchaos.com", RoleId = context.Roles.First(r => r.Identifier == Roles.Administrator).Id });
        }
    }
}
