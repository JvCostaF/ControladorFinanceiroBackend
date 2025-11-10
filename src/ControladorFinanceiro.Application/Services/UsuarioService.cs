using System;
using ControladorFinanceiro.Application.DTOs.Requests;
using ControladorFinanceiro.Application.Interfaces;
using ControladorFinanceiro.Domain.Entities;
using ControladorFinanceiro.Domain.ValueObjects;

namespace ControladorFinanceiro.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Usuario>> ListarAsync()
    {
        return await _repository.ListarAsync();
    }

    public async Task<Usuario> ObterUsuarioPorIdAsync(Guid id)
    {
        return await _repository.ObterUsuarioPorIdAsync(id);
    }

    public async Task<Usuario> ObterUsuarioPorEmailAsync(string email)
    {
        return await _repository.ObterUsuarioPorEmailAsync(email);
    }

    public async Task CriarNovoUsuario(NovoUsuarioDTO novoUsuario)
    {
        string senhaHash = BCrypt.Net.BCrypt.HashPassword(novoUsuario.Senha);
        Usuario usuario = new Usuario(novoUsuario.Nome, new Email(novoUsuario.Email), senhaHash);
        await _repository.CriarNovoUsuario(usuario);
    }

    public async Task AtualizarUsuario(Usuario usuario)
    {
        await _repository.AtualizarUsuario(usuario);
    }

    public async Task DeletarUsuario(Guid id)
    {
        await _repository.DeletarUsuario(id);
    }
}
