using FilmeApi2.Dtos;
using FilmeApi2.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FilmesAPI.Controllers;


/// <summary>
/// FilmeController deve ser "burra" e não deve ter regras de negócio.
/// Em um projeto de back-end profissional, a regra de negócio deve ser implementada em uma camada de serviço.
/// E a camada de serviço deve ser injetada na camada de controller.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }



    [HttpPost]
    [Route("addMovie")]
    public IActionResult AddMovie([FromBody] CreateMovie movieDto)
    {
        var Result = _movieService.CreateMovie(movieDto);
        return StatusCode(Result.StatusCode, Result);
    }

    [HttpGet]
    [Route("title/{title}")]
    public IActionResult SearchMovie(string title)
    {
        var Result = _movieService.SearchMovie(title);


        return StatusCode(Result.StatusCode, Result);
    }

    [HttpGet]
    [Route("genre/{genre}")]
    public IActionResult SeachGenre(string genre)
    {
        var Result = _movieService.SeachGenre(genre);

        return StatusCode(Result.StatusCode, Result);
    }

    [HttpPut("/movie/{Id}")]
    public IActionResult ChangeMovie([FromRoute] Guid Id, [FromBody] ChangeMovie changeMovie)
    {
        var Result = _movieService.ChangeMovie(Id, changeMovie);
  
        return StatusCode(Result.StatusCode, Result);
        
    }


}
