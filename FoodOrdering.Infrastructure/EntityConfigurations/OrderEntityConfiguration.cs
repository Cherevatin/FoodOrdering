using FoodOrdering.Domain.Aggregates.BasketAggregate;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdering.Infrastructure.EntityConfigurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> orderBuilder)
        {
            orderBuilder.HasKey(p => p.Id);

            orderBuilder.Property(p => p.CreatedAt).IsRequired();
            orderBuilder.Property(p => p.ExecutionDate).IsRequired();
            orderBuilder.Property(p => p.Status).IsRequired();

            orderBuilder.OwnsMany(order => order.OrderItems, orderItemsBuilder =>
            {
                orderItemsBuilder.ToTable("OrdersItems");

                orderItemsBuilder.HasKey(p => p.Id);

                orderItemsBuilder.Property(p => p.DishId).IsRequired();
                orderItemsBuilder.Property(p => p.DishTitle).IsRequired();
                orderItemsBuilder.Property(p => p.DishPrice).IsRequired();
                orderItemsBuilder.Property(p => p.Units).IsRequired();

                orderItemsBuilder.HasOne<Dish>().WithMany().HasForeignKey(p => p.DishId);

            });
        }
    }
}
