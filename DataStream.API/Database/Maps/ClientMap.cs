using DataStream.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataStream.API.Database.Maps
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(x => x.ClientId);

            builder.Property(x => x.ClientId)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.FullName)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.CreatedAt)
                   .HasColumnType("datetime2")
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(x => x.Email)
                   .IsUnique();
        }
    }
}
