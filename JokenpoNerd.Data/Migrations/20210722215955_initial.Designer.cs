﻿// <auto-generated />
using System;
using JokenpoNerd.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JokenpoNerd.Data.Migrations
{
    [DbContext(typeof(JokenpoNerdContext))]
    [Migration("20210722215955_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JokenpoNerd.Data.Models.Opcao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtInclusao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Opcao");
                });

            modelBuilder.Entity("JokenpoNerd.Data.Models.Regra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtInclusao")
                        .HasColumnType("datetime2");

                    b.Property<int>("OpcaoId1")
                        .HasColumnType("int");

                    b.Property<int>("OpcaoId2")
                        .HasColumnType("int");

                    b.Property<int>("VencedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OpcaoId1");

                    b.HasIndex("OpcaoId2");

                    b.HasIndex("VencedorId");

                    b.ToTable("Regra");
                });

            modelBuilder.Entity("JokenpoNerd.Data.Models.Regra", b =>
                {
                    b.HasOne("JokenpoNerd.Data.Models.Opcao", "Opcao1")
                        .WithMany("RegrasOpcao1")
                        .HasForeignKey("OpcaoId1")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("JokenpoNerd.Data.Models.Opcao", "Opcao2")
                        .WithMany("RegrasOpcao2")
                        .HasForeignKey("OpcaoId2")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("JokenpoNerd.Data.Models.Opcao", "Vencedor")
                        .WithMany("RegrasVencedor")
                        .HasForeignKey("VencedorId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Opcao1");

                    b.Navigation("Opcao2");

                    b.Navigation("Vencedor");
                });

            modelBuilder.Entity("JokenpoNerd.Data.Models.Opcao", b =>
                {
                    b.Navigation("RegrasOpcao1");

                    b.Navigation("RegrasOpcao2");

                    b.Navigation("RegrasVencedor");
                });
#pragma warning restore 612, 618
        }
    }
}
