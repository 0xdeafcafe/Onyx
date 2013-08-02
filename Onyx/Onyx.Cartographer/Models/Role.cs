using System.ComponentModel.DataAnnotations;

namespace Onyx.Cartographer.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        [Required]
        public string RoleDescription { get; set; }

        [Required]
        public string RoleVisualColour { get; set; }

        [Required]
        public Roles RoleIdentifier { get; set; }
    }

    public enum Roles
    {
        Administrator,
        Moderator
    }
}
