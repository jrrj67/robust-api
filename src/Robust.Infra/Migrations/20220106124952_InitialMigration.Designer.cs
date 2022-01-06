﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Robust.Infra.Context;

#nullable disable

namespace Robust.Infra.Migrations
{
    [DbContext(typeof(RobustContext))]
    [Migration("20220106124952_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Robust.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
