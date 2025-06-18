using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Entites
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public String Type { get; set; }
        public DateTime CreateTime { get; set; }
        public String Descripation { get; set; }
        [MaxLength(20)]
        public String Image { get; set; }
        public bool? IsFav { get; set; }

        [ForeignKey("Author")]
        public int Author_id { get; set; }
        public Author Author { get; set; }
    }
}
