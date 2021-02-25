using Microsoft.EntityFrameworkCore;
using SixConsultApi.Domain.Entities;
using SixConsultApi.Helpers;
using SixConsultApi.Helpers.Interfaces;
using SixConsultApi.Infra.Data.DBMapping;

namespace SixConsultApi.Infra.Data.Context
{
    public class ContextDB : DbContext
    {

        public ContextDB(DbContextOptions<ContextDB> options) : base(options) {}
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Profile> Profile { get; set; }
        private IHashService _hashService;

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {           

            modelBuilder.HasDefaultSchema("public");
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());

            // Seed Data Base
            this.Seeds(modelBuilder);
        }

        private void Seeds(ModelBuilder modelBuilder)
        {
            _hashService = new HashService();
            modelBuilder.Entity<Profile>().HasData(new[]{
                new Profile(id: 1, name: "Administrador do Sistema", create: true, update: true, delete: true, isAdmin: true) });
            modelBuilder.Entity<User>().HasData(new[]{
                new User(id: 1, name: "Administrador", email: "admin@admin.com.br", password: _hashService.HashPassword("123"), profileId: 1) });
        }

    }
}