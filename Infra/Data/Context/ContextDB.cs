using Microsoft.EntityFrameworkCore;
using SixConsultApi.Domain.Entities;
using SixConsultApi.Infra.Data.DBMapping;

namespace SixConsultApi.Infra.Data.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options) {}
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
        }

    }
}