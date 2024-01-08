using Microsoft.EntityFrameworkCore;
using FilmeApi2.Data;
namespace FilmeApi2;

public class MovieContext : DbContext, IMovieContext

{
    public MovieContext(DbContextOptions<MovieContext> opts)
           : base(opts)
    {

    }
    public MovieContext()
    {
    
    }

    public virtual DbSet<Movie> Movies { get; set; }

}




