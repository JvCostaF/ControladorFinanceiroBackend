using System;
using ControladorFinanceiro.Domain.Common;
using ControladorFinanceiro.Domain.ValueObjects;

namespace ControladorFinanceiro.Domain.Entities;

public class Usuario : BaseEntity
{
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public string SenhaHash { get; private set; }

    protected Usuario() { }

    public Usuario(string nome, Email email, string senhaHash)
    {
        Nome = nome;
        Email = email;
        SenhaHash = senhaHash;

        ValidarUsuario();
    }
    
    private void ValidarUsuario()
    {
        if (string.IsNullOrWhiteSpace(Nome))
        {
            throw new ArgumentException("O nome e obrigatorio.");
        } else if (SenhaHash.Length < 8)
        {
            throw new ArgumentException("A senha precisa conter no minimo 8 caracteres.");
        }
    }

}
