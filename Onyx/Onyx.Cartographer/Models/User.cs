using System;
using System.ComponentModel.DataAnnotations;

namespace Onyx.Cartographer.Models
{
    public class User
    {
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
        public string Email { get; set; }

        /// <summary>
        /// Boolean indicating if the User is an Administrator or not
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// The time the user registered
        /// </summary>
        public DateTime RegisterDate { get; set; }

        /// <summary>
        /// The time the user last signed in
        /// </summary>
        public DateTime LastSigninDate { get; set; }

        public User()
        {
            IsAdmin = false;
            RegisterDate = DateTime.UtcNow;
            LastSigninDate = DateTime.UtcNow;
        }
    }
}
