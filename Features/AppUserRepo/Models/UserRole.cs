using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uHubAPI.Features.AppUserRepo.Models
{
    /// <summary>
    ///    Entity class for a users role
    /// </summary>
    public class UserRole 
    {
        /// <summary>
        /// User role primary key
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RoleId { get; set; }

        /// <summary>
        /// User role foreign key to App user
        /// </summary>
        [Required]
        public required long AppUserId { get; set; }

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