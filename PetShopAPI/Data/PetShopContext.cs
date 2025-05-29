using Microsoft.EntityFrameworkCore;
using PetShopAPI.Models;

namespace PetShopAPI.Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) 
            : base(options)
        {
        }

        public DbSet<Dono> Donos { get; set; }
        public DbSet<Animal> Animais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Dono)
                .WithMany(d => d.Animais)
                .HasForeignKey(a => a.DonoId);

            var donos = new[] {
                new Dono { Id = 1, Nome = "João Silva", CPF = "123.456.789-00", Telefone = "(11) 98765-4321", Email = "joao@email.com" },
                new Dono { Id = 2, Nome = "Maria Souza", CPF = "987.654.321-00", Telefone = "(11) 91234-5678", Email = "maria@email.com" }
            };
            
            modelBuilder.Entity<Dono>().HasData(donos);

            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, Nome = "Rex", Especie = "Cachorro", Raca = "Labrador", Idade = 5, Peso = 25.5, DonoId = 1 },
                new Animal { Id = 2, Nome = "Miau", Especie = "Gato", Raca = "Siamês", Idade = 3, Peso = 4.2, DonoId = 1 },
                new Animal { Id = 3, Nome = "Caramelo", Especie = "Cachorro", Raca = "Vira-lata", Idade = 2, Peso = 12.0, DonoId = 2 }
            );
        }
    }
} 