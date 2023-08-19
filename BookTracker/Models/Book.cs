using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTracker.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public virtual Category Category { get; set; }
    }
}
