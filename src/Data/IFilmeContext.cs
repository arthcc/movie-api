using Microsoft.EntityFrameworkCore;

namespace FilmeApi2.Data
{
    /// <summary>
    /// Interface de implementação do contexto do banco de dados.
    /// Essa separação é necessário para habilitar os testes do contexto do banco de dados.
    /// Não chamamos o contexto diretamente nem no projeto principal, nem no projeto de testes,
    /// uma vez que é a camada mais sensível do projeto.
    /// </summary>
    public interface IFilmeContext
    {
        DbSet<Filme> Filmes { get; set; }
        int SaveChanges();
    }
}
