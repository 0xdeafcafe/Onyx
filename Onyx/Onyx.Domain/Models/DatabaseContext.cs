using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Onyx.Domain.Models
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext() : base("name=DefaultConnection") { }

		public DbSet<User> Users { get; set; }
		public DbSet<Session> Sessions { get; set; }
	}
}
