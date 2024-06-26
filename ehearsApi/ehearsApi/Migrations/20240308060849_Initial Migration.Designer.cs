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
    [Migration("20240308060849_Initial Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
#pragma warning restore 612, 618
        }
    }
}
