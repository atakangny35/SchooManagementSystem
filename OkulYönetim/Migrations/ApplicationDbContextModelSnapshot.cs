﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OkulYönetim.Entity.EntityFramework.Context;

#nullable disable

namespace OkulYönetim.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OkulYönetim.Entity.concrete.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.Ders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DersAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dersler");
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DersID")
                        .HasColumnType("int");

                    b.Property<float>("NoteValue")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DersID");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Branch = "Admin",
                            Email = "adminuser123>gmail.com",
                            Name = "AmidnUser",
                            PasswordHash = new byte[] { 204, 138, 11, 124, 163, 115, 117, 14, 245, 91, 156, 188, 53, 154, 131, 116, 32, 138, 30, 82, 251, 225, 76, 55, 102, 99, 153, 147, 146, 6, 243, 46 },
                            PasswordSalt = new byte[] { 30, 11, 153, 186, 202, 59, 76, 220, 0, 176, 103, 245, 238, 236, 12, 164, 133, 181, 126, 1, 194, 177, 163, 192, 78, 167, 170, 194, 5, 181, 129, 199, 156, 20, 90, 213, 125, 248, 42, 175, 255, 119, 153, 156, 16, 93, 140, 144, 242, 250, 169, 57, 74, 120, 225, 54, 43, 237, 217, 101, 155, 198, 247, 74 },
                            Surname = "AmidnUser",
                            UserRoleId = 4
                        });
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.UserClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("UserId");

                    b.ToTable("UserClasses");
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.UserDers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Dersid")
                        .HasColumnType("int");

                    b.Property<int>("Userid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Dersid");

                    b.HasIndex("Userid");

                    b.ToTable("UserDers");
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            RoleName = "Admin"
                        });
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.Note", b =>
                {
                    b.HasOne("OkulYönetim.Entity.concrete.Ders", "Dersler")
                        .WithMany()
                        .HasForeignKey("DersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OkulYönetim.Entity.concrete.User", "Users")
                        .WithMany("Notes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dersler");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.User", b =>
                {
                    b.HasOne("OkulYönetim.Entity.concrete.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.UserClass", b =>
                {
                    b.HasOne("OkulYönetim.Entity.concrete.Class", "Classes")
                        .WithMany("userClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OkulYönetim.Entity.concrete.User", "Users")
                        .WithMany("userClasses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classes");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.UserDers", b =>
                {
                    b.HasOne("OkulYönetim.Entity.concrete.Ders", "Dersler")
                        .WithMany("userDers")
                        .HasForeignKey("Dersid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OkulYönetim.Entity.concrete.User", "Users")
                        .WithMany("userDers")
                        .HasForeignKey("Userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dersler");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.Class", b =>
                {
                    b.Navigation("userClasses");
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.Ders", b =>
                {
                    b.Navigation("userDers");
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.User", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("userClasses");

                    b.Navigation("userDers");
                });

            modelBuilder.Entity("OkulYönetim.Entity.concrete.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
