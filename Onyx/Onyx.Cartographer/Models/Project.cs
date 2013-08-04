using System;
using System.ComponentModel.DataAnnotations;

namespace Onyx.Cartographer.Models
{
    public class Project
    {
        public Project()
        {
            UpdatedAt = CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
            SolutionId = Guid.NewGuid().ToString();
            StfsId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// The Id of the Project
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Name of the Project
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The Description of the Project
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// The UserId of the Creator of the Project
        /// </summary>
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        /// <summary>
        /// The Identifier that specifies which JSON file in the s3 bucket is the correct solution
        /// </summary>
        [Required]
        public string SolutionId { get; set; }

        /// <summary>
        /// The Identifier that specifies which STFS file in the s3 bucket is the correct STFS Package
        /// </summary>
        [Required]
        public string StfsId { get; set; }

        /// <summary>
        /// Identifies if the Project has been deleted or not (We never actually delete projects, just flag them)
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// The DateTime the project was created.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The DateTime the project was last updated.
        /// </summary>
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}