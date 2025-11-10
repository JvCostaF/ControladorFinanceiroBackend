using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using ControladorFinanceiro.Domain.Entities;
using System.Reflection;
using ControladorFinanceiro.Infrastructure.DB.Configurations;

namespace ControladorFinanceiro.Infrastructure.DB;

public class BDContext : DbContext
{
    private readonly IConfiguration configuration;

    public DbSet<Usuario> Usuarios { get; set; }

    public BDContext(IConfiguration _configuration)
    {
        configuration = _configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("ControladorFinanceiroDB"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        base.OnModelCreating(modelBuilder);
    }

}
