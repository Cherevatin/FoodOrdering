using FoodOrdering.Domain.Aggregates.DishAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Infrastructure.EntityConfigurations
{
    public class DishEntityConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> dishBuilder)
        {
            dishBuilder.HasKey(p => p.Id);

            dishBuilder.Property(p => p.Name).IsRequired();
            dishBuilder.Property(p => p.Price).IsRequired();
            dishBuilder.Property(p => p.Weight).IsRequired();

            dishBuilder.OwnsOne(dish => dish.Nutrients);
            
        }
    }
}
