using System.ComponentModel.DataAnnotations;

namespace BookstoreClient.Model
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
