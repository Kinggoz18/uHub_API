using System.ComponentModel.DataAnnotations;
using uHubAPI.Extensions.Models;

namespace uHubAPI.Features.AppUserRepo.Models
{
    /// <summary>
    ///     Class entity for an app user
    /// </summary>
    public class AppUser : BaseEntity
    {
        /// <summary>
        /// AppUser primary key 
        /// </summary>
        [Key]
        public long UserId { get; set; }

        /// <summary>
        /// App user uuid
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// App user first name
        /// </summary>
        [Required]
        public required string FirstName { get; set; }

        /// <summary>
        /// App user last name
        /// </summary>
        [Required]
        public required string LastName { get; set; }

        /// <summary>
        /// App user primary email
        /// </summary>
        [Required]
        public required string Email { get; set; }

        /// <summary>
        /// App user student email
        /// </summary>
        public string? StudentEmail { get; set; }

        /// <summary>
        /// App user phone number
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// App user hashed password
        /// </summary>
        [Required]
        public required string Password { get; set; }

        /// <summary>
        /// App user verification status
        /// </summary>
        public string VerificationStatus { get; set; } = null!;

        /// <summary>
        /// App user profile image key/link
        /// </summary>
        public string? ImageKey { get; set; }

        /// <summary>
        /// Flag representing if App user is locked
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// Flag representing if App user is banned
        /// </summary>
        public bool IsBanned { get; set; }

        /// <summary>
        /// App user report count
        /// </summary>
        public int ReportCount { get; set; }



        // App user navigations

        /// <summary>
        /// User role principal navigation
        /// </summary>
        public ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
    }
}