using System;
using System.ComponentModel.DataAnnotations;
using Onyx.Cartographer.Models;

namespace Onyx.Cartographer.ViewModels.User
{
    public class UserAdminEdit
    {
        public UserAdminEdit()
        {
            
        }

        public UserAdminEdit(Models.User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            RoleId = user.RoleId;
            Role = user.Role;
            RegisterDate = user.RegisterDate;
            LastSigninDate = user.LastSigninDate;
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
        public Role Role { get; set; }

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
