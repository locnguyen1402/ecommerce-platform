﻿// <auto-generated />
using System;
using ECommerce.Services.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace product.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20230710152553_AddProductSaleInfo")]
    partial class AddProductSaleInfo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "unaccent");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ECommerce.Services.Product.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("author");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("ImageUrlL")
                        .HasColumnType("text")
                        .HasColumnName("image_url_l");

                    b.Property<string>("ImageUrlM")
                        .HasColumnType("text")
                        .HasColumnName("image_url_m");

                    b.Property<string>("ImageUrlS")
                        .HasColumnType("text")
                        .HasColumnName("image_url_s");

                    b.Property<Guid?>("ProductSaleInfoId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_sale_info_id");

                    b.Property<short>("PublicationYear")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0)
                        .HasColumnName("publication_year");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasDefaultValue("''")
                        .HasColumnName("publisher");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("ECommerce.Services.Product.ProductSaleInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric")
                        .HasDefaultValue(0m)
                        .HasColumnName("price");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("pk_product_sale_info");

                    b.HasIndex("ProductId")
                        .IsUnique()
                        .HasDatabaseName("ix_product_sale_info_product_id");

                    b.ToTable("product_sale_info", (string)null);
                });

            modelBuilder.Entity("ECommerce.Services.Product.ProductSaleInfo", b =>
                {
                    b.HasOne("ECommerce.Services.Product.Product", "Product")
                        .WithOne("ProductSaleInfo")
                        .HasForeignKey("ECommerce.Services.Product.ProductSaleInfo", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_sale_info_products_product_id");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.Services.Product.Product", b =>
                {
                    b.Navigation("ProductSaleInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
