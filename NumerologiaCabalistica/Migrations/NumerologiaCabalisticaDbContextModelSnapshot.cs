﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NumerologiaCabalistica.Data;

#nullable disable

namespace NumerologiaCabalistica.Migrations
{
    [DbContext(typeof(NumerologiaCabalisticaDbContext))]
    partial class NumerologiaCabalisticaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NumerologiaCabalistica.Models.DiasMesFavoraveis.DiaDoMesFavoravelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<int>("DiaFavoravel")
                        .HasColumnType("int");

                    b.Property<int>("MesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MesId");

                    b.ToTable("DiasDoMesFavoraveis");
                });

            modelBuilder.Entity("NumerologiaCabalistica.Models.DiasMesFavoraveis.MesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Mes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MesNumeral")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mes");
                });

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

            modelBuilder.Entity("NumerologiaCabalistica.Models.DiasMesFavoraveis.DiaDoMesFavoravelModel", b =>
                {
                    b.HasOne("NumerologiaCabalistica.Models.DiasMesFavoraveis.MesModel", "Mes")
                        .WithMany("DiasDoMesFavoraveis")
                        .HasForeignKey("MesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mes");
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

            modelBuilder.Entity("NumerologiaCabalistica.Models.DiasMesFavoraveis.MesModel", b =>
                {
                    b.Navigation("DiasDoMesFavoraveis");
                });

            modelBuilder.Entity("NumerologiaCabalistica.Models.TextosNumericos.CategoriaNumeroPessoalModel", b =>
                {
                    b.Navigation("TextoNumerico");
                });
#pragma warning restore 612, 618
        }
    }
}