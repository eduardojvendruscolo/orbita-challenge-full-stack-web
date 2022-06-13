﻿// <auto-generated />
using System;
using GrupoA.Education.Student.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GrupoA.Education.Student.Infra.Data.Migrations.PgSql.Education
{
    [DbContext(typeof(EducationDbContext))]
    [Migration("20220609185935_Initial-2022-06-09_15-59")]
    partial class Initial20220609_1559
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GrupoA.Education.Student.Domain.Student.Entities.Student", b =>
                {
                    b.Property<Guid>("PrimaryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Itin")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Ra")
                        .HasColumnType("integer");

                    b.HasKey("PrimaryKey");

                    b.HasIndex("Ra")
                        .IsUnique();

                    b.ToTable("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
