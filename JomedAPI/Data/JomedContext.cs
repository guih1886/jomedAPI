using jomedAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace jomedAPI.Data;

public class JomedContext : DbContext
{
    public JomedContext(DbContextOptions<JomedContext> opts) : base(opts) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.OwnsOne(e => e.Endereco);
        });
        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.OwnsOne(e => e.Endereco);
        });
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Consulta> Consultas { get; set; }
}
