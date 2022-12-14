﻿// <auto-generated />
using System;
using ClayTestCase.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClayTestCase.Infrastructure.Migrations
{
    [DbContext(typeof(AssessmentDataContext))]
    [Migration("20221214200813_secondmig")]
    partial class secondmig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.11");

            modelBuilder.Entity("ClayTestCase.Core.Enitities.AccessRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DoorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DoorId");

                    b.ToTable("AccessRoles");
                });

            modelBuilder.Entity("ClayTestCase.Core.Enitities.Door", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Doors");
                });

            modelBuilder.Entity("ClayTestCase.Core.Enitities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ClayTestCase.Core.Enitities.AccessRoles", b =>
                {
                    b.HasOne("ClayTestCase.Core.Enitities.Door", null)
                        .WithMany("AccessRoles")
                        .HasForeignKey("DoorId");
                });

            modelBuilder.Entity("ClayTestCase.Core.Enitities.Door", b =>
                {
                    b.Navigation("AccessRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
