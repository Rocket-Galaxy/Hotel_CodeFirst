using Microsoft.EntityFrameworkCore;
using Hotel_CodeFirst.Models;

namespace Hotel_CodeFirst.Models
{
    public class Hotel : DbContext
    {
        public DbSet<Cliente> Clientes {get; set;} = null!;
        public DbSet<Endereco> Enderecos {get; set;} = null!;
        public DbSet<Funcionario> Funcionarios {get; set;} = null!;
        public DbSet<NotaFiscal> NotaFiscais {get; set;} = null!;
        public DbSet<Quarto> Quartos {get; set;} = null!;
        public DbSet<TipoFuncionario> TipoFuncionarios {get; set;} = null!;
        public DbSet<TipoPagamento> TipoPagementos {get; set;} = null!;
        public DbSet<TipoQuarto> TipoQuartos {get; set;} = null!;
        public DbSet<Telefone> Telefones {get; set;} = null!;

        public DbSet<ContaReserva> ContasReserva {get; set;} = null!;
        public DbSet<Reserva> Reservas {get; set;} = null!;
        public DbSet<Filial> Filiais {get; set;} = null!;
        public DbSet<Restaurante> Restaurantes {get; set;} = null!;
        public DbSet<Frigobar> Frigobares {get; set;} = null!;
        public DbSet<ConsumoRestaurante> ConsumoRestaurantes {get; set;} = null!;
        public DbSet<ConsumoFrigobar> ConsumoFrigobares {get; set;} = null!;
        public DbSet<ServicoLavanderia> ServicosLavanderia {get; set;} = null!;
        public DbSet<ConsumoLavanderia> ConsumosLavanderia {get; set;} = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Rocket\SQLEXPRESS;Database=Hotel;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }
}