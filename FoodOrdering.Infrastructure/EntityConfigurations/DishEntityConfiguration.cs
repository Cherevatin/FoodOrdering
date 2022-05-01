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
            //var navigation = dishBuilder.Metadata.FindNavigation(nameof(Dish.Weight));             ???  
            //navigation.SetPropertyAccessMode(PropertyAccessMode.Field);                            ???
                                                                                                     
            //var navigation1 = dishBuilder.Metadata.FindNavigation(nameof(Dish.Nutrients));         ???
            //navigation1.SetPropertyAccessMode(PropertyAccessMode.Field);                           ???

            dishBuilder.HasKey(p => p.Id);

            dishBuilder.Property(p => p.Name).IsRequired();
            dishBuilder.Property(p => p.Price).IsRequired();

            dishBuilder.OwnsOne(dish => dish.Nutrients);

            dishBuilder.OwnsOne(dish => dish.Weight, weightBuilder => 
            {
                weightBuilder.Property(p => p.MesurementUnit).IsRequired();
                weightBuilder.Property(p => p.Value).IsRequired();
            });
            
        }
    }
}
