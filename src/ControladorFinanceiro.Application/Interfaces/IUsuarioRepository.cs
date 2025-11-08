using System;
using ControladorFinanceiro.Domain.Entities;

namespace ControladorFinanceiro.Application.Interfaces;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> ListarAsync();
    Task CriarNovoUsuario(Usuario usuario);
}
