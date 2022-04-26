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
    [Migration("20220420162923_InitCreation")]
    partial class InitCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("FoodOrdering.Domain.Aggregates.BasketAggregate.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("FoodOrdering.Domain.Aggregates.DishAggregate.Dish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Ingredients")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("FoodOrdering.Domain.Aggregates.MenuAggregate.Menu", b =>
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

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("FoodOrdering.Domain.Aggregates.BasketAggregate.Basket", b =>
                {
                    b.OwnsMany("FoodOrdering.Domain.Aggregates.BasketAggregate.BasketItem", "BasketItems", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<Guid>("BasketId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("DishId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uuid");

                            b1.Property<int>("NumberOfServings")
                                .HasColumnType("integer");

                            b1.HasKey("Id");

                            b1.HasIndex("BasketId");

                            b1.HasIndex("DishId");

                            b1.HasIndex("MenuId");

                            b1.ToTable("BasketItems");

                            b1.WithOwner()
                                .HasForeignKey("BasketId");

                            b1.HasOne("FoodOrdering.Domain.Aggregates.DishAggregate.Dish", null)
                                .WithMany()
                                .HasForeignKey("DishId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.HasOne("FoodOrdering.Domain.Aggregates.MenuAggregate.Menu", null)
                                .WithMany()
                                .HasForeignKey("MenuId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();
                        });

                    b.Navigation("BasketItems");
                });

            modelBuilder.Entity("FoodOrdering.Domain.Aggregates.DishAggregate.Dish", b =>
                {
                    b.OwnsOne("FoodOrdering.Domain.Aggregates.DishAggregate.Nutrients", "Nutrients", b1 =>
                        {
                            b1.Property<Guid>("DishId")
                                .HasColumnType("uuid");

                            b1.Property<double?>("Calories")
                                .HasColumnType("double precision");

                            b1.Property<double?>("Carbohydrates")
                                .HasColumnType("double precision");

                            b1.Property<double?>("Fats")
                                .HasColumnType("double precision");

                            b1.Property<double?>("Proteins")
                                .HasColumnType("double precision");

                            b1.HasKey("DishId");

                            b1.ToTable("Dishes");

                            b1.WithOwner()
                                .HasForeignKey("DishId");
                        });

                    b.Navigation("Nutrients");
                });

            modelBuilder.Entity("FoodOrdering.Domain.Aggregates.MenuAggregate.Menu", b =>
                {
                    b.OwnsMany("FoodOrdering.Domain.Aggregates.MenuAggregate.MenuItem", "MenuItems", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<Guid>("DishId")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uuid");

                            b1.HasKey("Id");

                            b1.HasIndex("DishId");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuItems");

                            b1.HasOne("FoodOrdering.Domain.Aggregates.DishAggregate.Dish", null)
                                .WithMany()
                                .HasForeignKey("DishId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.Navigation("MenuItems");
                });
#pragma warning restore 612, 618
        }
    }
}