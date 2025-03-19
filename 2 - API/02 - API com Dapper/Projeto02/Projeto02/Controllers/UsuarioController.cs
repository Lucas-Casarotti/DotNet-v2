using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Repositories;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUsuarioRepository _repository = new UsuarioRepository();

        [HttpGet("BuscarUsuarios")]
        public IActionResult BuscarUsuarios()
        {
            return Ok(_repository.BuscarUsuarios());
        }

        [HttpGet("BuscarUsuario/{id_usuario}")]
        public IActionResult BuscarUsuario([FromRoute] int id_usuario)
        {
            var usuario = _repository.BuscarUsuario(id_usuario);
            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_repository.BuscarUsuario(id_usuario));
            }
        }

        [HttpPost("InserirUsuario")]
        public IActionResult InserirUsuario([FromBody] Usuarios param)
        {
            _repository.InserirUsuario(param);
            return Ok(param);
        }

        [HttpPut("AlterarUsuario")]
        public IActionResult AlterarUsuario([FromBody] Usuarios param)
        {
            var verifica = _repository.BuscarUsuario(param.ID_Usuario);
            if (verifica == null)
            {
                return NotFound("Usuário não localizado");
            }
            else
            {
                _repository.AlterarUsuario(param);
                return Ok(param);
            }
        }

        [HttpDelete("ExcluirUsuario/{id_usuario}")]
        public IActionResult ExcluirUsuario([FromRoute] int id_usuario)
        {
            var usuario = _repository.BuscarUsuario(id_usuario);
            if (usuario == null)
            {
                return NotFound("Usuário não localizado");
            }
            else
            {
                _repository.ExcluirUsuario(id_usuario);
                return Ok("Usuário excluido");
            }
        }
    }
}
