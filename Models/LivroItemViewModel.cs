using GerenciadorDeBiblioteca.API.Entities;

namespace GerenciadorDeBiblioteca.API.Models
{
    public class LivroItemViewModel
    {
        public LivroItemViewModel(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
        }

        public string Titulo { get; set; }
        public string Autor { get; set; }

        public static LivroItemViewModel FromEntity(Livro livro)
            => new (livro.Titulo, livro.Autor);
    }
}
