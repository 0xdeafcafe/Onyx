using System;
using System.ComponentModel.DataAnnotations;

namespace Onyx.Cartographer.Models
{
    public class User
    {
        public User()
        {
            RegisterDate = DateTime.UtcNow;
            LastSigninDate = DateTime.UtcNow;
        }

        /// <summary>
        /// The User's Id (Primary Key)
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The User's Username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// The User's Password
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// The User's Email Address
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Id indicating the role of the user
        /// </summary>
        [Required]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        /// <summary>
        /// The time the user registered
        /// </summary>
        [Required]
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// The time the user last signed in
        /// </summary>
        [Required]
        public DateTime LastSigninDate { get; set; }
    }
}
