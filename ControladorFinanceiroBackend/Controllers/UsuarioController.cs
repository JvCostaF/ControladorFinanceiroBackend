using ControladorFinanceiro.Application.Interfaces;
using ControladorFinanceiro.Domain.Entities;
using ControladorFinanceiroBackend.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControladorFinanceiroBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService service)
        {
            _usuarioService = service;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuariosAsync()
        {
            return Ok(await _usuarioService.ListarAsync());
        }

        // [HttpPost]
        // public async Task<IActionResult> CriaUsuario([FromBody] NovoUsuarioDTO novoUsuario)
        // {
        //     Usuario novoUsuario = await _usuarioService.CriarNovoUsuario(novoUsuario);
        //     return Created();
        // }
    }
}
