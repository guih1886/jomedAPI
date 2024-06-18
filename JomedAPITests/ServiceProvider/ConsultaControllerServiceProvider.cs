using jomedAPI.Data;
using JomedAPI.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using JomedAPI.Data.Interfaces.Controllers;
using JomedAPI.Data.Interfaces.Repositories;
using jomedAPI.Data.Repositories;
using JomedAPI.Data.Repositories;
using JomedAPI.Profiles;

namespace JomedAPITests.ServiceProvider;

public class ConsultaControllerServiceProvider
{
    public IConsultaController AdicionarServico()
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
        servico.AddSingleton<IPacienteRepository, PacienteRepository>();
        servico.AddSingleton<IMedicoRepository, MedicoRepository>();
        servico.AddSingleton<IUsuarioController, UsuarioController>();
        servico.AddSingleton<IConsultaRepository, ConsultaRepository>();
        servico.AddSingleton<IConsultaController, ConsultaController>();
        servico.AddAutoMapper(typeof(ConsultaProfile).Assembly);

        var provedor = servico.BuildServiceProvider();
        var controler = provedor.GetService<IConsultaController>();
        return controler!;
    }
}
