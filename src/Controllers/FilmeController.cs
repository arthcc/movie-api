using FilmeApi2.Dtos;
using FilmeApi2.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;


/// <summary>
/// FilmeController deve ser "burra" e não deve ter regras de negócio.
/// Em um projeto de back-end profissional, a regra de negócio deve ser implementada em uma camada de serviço.
/// E a camada de serviço deve ser injetada na camada de controller.
/// </summary>
[ApiController]
[Route("filme")]
public class FilmeController : ControllerBase
{
    private IFilmeService _filmeService;

    public FilmeController(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }


    //Não estamos trabalhando com método asyncrono no momento
    //Mas, caso fosse necessário, basta adicionar o "async" e o "await" no método.
    //E nas chamadas de serviço, adicionar o "async" e o "await" também.
    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        var Result = _filmeService.CreateFilme(filmeDto);
        return StatusCode(Result.StatusCode, Result);
    }

    [HttpGet]
    public IActionResult BuscaFilme(string titulo)
    {
        var Result = _filmeService.BuscarFilme(titulo);
        return StatusCode(Result.StatusCode, Result);
    }
}
