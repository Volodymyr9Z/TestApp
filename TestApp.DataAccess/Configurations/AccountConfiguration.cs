using TestApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestApp.DataAccess.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasMany(a => a.Contacts)
                   .WithOne(c => c.Account)
                   .IsRequired();
            builder.HasIndex(a => a.Name).IsUnique();
        }
    }
}
