using jomedAPI.Data;
using JomedAPI.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using JomedAPI.Data.Interfaces.Controllers;
using JomedAPI.Profiles;
using JomedAPI.Data.Interfaces.Repositories;
using jomedAPI.Data.Repositories;

namespace JomedAPITests.ServiceProvider;

public class UsuarioControllerServiceProvider
{
    public IUsuarioController AdicionarServico()
    {
        var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

        var connectionString = configuration.GetConnectionString("jomedApiTest");

        var servico = new ServiceCollection();
        servico.AddDbContext<JomedContext>(opts =>
            opts.UseSqlServer(connectionString, e => e.EnableRetryOnFailure()));

        servico.AddSingleton<IConfiguration>(configuration);
        servico.AddSingleton<IUsuarioRepository, UsuarioRepository>();
        servico.AddSingleton<IUsuarioController, UsuarioController>();
        servico.AddAutoMapper(typeof(UsuarioProfile).Assembly);

        var provedor = servico.BuildServiceProvider();
        var controler = provedor.GetService<IUsuarioController>();
        return controler!;
    }
}
