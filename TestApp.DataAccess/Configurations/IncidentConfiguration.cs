using TestApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TestApp.DataAccess.Configurations
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasMany(i => i.Accounts)
                   .WithOne(a => a.Incident);
            builder.HasKey(i => i.Name);
            builder.Property(i => i.Name).ValueGeneratedOnAdd();
        }
    }
}
