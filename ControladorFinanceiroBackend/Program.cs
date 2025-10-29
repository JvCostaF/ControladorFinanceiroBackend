using ControladorFinanceiro.Application;
using ControladorFinanceiro.Infrastructure;

using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// --- 1. REGISTRO DE SERVIÇOS (Clean Architecture) ---
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// --- 2. SERVIÇOS DA PRÓPRIA API ---
builder.Services.AddControllers();

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

app.Run();
