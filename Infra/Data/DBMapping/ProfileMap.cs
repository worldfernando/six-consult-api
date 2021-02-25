using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SixConsultApi.Domain.Entities;

namespace SixConsultApi.Infra.Data.DBMapping
{
    public class ProfileMap : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("profiles");
            builder.HasKey(k => k.Id);                
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("name");
            builder.Property(p => p.Create)
                .IsRequired()
                .HasColumnName("create");
            builder.Property(p => p.Update)
                .IsRequired()
                .HasColumnName("update");
            builder.Property(p => p.Delete)
                .IsRequired()
                .HasColumnName("delete");
            builder.Property(p => p.IsAdmin)
                .IsRequired()
                .HasColumnName("is_admin");
            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt)
                .IsRequired()
                .HasColumnName("updated_at");
            builder.HasMany(g => g.Users)
                .WithOne(w => w.Profile)
                .HasForeignKey(k => k.ProfileId);
        }
    }
}
