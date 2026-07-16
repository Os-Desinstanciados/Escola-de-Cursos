using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EscolaDeCursos.Infra.Compartilhado.Orm;

public class EscolaDeCursosDbContextFactory : IDesignTimeDbContextFactory<EscolaDeCursosDbContext>
{
    public EscolaDeCursosDbContext CreateDbContext(string[] args)
    {
        // 1. Busca o arquivo appsettings.json do projeto web para pegar a string real automaticamente
        // Ajuste o caminho relativo se a pasta do projeto Web tiver outro nome (ex: EscolaDeCursos.API)
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../EscolaDeCursos.WebApp");
        
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? "Server=(localdb)\\mssqllocaldb;Database=EscolaDeCursosDb;Trusted_Connection=True;";

        var optionsBuilder = new DbContextOptionsBuilder<EscolaDeCursosDbContext>();

        // 2. 💡 Ajuste aqui para o provedor do seu banco (UseNpgsql, UseMySql, etc.)
        optionsBuilder.UseSqlServer(connectionString);

        return new EscolaDeCursosDbContext(optionsBuilder.Options);
    }
}