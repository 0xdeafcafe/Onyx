using System.ComponentModel.DataAnnotations;
using Onyx.Cartographer.Models;

namespace Onyx.Cartographer.ViewModels.Role
{
    public class AddRole
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string VisualColour { get; set; }

        [Required]
        public Roles Identifier { get; set; }
    }
}