using Microsoft.EntityFrameworkCore;

using FoodOrdering.Domain.Entities;

namespace FoodOrdering.Infrastructure
{
    public class FoodOrderingContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }

        public DbSet<DishesMenu> DishesMenus { get; set; }

        public FoodOrderingContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
