using System.ComponentModel.DataAnnotations;

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
        [Required]
        public override required long Id { get; set; }

        /// <summary>
        ///      The role the user has
        /// </summary>
        [Required]
        public required string? Role { get; set; }

        /// <summary>
        ///      The unique identifier of users that the role is associated with
        ///      one-to-many relationship with an AppUser
        /// </summary>
        [Required]
        public required long AppUserId { get; set; }

        /// <summary>
        /// Navigation reference to app user
        /// </summary>
        public AppUser AppUser { get; set; } = null!;
    }
}