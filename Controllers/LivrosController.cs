using GerenciadorDeBiblioteca.API.Models;
using GerenciadorDeBiblioteca.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeBiblioteca.API.Controllers
{
    [Route("api/livros")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly GerenciadorDeBibliotecaDbContext _context;
        public LivrosController(GerenciadorDeBibliotecaDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var livros = _context.Livros.Where(l => !l.IsDeleted).ToList();

            var model = livros.Select( LivroItemViewModel.FromEntity).ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var livro = _context.Livros.SingleOrDefault(l => l.Id == id);

            var model = LivroViewModel.FromEntity(livro);

            return Ok(model);
        }

        [HttpPost]

        public IActionResult Post(CreateLivroInputModel model)
        {
            var livro = model.ToEntity();

            _context.Livros.Add(livro);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById),new { id = 1}, model);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id,UpdateLivroInputModel model)
        {
            var livro = _context.Livros.SingleOrDefault(l => l.Id == id);

            if (livro == null)
            {
                return NotFound();
            }

            livro.Update(model.Titulo, model.Autor, model.ISBN, model.AnoDePublicacao);

            _context.Livros.Update(livro);
            _context.SaveChanges();


            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var livro = _context.Livros.SingleOrDefault(l => l.Id == id);

            if (livro == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
