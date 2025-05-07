using api.DTOs;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuariosController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _service.GetById(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                Cedula = usuarioDTO.Cedula,
                Direccion = usuarioDTO.Direccion,
                Telefono = usuarioDTO.Telefono,
                FechaNacimiento = usuarioDTO.FechaNacimiento
            };
            _service.Add(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            var existingUsuario = _service.GetById(id);
            if (existingUsuario == null) return NotFound();

            existingUsuario.Nombre = usuarioDTO.Nombre;
            existingUsuario.Apellido = usuarioDTO.Apellido;
            existingUsuario.Cedula = usuarioDTO.Cedula;
            existingUsuario.Direccion = usuarioDTO.Direccion;
            existingUsuario.Telefono = usuarioDTO.Telefono;
            existingUsuario.FechaNacimiento = usuarioDTO.FechaNacimiento;

            _service.Update(existingUsuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _service.GetById(id);
            if (usuario == null) return NotFound();

            _service.Delete(id);
            return NoContent();
        }
    }
}