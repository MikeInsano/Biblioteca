﻿// <auto-generated />
using System;
using BibliotecaBolonMiguel.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotecaBolonMiguel.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250303201231_CambioRelacionesUnoAUno")]
    partial class CambioRelacionesUnoAUno
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BibliotecaBolonMiguel.Models.Domain.Autor", b =>
                {
                    b.Property<int>("PkAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkAutor"));

                    b.Property<string>("Biografia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("FotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkAutor");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("BibliotecaBolonMiguel.Models.Domain.Editorial", b =>
                {
                    b.Property<int>("PkEditorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkEditorial"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkEditorial");

                    b.ToTable("Editorials");
                });

            modelBuilder.Entity("BibliotecaBolonMiguel.Models.Domain.Genero", b =>
                {
                    b.Property<int>("PkGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkGenero"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkGenero");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("BibliotecaBolonMiguel.Models.Domain.Libro", b =>
                {
                    b.Property<int>("PkLibro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkLibro"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPublicacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("FotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Idioma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isbn10")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isbn13")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpenLibrary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Paginas")
                        .HasColumnType("int");

                    b.Property<int?>("PkAutor")
                        .HasColumnType("int");

                    b.Property<int?>("PkEditorial")
                        .HasColumnType("int");

                    b.Property<int?>("PkGenero")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkLibro");

                    b.HasIndex("PkAutor")
                        .IsUnique()
                        .HasFilter("[PkAutor] IS NOT NULL");

                    b.HasIndex("PkEditorial")
                        .IsUnique()
                        .HasFilter("[PkEditorial] IS NOT NULL");

                    b.HasIndex("PkGenero")
                        .IsUnique()
                        .HasFilter("[PkGenero] IS NOT NULL");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("BibliotecaBolonMiguel.Models.Domain.Rol", b =>
                {
                    b.Property<int>("PkRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkRol"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkRol");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            PkRol = 1,
                            Nombre = "Admin"
                        });
                });

            modelBuilder.Entity("BibliotecaBolonMiguel.Models.Domain.Usuario", b =>
                {
                    b.Property<int>("PkUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkUsuario"));

                    b.Property<int>("FkRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PkUsuario");

                    b.HasIndex("FkRol");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            PkUsuario = 1,
                            FkRol = 1,
                            Nombre = "Miguel Bolon",
                            Password = "chanchito",
                            UserName = "Mikey"
                        });
                });

            modelBuilder.Entity("BibliotecaBolonMiguel.Models.Domain.Libro", b =>
                {
                    b.HasOne("BibliotecaBolonMiguel.Models.Domain.Autor", "Autor")
                        .WithOne("Libro")
                        .HasForeignKey("BibliotecaBolonMiguel.Models.Domain.Libro", "PkAutor");

                    b.HasOne("BibliotecaBolonMiguel.Models.Domain.Editorial", "Editorial")
                        .WithOne("Libro")
                        .HasForeignKey("BibliotecaBolonMiguel.Models.Domain.Libro", "PkEditorial");

                    b.HasOne("BibliotecaBolonMiguel.Models.Domain.Genero", "Genero")
                        .WithOne("Libro")
                        .HasForeignKey("BibliotecaBolonMiguel.Models.Domain.Libro", "PkGenero");

                    b.Navigation("Autor");

                    b.Navigation("Editorial");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("BibliotecaBolonMiguel.Models.Domain.Usuario", b =>
                {
                    b.HasOne("BibliotecaBolonMiguel.Models.Domain.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FkRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("BibliotecaBolonMiguel.Models.Domain.Autor", b =>
                {
                    b.Navigation("Libro");
                });

            modelBuilder.Entity("BibliotecaBolonMiguel.Models.Domain.Editorial", b =>
                {
                    b.Navigation("Libro");
                });

            modelBuilder.Entity("BibliotecaBolonMiguel.Models.Domain.Genero", b =>
                {
                    b.Navigation("Libro");
                });
#pragma warning restore 612, 618
        }
    }
}
