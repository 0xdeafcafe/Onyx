using System.ComponentModel.DataAnnotations;

namespace Onyx.Cartographer.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string VisualColour { get; set; }

        [Required]
        public Roles Identifier { get; set; }
    }

    public enum Roles
    {
        Administrator,
        Moderator,
        PrimaryUser
    }
}
