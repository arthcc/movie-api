using System.ComponentModel.DataAnnotations;

namespace FilmeApi2.Dtos
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessageResourceName = "Required_Titulo", ErrorMessageResourceType = typeof(Resources))]
        public string Titulo { get; set; }

        [Required(ErrorMessageResourceName = "Required_Genero", ErrorMessageResourceType = typeof(Resources))]
        [StringLength(20, ErrorMessageResourceName = "StringLength_Genero", ErrorMessageResourceType = typeof(Resources))]
        public string Genero { get; set; }

        [Required(ErrorMessageResourceName = "Required_Duracao", ErrorMessageResourceType = typeof(Resources))]
        [Range(70, 400, ErrorMessageResourceName = "Range_Duracao", ErrorMessageResourceType = typeof(Resources))]
        public int Duracao { get; set; }

        [Required(ErrorMessageResourceName = "Required_Elenco", ErrorMessageResourceType = typeof(Resources))]
        public string Elenco { get; set; }

        [Required(ErrorMessageResourceName = "Required_Avaliacao", ErrorMessageResourceType = typeof(Resources))]
        public float Avaliacao { get; set; }
    }
}
