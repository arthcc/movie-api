using AutoMapper;
using FilmeApi2.Data;
using FilmeApi2.Dtos;


namespace FilmeApi2.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()

    {
        CreateMap<CreateMovie, Movie>(); 
        CreateMap<Movie, SearchMovie>();
        CreateMap<Movie, SearchGenre>();
        CreateMap<Movie, ChangeMovie>();
    }
 }
