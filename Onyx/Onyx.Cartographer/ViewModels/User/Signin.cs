﻿using System.ComponentModel.DataAnnotations;

namespace Onyx.Cartographer.ViewModels.User
{
    public class SignIn
    {
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
        /// Checks if the User wants to be remembered ;_; pls
        /// </summary>
        [Required]
        public bool RememberMe { get; set; }
    }
}
