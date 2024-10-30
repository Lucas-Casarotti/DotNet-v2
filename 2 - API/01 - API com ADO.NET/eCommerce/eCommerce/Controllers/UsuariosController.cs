using eCommerce.Models;
using eCommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        IUsuarioRepository _repository = new UsuarioRepository();

        [HttpGet("BuscarUsuarios")]
        public IActionResult BuscarUsuarios()
        {
            return Ok(_repository.BuscarUsuarios());
        }

        [HttpGet("BuscarUsuario/{id}")]
        public IActionResult BuscarUsuario(int id) 
        { 
            var usuario = _repository.BuscarUsuario(id);
            if(usuario == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_repository.BuscarUsuario(id));
            }
        }

        [HttpPost("InserirUsuario")]
        public IActionResult InserirUsuario([FromBody] Usuario usuario)
        {
            _repository.InserirUsuario(usuario);
            return Ok(usuario);
        }

        [HttpPut("AlterarUsuario")]
        public IActionResult AlterarUsuario([FromBody] Usuario usuario)
        {
            var verifica = _repository.BuscarUsuario(usuario.Id);
            if(verifica == null)
            {
                return NotFound("Usuário não localizado");
            }
            else
            {
                _repository.AlterarUsuario(usuario);
                return Ok(usuario);
            }
        }

        [HttpDelete("ExcluirUsuario")]
        public IActionResult ExcluirUsuario(int id)
        {
            var usuario = _repository.BuscarUsuario(id);
            if(usuario == null)
            {
                return NotFound("Usuário não localizado");
            }
            else
            {
                _repository.ExcluirUsuario(id);
                return Ok("Usuário excluido");
            }
        }
    }
}
