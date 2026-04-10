using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DerTransporte.Modules.TransportCompanies.Infrastructure.Entity;

namespace DerTransporte.Modules.TransportCompanies.Infrastructure.Entity;

public sealed class TransportCompaniesEntityConfiguration : IEntityTypeConfiguration<TransportCompaniesEntity>
{
    public void Configure(EntityTypeBuilder<TransportCompaniesEntity> builder)
    {
        builder.ToTable("transport_companies");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Nit).HasMaxLength(10);
        builder.HasIndex(x => x.Nit).IsUnique();

        builder.Property(x => x.CompanieName).HasMaxLength(60);

        builder.Property(x => x.ContactEmail).HasMaxLength(60);
        builder.HasIndex(x => x.ContactEmail).IsUnique();

        builder.Property(x => x.ContactPhone).HasMaxLength(50);
        builder.Property(x => x.Addres).HasColumnType("TEXT");
        builder.Property(x => x.LogoUrl).HasColumnType("TEXT");

        builder.Property(x => x.VerifiedAt).IsRequired(false);

        builder.HasOne(x => x.City)
            .WithMany()
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.LegalRepresentative)
            .WithMany()
            .HasForeignKey(x => x.LegalRepresentativeId)            
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}