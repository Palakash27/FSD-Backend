﻿// <auto-generated />
using BackEndTask.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEndTask.Migrations
{
    [DbContext(typeof(ExcelProcessorDbContext))]
    partial class ExcelProcessorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackEndTask.DTOs.ZoneClickCountDTO", b =>
                {
                    b.Property<int>("ClickCount")
                        .HasColumnType("int");

                    b.Property<string>("ZoneName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ZoneClickCountDTO");
                });

            modelBuilder.Entity("BackEndTask.Data.Entities.ClickZone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("XCord")
                        .HasColumnType("float");

                    b.Property<double>("YCord")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ClickZone", (string)null);
                });

            modelBuilder.Entity("BackEndTask.Data.Entities.Zone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ZoneCord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZoneName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zone", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}