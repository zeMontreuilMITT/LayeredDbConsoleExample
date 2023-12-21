﻿// <auto-generated />
using System;
using LayeredDbConsole.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LayeredDbConsole.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LayeredDbConsole.Models.Customer", b =>
                {
                    b.Property<Guid>("RegistrationNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RegistrationNumber");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LayeredDbConsole.Models.Lease", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerRegistrationNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VehicleRegistrationNumber")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerRegistrationNumber");

                    b.HasIndex("VehicleRegistrationNumber")
                        .IsUnique();

                    b.ToTable("Leases");
                });

            modelBuilder.Entity("LayeredDbConsole.Models.Vehicle", b =>
                {
                    b.Property<Guid>("RegistrationNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Colour")
                        .HasColumnType("int");

                    b.Property<string>("LicenceNumber")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RegistrationNumber");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("LayeredDbConsole.Models.Lease", b =>
                {
                    b.HasOne("LayeredDbConsole.Models.Customer", "Customer")
                        .WithMany("Leases")
                        .HasForeignKey("CustomerRegistrationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LayeredDbConsole.Models.Vehicle", "Vehicle")
                        .WithOne("Lease")
                        .HasForeignKey("LayeredDbConsole.Models.Lease", "VehicleRegistrationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("LayeredDbConsole.Models.Customer", b =>
                {
                    b.Navigation("Leases");
                });

            modelBuilder.Entity("LayeredDbConsole.Models.Vehicle", b =>
                {
                    b.Navigation("Lease");
                });
#pragma warning restore 612, 618
        }
    }
}
