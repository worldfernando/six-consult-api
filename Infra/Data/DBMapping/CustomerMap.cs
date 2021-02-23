using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SixConsultApi.Domain.Entities;

namespace SixConsultApi.Infra.Data.DBMapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");
            builder.HasKey(k => k.Id)
                .HasName("id");
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.FTIN)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnName("ftni");
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("name");
            builder.Property(p => p.TradeName)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("trade_name");
            builder.Property(p => p.ContactEmail)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("contact_email");
            builder.Property(p => p.ContactPhone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("contact_phone");
            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");
            builder.Property(p => p.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at");
        }
    }
}