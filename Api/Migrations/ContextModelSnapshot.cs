﻿// <auto-generated />
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Api.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Modelos.Lista", b =>
                {
                    b.Property<int>("ListaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<int>("UsuarioId");

                    b.HasKey("ListaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Listas");
                });

            modelBuilder.Entity("Modelos.Tarefa", b =>
                {
                    b.Property<int>("TarefaId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Concluida");

                    b.Property<int>("ListaId");

                    b.Property<string>("Nome");

                    b.HasKey("TarefaId");

                    b.HasIndex("ListaId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("Modelos.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Modelos.Lista", b =>
                {
                    b.HasOne("Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Modelos.Tarefa", b =>
                {
                    b.HasOne("Modelos.Lista", "Lista")
                        .WithMany()
                        .HasForeignKey("ListaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
