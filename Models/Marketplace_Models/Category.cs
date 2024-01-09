using System.ComponentModel.DataAnnotations;

namespace uHub_API.Models
{
    public class Category
    {
        [Required]
        public long CategoryId {get; set; }

        [Required]
        public string Name {get; set; }

        [Required]
        public long ParentCategoryId {get; set;}
    }
}