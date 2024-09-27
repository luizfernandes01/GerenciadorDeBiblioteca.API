namespace GerenciadorDeBiblioteca.API.Entities
{
    public class Usuario: BaseEntity
    {
        public Usuario(string nome, string email)
            :base()
        {
            Nome = nome;
            Email = email;
           Ativo = true;
        }

        public int Id { get;private set; }

        public string Nome { get;private set; }

        public string Email { get;private set; }

        public bool Ativo { get; private set; }

        public void UpdateUsuario(string nome,string email)
        {
            Nome = nome;
            Email = email;

        }
    }
}
