using System.ComponentModel.DataAnnotations;

namespace PaginationExample.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
