using FilmeApi2.Dtos;
using FilmeApi2.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("filme")]
public class FilmeController : ControllerBase
{
    private IFilmeService _filmeService;

    public FilmeController(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        var result = _filmeService.CreateFilme(filmeDto);
        return StatusCode(result.StatusCode, result);
    }

    //[HttpGet]
    //public IEnumerable<Filme> LerFime([FromQuery] int skip = 0,
    //    [FromQuery] int take = 50)
    //{
    //    return _conext.Filmes.Skip(skip).Take(take);
    //}

    //[HttpGet("{id}")]
    //public IActionResult RecuperaPorId(int id)
    //{
    //    var filme = _conext.Filmes.FirstOrDefault(filme => filme.Id == id);
    //    if (filme == null) return NotFound();
    //    return Ok(filme);
    //}

    //[HttpPut("{id}")]
    //public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    //{
    //    var filme = _conext.Filmes.FirstOrDefault(
    //        filme => filme.Id == id);
    //    if (filme == null) return NotFound();
    //    _mapper.Map(filmeDto, filme);
    //    _conext.SaveChanges();
    //    return NoContent();
    //}

    //[HttpPatch("{id}")]
    //public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    //{
    //    var filme = _conext.Filmes.FirstOrDefault(
    //        filme => filme.Id == id);
    //    if (filme == null) return NotFound();

    //    var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
    //    patch.ApplyTo(filmeParaAtualizar, ModelState);

    //    if (!TryValidateModel(filmeParaAtualizar))
    //    {
    //        return ValidationProblem(ModelState);
    //    }

    //    _mapper.Map(filmeParaAtualizar, filme);
    //    _conext.SaveChanges();
    //    return NoContent();
    //}
}
