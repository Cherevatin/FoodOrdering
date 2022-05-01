using FoodOrdering.Domain.Aggregates.BasketAggregate;
using FoodOrdering.Domain.Aggregates.DishAggregate;
using FoodOrdering.Domain.Aggregates.MenuAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodOrdering.Infrastructure.EntityConfigurations
{
    public class BasketEntityConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> basketBuilder)
        {

            var navigation = basketBuilder.Metadata.FindNavigation(nameof(Basket.BasketItems));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            basketBuilder.HasKey(p => p.Id);

            basketBuilder.Property(p => p.CustomerId).IsRequired();

            basketBuilder.OwnsMany(basket => basket.BasketItems, basketItemsBuilder => {

                basketItemsBuilder.ToTable("BasketItems");

                basketItemsBuilder.HasKey(p => p.Id);

                //basketItemsBuilder.WithOwner().HasForeignKey("BasketId");

                basketItemsBuilder.HasOne<Dish>().WithMany().HasForeignKey(b => b.DishId);
                basketItemsBuilder.HasOne<Menu>().WithMany().HasForeignKey(b => b.MenuId);

                basketItemsBuilder.Property(p => p.Id).ValueGeneratedNever();
                basketItemsBuilder.Property(p => p.DishId).IsRequired();
                basketItemsBuilder.Property(p => p.MenuId).IsRequired();
                basketItemsBuilder.Property(p => p.BasketId).IsRequired();
                basketItemsBuilder.Property(p => p.NumberOfServings).IsRequired();
            });
        }
    }
}
