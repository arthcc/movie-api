using FilmeApi2.Dtos;
using FilmeApi2.Helpers;

namespace FilmeApi2.Services
{
    public interface IFilmeService
    {
        ApiResponse<CreateFilmeDto> CreateFilme(CreateFilmeDto createFilmeDto);
        ApiResponse<BuscarFilmeDto> BuscarFilme(string titulo);
        ApiResponse<BuscarGeneroDto> BuscarGenero(string genero);
        //Buscar Gênero feito 

    }
}
