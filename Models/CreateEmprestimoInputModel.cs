namespace GerenciadorDeBiblioteca.API.Models
{
    public class CreateEmprestimoInputModel
    {

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdLivro { get; set; }
        public string DataEmprestimo { get; set; }


    }
}
