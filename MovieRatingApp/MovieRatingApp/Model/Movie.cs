using System.ComponentModel.DataAnnotations;

namespace MovieRatingApp.Model
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(0, 5)]
        public int Rating { get; set; }
    }
}
