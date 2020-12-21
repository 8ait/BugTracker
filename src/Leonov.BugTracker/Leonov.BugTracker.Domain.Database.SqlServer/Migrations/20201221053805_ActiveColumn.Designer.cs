﻿// <auto-generated />
using System;
using Leonov.BugTracker.Domain.Database.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leonov.BugTracker.Domain.Database.SqlServer.Migrations
{
    [DbContext(typeof(BugTrackerContext))]
    [Migration("20201221053805_ActiveColumn")]
    partial class ActiveColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ArmUserType", b =>
                {
                    b.Property<int>("ArmsId")
                        .HasColumnType("int");

                    b.Property<int>("UserTypesId")
                        .HasColumnType("int");

                    b.HasKey("ArmsId", "UserTypesId");

                    b.HasIndex("UserTypesId");

                    b.ToTable("ArmUserType");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.Arm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("arm");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.Audit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("About")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ErrorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ErrorStatusId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ErrorId");

                    b.HasIndex("ErrorStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("audit");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.Commentary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ErrorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("ErrorId");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("commentary");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.Error", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("About")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreateUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ErrorStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.Property<Guid>("ResponsibleUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreateUserId");

                    b.HasIndex("ErrorStatusId");

                    b.HasIndex("OriginId");

                    b.HasIndex("ResponsibleUserId");

                    b.ToTable("error");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.ErrorStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("error_status");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.OriginArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("origin_area");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<string>("About")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("project");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<byte[]>("CookieSession")
                        .HasMaxLength(128)
                        .HasColumnType("varbinary(128)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<byte[]>("HashPassword")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varbinary(128)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varbinary(128)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("UserTypeId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.UserInProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("user_in_project");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("user_type");
                });

            modelBuilder.Entity("ArmUserType", b =>
                {
                    b.HasOne("Leonov.BugTracker.Domain.Models.Arm", null)
                        .WithMany()
                        .HasForeignKey("ArmsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leonov.BugTracker.Domain.Models.UserType", null)
                        .WithMany()
                        .HasForeignKey("UserTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.Audit", b =>
                {
                    b.HasOne("Leonov.BugTracker.Domain.Models.Error", "Error")
                        .WithMany()
                        .HasForeignKey("ErrorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leonov.BugTracker.Domain.Models.ErrorStatus", "ErrorStatus")
                        .WithMany()
                        .HasForeignKey("ErrorStatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Leonov.BugTracker.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Error");

                    b.Navigation("ErrorStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.Commentary", b =>
                {
                    b.HasOne("Leonov.BugTracker.Domain.Models.Error", "Error")
                        .WithMany()
                        .HasForeignKey("ErrorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leonov.BugTracker.Domain.Models.Commentary", "Parent")
                        .WithMany("Commentaries")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Leonov.BugTracker.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Error");

                    b.Navigation("Parent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.Error", b =>
                {
                    b.HasOne("Leonov.BugTracker.Domain.Models.UserInProject", "CreateUser")
                        .WithMany()
                        .HasForeignKey("CreateUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Leonov.BugTracker.Domain.Models.ErrorStatus", "ErrorStatus")
                        .WithMany()
                        .HasForeignKey("ErrorStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leonov.BugTracker.Domain.Models.OriginArea", "OriginArea")
                        .WithMany()
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leonov.BugTracker.Domain.Models.UserInProject", "ResponsibleUser")
                        .WithMany()
                        .HasForeignKey("ResponsibleUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreateUser");

                    b.Navigation("ErrorStatus");

                    b.Navigation("OriginArea");

                    b.Navigation("ResponsibleUser");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.User", b =>
                {
                    b.HasOne("Leonov.BugTracker.Domain.Models.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.UserInProject", b =>
                {
                    b.HasOne("Leonov.BugTracker.Domain.Models.Project", "Project")
                        .WithMany("UserInProject")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leonov.BugTracker.Domain.Models.User", "User")
                        .WithMany("UserInProject")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.Commentary", b =>
                {
                    b.Navigation("Commentaries");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.Project", b =>
                {
                    b.Navigation("UserInProject");
                });

            modelBuilder.Entity("Leonov.BugTracker.Domain.Models.User", b =>
                {
                    b.Navigation("UserInProject");
                });
#pragma warning restore 612, 618
        }
    }
}
