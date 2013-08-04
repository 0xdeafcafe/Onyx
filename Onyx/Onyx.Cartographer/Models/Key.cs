using System.ComponentModel.DataAnnotations;

namespace Onyx.Cartographer.Models
{
    public class Key
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Data { get; set; }
    }
}