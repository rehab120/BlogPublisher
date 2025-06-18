using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel
{
    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]

        public string ConfirmPassword { get; set; }
        public DateOnly BirthDate { get; set; }
        [MaxLength(6)]
        [MinLength(3)]
        public string Gender { get; set; }
        [Range(1000, 10000)]
        public int Salary { get; set; }
        

    }
}
