using System;
using System.ComponentModel.DataAnnotations;

namespace FilmeApi2.Data
{
    /// <summary>
    /// A classe de filme representa o objeto direto do banco de dados.
    /// Por isso essa classe deve ficar na camada de "DATA".
    /// Evitando que outras pessoas ao desenvolverem acabem utilizando essa classe para outros fins.
    /// </summary>
    public class Movie
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int RunTime { get; set; }
        public string Cast { get; set; }
    }
}
