using GestaoFinanceira.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceira.Api.Data;

public class AppDbContext : DbContext
{
      public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
      {
      }

      public DbSet<Pessoa> Pessoas => Set<Pessoa>();

      public DbSet<Transacao> Transacoes => Set<Transacao>();

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>(entity =>
            {
                  entity.HasKey(p => p.Id);

                  entity.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

                  entity.Property(p => p.Idade)
                .IsRequired();

                  entity.HasMany(p => p.Transacoes)
                .WithOne(t => t.Pessoa)
                .HasForeignKey(t => t.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                  entity.HasKey(t => t.Id);

                  entity.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(200);

                  entity.Property(t => t.Valor)
                .HasPrecision(18, 2);

                  entity.Property(t => t.Tipo)
                .IsRequired();
            });
      }
}

