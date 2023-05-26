﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement.Services;

#nullable disable

namespace StudentManagement.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20230525211140_idk")]
    partial class idk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("StudentManagement.Models.Absence", b =>
                {
                    b.Property<int>("AbsenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AbsenceId");

                    b.HasIndex("CourseCode");

                    b.HasIndex("StudentId");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("StudentManagement.Models.Course", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("CourseCode");

                    b.HasIndex("GroupCode");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("StudentManagement.Models.Group", b =>
                {
                    b.Property<string>("GroupCode")
                        .HasColumnType("TEXT");

                    b.Property<int>("Grade")
                        .HasColumnType("INTEGER");

                    b.HasKey("GroupCode");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("StudentManagement.Models.Mark", b =>
                {
                    b.Property<int>("MarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DateReceived")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("MarkId");

                    b.HasIndex("CourseCode");

                    b.HasIndex("StudentId");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("StudentManagement.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GroupCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("StudentId");

                    b.HasIndex("GroupCode");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentManagement.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Subject")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("StudentManagement.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentManagement.Models.Absence", b =>
                {
                    b.HasOne("StudentManagement.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentManagement.Models.Course", b =>
                {
                    b.HasOne("StudentManagement.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("StudentManagement.Models.Mark", b =>
                {
                    b.HasOne("StudentManagement.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentManagement.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentManagement.Models.Student", b =>
                {
                    b.HasOne("StudentManagement.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });
#pragma warning restore 612, 618
        }
    }
}
