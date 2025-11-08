using System;
using ControladorFinanceiro.Domain.Entities;

namespace ControladorFinanceiro.Application.Interfaces;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> ListarAsync();
    Task<Usuario> ObterUsuarioPorIdAsync(Guid Id);
    Task<Usuario> ObterUsuarioPorEmailAsync(string email);
    Task CriarNovoUsuario(Usuario usuario);
    Task AtualizarUsuario(Usuario usuario);
    Task DeletarUsuario(Guid id);
}
