using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Entites;

namespace WebApplication1.Models.Entites
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public ICollection<Author> author { get; set; }
    }
}
