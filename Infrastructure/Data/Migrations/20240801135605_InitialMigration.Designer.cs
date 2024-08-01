﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240801135605_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.PriceList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PriceLists");
                });

            modelBuilder.Entity("Domain.Entities.PriceListColValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PriceListColumnId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("value_type")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.HasKey("Id");

                    b.HasIndex("PriceListColumnId");

                    b.HasIndex("ProductId");

                    b.ToTable("PriceListColValue");

                    b.HasDiscriminator<string>("value_type").HasValue("PriceListColValue");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.PriceListColumn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PriceListColValType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<Guid>("PriceListId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PriceListId");

                    b.ToTable("PriceListColumns");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PriceListProduct", b =>
                {
                    b.Property<Guid>("PriceListsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PriceListsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("PriceListProduct");
                });

            modelBuilder.Entity("Domain.Entities.PriceListColValueInt", b =>
                {
                    b.HasBaseType("Domain.Entities.PriceListColValue");

                    b.Property<int>("Value")
                        .HasColumnType("int")
                        .HasColumnName("valueInt");

                    b.HasDiscriminator().HasValue("Int");
                });

            modelBuilder.Entity("Domain.Entities.PriceListColValueString", b =>
                {
                    b.HasBaseType("Domain.Entities.PriceListColValue");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("valueString");

                    b.HasDiscriminator().HasValue("String");
                });

            modelBuilder.Entity("Domain.Entities.PriceListColValueText", b =>
                {
                    b.HasBaseType("Domain.Entities.PriceListColValue");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(2000)")
                        .HasColumnName("valueText");

                    b.HasDiscriminator().HasValue("Text");
                });

            modelBuilder.Entity("Domain.Entities.PriceListColValue", b =>
                {
                    b.HasOne("Domain.Entities.PriceListColumn", "PriceListColumn")
                        .WithMany("PriceListColValues")
                        .HasForeignKey("PriceListColumnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", "Product")
                        .WithMany("priceListColumnValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PriceListColumn");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.PriceListColumn", b =>
                {
                    b.HasOne("Domain.Entities.PriceList", "PriceList")
                        .WithMany("Columns")
                        .HasForeignKey("PriceListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PriceList");
                });

            modelBuilder.Entity("PriceListProduct", b =>
                {
                    b.HasOne("Domain.Entities.PriceList", null)
                        .WithMany()
                        .HasForeignKey("PriceListsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.PriceList", b =>
                {
                    b.Navigation("Columns");
                });

            modelBuilder.Entity("Domain.Entities.PriceListColumn", b =>
                {
                    b.Navigation("PriceListColValues");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Navigation("priceListColumnValues");
                });
#pragma warning restore 612, 618
        }
    }
}
