using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using FoodOrdering.Domain.Aggregates.UserAggregate;

namespace FoodOrdering.Infrastructure.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userBuilder)
        {
            userBuilder.HasKey(p => p.Id);

            userBuilder.Property(p => p.Id).ValueGeneratedNever();

            userBuilder.Property(p => p.Name).IsRequired();
            userBuilder.Property(p => p.Surname).IsRequired();
            userBuilder.Property(p => p.Role).IsRequired();
            userBuilder.Property(p => p.Email).IsRequired();
            userBuilder.Property(p => p.PasswordHash).IsRequired();
            userBuilder.Property(p => p.PasswordSalt).IsRequired();

            userBuilder.Property(p => p.Role).HasConversion<string>();
        }
    }
}
