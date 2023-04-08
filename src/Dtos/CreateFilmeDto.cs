using System.ComponentModel.DataAnnotations;

namespace FilmeApi2.Dtos
{
    public class CreateFilmeDto
    {
        //Um desafio bacana para o seu projeto, será não usar texto direto igual está sendo usado nessa classe.
        //A maneira correta é utilizando ou um arquivo de recursos, ou uma classe constante para armazenar os textos.
        //Isso é importante para que o texto possa ser traduzido para outros idiomas.
        //Aqui eu não fiz para não complicar o exemplo.
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
