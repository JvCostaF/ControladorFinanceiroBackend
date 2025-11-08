using System;

namespace ControladorFinanceiro.Domain.ValueObjects;

public class Email
{
    public string Endereco { get; }

    public Email(string endereco)
    {
        if (string.IsNullOrWhiteSpace(endereco))
        {
            throw new ArgumentException("E-mail nao pode ser vazio");
        } else if (!ValidarFormato(endereco))
        {
            throw new ArgumentException("Formato do e-mail incorreto.");
        }

        Endereco = endereco.Trim().ToLowerInvariant();
    }

    private bool ValidarFormato(string endereco)
    {
        return endereco.Contains("@") && endereco.Contains(".");
    }

    public override string ToString() => Endereco;

    public override bool Equals(object obj)
    {
        if (obj is not Email other) return false;
        return Endereco == other.Endereco;
    }

    public override int GetHashCode() => Endereco.GetHashCode();
}
