using Microsoft.EntityFrameworkCore;
using Hotel_CodeFirst.Models;

namespace Hotel_CodeFirst.Models
{
    public class Hotel : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Endereco> Enderecos { get; set; } = null!;
        public DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public DbSet<NotaFiscal> NotaFiscais { get; set; } = null!;
        public DbSet<Quarto> Quartos { get; set; } = null!;
        public DbSet<TipoFuncionario> TipoFuncionarios { get; set; } = null!;
        public DbSet<TipoPagamento> TipoPagementos { get; set; } = null!;
        public DbSet<TipoQuarto> TipoQuartos { get; set; } = null!;
        public DbSet<Telefone> Telefones { get; set; } = null!;
        public DbSet<Email> Emails { get; set; } = null!;
        public DbSet<ContaReserva> ContasReserva { get; set; } = null!;
        public DbSet<Reserva> Reservas { get; set; } = null!;
        public DbSet<Filial> Filiais { get; set; } = null!;
        public DbSet<Restaurante> Restaurantes { get; set; } = null!;
        public DbSet<Frigobar> Frigobares { get; set; } = null!;
        public DbSet<ConsumoRestaurante> ConsumoRestaurantes { get; set; } = null!;
        public DbSet<ConsumoFrigobar> ConsumoFrigobares { get; set; } = null!;
        public DbSet<ServicoLavanderia> ServicosLavanderia { get; set; } = null!;
        public DbSet<ConsumoLavanderia> ConsumosLavanderia { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>()
                .HasOne<ContaReserva>()
                .WithMany()
                .HasForeignKey(r => r.Codigo_NotaFiscal)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Reserva>()
                .HasOne<ContaReserva>()
                .WithMany()
                .HasForeignKey(r => r.Codigo_ContaReserva)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(r => r.Codigo_Cliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Email>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(e => e.Codigo_Cliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Telefone>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(t => t.Codigo_Cliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConsumoFrigobar>()
                .HasOne<ContaReserva>()
                .WithMany()
                .HasForeignKey(cf => cf.Codigo_ContaReserva)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConsumoLavanderia>()
                .HasOne<ContaReserva>()
                .WithMany()
                .HasForeignKey(cl => cl.Codigo_ContaReserva)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConsumoRestaurante>()
                .HasOne<ContaReserva>()
                .WithMany()
                .HasForeignKey(cr => cr.Codigo_ContaReserva)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConsumoRestaurante>()
                .HasOne<Restaurante>()
                .WithMany()
                .HasForeignKey(cr => cr.Codigo_Restaurante)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne<ContaReserva>()
                .WithMany()
                .HasForeignKey(r => r.Codigo_ContaReserva)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Endereco>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(e => e.Codigo_Cliente)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Filial>()
                .HasMany<Quarto>()
                .WithOne()
                .HasForeignKey(q => q.Codigo_Filial)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Frigobar>()
                .HasMany<ConsumoFrigobar>()
                .WithOne()
                .HasForeignKey(cf => cf.Codigo_Frigobar)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Funcionario>()
                .HasOne<TipoFuncionario>()
                .WithMany()
                .HasForeignKey(f => f.Codigo_TipoFuncionario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NotaFiscal>()
                .HasOne<TipoPagamento>()
                .WithMany()
                .HasForeignKey(nf => nf.Codigo_TipoPagamento)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quarto>()
                .HasOne<TipoQuarto>()
                .WithMany()
                .HasForeignKey(q => q.Codigo_TipoQuarto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reserva>()
                .HasOne<Quarto>()
                .WithMany()
                .HasForeignKey(r => r.Numero_Quarto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Restaurante>()
                .HasMany<ConsumoRestaurante>()
                .WithOne()
                .HasForeignKey(cr => cr.Codigo_Restaurante)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServicoLavanderia>()
                .HasMany<ConsumoLavanderia>()
                .WithOne()
                .HasForeignKey(cl => cl.Codigo_ServicoLavanderia)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ROCKET\SQLEXPRESS;Database=Hotel;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }
}
