using Microsoft.EntityFrameworkCore;

namespace FilmeApi2.Data;

public class FilmeContext : DbContext, IFilmeContext

{
    public FilmeContext(DbContextOptions<FilmeContext> opts)
           : base(opts)
    {
    }

    public virtual DbSet<Filme> Filmes { get; set; }

}
