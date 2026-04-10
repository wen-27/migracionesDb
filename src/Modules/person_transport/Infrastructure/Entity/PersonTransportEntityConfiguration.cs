using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.PersonTransport.Infrastructure.Entity;

public sealed class PersonTransportEntityConfiguration : IEntityTypeConfiguration<PersonTransportEntity>
{
    public void Configure(EntityTypeBuilder<PersonTransportEntity> builder)
    {
        builder.ToTable("person_transport");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.Property(x => x.JoinedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

        // FK → persons
        builder.HasOne(x => x.Person)
               .WithMany()
               .HasForeignKey(x => x.PersonId)
               .OnDelete(DeleteBehavior.Restrict);

        // FK → transport_companies
        builder.HasOne(x => x.Company)
               .WithMany()
               .HasForeignKey(x => x.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

        // FK → relation_type
        builder.HasOne(x => x.RelationType)
               .WithMany()
               .HasForeignKey(x => x.RelationTypeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}