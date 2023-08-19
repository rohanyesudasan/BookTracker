using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTracker.Models
{
    [Table("CategoryType")]
    public class CategoryType
    {
        [Key]
        public int Type { get; set; }
        public string Name { get; set; }

    }
}
