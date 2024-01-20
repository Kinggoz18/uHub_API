using System.ComponentModel.DataAnnotations;
namespace uHubAPI.Models.UserAccountModels
{
    /*======================================================================
    | Account Entity class
    |
    | Name: Account.cs
    |
    | Written by: Chigozie Muonagolu - January 2024
    |
    | Purpose: Entity Class model for an App user.
    */

    /// <summary>
    ///     Class entity for an app user
    /// </summary>
    public class AppUser : EntityBaseClass
    {
        /// <summary>
        ///  A users unique identifier in the database.
        /// </summary>
        [Required]
        [Key]
        public override required long Id { get; set; }

        /// <summary>
        ///  A users account unique identifier.
        /// </summary>
        [Required]
        public required string AccountId { get; set; }

        /// <summary>
        /// The users first name
        /// </summary>
        [Required]
        public required string FirstName { get; set; }

        /// <summary>
        /// The users last name
        /// </summary>
        [Required]
        public required string LastName { get; set; }

        /// <summary>
        /// A users primary email address
        /// </summary>
        [Required]
        public required string Email { get; set; }

        /// <summary>
        /// The users Student email address. Maybe null/empty if the user has not verified their student status 
        /// </summary>
        [Required]
        public string? StudentEmail { get; set; }

        /// <summary>
        /// The users phone number
        /// </summary>
        [Required]
        public required string? PhoneNumber { get; set; }

        /// <summary>
        /// The users hashed password
        /// </summary>
        [Required]
        public required string Password { get; set; }

        /// <summary>
        /// The current verification status of a user
        /// </summary>
        [Required]
        public required string VerificationStatus { get; set; }

        /// <summary>
        /// The users profile image key
        /// </summary>
        [Required]
        public string? ImageKey { get; set; }

        /// <summary>
        /// Flag to check if a users account is locked
        /// </summary>
        [Required]
        public required bool IsLocked { get; set; }

        /// <summary>
        /// Flag to check if a users account is banned
        /// </summary>
        [Required]
        public required bool IsBanned { get; set; }

        /// <summary>
        /// Property to keep count of number of times a user has been report
        /// </summary>
        [Required]
        public required int ReportCount { get; set; }

        /// <summary>
        ///     Principal navigation to user role
        /// </summary>
        public ICollection<UserRole> UserRole { get; } = new List<UserRole>();

        /// <summary>
        ///     Principal navigation to user point
        /// </summary>
        public UserPoint? UserPoint { get; set; }

        /// <summary>
        ///     Principal navigation to Sellers Address
        /// </summary>
        public SellerAddress? SellerAddress { get; set; }

        /// <summary>
        /// Principal naviagtion to oder history
        /// </summary>
        public ICollection<OrderHistory> OrderHistory { get; } = new List<OrderHistory>();

        /// <summary>
        ///     Principal navigation to a wishlist
        /// </summary>
        public Wishlist? Wishlist { get; set; }
    }
}