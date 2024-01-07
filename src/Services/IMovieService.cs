using FilmeApi2.Dtos;
using FilmeApi2.Helpers;
using System.Collections.Generic;

namespace FilmeApi2.Services
{
    public interface IMovieService
    {
        ApiResponse<CreateMovie> CreateMovie(CreateMovie createMovie);
        ApiResponse<SearchMovie> SearchMovie(string title);
        ApiResponse<List<SearchGenre>> SeachGenre(string genre);

    }
}
