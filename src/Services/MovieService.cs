using AutoMapper;
using FilmeApi2.Data;
using FilmeApi2.Dtos;
using FilmeApi2.Helpers;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace FilmeApi2.Services
{
    /// <summary>
    /// Classe de serviço de filme deve ter regras de negócio.
    /// Em alguns casos usamos os repotirio para deixar a regra de negócio no serviço e a regra de banco no repositório.
    /// No caso abaixo eu não criei para não complicar o exemplo.
    /// Mas, caso houvesse a camada de repositório, todo o processo de "salvar, alterar, excluir, etc" seria feito nessa camada, mas a regra continuaria nessa classe.
    /// Esse padrão é chamado de "Repository Pattern".
    /// </summary>
    public class MovieService : IMovieService
    {
        private IMapper _mapper;

        private MovieContext _context; 
        
        public MovieService(IMapper mapper, MovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public ApiResponse<List<SearchGenre>> SeachGenre(string genre)

        {
            try
            {   //Changed to "Where" so it can seach the all genres with the same name
                var movieResult = _context.Movies.Where(x => x.Genre.Equals(genre)).ToList();

                if (!movieResult.Any())
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                List<SearchGenre> movies = _mapper.Map<List<SearchGenre>>(movieResult);
                return ApiResponse<List<SearchGenre>>.Success(movies);

            }
            catch (HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return ApiResponse<List<SearchGenre>>.Error("Genre Not Found", 404);
                }
                else
                {
                    return ApiResponse<List<SearchGenre>>.Error("Server Error", 500);
                }
            }


        }
        public ApiResponse<List<SearchMovie>> SearchMovie(string title)
        { 
            try
            {
                var movieResult = _context.Movies.Where(x => x.Title.Equals(title)).ToList();
                if (movieResult == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                List<SearchMovie> movies = _mapper.Map<List<SearchMovie>>(movieResult);
                return ApiResponse<List<SearchMovie>>.Success(movies);


            }
            catch (HttpResponseException ex)
            {
                // return ApiResponse<BuscarGeneroDto>.Error(ex.Response.ReasonPhrase, 404);

                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return ApiResponse<List<SearchMovie>>.Error("Movie Not Found", 404);
                }
                else
                {
                    return ApiResponse<List<SearchMovie>>.Error("Server Error", 500);
                }
            }
        }

        /// <summary>
        /// Método para criar um filme.
        /// Aqui, eu acrescentei algo que faltou no seu projeto que é o try/catch.
        /// O try/catch é importante para que o sistema não quebre caso ocorra algum erro.
        /// Anteriormente em caso de erro 500 (internal server), o sistema quebrava.
        /// Agora, com a nossa mensagem customizada da ApiResponse, nós podemos retornar o erro para o usuário de forma amigável e legível.
        /// </summary>
        /// <param name="CreateMovie"></param>
        /// <returns></returns>
        public ApiResponse<CreateMovie> CreateMovie(CreateMovie createMovie)
        {
            try
            {
                Movie movie = _mapper.Map<Movie>(createMovie);
                movie.Id = new Guid();
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return ApiResponse<CreateMovie>.Success(createMovie);

            }
            catch (Exception ex)
            {
                return ApiResponse<CreateMovie>.Error(ex.Message);
            }
        }

        public ApiResponse<ChangeMovie> ChangeMovie(Guid Id, ChangeMovie changeMovie)
        {
            try
            {
                var movieResult = _context.Movies.Where(x => x.Id.Equals(Id)).FirstOrDefault();
                if (movieResult == null)
                {
                    return ApiResponse<ChangeMovie>.Error("Movie Not Found with Provider Id", 404);
                }

                movieResult.Genre = changeMovie.Genre;
                movieResult.RunTime = changeMovie.RunTime;
                movieResult.Cast = changeMovie.Cast;
                movieResult.Title = changeMovie.Title;


                // Save changes to database
                _context.Entry(movieResult).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                return ApiResponse<ChangeMovie>.Success(_mapper.Map<ChangeMovie>(movieResult));
            }
            catch (HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return ApiResponse<ChangeMovie>.Error("Movie Not Found", 404);
                }
                else
                {
                    return ApiResponse<ChangeMovie>.Error("Server Error", 500);
                }
            }
        }

    }


}

