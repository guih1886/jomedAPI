using jomedAPI.Data;
using jomedAPI.Data.Repositories;
using jomedAPI.Services;
using JomedAPI.Data.Interfaces.Repositories;
using JomedAPI.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("jomedApi");

builder.Services.AddDbContext<JomedContext>(opts =>
    opts.UseSqlServer(connectionString, e => e.EnableRetryOnFailure()));

builder.Services.AddControllers();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Jomed API",
        Description = "O projeto JomedAPI gerencia médicos e pacientes com funcionalidades CRUD, permite o agendamento e cancelamento de consultas usando ID de médico e paciente e uma data. O cadastro de médicos e pacientes podem ser inativados. Autenticação é feita com JSON Web Tokens (JWT), exigido para acesso e manipulação de dados.",
        Contact = new OpenApiContact() { Name = "LinkedIn", Url = new Uri("https://www.linkedin.com/in/guih1886/") },
    });
    opts.AddSecurityDefinition("1", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "Jwt",
        In = ParameterLocation.Header,
        Description = "Cabeçalho de autorização JWT está usando o esquema de Bearer, digite o jwt para fazer as requisições."
    });
    opts.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference()
            {
                Type = ReferenceType.SecurityScheme,
                Id = "1"
            }
        },
        Array.Empty<string>()
        }
    });
});
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opts =>
{
    opts.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
