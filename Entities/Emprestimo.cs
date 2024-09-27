using System.Net.Sockets;
using System.Text.Json.Serialization;

namespace GerenciadorDeBiblioteca.API.Entities
{
    public class Emprestimo
    {
        public Emprestimo(int idCliente,int idLivro)
            :base()
        {
            IdCliente = idCliente;
            IdLivro = idLivro;
        }

        public int Id { get; private set; }
        public int IdCliente { get; private set; }
        [JsonIgnore]
        public Usuario? Cliente { get; private set; }
        public int IdLivro { get; private set; }
        [JsonIgnore]
        public Livro? Livro { get; private set; }

        public DateTime DataEmprestimo { get; private set; } = DateTime.Now.Date;

        public DateTime Devolucao { get; private set; } = DateTime.Now.Date.AddDays(7);

        public void UpdateLoan(int idCliente, int idLivro)
        {
            IdCliente = idCliente;
            IdLivro = idLivro;
        }
        public void renovacao(DateTime date)
        {
            Devolucao = date;
        }
            
            
        
    }
}
