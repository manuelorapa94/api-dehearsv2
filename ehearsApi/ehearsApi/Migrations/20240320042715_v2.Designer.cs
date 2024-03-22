﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ehearsApi.Data;

#nullable disable

namespace ehearsApi.Migrations
{
    [DbContext(typeof(dhearsApiContext))]
    [Migration("20240320042715_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ehearsApi.Models.QRInformation", b =>
                {
                    b.Property<string>("qrCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("civilStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("extName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("formattedBirthdate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("sex")
                        .HasColumnType("bit");

                    b.HasKey("qrCode");

                    b.ToTable("QRInformations");
                });

            modelBuilder.Entity("ehearsApi.Models.ReasonType", b =>
                {
                    b.Property<Guid>("reasonTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("reasonTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("reasonTypeId");

                    b.ToTable("ReasonTypes");
                });

            modelBuilder.Entity("ehearsApi.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}