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

    public async Task<IEnumerable<Usuario>> ListarAsync()
    {
        return await _context.Usuarios.AsNoTracking().ToListAsync();
    }

    public async Task<Usuario> ObterUsuarioPorIdAsync(Guid id)
    {
        return await _context.Usuarios.FindAsync(id) ?? throw new KeyNotFoundException($"Usuario com id: {id} nao encontrado.");
    }
    
    public async Task<Usuario> ObterUsuarioPorEmailAsync(string email)
    {
        return await _context.Usuarios.FindAsync(email) ?? throw new KeyNotFoundException($"Usuario com email: {email} nao encontrado.");
    }

    public async Task CriarNovoUsuario(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarUsuario(Usuario usuario)
    {
        _context.Usuarios.Update(usuario); // TO-DO: Precisamos rever a logica de update, da maneira que esta nao funciona!
        await _context.SaveChangesAsync();
    }
    
    public async Task DeletarUsuario(Guid id)
    {
        var usuario = await _context.Usuarios.FindAsync(id) ?? throw new KeyNotFoundException($"Usuario com id: {id} nao encontrado.");
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
    }

    
}
