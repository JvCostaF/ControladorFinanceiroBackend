using System;
using ControladorFinanceiro.Domain.Entities;

namespace ControladorFinanceiro.Application.Interfaces;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> ListarAsync();
    Task CriarNovoUsuario(Usuario usuario);
}
