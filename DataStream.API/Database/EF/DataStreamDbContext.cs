using DataStream.API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataStream.API.Database.EF
{
    public class DataStreamDbContext(DbContextOptions<DataStreamDbContext> options) : DbContext(options)
    {
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Sale> Sales => Set<Sale>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataStreamDbContext).Assembly);
        }
    }
}
