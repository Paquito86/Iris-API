﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestAPI.Models;

#nullable disable

namespace TestAPI.Migrations
{
    [DbContext(typeof(NodeDb))]
    [Migration("20220412181712_InitialCreate1")]
    partial class InitialCreate1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("TestAPI.Models.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPU")
                        .HasColumnType("TEXT");

                    b.Property<int>("CPUCores")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cost")
                        .HasColumnType("REAL");

                    b.Property<int>("DatacenterId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Docker")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Kubernetes")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Monolith")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Provider")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Pterodactyl")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RAM")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Retired")
                        .HasColumnType("INTEGER");

                    b.Property<string>("longId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Nodes");
                });
#pragma warning restore 612, 618
        }
    }
}