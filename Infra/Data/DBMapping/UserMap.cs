using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SixConsultApi.Domain.Entities;

namespace SixConsultApi.Infra.Data.DBMapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(k => k.Id);                
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("name");
            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("email");
            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("password");
            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at");
        }
    }
}
