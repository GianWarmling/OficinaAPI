using Microsoft.EntityFrameworkCore;
using OficinaAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OficinaAPI.Data
{
    public class OficinaContext : DbContext
    {
        public OficinaContext(DbContextOptions<OficinaContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<OrdemServico> OrdensServico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Veiculos)
                .HasForeignKey(v => v.ClienteId);

            modelBuilder.Entity<OrdemServicoServico>()
                .HasKey(x => new { x.OrdemServicoId, x.ServicoId });

            modelBuilder.Entity<OrdemServicoProduto>()
                .HasKey(x => new { x.OrdemServicoId, x.ProdutoId });
        }
    }
}
