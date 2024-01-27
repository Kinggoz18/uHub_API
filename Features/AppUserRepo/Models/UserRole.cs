using System.ComponentModel.DataAnnotations;
using uHubAPI.Extensions.Models;

namespace uHubAPI.Features.AppUserRepo.Models
{
    /// <summary>
    ///    Entity class for a users role
    /// </summary>
    public class UserRole : BaseEntity
    {
        /// <summary>
        /// User role primary key
        /// </summary>
        [Key]
        public long RoleId { get; set; }

        /// <summary>
        /// User role foreign key to App user
        /// </summary>
        [Required]
        public required long UserId { get; set; }

        /// <summary>
        /// The App user role
        /// </summary>
        [Required]
        public required string Role { get; set; }

        /// <summary>
        /// App user reference navigation
        /// </summary>
        public AppUser AppUser { get; set; } = null!;
    }
}