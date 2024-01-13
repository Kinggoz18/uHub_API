using System.ComponentModel.DataAnnotations;

namespace uHubAPI.Models.UserAccountModels
{
    /*======================================================================
    | User Point Entity class
    |
    | Name: UserPoint.cs
    |
    | Written by: Chigozie Muonagolu - January 2023
    |      
    | Purpose: Class enity for UserPoint.
    |
    | Usage: Used in database context, service and controller classes that require it.   
    |
    |------------------------------------------------------------------ 
    */
    /// <summary>
    ///    Entity class for a users point
    /// </summary>
    public class UserPoint : EntityBaseClass
    {
        /// <summary>
        ///    The unique identifier of users point
        /// </summary>
        [Key]
        [Required]
        public override required long Id { get; set; }

        /// <summary>
        ///      The unique identifier of users that the point is associated with 
        /// </summary>
        [Required]
        public required long UserId {get; set;}

        /// <summary>
        ///    The amount of points the user has
        /// </summary>
        [Required]
        public required long UserPoints {get; set;}
    }
}