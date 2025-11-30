using System.ComponentModel.DataAnnotations;

namespace moviesMVC.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Название должно быть от 2 до 100 символов")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Укажите режиссёра")]
        [StringLength(60)]
        public string Director { get; set; }

        [Required(ErrorMessage = "Укажите жанр")]
        public string Genre { get; set; }

        [Range(1900, 2100, ErrorMessage = "Год должен быть в диапазоне 1900–2100")]
        public int Year { get; set; }

        [Url(ErrorMessage = "Введите корректный URL")]
        public string? PosterUrl { get; set; }

        [StringLength(500, ErrorMessage = "Описание не может быть длиннее 500 символов")]
        public string? Description { get; set; }

        [ProhibitWord("test", ErrorMessage = "Название не должно содержать слово 'test'")]
        public string? ValidationField { get; set; }
    }

    public class ProhibitWordAttribute : ValidationAttribute
    {
        private readonly string _word;

        public ProhibitWordAttribute(string word)
        {
            _word = word.ToLower();
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
                return true;

            return !value.ToString()!.ToLower().Contains(_word);
        }
    }
}
