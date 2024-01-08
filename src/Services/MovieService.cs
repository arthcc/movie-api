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

        private IMovieContext _context; 
        
        public MovieService(IMapper mapper, IMovieContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        public ApiResponse<List<SearchGenre>> SeachGenre(string genre)

        {
            try
            {   //Changed to "Where" so it can seach the all genres with the same name
                var movieResult = _context.Movies.Where(x => x.Genre.Equals(genre));

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
        public ApiResponse<SearchMovie> SearchMovie(string title)
        { 
            try
            {   
                var movieResult = _context.Movies.FirstOrDefault(x => x.Title.Equals(title));
                if (movieResult == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
               
                SearchMovie movie = _mapper.Map<SearchMovie>(movieResult);
                return ApiResponse<SearchMovie>.Success(movie);
            }
            catch (HttpResponseException ex)
            {
                // return ApiResponse<BuscarGeneroDto>.Error(ex.Response.ReasonPhrase, 404);

                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return ApiResponse<SearchMovie>.Error("Movie Not Found", 404);
                }
                else
                {
                    return ApiResponse<SearchMovie>.Error("Server Error", 500);
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
                _context.Movies.Add(movie);
                _context.SaveChanges();
                createMovie.Id = movie.Id;
                return ApiResponse<CreateMovie>.Success(createMovie);

            }
            catch (Exception ex)
            {
                return ApiResponse<CreateMovie>.Error(ex.Message);
            }
        }

       
    }
}
