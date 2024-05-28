﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.Database;

#nullable disable

namespace Shared.Migrations
{
    [DbContext(typeof(AirVolunteerDBContext))]
    [Migration("20240528151030_2405281210")]
    partial class _2405281210
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Shared.Models.FlightMOD", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AirplaneModel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DestinyAirport")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FullPaxMaxLoad")
                        .HasColumnType("int");

                    b.Property<string>("OriginAirport")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PaxPositionsAvailable")
                        .HasColumnType("int");

                    b.Property<Guid>("PilotId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PilotId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Shared.Models.PilotMOD", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<long>("CPF")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("Shared.Models.FlightMOD", b =>
                {
                    b.HasOne("Shared.Models.PilotMOD", "Pilot")
                        .WithMany()
                        .HasForeignKey("PilotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pilot");
                });
#pragma warning restore 612, 618
        }
    }
}