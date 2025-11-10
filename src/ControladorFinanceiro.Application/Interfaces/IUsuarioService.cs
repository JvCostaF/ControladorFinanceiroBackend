using System;
using ControladorFinanceiro.Application.DTOs.Requests;
using ControladorFinanceiro.Domain.Entities;

namespace ControladorFinanceiro.Application.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> ListarAsync();
    Task<Usuario> ObterUsuarioPorIdAsync(Guid Id);
    Task<Usuario> ObterUsuarioPorEmailAsync(string email);
    Task CriarNovoUsuario(NovoUsuarioDTO novoUsuario);
    Task AtualizarUsuario(Usuario usuario);
    Task DeletarUsuario(Guid id);
}
