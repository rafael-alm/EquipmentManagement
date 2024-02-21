﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using equipmentManagement.infra.data.input;

#nullable disable

namespace equipmentManagement.infra.data.input.Migrations
{
    [DbContext(typeof(ContextEquipmentManagement))]
    partial class ContextEquipmentManagementModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("equipmentManagement.infra.data.input.entityTypeConfiguration.models.CompanyModel", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(32)
                        .HasColumnType("CHAR");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("RegisteredName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("TypeOfFacility")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Company", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}