﻿using Microsoft.EntityFrameworkCore;

using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Domain.Aggregates.BasketAggregate;
using FoodOrdering.Domain.Aggregates.OrderAggregate;
using FoodOrdering.Infrastructure.EntityConfigurations;

namespace FoodOrdering.Infrastructure
{
    public class FoodOrderingContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<Order> Orders { get; set; }

        public FoodOrderingContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DishEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BasketEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
        }
    }
}
