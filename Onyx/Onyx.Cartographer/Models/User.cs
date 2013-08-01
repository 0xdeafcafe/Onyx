using System.ComponentModel.DataAnnotations;

namespace Onyx.Cartographer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
