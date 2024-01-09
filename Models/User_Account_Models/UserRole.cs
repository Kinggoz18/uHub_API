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
        public long RoleID;
        [Required]
        public long? UserID;
        [Required]
        public string? Role;
    }
}