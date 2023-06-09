﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherService.Data;

#nullable disable

namespace WeatherService_DynamicSun.Migrations
{
    [DbContext(typeof(WeatherServiceContext))]
    partial class WeatherServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WeatherService_DynamicSun.Models.WeatherConditions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short>("AtmosphericPressure")
                        .HasColumnType("smallint");

                    b.Property<byte?>("CloudCover")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DewPoint")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)");

                    b.Property<string>("HorizontalVisibility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("LowerCloudLimit")
                        .HasColumnType("smallint");

                    b.Property<decimal>("RelativeHumidity")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("TemperatureAir")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<string>("WeatherPhenomena")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("WindDirection")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<byte?>("WindSpeed")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("WeatherConditions");
                });
#pragma warning restore 612, 618
        }
    }
}
