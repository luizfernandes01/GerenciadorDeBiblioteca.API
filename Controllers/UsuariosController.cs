using GerenciadorDeBiblioteca.API.Entities;
using GerenciadorDeBiblioteca.API.Models;
using GerenciadorDeBiblioteca.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeBiblioteca.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly GerenciadorDeBibliotecaDbContext _context;
        public UsuariosController(GerenciadorDeBibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {

            return Ok();
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == id); 
          
            if (usuario == null)
            {
                return NotFound();
            }
            

            return Ok(usuario);
        }

        [HttpPost]

        public IActionResult Post(CreateUsuarioInputModel model)
        {
            var usuario = new Usuario(model.Nome,model.Email);

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return NoContent();

        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, UpdateUsuarioInputModel model)
        {
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
