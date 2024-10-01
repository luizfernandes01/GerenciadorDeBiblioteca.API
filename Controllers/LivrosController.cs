
using GerenciadorDeBiblioteca.API.Models;
using GerenciadorDeBiblioteca.API.Persistence;
using GerenciadorDeBiblioteca.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeBiblioteca.API.Controllers
{
    [Route("api/livros")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly GerenciadorDeBibliotecaDbContext _context;
        private readonly ILivroService _service;
        public LivrosController(GerenciadorDeBibliotecaDbContext context,ILivroService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var result = _service.GetAll();

            return Ok(result);

        }        

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
          var result = _service.GetById(id);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
                           
        }

        [HttpPost]

        public IActionResult Post(CreateLivroInputModel model)
        {
            var result = _service.Insert(model);

            
            return CreatedAtAction(nameof(GetById),new { id = result.Data }, model);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id,UpdateLivroInputModel model)
        {
            var result = _service.Update(model);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
                                            


            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }


            return NoContent();
        }
    }
}
