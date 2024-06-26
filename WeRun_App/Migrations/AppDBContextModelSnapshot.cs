﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeRun_App.Database;

#nullable disable

namespace WeRun_App.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("WeRun_App.Entities.Goal", b =>
                {
                    b.Property<uint>("GoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("GoalType")
                        .HasColumnType("TEXT");

                    b.Property<double?>("GoalValue")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsAchieved")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<uint>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GoalId");

                    b.HasIndex("UserId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("WeRun_App.Entities.Route", b =>
                {
                    b.Property<uint>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("ElevationGain")
                        .HasColumnType("REAL");

                    b.Property<string>("EndPoint")
                        .HasColumnType("TEXT");

                    b.Property<string>("MapData")
                        .HasColumnType("TEXT");

                    b.Property<string>("RouteName")
                        .HasColumnType("TEXT");

                    b.Property<string>("StartPoint")
                        .HasColumnType("TEXT");

                    b.Property<double?>("TotalDistance")
                        .HasColumnType("REAL");

                    b.Property<uint>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RouteId");

                    b.HasIndex("UserId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("WeRun_App.Entities.RunHistory", b =>
                {
                    b.Property<uint>("HistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("BestDistance")
                        .HasColumnType("REAL");

                    b.Property<TimeSpan?>("BestTime")
                        .HasColumnType("TEXT");

                    b.Property<uint>("RouteId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TotalCalories")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("TotalDistance")
                        .HasColumnType("REAL");

                    b.Property<int?>("TotalRuns")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("HistoryId");

                    b.HasIndex("RouteId");

                    b.HasIndex("UserId");

                    b.ToTable("RunHistory");
                });

            modelBuilder.Entity("WeRun_App.Entities.RunLog", b =>
                {
                    b.Property<uint>("RunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CaloriesBurned")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Distance")
                        .HasColumnType("REAL");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<uint?>("RouteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<uint>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RunId");

                    b.HasIndex("RouteId");

                    b.HasIndex("UserId");

                    b.ToTable("RunLogs");
                });

            modelBuilder.Entity("WeRun_App.Entities.User", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WeRun_App.Entities.Goal", b =>
                {
                    b.HasOne("WeRun_App.Entities.User", "User")
                        .WithMany("Goals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WeRun_App.Entities.Route", b =>
                {
                    b.HasOne("WeRun_App.Entities.User", "User")
                        .WithMany("Routes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WeRun_App.Entities.RunHistory", b =>
                {
                    b.HasOne("WeRun_App.Entities.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeRun_App.Entities.User", "User")
                        .WithMany("RunHistory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WeRun_App.Entities.RunLog", b =>
                {
                    b.HasOne("WeRun_App.Entities.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId");

                    b.HasOne("WeRun_App.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WeRun_App.Entities.User", b =>
                {
                    b.Navigation("Goals");

                    b.Navigation("Routes");

                    b.Navigation("RunHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
