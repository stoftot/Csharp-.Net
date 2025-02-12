﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.DataAccess.Data;

#nullable disable

namespace Web.Api.Migrations
{
    [DbContext(typeof(UniversityDbContext))]
    [Migration("20250208231302_MovedProjects")]
    partial class MovedProjects
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<string>("SubjectsCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("SubjectsCode", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("Api.DataAccess.Models.ClassRoom", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("Api.DataAccess.Models.Course", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("ClassRoomCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CourseAdministratorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.HasIndex("ClassRoomCode");

                    b.HasIndex("CourseAdministratorId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Api.DataAccess.Models.Subject", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Api.DataAccess.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("Api.DataAccess.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.DataAccess.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.DataAccess.Models.Course", b =>
                {
                    b.HasOne("Api.DataAccess.Models.ClassRoom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomCode")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Api.DataAccess.Models.Teacher", "CourseAdministrator")
                        .WithMany("Courses")
                        .HasForeignKey("CourseAdministratorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Api.DataAccess.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ClassRoom");

                    b.Navigation("CourseAdministrator");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Api.DataAccess.Models.Teacher", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
