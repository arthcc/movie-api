using AutoMapper;
using FilmeApi2.Data;
using FilmeApi2.Dtos;


namespace FilmeApi2.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()

    {
        CreateMap<CreateFilmeDto, Filme>(); 
        CreateMap<Filme, BuscarFilmeDto>();
        CreateMap<Filme, BuscarGeneroDto>();
    }
 }
