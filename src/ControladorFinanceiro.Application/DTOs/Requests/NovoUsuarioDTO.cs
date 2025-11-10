using System;

namespace ControladorFinanceiro.Application.DTOs.Requests;

public class NovoUsuarioDTO
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}
