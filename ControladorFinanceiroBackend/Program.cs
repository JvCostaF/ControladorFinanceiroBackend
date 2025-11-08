using ControladorFinanceiro.Application;
using ControladorFinanceiro.Infrastructure;
using ControladorFinanceiro.Infrastructure.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// --- 1. REGISTRO DE SERVIÇOS (Clean Architecture) ---
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// --- 2. SERVIÇOS DA PRÓPRIA API ---
builder.Services.AddControllers();

builder.Services.AddHealthChecks()
                .AddDbContextCheck<BDContext>(
                    name: "ControladorFinanceiroDB",
                    failureStatus: HealthStatus.Degraded,
                    tags: new[] { "DataBase" });

var connectionString = builder.Configuration.GetConnectionString("ControladorFinanceiroDB");
builder.Services.AddDbContext<BDContext>(options =>
                    options.UseNpgsql(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // <-- ADICIONADO: A interface visual do Swagger
}

app.UseHttpsRedirection();

// --- 3. MAPEAMENTO DE ENDPOINTS ---
app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
