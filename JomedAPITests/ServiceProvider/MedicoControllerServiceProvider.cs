using jomedAPI.Controllers;
using jomedAPI.Data.Repositories;
using jomedAPI.Data;
using jomedAPI.Services;
using JomedAPI.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using JomedAPI.Data.Repositories;
using JomedAPI.Data.Interfaces.Repositories;
using JomedAPI.Data.Interfaces.Controllers;
using JomedAPI.Profiles;

namespace JomedAPITests.ServiceProvider;

public class MedicoControllerServiceProvider
{
    public IMedicoController AdicionarServico()
    {
        var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

        var connectionString = configuration.GetConnectionString("jomedApiTest");

        var servico = new ServiceCollection();
        servico.AddDbContext<JomedContext>(opts =>
            opts.UseSqlServer(connectionString, e => e.EnableRetryOnFailure()));

        servico.AddScoped<LoginService>();
        servico.AddSingleton<IConfiguration>(configuration);
        servico.AddScoped<IUsuarioRepository, UsuarioRepository>();
        servico.AddScoped<IMedicoRepository, MedicoRepository>();
        servico.AddScoped<LoginController>();
        servico.AddScoped<IMedicoController, MedicoController>();
        servico.AddAutoMapper(typeof(MedicoProfile).Assembly);

        var provedor = servico.BuildServiceProvider();
        var controler = provedor.GetService<IMedicoController>();
        return controler;
    }
}
