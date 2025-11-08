using ControladorFinanceiro.Application.Interfaces;
using ControladorFinanceiro.Domain.Entities;
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
        public async Task<IActionResult> ListarUsuarios()
        {
            return Ok(await _usuarioService.ListarAsync());
        }

        [HttpGet("por-id/{id}")]
        public async Task<Usuario> ObterUsuarioPorId(Guid id)
        {
            return await _usuarioService.ObterUsuarioPorIdAsync(id);
        }

        [HttpGet("por-email/{email}")]
        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            return await _usuarioService.ObterUsuarioPorEmailAsync(email);
        }

        [HttpPost("cria-usuario")]
        public async Task<IActionResult> CriaUsuario([FromBody] Usuario usuario)
        {
            await _usuarioService.CriarNovoUsuario(usuario);
            return CreatedAtAction(nameof(ObterUsuarioPorId), new { id = usuario.Id }, usuario);
        }

        [HttpPut("atualiza-usuario")]
        public async Task<IActionResult> AtualizaUsuario([FromBody] Usuario usuario)
        {
            await _usuarioService.AtualizarUsuario(usuario);
            return Accepted(usuario);
        }

        [HttpDelete("deleta-usuario/{id}")]
        public async Task<IActionResult> DeletaUsuario(Guid id)
        {
            await _usuarioService.DeletarUsuario(id);
            return Ok($"Usuario com id: {id} deletado com sucesso");
        }
    }
}
