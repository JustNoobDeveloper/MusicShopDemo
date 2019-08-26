﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicShop.Models;

namespace MusicShop.Migrations
{
    [DbContext(typeof(MusicShopContentContext))]
    partial class MusicShopContentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusicShop.Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreName");

                    b.HasKey("ID");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MusicShop.Models.Music", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArtistName");

                    b.Property<int>("GenreId");

                    b.Property<string>("MusicName");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.HasIndex("GenreId");

                    b.ToTable("Music");
                });

            modelBuilder.Entity("MusicShop.Models.Sales", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("PaymentMethod");

                    b.Property<string>("ProductID");

                    b.Property<decimal>("Total");

                    b.HasKey("ID");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("MusicShop.Models.Test", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("MusicShop.Models.Music", b =>
                {
                    b.HasOne("MusicShop.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
