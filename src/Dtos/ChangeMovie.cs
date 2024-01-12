using System;
using System.ComponentModel.DataAnnotations;

namespace FilmeApi2.Dtos
{
    public class ChangeMovie
    {
        [Key]
        public string Title { get; set; }
        public string Genre { get; set; }
        public int RunTime { get; set; }
        public string Cast { get; set; }

    }

}