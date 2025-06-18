using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Entites
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public DateOnly? BirthDate { get; set; }
        [MaxLength(6)]
        [MinLength(3)]
        public string? Gender { get; set; }
        [Range(1000, 10000)]
        public int? Salary { get; set; }

        [MaxLength(30)]
        public string Address { get; set; }
        [ForeignKey("department")]
        public int? Dep_id { get; set; }
        
        public Department department { get; set; }

        // [ForeignKey("post")]
        // public int Post_id { get; set; }
        // public Post post { get; set; }
        public ICollection<Post> post { get; set; }

    }
}
