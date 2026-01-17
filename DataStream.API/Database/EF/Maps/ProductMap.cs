using DataStream.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataStream.API.Database.EF.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.ProductId)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Category)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.HasIndex(x => x.Name);
            builder.HasIndex(x => x.Category);
        }
    }
}
