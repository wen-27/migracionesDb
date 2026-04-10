using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DerTransporte.Modules.Persons.Infrastructure.Entity;

namespace DerTransporte.Modules.AuthSessions.Infrastructure.Entity;

public sealed class AuthSessionsEntityConfiguration: IEntityTypeConfiguration<AuthSessionsEntity>
{
    public void Configure(EntityTypeBuilder<AuthSessionsEntity> builder)
    {
        builder.ToTable("auth_sessions");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.RefreshToken).IsRequired().HasColumnType("TEXT");
        builder.Property(x => x.ExpiresAt).IsRequired();
        builder.Property(x => x.IpAddress).IsRequired().HasMaxLength(45);
        builder.Property(x => x.DeviceInfo).IsRequired().HasColumnType("TEXT");
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

        // FK → persons
        builder.HasOne(x => x.Person)
               .WithMany()
               .HasForeignKey(x => x.PersonId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}