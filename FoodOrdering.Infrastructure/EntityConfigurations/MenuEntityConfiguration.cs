﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Domain.Aggregates.DishAggregate;

namespace FoodOrdering.Infrastructure.EntityConfigurations
{
    public class MenuEntityConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> menuBuilder)
        {
            var navigation = menuBuilder.Metadata.FindNavigation(nameof(Menu.MenuItems));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            menuBuilder.OwnsMany(menu => menu.MenuItems, menuItemsBuilder =>
            {
                menuItemsBuilder.ToTable("MenuItems");

                menuItemsBuilder.HasKey(p => p.Id);

                menuItemsBuilder.HasOne<Dish>().WithMany().HasForeignKey(p => p.DishId);

                menuItemsBuilder.HasIndex(p => p.MenuId);
                menuItemsBuilder.HasIndex(p => p.DishId);

                menuItemsBuilder.Property<Guid>("MenuId").IsRequired();
                menuItemsBuilder.Property<Guid>("DishId").IsRequired();

            });
        }
    }
}