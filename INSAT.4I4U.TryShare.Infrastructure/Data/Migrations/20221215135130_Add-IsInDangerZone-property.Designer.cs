﻿// <auto-generated />
using INSAT._4I4U.TryShare.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace INSAT._4I4U.TryShare.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221215135130_Add-IsInDangerZone-property")]
    partial class AddIsInDangerZoneproperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("INSAT._4I4U.TryShare.Core.Models.Tricycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BatteryPercentage")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInDangerZone")
                        .HasColumnType("bit");

                    b.Property<double>("LastKnownLatitude")
                        .HasColumnType("float");

                    b.Property<double>("LastKnownLongitude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Tricycles");
                });
#pragma warning restore 612, 618
        }
    }
}