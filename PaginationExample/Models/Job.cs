using System.ComponentModel.DataAnnotations;

namespace PaginationExample.Models
{
    public class Job : BaseModel
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public string Area { get; set; } = string.Empty;

        [Required]
        public double Salary { get; set; }
    }
}
