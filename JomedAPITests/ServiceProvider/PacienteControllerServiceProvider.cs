using jomedAPI.Data;
using JomedAPI.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using JomedAPI.Data.Repositories;
using JomedAPI.Data.Interfaces.Repositories;
using JomedAPI.Data.Interfaces.Controllers;
using JomedAPI.Profiles;

namespace JomedAPITests.ServiceProvider;

public class PacienteControllerServiceProvider
{
    public IPacienteController AdicionarServico()
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
        servico.AddSingleton<IPacienteRepository, PacienteRepository>();
        servico.AddSingleton<IPacienteController, PacienteController>();
        servico.AddAutoMapper(typeof(PacienteProfile).Assembly);

        var provedor = servico.BuildServiceProvider();
        var controler = provedor.GetService<IPacienteController>();
        return controler!;
    }
}
