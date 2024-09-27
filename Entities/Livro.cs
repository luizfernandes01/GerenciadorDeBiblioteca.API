using GerenciadorDeBiblioteca.API.Enums;

namespace GerenciadorDeBiblioteca.API.Entities
{
    public class Livro : BaseEntity
    {
        protected Livro() { }
        public Livro(string titulo, string autor, string iSBN, int anoDePublicacao)
            :base()
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoDePublicacao = anoDePublicacao;

            Status = LivroStatusEnum.Disponivel;
        }

        public int Id { get;private set; }
        public string Titulo { get;private set; }
        public string Autor { get;private set; }
        public string ISBN { get;private set; }
        public int AnoDePublicacao { get; private set; }

        public LivroStatusEnum Status { get; private set; }

        public void Update(string titulo, string autor, string isbn, int anoDePublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            AnoDePublicacao = anoDePublicacao;
        }

        public void Cancelado()
        {
            if (Status == LivroStatusEnum.Disponivel)
            {
                Status = LivroStatusEnum.Cancelado;
            }
        }
    }
   
          
   
}
