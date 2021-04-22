﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kassYazilim.DBContext;

namespace kassYazilim.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210422124011_d1")]
    partial class d1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("kassYazilim.Models.Odev", b =>
                {
                    b.Property<int>("OdevId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("OdevId");

                    b.ToTable("odev");
                });

            modelBuilder.Entity("kassYazilim.Models.Ogrenci", b =>
                {
                    b.Property<Guid>("OgrenciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("OdevId")
                        .HasColumnType("int");

                    b.HasKey("OgrenciId");

                    b.HasIndex("OdevId");

                    b.ToTable("ogrenci");
                });

            modelBuilder.Entity("kassYazilim.Models.Ogrenci", b =>
                {
                    b.HasOne("kassYazilim.Models.Odev", "Odev")
                        .WithMany("ogrencis")
                        .HasForeignKey("OdevId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Odev");
                });

            modelBuilder.Entity("kassYazilim.Models.Odev", b =>
                {
                    b.Navigation("ogrencis");
                });
#pragma warning restore 612, 618
        }
    }
}
