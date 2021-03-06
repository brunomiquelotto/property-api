﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Redis.Infra.Data.Context;

namespace Redis.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190321170935_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Redis.Domain.Entities.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Redis.Domain.Entities.PropertyUnity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("PropertyId");

                    b.Property<Guid?>("PropertyId1");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId1");

                    b.ToTable("PropertyUnities");
                });

            modelBuilder.Entity("Redis.Domain.Entities.Realtor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Realtor");
                });

            modelBuilder.Entity("Redis.Domain.Entities.PropertyUnity", b =>
                {
                    b.HasOne("Redis.Domain.Entities.Property", "Property")
                        .WithMany("Unities")
                        .HasForeignKey("PropertyId1");
                });
#pragma warning restore 612, 618
        }
    }
}
