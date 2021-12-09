﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccess.Migrations
{
    [DbContext(typeof(PostgreContext))]
    [Migration("20211209123658_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DataAccess.Models.Boards.BoardEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("DataAccess.Models.Boards.SectionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BoardId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("DataAccess.Models.Boards.SprintEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BoardId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Ends")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Starts")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("DataAccess.Models.Boards.Tasks.TaskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("From")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("Until")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("DataAccess.Models.Teams.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TaskEntityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TaskEntityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SprintEntityTaskEntity", b =>
                {
                    b.Property<Guid>("SprintId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TasksId")
                        .HasColumnType("uuid");

                    b.HasKey("SprintId", "TasksId");

                    b.HasIndex("TasksId");

                    b.ToTable("SprintEntityTaskEntity");
                });

            modelBuilder.Entity("DataAccess.Models.Boards.BoardEntity", b =>
                {
                    b.HasOne("DataAccess.Models.Teams.UserEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DataAccess.Models.Boards.SectionEntity", b =>
                {
                    b.HasOne("DataAccess.Models.Boards.BoardEntity", "Board")
                        .WithMany("Sections")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("DataAccess.Models.Boards.SprintEntity", b =>
                {
                    b.HasOne("DataAccess.Models.Boards.BoardEntity", "Board")
                        .WithMany("Sprints")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Board");
                });

            modelBuilder.Entity("DataAccess.Models.Boards.Tasks.TaskEntity", b =>
                {
                    b.HasOne("DataAccess.Models.Boards.SectionEntity", "Section")
                        .WithMany("Tasks")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("DataAccess.Models.Teams.UserEntity", b =>
                {
                    b.HasOne("DataAccess.Models.Boards.Tasks.TaskEntity", null)
                        .WithMany("Assignees")
                        .HasForeignKey("TaskEntityId");
                });

            modelBuilder.Entity("SprintEntityTaskEntity", b =>
                {
                    b.HasOne("DataAccess.Models.Boards.SprintEntity", null)
                        .WithMany()
                        .HasForeignKey("SprintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Models.Boards.Tasks.TaskEntity", null)
                        .WithMany()
                        .HasForeignKey("TasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccess.Models.Boards.BoardEntity", b =>
                {
                    b.Navigation("Sections");

                    b.Navigation("Sprints");
                });

            modelBuilder.Entity("DataAccess.Models.Boards.SectionEntity", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("DataAccess.Models.Boards.Tasks.TaskEntity", b =>
                {
                    b.Navigation("Assignees");
                });
#pragma warning restore 612, 618
        }
    }
}