using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookTracker.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string NameToken { get; set; }
        public string Description { get; set; }
        [ForeignKey("CategoryType")]
        public int TypeId { get; set; }
        [ValidateNever]
        [NotMapped]
        public virtual CategoryType CategoryType { get; set; } = new();
    }
}
