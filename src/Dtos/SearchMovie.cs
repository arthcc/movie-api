using System;

namespace FilmeApi2.Dtos
{
    public class SearchMovie
    {
        public string Title{ get; set; }
        public string Genre { get; set; }
        public int RunTime { get; set; }
        public string Cast { get; set; }
        public Guid Id { get; set; }


    }
}
