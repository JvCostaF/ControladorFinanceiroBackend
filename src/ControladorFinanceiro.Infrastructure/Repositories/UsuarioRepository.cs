using System;
using ControladorFinanceiro.Application.Interfaces;
using ControladorFinanceiro.Domain.Entities;
using ControladorFinanceiro.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace ControladorFinanceiro.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly BDContext _context;

    public UsuarioRepository(BDContext context)
    {
        _context = context;
    }

    public async Task CriarNovoUsuario(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Usuario>> ListarAsync()
    {
        return await _context.Usuarios.AsNoTracking().ToListAsync();
    }
}
