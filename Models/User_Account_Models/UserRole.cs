using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace uHub_API.Models
{
    public class UserRole
    {
        [Required]
        [Key]
        public long RoleID { get; set; }
        [Required]
        public long? UserID { get; set; }
        [Required]
        public string? Role { get; set; }
    }
}