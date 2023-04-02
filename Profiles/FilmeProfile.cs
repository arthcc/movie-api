using AutoMapper;
using FilmeApi2.Data.Dtos;
using FilmeApi2.Models;

namespace FilmeApi2.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()

    {
        CreateMap<CreateFilmeDto, Filme>(); 
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
    }
 }
