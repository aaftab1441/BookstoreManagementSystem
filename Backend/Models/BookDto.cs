using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }
    }
}
