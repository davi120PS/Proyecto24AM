﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto24AM.Context;

#nullable disable

namespace Proyecto24AM.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto24AM.Models.Entities.Article", b =>
                {
                    b.Property<int>("PKArticle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PKArticle"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("PKArticle");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Proyecto24AM.Models.Entities.Book", b =>
                {
                    b.Property<int>("PKBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PKBook"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PKBook");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Proyecto24AM.Models.Entities.Rol", b =>
                {
                    b.Property<int>("PKRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PKRol"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PKRol");

                    b.ToTable("Rols");

                    b.HasData(
                        new
                        {
                            PKRol = 1,
                            Name = "admin"
                        },
                        new
                        {
                            PKRol = 2,
                            Name = "sa"
                        });
                });

            modelBuilder.Entity("Proyecto24AM.Models.Entities.User", b =>
                {
                    b.Property<int>("PKUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PKUser"));

                    b.Property<int?>("FKRol")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PKUser");

                    b.HasIndex("FKRol");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            PKUser = 1,
                            FKRol = 1,
                            Name = "David",
                            Password = "1234",
                            UserName = "davi120",
                            lastName = "Peña"
                        },
                        new
                        {
                            PKUser = 2,
                            FKRol = 2,
                            Name = "Diego",
                            Password = "1234",
                            UserName = "dieguitocraft",
                            lastName = "Cortez"
                        });
                });

            modelBuilder.Entity("Proyecto24AM.Models.Entities.User", b =>
                {
                    b.HasOne("Proyecto24AM.Models.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FKRol");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
