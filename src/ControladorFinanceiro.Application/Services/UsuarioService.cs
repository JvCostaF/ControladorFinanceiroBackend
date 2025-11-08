using System;
using ControladorFinanceiro.Application.Interfaces;
using ControladorFinanceiro.Domain.Entities;

namespace ControladorFinanceiro.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }
    public async Task CriarNovoUsuario(Usuario usuario)
    {
        await _repository.CriarNovoUsuario(usuario);
    }

    public async Task<IEnumerable<Usuario>> ListarAsync()
    {
        return await _repository.ListarAsync();
    }
}
