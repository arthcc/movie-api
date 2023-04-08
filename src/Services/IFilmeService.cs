using FilmeApi2.Dtos;
using FilmeApi2.Helpers;

namespace FilmeApi2.Services
{
    public interface IFilmeService
    {
        ApiResponse<CreateFilmeDto> CreateFilme(CreateFilmeDto createFilmeDto);
    }
}
