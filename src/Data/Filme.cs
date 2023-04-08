using System.ComponentModel.DataAnnotations;

namespace FilmeApi2.Data
{
    /// <summary>
    /// A classe de filme representa o objeto direto do banco de dados.
    /// Por isso essa classe deve ficar na camada de "DATA".
    /// Evitando que outras pessoas ao desenvolverem acabem utilizando essa classe para outros fins.
    /// </summary>
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
