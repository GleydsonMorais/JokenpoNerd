using JokenpoNerd.Data.Models;
using JokenpoNerd.Data.Models.Logs;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace JokenpoNerd.Data.Context
{
    public class JokenpoNerdContext : DbContext
    {
        public DbSet<Opcao> Opcoes { get; set; }
        public DbSet<Regra> Regras { get; set; }
        public DbSet<Log> Logs { get; set; }
            
        public JokenpoNerdContext(DbContextOptions<JokenpoNerdContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Jokenpo
            modelBuilder.Entity<Opcao>(i =>
            {
                i.ToTable("Opcao");
                i.HasKey(x => x.Id);

                i.Property(x => x.Descricao).IsRequired();
                i.Property(x => x.DtInclusao).IsRequired();
            });

            modelBuilder.Entity<Regra>(i =>
            {
                i.ToTable("Regra");
                i.HasKey(x => x.Id);

                i.Property(x => x.Descricao).IsRequired();
                i.Property(x => x.DtInclusao).IsRequired();

                i.HasOne(x => x.Opcao1)
                .WithMany(x => x.RegrasOpcao1)
                .HasForeignKey(x => x.OpcaoId1)
                .OnDelete(DeleteBehavior.ClientCascade);

                i.HasOne(x => x.Opcao2)
                .WithMany(x => x.RegrasOpcao2)
                .HasForeignKey(x => x.OpcaoId2)
                .OnDelete(DeleteBehavior.ClientCascade);

                i.HasOne(x => x.Vencedor)
                .WithMany(x => x.RegrasVencedor)
                .HasForeignKey(x => x.VencedorId)
                .OnDelete(DeleteBehavior.ClientCascade);
            });
            #endregion

            #region Logs
            modelBuilder.Entity<Log>(i =>
            {
                i.ToTable("Log");
                i.HasKey(x => x.Id);

                i.Property(x => x.Opcao1).IsRequired();
                i.Property(x => x.Opcao2).IsRequired();
                i.Property(x => x.Mensagem).IsRequired();
                i.Property(x => x.DtInclusao).IsRequired();
            });
            #endregion
        }
    }
}
