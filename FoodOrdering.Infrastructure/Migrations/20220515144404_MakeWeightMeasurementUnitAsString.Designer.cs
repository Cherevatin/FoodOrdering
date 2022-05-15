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
    [Migration("20220515144404_MakeWeightMeasurementUnitAsString")]
    partial class MakeWeightMeasurementUnitAsString
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
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("FoodOrdering.Domain.Aggregates.DishAggregate.Dish", b =>
                {
                    b.Property<Guid>("Id")
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

                    b.HasKey("Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("FoodOrdering.Domain.Aggregates.MenuAggregate.Menu", b =>
                {
                    b.Property<Guid>("Id")
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

            modelBuilder.Entity("FoodOrdering.Domain.Aggregates.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodOrdering.Domain.Aggregates.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FoodOrdering.Domain.Aggregates.BasketAggregate.Basket", b =>
                {
                    b.OwnsMany("FoodOrdering.Domain.Aggregates.BasketAggregate.BasketItem", "BasketItems", b1 =>
                        {
                            b1.Property<Guid>("Id")
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

                            b1.Property<double>("Calories")
                                .HasColumnType("double precision");

                            b1.Property<double>("Carbohydrates")
                                .HasColumnType("double precision");

                            b1.Property<double>("Fats")
                                .HasColumnType("double precision");

                            b1.Property<double>("Proteins")
                                .HasColumnType("double precision");

                            b1.HasKey("DishId");

                            b1.ToTable("Dishes");

                            b1.WithOwner()
                                .HasForeignKey("DishId");
                        });

                    b.OwnsOne("FoodOrdering.Domain.Aggregates.DishAggregate.Weight", "Weight", b1 =>
                        {
                            b1.Property<Guid>("DishId")
                                .HasColumnType("uuid");

                            b1.Property<string>("MesurementUnit")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<double>("Value")
                                .HasColumnType("double precision");

                            b1.HasKey("DishId");

                            b1.ToTable("Dishes");

                            b1.WithOwner()
                                .HasForeignKey("DishId");
                        });

                    b.Navigation("Nutrients");

                    b.Navigation("Weight");
                });

            modelBuilder.Entity("FoodOrdering.Domain.Aggregates.MenuAggregate.Menu", b =>
                {
                    b.OwnsMany("FoodOrdering.Domain.Aggregates.MenuAggregate.MenuItem", "MenuItems", b1 =>
                        {
                            b1.Property<Guid>("Id")
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

            modelBuilder.Entity("FoodOrdering.Domain.Aggregates.OrderAggregate.Order", b =>
                {
                    b.OwnsMany("FoodOrdering.Domain.Aggregates.OrderAggregate.OrderItem", "OrderItems", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("DishId")
                                .HasColumnType("uuid");

                            b1.Property<double>("DishPrice")
                                .HasColumnType("double precision");

                            b1.Property<string>("DishTitle")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Units")
                                .HasColumnType("integer");

                            b1.HasKey("Id");

                            b1.HasIndex("DishId");

                            b1.HasIndex("OrderId");

                            b1.ToTable("OrdersItems");

                            b1.HasOne("FoodOrdering.Domain.Aggregates.DishAggregate.Dish", null)
                                .WithMany()
                                .HasForeignKey("DishId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}