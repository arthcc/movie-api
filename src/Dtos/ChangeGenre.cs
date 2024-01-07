using System;
using System.ComponentModel.DataAnnotations;

namespace FilmeApi2.Dtos
{
    public class ChangeGenre
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
    }

}
