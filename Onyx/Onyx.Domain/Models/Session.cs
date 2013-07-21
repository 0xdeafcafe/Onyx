using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Onyx.Domain.Models
{
	public class Session
	{
		[Key]
		public int Id { get;set;}
		public int UserId { get; set; }
		public string SessionToken { get; set; }

		public virtual User User { get; set; }
	}
}