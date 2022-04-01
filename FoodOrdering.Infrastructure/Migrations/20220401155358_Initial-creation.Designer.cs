﻿// <auto-generated />
using System;
using FoodOrdering.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FoodOrdering.Infrastructure.Migrations
{
    [DbContext(typeof(FoodOrderingContext))]
    [Migration("20220401155358_Initial-creation")]
    partial class Initialcreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FoodOrdering.Domain.Entities.Dish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double?>("Calories")
                        .HasColumnType("double precision");

                    b.Property<double?>("Carbohydrates")
                        .HasColumnType("double precision");

                    b.Property<Guid?>("DishesMenuId")
                        .HasColumnType("uuid");

                    b.Property<double?>("Fats")
                        .HasColumnType("double precision");

                    b.Property<string>("ImageName")
                        .HasColumnType("text");

                    b.Property<string>("Ingredients")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double?>("Proteins")
                        .HasColumnType("double precision");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("DishesMenuId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("FoodOrdering.Domain.Entities.DishesMenu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("ReadyToOrder")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("DishesMenus");
                });

            modelBuilder.Entity("FoodOrdering.Domain.Entities.Dish", b =>
                {
                    b.HasOne("FoodOrdering.Domain.Entities.DishesMenu", "DishesMenu")
                        .WithMany("Dishes")
                        .HasForeignKey("DishesMenuId");

                    b.Navigation("DishesMenu");
                });

            modelBuilder.Entity("FoodOrdering.Domain.Entities.DishesMenu", b =>
                {
                    b.Navigation("Dishes");
                });
#pragma warning restore 612, 618
        }
    }
}