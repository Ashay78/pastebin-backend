﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pastebin_backend.Models;

#nullable disable

namespace Pastebin_backend.Migrations
{
    [DbContext(typeof(PastebinContext))]
    [Migration("20221007183434_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Pastebin_backend.Models.Pastebin", b =>
                {
                    b.Property<string>("key")
                        .HasColumnType("text");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("code")
                        .HasColumnType("text");

                    b.Property<long>("dateEnd")
                        .HasColumnType("bigint");

                    b.Property<string>("type")
                        .HasColumnType("text");

                    b.HasKey("key");

                    b.ToTable("Pastebins");
                });
#pragma warning restore 612, 618
        }
    }
}
