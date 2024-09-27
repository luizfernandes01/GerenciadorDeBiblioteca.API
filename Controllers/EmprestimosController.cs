using GerenciadorDeBiblioteca.API.Entities;
using GerenciadorDeBiblioteca.API.Models;
using GerenciadorDeBiblioteca.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeBiblioteca.API.Controllers
{
    [Route("api/emprestimos")]
    [ApiController]
    public class EmprestimosController : ControllerBase
    {
        private readonly GerenciadorDeBibliotecaDbContext _context;
        public EmprestimosController(GerenciadorDeBibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var emprestimos = _context.Emprestimos.ToList();

            return Ok(emprestimos);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            return Ok();
        }
        [HttpPost]

        public IActionResult Post(CreateEmprestimoInputModel model)
        {
            var emprestimo = new Emprestimo(model.IdCliente,model.IdLivro);

            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();

            return NoContent(); 
        }

        [HttpPut("renovacao/{id}")]

        public IActionResult Renovacao(int id)
        {
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id,UpdateEmprestimoInputModel model)
        {
            return BadRequest();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
