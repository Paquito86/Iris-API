﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestAPI.Models;

#nullable disable

namespace TestAPI.Migrations.KeyDbMigrations
{
    [DbContext(typeof(KeyDb))]
    [Migration("20220412181726_InitialCreate2")]
    partial class InitialCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("TestAPI.Models.SSHPubKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Node_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RSA")
                        .HasColumnType("TEXT");

                    b.Property<string>("Workstation")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Keys");
                });
#pragma warning restore 612, 618
        }
    }
}
