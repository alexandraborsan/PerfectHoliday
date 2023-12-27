﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PerfectHoliday.Data;

#nullable disable

namespace PerfectHoliday.Migrations
{
    [DbContext(typeof(PerfectHolidayContext))]
    partial class PerfectHolidayContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PerfectHoliday.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfAdults")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfKids")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HotelID");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("PerfectHoliday.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfStars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("PerfectHoliday.Models.Booking", b =>
                {
                    b.HasOne("PerfectHoliday.Models.Hotel", "Hotel")
                        .WithMany("Bookings")
                        .HasForeignKey("HotelID");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("PerfectHoliday.Models.Hotel", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
