﻿// <auto-generated />
using FilmeApi2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilmeApi2.Migrations;

[DbContext(typeof(FilmeContext))]
partial class FilmeContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "6.0.12")
            .HasAnnotation("Relational:MaxIdentifierLength", 64);

        modelBuilder.Entity("FilmeApi2.Models.Filme", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<int>("Duracao")
                    .HasColumnType("int");

                b.Property<string>("Elenco")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.Property<string>("Genero")
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)");

                b.Property<string>("Titulo")
                    .IsRequired()
                    .HasColumnType("longtext");

                b.HasKey("Id");

                b.ToTable("Filmes");
            });
#pragma warning restore 612, 618
    }
}
