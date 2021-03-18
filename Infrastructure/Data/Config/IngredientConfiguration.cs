using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
           builder.Property(p => p.Id).IsRequired();
           builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
           builder.Property(p => p.Description).HasMaxLength(180);
           builder.Property(p => p.Protein).HasColumnType("decimal(18,2)");
           builder.Property(p => p.Calori).HasColumnType("decimal(18,2)");
           builder.Property(p => p.Fat).HasColumnType("decimal(18,2)");
        }
    }
}