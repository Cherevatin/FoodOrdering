using Microsoft.EntityFrameworkCore;

using FoodOrdering.Domain.Entities;

namespace FoodOrdering.Infrastructure
{
    public class FoodOrderingContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Menu> Menus { get; set; }

        //public DbSet<MenuDish> MenuDishes { get; set; }

        public FoodOrderingContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuDish>()
            .HasKey(bc => new { bc.DishId, bc.MenuId });
            modelBuilder.Entity<MenuDish>()
                .HasOne(bc => bc.Dish)
                .WithMany(b => b.Dishes)
                .HasForeignKey(bc => bc.DishId);
            modelBuilder.Entity<MenuDish>()
                .HasOne(bc => bc.Menu)
                .WithMany(c => c.Dishes)
                .HasForeignKey(bc => bc.MenuId);
        }
    }
}
