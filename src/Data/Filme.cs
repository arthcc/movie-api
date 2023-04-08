using System.ComponentModel.DataAnnotations;

namespace FilmeApi2.Data
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Genero { get; set; }
        public int Duracao { get; set; }
        public string? Elenco { get; set; }
    }
}
