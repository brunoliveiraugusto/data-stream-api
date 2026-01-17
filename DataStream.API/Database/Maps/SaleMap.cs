using DataStream.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataStream.API.Database.Maps
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(x => x.SaleId);

            builder.Property(x => x.SaleId)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Quantity)
                   .IsRequired();

            builder.Property(x => x.TotalAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(x => x.SaleDate)
                   .HasColumnType("datetime2")
                   .IsRequired();

            builder.HasOne(x => x.Client)
                   .WithMany(c => c.Sales)
                   .HasForeignKey(x => x.ClientId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Product)
                   .WithMany()
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.ClientId);
            builder.HasIndex(x => x.ProductId);
            builder.HasIndex(x => x.SaleDate);
        }
    }
}
