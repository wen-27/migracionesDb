using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.AuthCredentials.Infrastructure.Entity;

public sealed class AuthCredentialsEntityConfiguration 
    : IEntityTypeConfiguration<AuthCredentialsEntity>
{
    public void Configure(EntityTypeBuilder<AuthCredentialsEntity> builder)
    {
        builder.ToTable("auth_credentials");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.PasswordHash).IsRequired().HasColumnType("TEXT");

        builder.Property(x => x.LastLogin).IsRequired(false);
        builder.Property(x => x.LockUntil).IsRequired(false);

        builder.Property(x => x.FailedAttempts).HasDefaultValue(0);
        builder.Property(x => x.IsActive).HasDefaultValue(true);

        // FK → persons
        builder.HasOne(x => x.Person)
               .WithMany()
               .HasForeignKey(x => x.PersonId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}