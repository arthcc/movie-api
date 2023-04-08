using Microsoft.EntityFrameworkCore;

namespace FilmeApi2.Data
{
    public interface IFilmeContext
    {
        DbSet<Filme> Filmes { get; set; }
        int SaveChanges();
    }
}
