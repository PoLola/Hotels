﻿// <auto-generated />
using System;
using Hotels.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotels.Infrastructure.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotels.Domain.Entities.Guest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("guestid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birthdate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("gender");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("identificationnumber");

                    b.Property<string>("IdentificationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("identificationtype");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.Property<long>("ReservationId")
                        .HasColumnType("bigint")
                        .HasColumnName("reservationid");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("guest");
                });

            modelBuilder.Entity("Hotels.Domain.Entities.Hotel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("hotelid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<long>("AgencyId")
                        .HasColumnType("bigint")
                        .HasColumnName("agencyid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("city");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("isenabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("hotels");
                });

            modelBuilder.Entity("Hotels.Domain.Entities.Reservation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("reservationid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("EmergencyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("emergencyname");

                    b.Property<string>("EmergencyPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("emergencyphone");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint")
                        .HasColumnName("roomid");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("Hotels.Domain.Entities.Room", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("roomid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("HotelId")
                        .HasColumnType("bigint")
                        .HasColumnName("hotelid");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("isenabled");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("location");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int")
                        .HasColumnName("maxcapacity");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Taxes")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("taxes");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("Hotels.Domain.Entities.Guest", b =>
                {
                    b.HasOne("Hotels.Domain.Entities.Reservation", "Reservation")
                        .WithMany("Guests")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Hotels.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Hotels.Domain.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Hotels.Domain.Entities.Room", b =>
                {
                    b.HasOne("Hotels.Domain.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Hotels.Domain.Entities.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Hotels.Domain.Entities.Reservation", b =>
                {
                    b.Navigation("Guests");
                });
#pragma warning restore 612, 618
        }
    }
}
