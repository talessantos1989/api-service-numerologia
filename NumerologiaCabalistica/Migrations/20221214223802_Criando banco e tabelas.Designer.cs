﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NumerologiaCabalistica.Data;

#nullable disable

namespace NumerologiaCabalistica.Migrations
{
    [DbContext(typeof(NumerologiaCabalisticaDbContext))]
    [Migration("20221214223802_Criando banco e tabelas")]
    partial class Criandobancoetabelas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NumerologiaCabalistica.Models.TextosNumericos.CategoriaNumeroPessoalModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CategoriaNumero");
                });

            modelBuilder.Entity("NumerologiaCabalistica.Models.TextosNumericos.TextoNumericoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("TextoNumerico");
                });

            modelBuilder.Entity("NumerologiaCabalistica.Models.TextosNumericos.TextoNumericoModel", b =>
                {
                    b.HasOne("NumerologiaCabalistica.Models.TextosNumericos.CategoriaNumeroPessoalModel", "Categoria")
                        .WithMany("TextoNumerico")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("NumerologiaCabalistica.Models.TextosNumericos.CategoriaNumeroPessoalModel", b =>
                {
                    b.Navigation("TextoNumerico");
                });
#pragma warning restore 612, 618
        }
    }
}
