using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
