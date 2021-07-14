﻿// <auto-generated />
using System;
using CharCostCalc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CharCostCalc.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210713203956_ascendsTableRemoved")]
    partial class ascendsTableRemoved
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("CharCostCalc.Models.Book", b =>
                {
                    b.Property<int>("Tier")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EXP")
                        .HasColumnType("INTEGER");

                    b.HasKey("Tier");

                    b.ToTable("ExpBooks");
                });

            modelBuilder.Entity("CharCostCalc.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("CharCostCalc.Models.LevelCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CostEXP")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Lvl")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("LevelCosts");
                });

            modelBuilder.Entity("CharCostCalc.Models.Resource", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("CharCostCalc.Models.Upgrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CharId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Lvl")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Resid")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CharId");

                    b.HasIndex("Resid");

                    b.ToTable("Upgrades");
                });

            modelBuilder.Entity("CharCostCalc.Models.Upgrade", b =>
                {
                    b.HasOne("CharCostCalc.Models.Character", "Char")
                        .WithMany()
                        .HasForeignKey("CharId");

                    b.HasOne("CharCostCalc.Models.Resource", "Res")
                        .WithMany()
                        .HasForeignKey("Resid");

                    b.Navigation("Char");

                    b.Navigation("Res");
                });
#pragma warning restore 612, 618
        }
    }
}
