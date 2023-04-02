using FilmeApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeApi2.Data;

public class FilmeContext : DbContext 

{
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base (opts)
    {

    }

    public DbSet<Filme> Filmes { get; set; }
}
