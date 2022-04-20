using Microsoft.EntityFrameworkCore;
using FoodOrdering.Infrastructure.EntityConfigurations;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using FoodOrdering.Domain.Aggregates.BasketAggregate;

namespace FoodOrdering.Infrastructure
{
    public class FoodOrderingContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public FoodOrderingContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DishEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BasketEntityConfiguration());
        }
    }
}
