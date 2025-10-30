using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ControladorFinanceiro.Infrastructure.DB;

public class BDContext : DbContext
{
    private readonly IConfiguration configuration;

    public BDContext(IConfiguration _configuration)
    {
        configuration = _configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("ControladorFinanceiroDB")); 
    }

}
