using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Onyx.Domain.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public int ExternalId { get; set; }
	}
}
