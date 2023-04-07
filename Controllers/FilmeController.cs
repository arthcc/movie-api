using AutoMapper;
using FilmeApi2.Data;
using FilmeApi2.Data.Dtos;
using FilmeApi2.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("filme")]
public class FilmeController : ControllerBase
{
    private FilmeContext _conext;
    private IMapper _mapper;

    public FilmeController(FilmeContext conext, IMapper mapper)
    {
        _conext = conext;
        _mapper = mapper;
    }
    
    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {   
        Filme filme = _mapper.Map<Filme>(filmeDto); 
        _conext.Filmes.Add(filme);
        _conext.SaveChanges();
        return CreatedAtAction(nameof(RecuperaPorId), 
            new { 
            id = filme.Id 
            }, 
            filme);

    }
    
    [HttpGet]
    public IEnumerable<Filme> LerFime([FromQuery]int skip = 0,
        [FromQuery]int take = 50)
    {
        return _conext.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaPorId(int id)
    {
        var filme = _conext.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _conext.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _conext.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id,JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _conext.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if(!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _conext.SaveChanges();
        return NoContent();
    }
}
