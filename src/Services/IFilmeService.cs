using FilmeApi2.Dtos;
using FilmeApi2.Helpers;
using System.Collections.Generic;

namespace FilmeApi2.Services
{
    public interface IFilmeService
    {
        ApiResponse<CreateFilmeDto> CreateFilme(CreateFilmeDto createFilmeDto);
        ApiResponse<BuscarFilmeDto> BuscarFilme(string titulo);
        ApiResponse<List<BuscarGeneroDto>> BuscarGenero(string genero);
        //Buscar Gênero List feito 

    }
}
