using System.ComponentModel.DataAnnotations;

namespace FilmeApi2.Data.Dtos
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O título do Filme é obrigatório!")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O gênero do Filme é obrigatório!")]
        [StringLength(20, ErrorMessage = "O tamanho do gênero excede o limite de caracteres!")]
        public string Genero { get; set; }
        [Required]
        [Range(70, 400, ErrorMessage = "A duração deve ter entre 70 a 400 minutos")]
        public int Duracao { get; set; }
        [Required(ErrorMessage = "O nome do elenco é obrigatório!")]
        public string Elenco { get; set; }

    }
}
