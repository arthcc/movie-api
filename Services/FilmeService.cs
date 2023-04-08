using AutoMapper;
using FilmeApi2.Data;
using FilmeApi2.Dtos;
using FilmeApi2.Helpers;
using System;

namespace FilmeApi2.Services
{
    public class FilmeService : IFilmeService
    {
        private IMapper _mapper;
        
        //opcional, pode usar repositório para deixar a regra de negócio no serviço e a regra de banco no repositório
        private FilmeContext _context; 
        
        public FilmeService(IMapper mapper, FilmeContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public ApiResponse<CreateFilmeDto> CreateFilme(CreateFilmeDto createFilmeDto)
        {
            try
            {
                Filme filme = _mapper.Map<Filme>(createFilmeDto);
                _context.Filmes.Add(filme);
                _context.SaveChanges();
                return ApiResponse<CreateFilmeDto>.Success(createFilmeDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<CreateFilmeDto>.Error(ex.Message);
            }
        }
    }
}
