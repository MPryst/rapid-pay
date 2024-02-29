﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RapidPay.Data;

#nullable disable

namespace RapidPay.Data.Migrations
{
    [DbContext(typeof(RapidPayDbContext))]
    [Migration("20240229164848_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("RapidPay")
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RapidPay.Data.Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpirationMonth")
                        .HasColumnType("int");

                    b.Property<int>("ExpirationYear")
                        .HasColumnType("int");

                    b.Property<string>("Numbers")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("Numbers")
                        .IsUnique();

                    b.ToTable("Cards", "RapidPay");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0ee32853-371a-4a5b-85e8-4155bfb15919"),
                            Balance = 10000.0,
                            CVV = 123,
                            CardHolder = "Maxi",
                            ExpirationMonth = 1,
                            ExpirationYear = 2027,
                            Numbers = "123456789012345"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
