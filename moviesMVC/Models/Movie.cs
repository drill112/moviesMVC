using System.ComponentModel.DataAnnotations;

namespace moviesMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; } = string.Empty; 

        [StringLength(120)]
        public string? Director { get; set; }

        [StringLength(60)]
        public string? Genre { get; set; }

        [Range(1888, 2100)]
        public int Year { get; set; }

        [StringLength(300)]
        public string? PosterUrl { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }
    }
}
