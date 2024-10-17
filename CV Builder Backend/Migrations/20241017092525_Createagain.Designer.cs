﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CVBuilder.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241017092525_Createagain")]
    partial class Createagain
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Accomplishment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IssuedOn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonalInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInfoId");

                    b.ToTable("Accomplishments");
                });

            modelBuilder.Entity("Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Achievement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EndYear")
                        .HasColumnType("int");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PersonalInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInfoId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PersonalInfoId")
                        .HasColumnType("int");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInfoId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("PersonalInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GitHubUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LinkedInUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PersonalInfos");
                });

            modelBuilder.Entity("Skills", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PersonalInfoId")
                        .HasColumnType("int");

                    b.Property<string>("Reading")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speaking")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Writing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonalInfoId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Accomplishment", b =>
                {
                    b.HasOne("PersonalInfo", "PersonalInfo")
                        .WithMany("Accomplishments")
                        .HasForeignKey("PersonalInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("Education", b =>
                {
                    b.HasOne("PersonalInfo", "PersonalInfo")
                        .WithMany("Educations")
                        .HasForeignKey("PersonalInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("Experience", b =>
                {
                    b.HasOne("PersonalInfo", "PersonalInfo")
                        .WithMany("Experiences")
                        .HasForeignKey("PersonalInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("Skills", b =>
                {
                    b.HasOne("PersonalInfo", "PersonalInfo")
                        .WithMany("Skills")
                        .HasForeignKey("PersonalInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInfo");
                });

            modelBuilder.Entity("PersonalInfo", b =>
                {
                    b.Navigation("Accomplishments");

                    b.Navigation("Educations");

                    b.Navigation("Experiences");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
