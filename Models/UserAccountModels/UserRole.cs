using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uHubAPI.Models.UserAccountModels
{
    /*======================================================================
    | User Role Entity class
    |
    | Name: UserRole.cs
    |
    | Written by: Chigozie Muonagolu - January 2023
    |      
    | Purpose: Class enity for UserRole.
    |
    | Usage: Used in database context, service and controller classes that require it.   
    |
    |------------------------------------------------------------------ 
    */

    /// <summary>
    ///    Entity class for a users role
    /// </summary>
    public class UserRole : EntityBaseClass
    {
        /// <summary>
        ///      The unique identifier of users role
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        /// <summary>
        ///      The role the user has
        /// </summary>
        [Required]
        public required string? Role { get; set; }

        /// <summary>
        ///      Foreign key to an app user
        /// </summary>
        [Required]
        public required long AppUserId { get; set; }

        /// <summary>
        ///     Navigation reference to app user
        /// </summary>
        public AppUser AppUser { get; set; } = null!;
    }
}