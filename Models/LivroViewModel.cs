using GerenciadorDeBiblioteca.API.Entities;

namespace GerenciadorDeBiblioteca.API.Models
{
    public class LivroViewModel
    {
        public LivroViewModel(string titulo, string autor, string iSBN, int anoDePublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoDePublicacao = anoDePublicacao;
        }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int  AnoDePublicacao { get; set; }

        public static LivroViewModel FromEntity(Livro entity) 
            => new (entity.Titulo,entity.Autor,entity.ISBN,entity.AnoDePublicacao);

    }
}
