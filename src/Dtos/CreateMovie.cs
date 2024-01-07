using System;
using System.ComponentModel.DataAnnotations;

namespace FilmeApi2.Dtos
{
    public class CreateMovie
    {
        [Required(ErrorMessage = "Movie Title is required!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Movie Genre is required!")]
        [StringLength(20, ErrorMessage = "Genre name exceed the limit of characters!")]
        public string Genre { get; set; }
        [Required]
        [Range(70, 400, ErrorMessage = "Runtime must be between 70-400 minutes!")]
        public int Runtime { get; set; }
        [Required(ErrorMessage = "Cast name is required!")]
        public string Cast{ get; set; }
        public Guid? Id { get; set; }

    }
}
