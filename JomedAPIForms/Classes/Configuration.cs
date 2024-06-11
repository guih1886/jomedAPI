using Microsoft.Extensions.Configuration;

namespace JomedAPIForms.Classes;

public class Configuration
{
    public static IConfigurationRoot GetIConfiguration()
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        return builder.Build();
    }
}
