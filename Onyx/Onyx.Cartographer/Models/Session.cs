using System;
using System.ComponentModel.DataAnnotations;

namespace Onyx.Cartographer.Models
{
    public class Session
    {
        public Session()
        {
            SessionId = Guid.NewGuid();
            Expires = DateTime.UtcNow.AddDays(2);
        }

        [Key]
        [Required]
        public Guid SessionId { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public DateTime Expires { get; set; }
    }
}
