using jomedAPI.Controllers;
using jomedAPI.Data;
using jomedAPI.Data.Repositories;
using jomedAPI.Services;
using JomedAPI.Data.Interfaces.Repositories;
using JomedAPI.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JomedAPITests.ServiceProvider;

public class LoginControllerServiceProvider
{
    public LoginController AdicionarServico()
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
        servico.AddScoped<LoginController>();
        servico.AddAutoMapper(typeof(UsuarioProfile).Assembly);

        var provedor = servico.BuildServiceProvider();
        var controler = provedor.GetService<LoginController>();
        return controler!;
    }
}