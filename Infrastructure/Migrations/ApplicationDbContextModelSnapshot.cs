﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test.Infrastructure.Persistence;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctor", "dbo");
                });

            modelBuilder.Entity("Domain.Entities.ReserveTime", b =>
                {
                    b.Property<long>("ReserveTimeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ReserveTimeId"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndReservationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReservationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReserveLimitCount")
                        .HasColumnType("int");

                    b.Property<bool>("ReserveTimeLocked")
                        .HasColumnType("bit");

                    b.Property<int>("ReserveUserCount")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("StartReservationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrackingBaseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ReserveTimeId");

                    b.HasIndex("DoctorId");

                    b.ToTable("ReserveTime", "dbo");
                });

            modelBuilder.Entity("Domain.Entities.ReserveTimeUser", b =>
                {
                    b.Property<long>("ReserveTimeUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ReserveTimeUserId"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ReserveTimeId")
                        .HasColumnType("bigint");

                    b.Property<string>("TrackingCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReserveTimeUserId");

                    b.HasIndex("ReserveTimeId");

                    b.ToTable("ReserveTimeUser", "dbo");
                });

            modelBuilder.Entity("Domain.Entities.ReserveTime", b =>
                {
                    b.HasOne("Domain.Entities.Doctor", "Doctor")
                        .WithMany("ReserveTimes")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Domain.Entities.ReserveTimeUser", b =>
                {
                    b.HasOne("Domain.Entities.ReserveTime", null)
                        .WithMany("ReserveTimeUsers")
                        .HasForeignKey("ReserveTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Doctor", b =>
                {
                    b.Navigation("ReserveTimes");
                });

            modelBuilder.Entity("Domain.Entities.ReserveTime", b =>
                {
                    b.Navigation("ReserveTimeUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
