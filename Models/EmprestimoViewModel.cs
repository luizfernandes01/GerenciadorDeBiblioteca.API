namespace GerenciadorDeBiblioteca.API.Models
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel(string? nomeCliente, string? nomeLivro, string dataEmprestimo, string devolucao)
        {
            NomeCliente = nomeCliente;
            NomeLivro = nomeLivro;
            DataEmprestimo = dataEmprestimo;
            Devolucao = devolucao;
        }

        public string? NomeCliente { get; set; }
        public string? NomeLivro { get; set; }
        public string DataEmprestimo { get; set; }
        public string Devolucao { get; set; }

      

    }
}
