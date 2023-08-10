﻿// <auto-generated />
using System;
using GestorTareas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestorTareas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230808182448_SubTareas")]
    partial class SubTareas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestorTareas.Models.Categorias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("GestorTareas.Models.CategoriasTareas", b =>
                {
                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("TareaId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoriasId")
                        .HasColumnType("int");

                    b.Property<int?>("TareasId")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId", "TareaId");

                    b.HasIndex("CategoriasId");

                    b.HasIndex("TareasId");

                    b.ToTable("CategoriasTareas");
                });

            modelBuilder.Entity("GestorTareas.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("GestorTareas.Models.Nivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nivel");
                });

            modelBuilder.Entity("GestorTareas.Models.SubTareas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_prevista")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("SubTareas");
                });

            modelBuilder.Entity("GestorTareas.Models.Tareas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("NivelId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.HasIndex("NivelId");

                    b.ToTable("Tareas");
                });

            modelBuilder.Entity("GestorTareas.Models.TareasSubTareas", b =>
                {
                    b.Property<int>("TareaId")
                        .HasColumnType("int");

                    b.Property<int>("SubTareasId")
                        .HasColumnType("int");

                    b.Property<int?>("TareasId")
                        .HasColumnType("int");

                    b.HasKey("TareaId", "SubTareasId");

                    b.HasIndex("SubTareasId");

                    b.HasIndex("TareasId");

                    b.ToTable("TareasSubTareas");
                });

            modelBuilder.Entity("GestorTareas.Models.CategoriasTareas", b =>
                {
                    b.HasOne("GestorTareas.Models.Categorias", "Categorias")
                        .WithMany("CategoriasTareas")
                        .HasForeignKey("CategoriasId");

                    b.HasOne("GestorTareas.Models.Tareas", "Tareas")
                        .WithMany("CategoriasTareas")
                        .HasForeignKey("TareasId");

                    b.Navigation("Categorias");

                    b.Navigation("Tareas");
                });

            modelBuilder.Entity("GestorTareas.Models.SubTareas", b =>
                {
                    b.HasOne("GestorTareas.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("GestorTareas.Models.Tareas", b =>
                {
                    b.HasOne("GestorTareas.Models.Nivel", "Nivel")
                        .WithMany()
                        .HasForeignKey("NivelId");

                    b.Navigation("Nivel");
                });

            modelBuilder.Entity("GestorTareas.Models.TareasSubTareas", b =>
                {
                    b.HasOne("GestorTareas.Models.SubTareas", "SubTareas")
                        .WithMany("TareasSubTareas")
                        .HasForeignKey("SubTareasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorTareas.Models.Tareas", "Tareas")
                        .WithMany("TareasSubTareas")
                        .HasForeignKey("TareasId");

                    b.Navigation("SubTareas");

                    b.Navigation("Tareas");
                });

            modelBuilder.Entity("GestorTareas.Models.Categorias", b =>
                {
                    b.Navigation("CategoriasTareas");
                });

            modelBuilder.Entity("GestorTareas.Models.SubTareas", b =>
                {
                    b.Navigation("TareasSubTareas");
                });

            modelBuilder.Entity("GestorTareas.Models.Tareas", b =>
                {
                    b.Navigation("CategoriasTareas");

                    b.Navigation("TareasSubTareas");
                });
#pragma warning restore 612, 618
        }
    }
}