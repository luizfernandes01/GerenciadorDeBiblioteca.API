using GerenciadorDeBiblioteca.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeBiblioteca.API.Persistence
{
    public class GerenciadorDeBibliotecaDbContext: DbContext
    {
        public GerenciadorDeBibliotecaDbContext(DbContextOptions<GerenciadorDeBibliotecaDbContext>options):base(options)
        {

        }

        public DbSet <Livro> Livros { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Emprestimo>(e =>
                {
                    e.HasKey(e => e.Id);

                   
                 e.HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.IdCliente);

                e.HasOne(l => l.Livro)
                .WithMany()
                .HasForeignKey(l => l.IdLivro);

                });

            builder
             .Entity<Usuario>(e =>
             {
                 e.HasKey(u => u.Id);
             });

            builder
                .Entity<Livro>(e =>
                {
                     e.HasKey(l => l.Id);
                });

            base.OnModelCreating(builder);
        }




    }
}
