﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalApi.Context;

#nullable disable

namespace MinimalApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MinimalApi.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CarRaceId")
                        .HasColumnType("int");

                    b.Property<int>("DistanceCoverdInMiles")
                        .HasColumnType("int");

                    b.Property<bool>("FinishedRace")
                        .HasColumnType("bit");

                    b.Property<double>("MelfunctionChance")
                        .HasColumnType("float");

                    b.Property<int>("MelfunctionsOccured")
                        .HasColumnType("int");

                    b.Property<int>("RacedForHours")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarRaceId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("MinimalApi.Models.CarRace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimeLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CarRaces");
                });

            modelBuilder.Entity("MinimalApi.Models.Motorbike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DistanceCoverdInMiles")
                        .HasColumnType("int");

                    b.Property<bool>("FinishedRace")
                        .HasColumnType("bit");

                    b.Property<double>("MelfunctionChance")
                        .HasColumnType("float");

                    b.Property<int>("MelfunctionsOccured")
                        .HasColumnType("int");

                    b.Property<int>("RacedForHours")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Motorbikes");
                });

            modelBuilder.Entity("MinimalApi.Models.Car", b =>
                {
                    b.HasOne("MinimalApi.Models.CarRace", null)
                        .WithMany("Cars")
                        .HasForeignKey("CarRaceId");
                });

            modelBuilder.Entity("MinimalApi.Models.CarRace", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}